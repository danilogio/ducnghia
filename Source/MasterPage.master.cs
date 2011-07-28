using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using DAO;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltsItem.Items.Add("-- Tất cả danh mục  --");
        ltsItem.Items.Add("Luyện thi đại học");
        ltsItem.Items.Add("Anh văn");
        ltsItem.Items.Add("Tin học");
        ltsItem.Width = 150;

        if (Session["User"] == null)
        {
            userStateTitle.Text = "Đăng nhập";
            loginPanel.Visible = true;
            userPanel.Visible = false;
        }
        else
        {
            tblUser user = (tblUser)Session["User"];
            userStateTitle.Text = "Thông tin tài khoản";
            loginUser.Text = user.DisplayName;
            loginPanel.Visible = false;
            userPanel.Visible = true;
        }

    }

    public void updateAccount(tblUser  _user)
    {
        Session["User"] = _user;
        loginUser.Text = _user.DisplayName;
        userStateTitle.Text = "Thông tin tài khoản";
        loginPanel.Visible = false;
        userPanel.Visible = true;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strUsername = txtUsername.Text;
        string strPassword = txtPassword.Text;

        tblUser user = DAO.UsersDAO.getUser(strUsername, strPassword);

        if (user != null)
        {
            //Đăng nhập thành công
            updateAccount(user);
        }
        else
        {
            //Đăng nhập thất bại
            Response.Redirect("~/Login.aspx");
        }
        
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["User"] = null;
        
        userStateTitle.Text = "Đăng nhập";
        loginPanel.Visible = true;
        userPanel.Visible = false;

        Response.Redirect("~/Home.aspx");
    }

    
}
