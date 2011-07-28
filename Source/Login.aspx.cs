using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAO;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmitLogin_Click(object sender, EventArgs e)
    {
        string strUsername = txtboxLoginName.Text;
        string strPassword = txtboxPassword.Text;

        tblUser user = DAO.UsersDAO.getUser(strUsername, strPassword);

        if (user != null)
        {
            //Đăng nhập thành công
            MasterPage page = (MasterPage)Master;
            page.updateAccount(user);

            Response.Redirect("~/Home.aspx");
        }
        else
        {
            //Đăng nhập thất bại
            Response.Redirect("~/Login.aspx");
        }
    }
}
