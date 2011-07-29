using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAO;

namespace DucNghia
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        public void updateMessage(string _message)
        {
            lMessage.Text = _message;
            lMessage.Visible = true;
            messagePanel.Visible = true;
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
                lMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng. Xin vui lòng kiểm tra lại!";
                lMessage.Visible = true;
                messagePanel.Visible = true;

                Response.Redirect("~/Login.aspx");
            }
        }
    }
}