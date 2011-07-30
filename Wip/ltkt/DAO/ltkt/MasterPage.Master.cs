using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace ltkt
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltsItem.Width = 240;

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

        public void hideLoginSidebar()
        {
            loginSidebar.Visible = false;
        }

        public void updateAccount(tblUser _user)
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

            tblUser user = DAO.Users.getUser(strUsername, strPassword);

            if (user != null)
            {

                updateAccount(user);


                switch (user.State)
                {
                    case 0: //Tài khoản chưa kích hoạt
                        {
                            // Thông báo là tài khoản chưa kích hoạt.

                            //Response.Redirect("~/Login.aspx?state=non-active");

                            break;
                        }
                    case 1: // Tài khoản đã kích hoạt, đăng nhập ok
                    case 2: // Bị báo xấu, đăng nhập ok
                        {
                            updateAccount(user);
                            break;
                        }
                    case 31: // KIA 3 ngày
                    case 32: // KIA 1 tuần
                    case 33: // KIA 2 tuần
                    case 34: // KIA 3 tuần
                    case 35: // KIA 1 tháng
                        {
                            // Kiểm tra ngày KIA

                            // Kiểm tra xem hết chưa

                            break;
                        }
                }

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
}
