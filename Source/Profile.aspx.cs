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
    
    protected void btnSubmitChangePassword_Click (object sender, EventArgs e)
    {

    }

    protected void btnChangePassword_Click (object sender, EventArgs e)
    {
        lTitle.Text = "Đổi mật khẩu";
        viewPanel.Visible = false;
        editPanel.Visible = false;
        changePassword.Visible = true;

    }

    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {
        lTitle.Text = "Cập nhật hồ sơ";
        viewPanel.Visible = false;
        editPanel.Visible = true;
        changePassword.Visible = false;
    }
}
