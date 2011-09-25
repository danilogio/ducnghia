using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ltktDAO;
namespace ltkt
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        ltktDAO.Users userDAO = new ltktDAO.Users();
        EventLog log = new EventLog();

        ltktDAO.Control control = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_RESET_PASSWORD_NAME
                               + CommonConstants.SPACE + CommonConstants.HLINE
                               + CommonConstants.SPACE
                               + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string strEmail = txtboxRegistryEmail.Text;

                // Kiểm tra sự tồn tại của email
                string strUsername = userDAO.existedEmail(strEmail);


                if (strUsername != null)
                {
                    // Phát sinh mật khẩu bất kỳ
                    string strNewPassword = userDAO.generatePassword();

                    // Gửi mật khẩu đến email
                    userDAO.sendNewPassword(strUsername, strNewPassword, strEmail);

                    liMessage.Text = CommonConstants.MSG_I_RESET_PASSWORD_SUCCESSFUL;
                    liMessage.Visible = true;
                    requestPassword.Visible = false;
                }
                else
                {
                    liMessage.Text = CommonConstants.MSG_E_RESET_PASSWORD_FAILED;
                    liMessage.Visible = true;
                }

                // Thông báo cho người dùng
            }
            catch (Exception ex)
            {
                string username = CommonConstants.USER_GUEST;
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }
    }
}