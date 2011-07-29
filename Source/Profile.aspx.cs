using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tblUser user = (tblUser)Session["User"];

        lLogonUser.Text = user.Username;
        lDisplayName.Text = user.DisplayName;
        lSex.Text = (user.Sex == false ? "Nam" : "Nữ");
        lEmail.Text = user.Email;
        lNumberOfArticles.Text = user.NumberOfArticles.ToString();

        viewPanel.Visible = true;
        messagePanel.Visible = false;
        editPanel.Visible = false;
        changePasswordPanel.Visible = false;
    }
    
    protected void btnSubmitChangePassword_Click (object sender, EventArgs e)
    {
        string oldPassword = txtboxPassword.Text;

        // Kiểm tra xem có đúng password hay không?
        tblUser user = (tblUser)Session["User"];

        Boolean isExist = DAO.UsersDAO.isUser(user.Username, oldPassword);

        if (isExist)
        {
            string newPassword = txtboxNewPassword.Text;

            Boolean isOK = DAO.UsersDAO.updateUserPassword(user.Username, newPassword);

            // Thành công
            if (isOK)
            {
                lMessage.Text = "Bạn đã đổi mật khẩu thành công!";
                lMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
                lMessage.Visible = true;

                messagePanel.Visible = true;
                changePasswordPanel.Visible = false;
            }
        }
        else
        {
            lMessage.Text = "Mật khẩu hiện tại không đúng. Xin vui lòng kiểm tra lại!";
            lMessage.Visible = true;

            messagePanel.Visible = true;
        }
    }


    protected void btnChangePassword_Click (object sender, EventArgs e)
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
    }
    
}
