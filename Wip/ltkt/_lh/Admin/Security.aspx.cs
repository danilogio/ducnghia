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

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            ltktDAO.Admin adminDAO = new ltktDAO.Admin();

            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_SECURITY)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader("Quản lý các vần đề Bảo mật");

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

                    if (adminDAO.isON(CommonConstants.AF_ADS))
                    {
                        chkAds.Checked = true;
                        txtAdsReason.Text = adminDAO.getReason(CommonConstants.AF_ADS);
                    }
                    if (adminDAO.isON(CommonConstants.AF_ANNOUCEMENT))
                    {
                        chkAnnoucement.Checked = true;
                        ltktDAO.Control controlDAO = new ltktDAO.Control();
                        txtAnnoucementMessage.Text = controlDAO.getValueString(CommonConstants.CF_ANNOUCEMENT);
                    }
                    if (adminDAO.isON(CommonConstants.AF_COMMENT))
                    {
                        chkComment.Checked = true;
                        txtCommentReason.Text = adminDAO.getReason(CommonConstants.AF_COMMENT);
                    }
                    if (adminDAO.isON(CommonConstants.AF_COMMENT_EASY))
                    {
                        chkCommentEasy.Checked = true;
                        txtCommentEasyReason.Text = adminDAO.getReason(CommonConstants.AF_COMMENT_EASY);
                    }
                    if (adminDAO.isON(CommonConstants.AF_CONTACT))
                    {
                        chkContact.Checked = true;
                        txtContactReason.Text = adminDAO.getReason(CommonConstants.AF_CONTACT);
                    }
                    if (adminDAO.isON(CommonConstants.AF_DOWNLOAD))
                    {
                        chkDownloadAll.Checked = true;
                        txtDownloadAllReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD);
                    }
                    if (adminDAO.isON(CommonConstants.AF_DOWNLOAD_EL))
                    {
                        chkDownloadEnglish.Checked = true;
                        txtDownloadEnglishReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD_EL);
                    }
                    if (adminDAO.isON(CommonConstants.AF_DOWNLOAD_IT))
                    {
                        chkDownloadIT.Checked = true;
                        txtDownloadITReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD_IT);
                    }
                    if (adminDAO.isON(CommonConstants.AF_DOWNLOAD_UNI))
                    {
                        chkDownloadUni.Checked = true;
                        txtDownloadUniReason.Text = adminDAO.getReason(CommonConstants.AF_DOWNLOAD_UNI);
                    }
                    if (adminDAO.isON(CommonConstants.AF_EMAIL_SEND))
                    {
                        chkEmailSending.Checked = true;
                        txtEmailSendReason.Text = adminDAO.getReason(CommonConstants.AF_EMAIL_SEND);
                    }
                    if (adminDAO.isON(CommonConstants.AF_LOGIN))
                    {
                        chkLogin.Checked = true;
                        txtLoginReason.Text = adminDAO.getReason(CommonConstants.AF_LOGIN);
                    }
                    if (adminDAO.isON(CommonConstants.AF_NEWS_POST))
                    {
                        chkNewsPost.Checked = true;
                        txtNewsPostReason.Text = adminDAO.getReason(CommonConstants.AF_NEWS_POST);
                    }
                    if (adminDAO.isON(CommonConstants.AF_NEWS_VIEW))
                    {
                        chkNewsView.Checked = true;
                        txtNewsViewReason.Text = adminDAO.getReason(CommonConstants.AF_NEWS_VIEW);
                    }
                    if (adminDAO.isON(CommonConstants.AF_PREVIEW_ARTICLE))
                    {
                        chkPreview.Checked = true;
                        txtPreviewReason.Text = adminDAO.getReason(CommonConstants.AF_PREVIEW_ARTICLE);
                    }
                    if (adminDAO.isON(CommonConstants.AF_REGISTRY))
                    {
                        chkRegistry.Checked = true;
                        txtRegistryReason.Text = adminDAO.getReason(CommonConstants.AF_REGISTRY);
                    }
                    if (adminDAO.isON(CommonConstants.AF_SEARCH))
                    {
                        chkSearch.Checked = true;
                        txtSearchReason.Text = adminDAO.getReason(CommonConstants.AF_SEARCH);
                    }
                    if (adminDAO.isON(CommonConstants.AF_UNDERCONTRUCTION))
                    {
                        chkUndercontruction.Checked = true;
                        txtUndercontructionReason.Text = adminDAO.getReason(CommonConstants.AF_UNDERCONTRUCTION);
                    }
                    if (adminDAO.isON(CommonConstants.AF_UPLOAD))
                    {
                        chkUploadAll.Checked = true;
                        txtUploadAllReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD);
                    }
                    if (adminDAO.isON(CommonConstants.AF_UPLOAD_EL))
                    {
                        chkUploadEnglish.Checked = true;
                        txtUploadEnglishReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD_EL);
                    }
                    if (adminDAO.isON(CommonConstants.AF_UPLOAD_IT))
                    {
                        chkUploadIT.Checked = true;
                        txtUploadITReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD_UNI);
                    }
                    if (adminDAO.isON(CommonConstants.AF_UPLOAD_UNI))
                    {
                        chkUploadUni.Checked = true;
                        txtUploadUniReason.Text = adminDAO.getReason(CommonConstants.AF_UPLOAD_UNI);
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
            if (chkAds.Checked)
            {
                if (BaseServices.isNullOrBlank(txtAdsReason.Text))
                {
                    showMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, 
                        CommonConstants.TXT_REASON + CommonConstants.SPACE + CommonConstants.AF_ADS_NAME));
                    return;
                }
            }
            else
            {

            }
        }
        private void showMessage(string msg)
        {
            liErrorMessage.Text = msg;
            ErrorMessagePanel.Visible = true;
        }
    }
}