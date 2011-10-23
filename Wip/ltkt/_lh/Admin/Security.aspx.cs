using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class Security : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        private EventLog log = new EventLog();
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();
        ltktDAO.Control controlDAO = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            

            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_SECURITY)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader("Quản lý các vần đề Bảo mật");

                    loadMessageForCheckbox();

                    string state = Request.QueryString[CommonConstants.REQ_STATE];
                    if (BaseServices.isNullOrBlank(state))
                    {
                        state = CommonConstants.PARAM_NEW;
                    }

                    if (state == CommonConstants.PARAM_NEW)
                    {
                        Session[CommonConstants.SES_FIRST_LOAD] = false;
                        string url = Request.Path.ToString();
                        int pos = url.IndexOf(CommonConstants.ADD_PARAMETER);
                        if (pos >= 0)
                        {
                            Context.RewritePath(url.Substring(0, pos));
                        }
                        else
                        {
                            Context.RewritePath(url + CommonConstants.ADD_PARAMETER + CommonConstants.REQ_STATE + CommonConstants.EQUAL + CommonConstants.PARAM_RESET);
                        }
                    }
                    if (Session[CommonConstants.SES_FIRST_LOAD] == null)
                    {
                        Session[CommonConstants.SES_FIRST_LOAD] = false;
                    }
                    if (Session[CommonConstants.SES_FIRST_LOAD] != null)
                    {
                        bool isFirst = (bool)Session[CommonConstants.SES_FIRST_LOAD];
                        if (isFirst == false)
                        {
                            try
                            {
                                loadData();
                            }
                            catch (Exception ex)
                            {
                                writeException(ex);
                            }
                            isFirst = true;
                            Session[CommonConstants.SES_FIRST_LOAD] = isFirst;
                        }
                        //else
                        //{
                        //    saveDataOnScreen();
                        //    if (Session[CommonConstants.SES_SECURITY_ADMIN_VO] != null)
                        //    {
                        //        ArrayList arraySAVO = (ArrayList)Session[CommonConstants.SES_SECURITY_ADMIN_VO];
                        //        if (arraySAVO != null)
                        //        {
                        //            SecurityAdminVO saVO = (SecurityAdminVO)arraySAVO[0];
                        //            chkAds.Checked = saVO.Ischecked;
                        //            txtAdsReason.Text = saVO.SReason;
                        //            Session[CommonConstants.SES_SECURITY_ADMIN_VO] = null;
                        //        }
                        //    }
                        //}
                    }

                    //////////////////////////////////////////////////
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            saveDataOnScreen();
            bool isError = false;
            try
            {
                //Underconstruction
                if (chkUndercontruction.Checked)
                {
                    //need message when on
                    if (BaseServices.isNullOrBlank(txtUndercontructionReason.Text))
                    {
                        showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                            CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_UNDERCONTRUCTION_NAME));
                        isError = true;
                        
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_UNDERCONTRUCTION, txtUndercontructionReason.Text, getCurrentUserName());
                    }
                }
                else
                {
                    adminDAO.changeStateOFF(CommonConstants.AF_UNDERCONTRUCTION, txtUndercontructionReason.Text, getCurrentUserName());
                }



                if (!isError)
                {
                    //Ads
                    if (!chkAds.Checked)
                    {
                        //need message when off
                        if (BaseServices.isNullOrBlank(txtAdsReason.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_ADS_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateOFF(CommonConstants.AF_ADS, txtAdsReason.Text, getCurrentUserName());
                        }
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_ADS, txtAdsReason.Text, getCurrentUserName());
                    }
                }

                //Annoucement
                if (!isError)
                {
                    if (chkAnnoucement.Checked)
                    {
                        //need message when on
                        if (BaseServices.isNullOrBlank(txtAnnoucementMessage.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_ANNOUCEMENT_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateON(CommonConstants.AF_ANNOUCEMENT, txtAnnoucementMessage.Text, getCurrentUserName());
                            controlDAO.setValue(CommonConstants.CF_ANNOUCEMENT, txtAnnoucementMessage.Text);
                        }
                    }
                    else
                    {
                        adminDAO.changeStateOFF(CommonConstants.AF_ANNOUCEMENT, txtAnnoucementMessage.Text, getCurrentUserName());
                        controlDAO.setValue(CommonConstants.CF_ANNOUCEMENT, txtAnnoucementMessage.Text);
                    }
                }

                //Comment
                if (!isError)
                {
                    if (!chkComment.Checked)
                    {
                        //need message when off
                        if (BaseServices.isNullOrBlank(txtCommentReason.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_COMMENT_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateOFF(CommonConstants.AF_COMMENT, txtCommentReason.Text, getCurrentUserName());
                        }
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_COMMENT, txtCommentReason.Text, getCurrentUserName());
                    }
                }

                //Contact
                if (!isError)
                {
                    if (!chkContact.Checked)
                    {
                        //need message when off
                        if (BaseServices.isNullOrBlank(txtContactReason.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_CONTACT_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateOFF(CommonConstants.AF_CONTACT, txtContactReason.Text, getCurrentUserName());
                        }
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_CONTACT, txtContactReason.Text, getCurrentUserName());
                    }
                }

                //download website
                if (!isError)
                {
                    if (!chkDownloadAll.Checked)
                    {
                        //need message when off
                        if (BaseServices.isNullOrBlank(txtDownloadAllReason.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_DOWNLOAD_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateOFF(CommonConstants.AF_DOWNLOAD, txtDownloadAllReason.Text, getCurrentUserName());
                        }
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_DOWNLOAD, txtDownloadAllReason.Text, getCurrentUserName());
                    }
                }
                //Download Uni
                if (!isError)
                {
                    if (!chkDownloadUni.Checked)
                    {
                        //need message when off
                        if (BaseServices.isNullOrBlank(txtDownloadUniReason.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_DOWNLOAD_UNI_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateOFF(CommonConstants.AF_DOWNLOAD_UNI, txtDownloadUniReason.Text, getCurrentUserName());
                        }
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_DOWNLOAD_UNI, txtDownloadUniReason.Text, getCurrentUserName());
                    }
                }
                //Download IT
                if (!isError)
                {
                    if (!chkDownloadIT.Checked)
                    {
                        //need message when off
                        if (BaseServices.isNullOrBlank(txtDownloadITReason.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_DOWNLOAD_IT_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateOFF(CommonConstants.AF_DOWNLOAD_IT, txtDownloadITReason.Text, getCurrentUserName());
                        }
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_DOWNLOAD_IT, txtDownloadITReason.Text, getCurrentUserName());
                    }
                }
                //Download EL
                if (!isError)
                {
                    if (!chkDownloadEnglish.Checked)
                    {
                        //need message when off
                        if (BaseServices.isNullOrBlank(txtDownloadEnglishReason.Text))
                        {
                            showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA,
                                CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_DOWNLOAD_EL_NAME));
                            isError = true;
                        }
                        else
                        {
                            adminDAO.changeStateOFF(CommonConstants.AF_DOWNLOAD_EL, txtDownloadEnglishReason.Text, getCurrentUserName());
                        }
                    }
                    else
                    {
                        adminDAO.changeStateON(CommonConstants.AF_DOWNLOAD_EL, txtDownloadEnglishReason.Text, getCurrentUserName());
                    }
                }
                

                if (isError)
                {
                    resetInputData();
                    return;
                }
            }
            catch (Exception ex)
            {
                writeException(ex);
            }

            //reload data when finish
            try
            {
                Session[CommonConstants.SES_FIRST_LOAD] = true;
                loadData();
                loadMessageForCheckbox();
                turnOffMessage();
            }
            catch (Exception ex)
            {
                writeException(ex);
            }

        }

        private void saveDataOnScreen()
        {
            ArrayList arraySAVO = new ArrayList();
            
            //Under contruction[0]
            SecurityAdminVO UnderItem = new SecurityAdminVO();
            UnderItem.Ischecked = chkUndercontruction.Checked;
            UnderItem.SMessage = chkUndercontruction.Text;
            UnderItem.SReason = txtUndercontructionReason.Text;
            arraySAVO.Add(UnderItem);
            //Ads[1]
            SecurityAdminVO AdsItem = new SecurityAdminVO();
            AdsItem.Ischecked = chkAds.Checked;
            AdsItem.SMessage = chkAds.Text;
            AdsItem.SReason = txtAdsReason.Text;
            arraySAVO.Add(AdsItem);
            //Annoucement[2]
            SecurityAdminVO AnnItem = new SecurityAdminVO();
            AnnItem.Ischecked = chkAnnoucement.Checked;
            AnnItem.SMessage = chkAnnoucement.Text;
            AnnItem.SReason = txtAnnoucementMessage.Text;
            arraySAVO.Add(AnnItem);
            //Comment[3]
            SecurityAdminVO CommentItem = new SecurityAdminVO();
            CommentItem.Ischecked = chkComment.Checked;
            CommentItem.SMessage = chkComment.Text;
            CommentItem.SReason = txtCommentReason.Text;
            arraySAVO.Add(CommentItem);
            //Contact[4]
            SecurityAdminVO ContactItem = new SecurityAdminVO();
            ContactItem.Ischecked = chkContact.Checked;
            ContactItem.SMessage = chkContact.Text;
            ContactItem.SReason = txtContactReason.Text;
            arraySAVO.Add(ContactItem);
            //Download all[5]
            SecurityAdminVO DownloadItem = new SecurityAdminVO();
            DownloadItem.Ischecked = chkDownloadAll.Checked;
            DownloadItem.SMessage = chkDownloadAll.Text;
            DownloadItem.SReason = txtDownloadAllReason.Text;
            arraySAVO.Add(DownloadItem);
            //Download Uni[6]
            SecurityAdminVO DownloadUniItem = new SecurityAdminVO();
            DownloadUniItem.Ischecked = chkDownloadUni.Checked;
            DownloadUniItem.SMessage = chkDownloadUni.Text;
            DownloadUniItem.SReason = txtDownloadUniReason.Text;
            arraySAVO.Add(DownloadUniItem);
            //Download IT[7]
            SecurityAdminVO DownloadITItem = new SecurityAdminVO();
            DownloadITItem.Ischecked = chkDownloadIT.Checked;
            DownloadITItem.SMessage = chkDownloadIT.Text;
            DownloadITItem.SReason = txtDownloadITReason.Text;
            arraySAVO.Add(DownloadITItem);
            //Download English[8]
            SecurityAdminVO DownloadEngItem = new SecurityAdminVO();
            DownloadEngItem.Ischecked = chkDownloadEnglish.Checked;
            DownloadEngItem.SMessage = chkDownloadEnglish.Text;
            DownloadEngItem.SReason = txtDownloadEnglishReason.Text;
            arraySAVO.Add(DownloadEngItem);

            Session[CommonConstants.SES_SECURITY_ADMIN_VO] = arraySAVO;

        }
        private void resetInputData()
        {
            if (Session[CommonConstants.SES_SECURITY_ADMIN_VO] != null)
            {
                ArrayList arraySAVO = (ArrayList)Session[CommonConstants.SES_SECURITY_ADMIN_VO];
                if (arraySAVO != null)
                {
                    //Under contruction
                    SecurityAdminVO saVO = (SecurityAdminVO)arraySAVO[0];
                    chkUndercontruction.Checked = saVO.Ischecked;
                    txtUndercontructionReason.Text = saVO.SReason;

                    //Ads
                    saVO = (SecurityAdminVO)arraySAVO[1];
                    chkAds.Checked = saVO.Ischecked;
                    txtAdsReason.Text = saVO.SReason;

                    //Annoucement
                    saVO = (SecurityAdminVO)arraySAVO[2];
                    chkAnnoucement.Checked = saVO.Ischecked;
                    txtAnnoucementMessage.Text = saVO.SReason;
                    
                    //Comment
                    saVO = (SecurityAdminVO)arraySAVO[3];
                    chkComment.Checked = saVO.Ischecked;
                    txtCommentReason.Text = saVO.SReason;

                    //Contact
                    saVO = (SecurityAdminVO)arraySAVO[4];
                    chkContact.Checked = saVO.Ischecked;
                    txtContactReason.Text = saVO.SReason;

                    //Download all
                    saVO = (SecurityAdminVO)arraySAVO[5];
                    chkDownloadAll.Checked = saVO.Ischecked;
                    txtDownloadAllReason.Text = saVO.SReason;

                    //Download Uni
                    saVO = (SecurityAdminVO)arraySAVO[6];
                    chkDownloadUni.Checked = saVO.Ischecked;
                    txtDownloadUniReason.Text = saVO.SReason;

                    //Download IT
                    saVO = (SecurityAdminVO)arraySAVO[7];
                    chkDownloadIT.Checked = saVO.Ischecked;
                    txtDownloadITReason.Text = saVO.SReason;
                    //Download English
                    saVO = (SecurityAdminVO)arraySAVO[8];
                    chkDownloadEnglish.Checked = saVO.Ischecked;
                    txtDownloadEnglishReason.Text = saVO.SReason;

                    Session[CommonConstants.SES_SECURITY_ADMIN_VO] = null;
                }
            }
        }
        private void loadData()
        {
            txtAdsReason.Text = adminDAO.getReason(CommonConstants.AF_ADS);
            chkAds.Checked = adminDAO.isON(CommonConstants.AF_ADS);
            chkAnnoucement.Checked = adminDAO.isON(CommonConstants.AF_ANNOUCEMENT);

            ltktDAO.Control controlDAO = new ltktDAO.Control();
            txtAnnoucementMessage.Text = controlDAO.getValueString(CommonConstants.CF_ANNOUCEMENT);

            chkComment.Checked = adminDAO.isON(CommonConstants.AF_COMMENT);
            txtCommentReason.Text = adminDAO.getReason(CommonConstants.AF_COMMENT);

            chkCommentEasy.Checked = adminDAO.isON(CommonConstants.AF_COMMENT_EASY);
            txtCommentEasyReason.Text = adminDAO.getReason(CommonConstants.AF_COMMENT_EASY);

            chkContact.Checked = adminDAO.isON(CommonConstants.AF_CONTACT);
            txtContactReason.Text = adminDAO.getReason(CommonConstants.AF_CONTACT);

            chkDownloadAll.Checked = adminDAO.isON(CommonConstants.AF_DOWNLOAD);
            txtDownloadAllReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD);

            chkDownloadEnglish.Checked = adminDAO.isON(CommonConstants.AF_DOWNLOAD_EL);
            txtDownloadEnglishReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD_EL);

            chkDownloadIT.Checked = adminDAO.isON(CommonConstants.AF_DOWNLOAD_IT);
            txtDownloadITReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD_IT);

            chkDownloadUni.Checked = adminDAO.isON(CommonConstants.AF_DOWNLOAD_UNI);
            txtDownloadUniReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD_UNI);

            chkEmailSending.Checked = adminDAO.isON(CommonConstants.AF_EMAIL_SEND);
            txtEmailSendReason.Text = adminDAO.getReason(CommonConstants.AF_EMAIL_SEND);

            chkLogin.Checked = adminDAO.isON(CommonConstants.AF_LOGIN);
            txtLoginReason.Text = adminDAO.getReason(CommonConstants.AF_LOGIN);

            chkNewsPost.Checked = adminDAO.isON(CommonConstants.AF_NEWS_POST);
            txtNewsPostReason.Text = adminDAO.getReason(CommonConstants.AF_NEWS_POST);

            chkNewsView.Checked = adminDAO.isON(CommonConstants.AF_NEWS_VIEW);
            txtNewsViewReason.Text = adminDAO.getReason(CommonConstants.AF_NEWS_VIEW);

            chkPreview.Checked = adminDAO.isON(CommonConstants.AF_PREVIEW_ARTICLE);
            txtPreviewReason.Text = adminDAO.getReason(CommonConstants.AF_PREVIEW_ARTICLE);

            chkRegistry.Checked = adminDAO.isON(CommonConstants.AF_REGISTRY);
            txtRegistryReason.Text = adminDAO.getReason(CommonConstants.AF_REGISTRY);

            chkSearch.Checked = adminDAO.isON(CommonConstants.AF_SEARCH);
            txtSearchReason.Text = adminDAO.getReason(CommonConstants.AF_SEARCH);

            chkUndercontruction.Checked = adminDAO.isON(CommonConstants.AF_UNDERCONTRUCTION);
            txtUndercontructionReason.Text = adminDAO.getReason(CommonConstants.AF_UNDERCONTRUCTION);

            chkUploadAll.Checked = adminDAO.isON(CommonConstants.AF_UPLOAD);
            txtUploadAllReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD);

            chkUploadEnglish.Checked = adminDAO.isON(CommonConstants.AF_UPLOAD_EL);
            txtUploadEnglishReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD_EL);

            chkUploadIT.Checked = adminDAO.isON(CommonConstants.AF_UPLOAD_IT);
            txtUploadITReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD_UNI);
            chkUploadUni.Checked = adminDAO.isON(CommonConstants.AF_UPLOAD_UNI);
            txtUploadUniReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD_UNI);
        }
        private void loadMessageForCheckbox()
        {
            chkAds.Text = adminDAO.getMessage(CommonConstants.AF_ADS);
            chkAnnoucement.Text = adminDAO.getMessage(CommonConstants.AF_ANNOUCEMENT);
            chkComment.Text = adminDAO.getMessage(CommonConstants.AF_COMMENT);
            chkCommentEasy.Text = adminDAO.getMessage(CommonConstants.AF_COMMENT_EASY);
            chkContact.Text = adminDAO.getMessage(CommonConstants.AF_CONTACT);
            chkDownloadAll.Text = adminDAO.getMessage(CommonConstants.AF_DOWNLOAD);
            chkDownloadEnglish.Text = adminDAO.getMessage(CommonConstants.AF_DOWNLOAD_EL);
            chkDownloadIT.Text = adminDAO.getMessage(CommonConstants.AF_DOWNLOAD_IT);
            chkDownloadUni.Text = adminDAO.getMessage(CommonConstants.AF_DOWNLOAD_UNI);
            chkEmailSending.Text = adminDAO.getMessage(CommonConstants.AF_EMAIL_SEND);
            chkLogin.Text = adminDAO.getMessage(CommonConstants.AF_LOGIN);
            chkNewsPost.Text = adminDAO.getMessage(CommonConstants.AF_NEWS_POST);
            chkNewsView.Text = adminDAO.getMessage(CommonConstants.AF_NEWS_VIEW);
            chkPreview.Text = adminDAO.getMessage(CommonConstants.AF_PREVIEW_ARTICLE);
            chkRegistry.Text = adminDAO.getMessage(CommonConstants.AF_REGISTRY);
            chkSearch.Text = adminDAO.getMessage(CommonConstants.AF_SEARCH);
            chkUndercontruction.Text = adminDAO.getMessage(CommonConstants.AF_UNDERCONTRUCTION);
            chkUploadAll.Text = adminDAO.getMessage(CommonConstants.AF_UPLOAD);
            chkUploadEnglish.Text = adminDAO.getMessage(CommonConstants.AF_UPLOAD_EL);
            chkUploadIT.Text = adminDAO.getMessage(CommonConstants.AF_UPLOAD_IT);
            chkUploadUni.Text = adminDAO.getMessage(CommonConstants.AF_UPLOAD_UNI);
        }
        private void showMessage(string msg)
        {
            liErrorMessage.Text = msg;
            ErrorMessagePanel.Visible = true;
        }
        private void turnOffMessage()
        {
            ErrorMessagePanel.Visible = false;
        }
        private void writeException(Exception ex)
        {
            string username = getCurrentUserName();
            log.writeLog(DBHelper.strPathLogFile, username, ex.Message
                                                    + CommonConstants.NEWLINE
                                                    + ex.Source
                                                    + CommonConstants.NEWLINE
                                                    + ex.StackTrace
                                                    + CommonConstants.NEWLINE
                                                    + ex.HelpLink);
            return;
        }
        private string getCurrentUserName()
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            string username = CommonConstants.BLANK;
            if (user == null)
            {
                username = CommonConstants.USER_GUEST;
            }
            else
            {
                username = user.Username;
            }
            return username;
        }
    }
}