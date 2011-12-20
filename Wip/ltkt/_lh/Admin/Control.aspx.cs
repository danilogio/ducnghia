using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
using System.IO;

namespace ltkt.Admin
{
    public partial class Control : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        private ltktDAO.Control controlDao = new ltktDAO.Control();
        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_CONTROL)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader("Quản lý điều khiển");
                    if (Page.IsPostBack)
                    {
                        return;
                    }
                    loadData(sender, e);
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
        private void loadData(object sender, EventArgs e)
        {
            txtWellcomeText.Text = controlDao.getValueString(CommonConstants.CF_WELCOME_TEXT);
            txtTitleHeader.Text = controlDao.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            txtTitleFooter.Text = controlDao.getValueString(CommonConstants.CF_TITLE_ON_FOOTER);
            txtLogo.Text = controlDao.getValueString(CommonConstants.CF_LOGO);
            showLogo(txtLogo.Text);
            txtMaxFileImgSize.Text = controlDao.getValueString(CommonConstants.CF_IMG_FILE_SIZE_MAX);
            txtMaxFileSize.Text = controlDao.getValueString(CommonConstants.CF_MAX_FILE_SIZE);
            txtValidExtension.Text = controlDao.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);
            txtValidImageExtension.Text = controlDao.getValueString(CommonConstants.CF_IMG_FILE_TYPE_ALLOW);
            txtAnouncement.Text = controlDao.getValueString(CommonConstants.CF_ANNOUCEMENT);
            txtEmailConfig.Text = controlDao.getValueString(CommonConstants.CF_EMAIL_CONFIG);
            txtNumArtOnContest.Text = controlDao.getValueString(CommonConstants.CF_NUM_ARTICLE_ON_UNI);
            txtNumArtOnEnglish.Text = controlDao.getValueString(CommonConstants.CF_NUM_ARTICLE_ON_EL);
            txtNumArtOnInformatics.Text = controlDao.getValueString(CommonConstants.CF_NUM_ARTICLE_ON_IT);
            txtNumArtOnTab.Text = controlDao.getValueString(CommonConstants.CF_NUM_ARTICLE_ON_TAB);
            txtNumArtSticky.Text = controlDao.getValueString(CommonConstants.CF_NUM_ARTICLE_STICKY);
            txtNumRelativeArt.Text = controlDao.getValueString(CommonConstants.CF_NUM_RECORD_RELATIVE);
            txtAddress.Text = controlDao.getValueString(CommonConstants.CF_ADDRESS);
        }
        private void showLogo(string location)
        {
            if (File.Exists(DBHelper.strCurrentPath + location))
            {
                liLogo.Text = "&nbsp;&nbsp;<br /><input type=\"button\" value=\"Mở\" class=\"formbutton\" onclick=\"DisplayFullImage('../../" + location.Replace("\\", "/") + "')\"/>";
            }
            else
            {
                liLogo.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
            }
            liLogo.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải hình thu nhỏ\" class=\"formbutton\" onclick=\"uploadLogo()\" />";
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //save wellcome text
            string wellcomeText = Server.HtmlDecode(txtWellcomeText.Text.Trim());
            controlDao.setValue(CommonConstants.CF_WELCOME_TEXT, wellcomeText);
            //title header
            controlDao.setValue(CommonConstants.CF_TITLE_ON_HEADER, txtTitleHeader.Text.Trim());
            //title footer
            controlDao.setValue(CommonConstants.CF_TITLE_ON_FOOTER, txtTitleFooter.Text.Trim());
            //max file size
            controlDao.setValue(CommonConstants.CF_MAX_FILE_SIZE, txtMaxFileSize.Text.Trim());
            //valid file type
            controlDao.setValue(CommonConstants.CF_FILE_TYPE_ALLOW, txtValidExtension.Text.Trim());
            //valid img file
            controlDao.setValue(CommonConstants.CF_IMG_FILE_TYPE_ALLOW, txtValidImageExtension.Text.Trim());
            //max img file sizw
            controlDao.setValue(CommonConstants.CF_IMG_FILE_SIZE_MAX, txtMaxFileImgSize.Text.Trim());
            //Announcement
            controlDao.setValue(CommonConstants.CF_ANNOUCEMENT, txtAnouncement.Text.Trim());
            //email config
            controlDao.setValue(CommonConstants.CF_EMAIL_CONFIG, txtEmailConfig.Text.Trim());
            //num article on contest
            controlDao.setValue(CommonConstants.CF_NUM_ARTICLE_ON_UNI, txtNumArtOnContest.Text.Trim());
            //num article on english
            controlDao.setValue(CommonConstants.CF_NUM_ARTICLE_ON_EL, txtNumArtOnEnglish.Text.Trim());
            //num article on it
            controlDao.setValue(CommonConstants.CF_NUM_ARTICLE_ON_IT, txtNumArtOnInformatics.Text.Trim());
            //num article on tab
            controlDao.setValue(CommonConstants.CF_NUM_ARTICLE_ON_TAB, txtNumArtOnTab.Text.Trim());
            //num article on sticky
            controlDao.setValue(CommonConstants.CF_NUM_ARTICLE_STICKY, txtNumArtSticky.Text.Trim());
            //num relative article
            controlDao.setValue(CommonConstants.CF_NUM_RECORD_RELATIVE, txtNumRelativeArt.Text.Trim());
            //address
            controlDao.setValue(CommonConstants.CF_ADDRESS, txtAddress.Text);
            //upload thumbnail
            string _fileThumbnail = CommonConstants.BLANK;
            string rootFolder = Server.MapPath("~") + "/" + CommonConstants.FOLDER_IMAGES;
            BaseServices bs = new BaseServices();
            string fileTypes = controlDao.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);
            //check filesize max (KB)
            int fileSizeMax = 0;
            if (fileThumbnail.HasFile)
            {
                //check file existed: keep both
                _fileThumbnail = fileThumbnail.FileName;

                _fileThumbnail = bs.fileNameToSave(rootFolder + "/" + _fileThumbnail);
                //filename = rootFolder + newFileName;

                //check filetype
                fileTypes = controlDao.getValueString(CommonConstants.CF_IMG_FILE_TYPE_ALLOW);
                if (!bs.checkFileType(fileThumbnail.FileName, fileTypes))
                {
                    showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_NOT_ALLOW);
                    return;
                }
                //check filesize max (KB)
                fileSizeMax = controlDao.getValueByInt(CommonConstants.CF_IMG_FILE_SIZE_MAX);
                fileSizeMax = 1024 * fileSizeMax;
                if (fileThumbnail.PostedFile.ContentLength > fileSizeMax)
                {
                    showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_TOO_LARGE);
                    return;
                }
                //logo
                controlDao.setValue(CommonConstants.CF_LOGO, CommonConstants.FOLDER_IMAGES + "/" + fileThumbnail.FileName);
                string folder = Path.GetDirectoryName(_fileThumbnail);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                fileThumbnail.SaveAs(_fileThumbnail);
                Response.Redirect(CommonConstants.PAGE_ADMIN_CONTROL);
            }
        }
        /// <summary>
        /// use to show message error on mode EDIT, VIEW
        /// </summary>
        /// <param name="errorText"></param>
        private void showErrorMessage(string errorText)
        {
            liErrorMessage.Text = errorText;
            ErrorMessagePanel.Visible = true;
        }

    }
}