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

namespace ltkt
{
    public partial class Profiles : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_PROFILE_NAME
                               + CommonConstants.SPACE + CommonConstants.HLINE
                               + CommonConstants.SPACE
                               + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

            if (Session[CommonConstants.SES_USER] != null)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                lLogonUser.Text = user.Username;
                lDisplayName.Text = user.DisplayName;
                lSex.Text = (user.Sex == false ? "Nam" : "Nữ");
                lEmail.Text = user.Email;
                lNumberOfArticles.Text = user.NumberOfArticles.ToString();

                txtboxDisplayName.Text = user.DisplayName;
                txtboxEmail.Text = user.Email;
            }
            else
            {
                Response.Redirect(CommonConstants.PAGE_LOGIN);
            }

        }

        protected void btnSubmitChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPassword = txtboxPassword.Text;

                // Kiểm tra xem có đúng password hay không?
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                Boolean isExist = userDAO.isUser(user.Username, oldPassword);

                if (isExist)
                {
                    string newPassword = txtboxNewPassword.Text;

                    Boolean isOK = userDAO.updateUserPassword(user.Username, newPassword);

                    // Thành công
                    if (isOK)
                    {
                        lMessage.Text = CommonConstants.MSG_I_CHANGE_PASSWORD_SUCCESSFUL;
                        lMessage.Text += CommonConstants.MSG_I_BACK_TO_HOME;
                        lMessage.Visible = true;

                        messagePanel.Visible = true;
                        changePasswordPanel.Visible = false;
                    }
                }
                else
                {
                    lMessage.Text = CommonConstants.MSG_E_PASSWORD_REQUIRED_WRONG;
                    lMessage.Visible = true;

                    messagePanel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }


        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            lTitle.Text = "Đổi mật khẩu";
            viewPanel.Visible = false;
            editPanel.Visible = false;
            changePasswordPanel.Visible = true;

        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            lTitle.Text = "Cập nhật hồ sơ";
            viewPanel.Visible = false;
            editPanel.Visible = true;
            changePasswordPanel.Visible = false;
        }

        protected void btnSubmitUpdateProfile_Click(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];

            string strDisplayName = txtboxDisplayName.Text;
            string strEmail = txtboxEmail.Text;

            user.Email = strEmail;
            user.DisplayName = strDisplayName;
            try
            {

                bool isOK = userDAO.updateUser(user.Username, user);
                if (isOK)
                {
                    lMessage.Text = CommonConstants.MSG_I_UPDATE_PROFILE_SUCCESSFUL;
                    lMessage.Text += CommonConstants.MSG_I_BACK_TO_HOME;
                    lMessage.Visible = true;

                    messagePanel.Visible = true;
                    editPanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }
    }
}