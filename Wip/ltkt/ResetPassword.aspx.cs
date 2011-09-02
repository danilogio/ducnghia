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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
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

                liMessage.Text = CommonConstants.MSG_RESET_PASSWORD_SUCCESSFUL;
                liMessage.Visible = true;
                requestPassword.Visible = false;
            }
            else
            {
                liMessage.Text = CommonConstants.MSG_RESET_PASSWORD_FAILED;
                liMessage.Visible = true;
            }

            // Thông báo cho người dùng
        }
    }
}