using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        string strEmail = txtboxRegistryEmail.Text;

        // Phát sinh mật khẩu bất kỳ

        // Gửi mật khẩu đến email

        // Thông báo cho người dùng
    }
}
