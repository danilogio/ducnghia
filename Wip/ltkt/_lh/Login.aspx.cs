using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;


namespace ltkt.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        ltktDAO.Users userDAO = new ltktDAO.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string strUsername = txtboxLoginName.Text;
            string strPassword = txtboxPassword.Text;

            tblUser user = userDAO.getUser(strUsername, strPassword, false);

            if (user != null)
            {
                if (user.Type == false)
                {
                    Session["User"] = user;
                    Response.Redirect("./Admin/General.aspx");
                }
                else
                {
                    lMessage.Text = "Bạn không có quyền truy cập khu vực này!";
                    lMessage.Visible = true;
                }
            }
            else
            {
                lMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng. Xin vui lòng kiểm tra lại!";
                lMessage.Visible = true;
            }
        }
    }
}