using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

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
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}