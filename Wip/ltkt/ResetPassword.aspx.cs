using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ltkt
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string strEmail = txtboxRegistryEmail.Text;

            // Kiểm tra sự tồn tại của email
            string strUsername = ltktDAO.Users.existedEmail(strEmail);


            if (strUsername != null)
            {
                // Phát sinh mật khẩu bất kỳ
                string strNewPassword = ltktDAO.Users.generatePassword();

                // Gửi mật khẩu đến email
                ltktDAO.Users.sendNewPassword(strUsername, strNewPassword, strEmail);

                liMessage.Text = "Mật khẩu mới đã được gửi tới email của bạn. Xin vui lòng kiểm tra email.";
                liMessage.Visible = true;
                requestPassword.Visible = false;
            }
            else
            {
                liMessage.Text = "Lỗi: Không tìm thấy email của bạn!";
                liMessage.Visible = true;
            }

            // Thông báo cho người dùng
        }
    }
}