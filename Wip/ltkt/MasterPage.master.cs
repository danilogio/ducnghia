using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ltktDAO;


namespace ltkt
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            ltsItem.Width = 240;
            string[] sInformation = readInformation();
            //get cookie successful
            if (sInformation != null)
            {
                tblUser user = ltktDAO.Users.getUser(sInformation[0], sInformation[1]);
                chxRemember.Checked = true;
                if (user != null)
                {
                    updateAccount(user);
                }
            }

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

        private string[] readInformation()
        {
            string[] inform = new string[2] { "", "" };
            if (Response.Cookies["Username"] != null
                && Response.Cookies["Password"] != null)
            {
                string sUsername = Response.Cookies["Username"].ToString();
                string sPassword = Response.Cookies["Password"].ToString();
                inform[0] = sUsername;
                inform[1] = sPassword;
                return inform;
            }
            return null;

        }
        private void saveInformationForNext(string sUsername,string sPassword)
        {
            //if cookie has'nt been written for 2 weeks.
            if (Response.Cookies["Username"] != null && Response .Cookies["Password"] != null)
            {
                HttpCookie cookUsername = new HttpCookie("Username");
                HttpCookie cookPassword = new HttpCookie("Password");

                cookUsername.Value = sUsername;
                cookPassword.Value = Users.encryptPassword(sPassword);

                cookUsername.Domain = "www.luyenthikinhte.com";
                cookPassword.Domain = "www.luyenthikinhte.com";

                cookUsername.Expires = DateTime.Today.AddDays(14);
                cookPassword.Expires = DateTime.Today.AddDays(14);

                Response.Cookies.Add(cookUsername);
                Response.Cookies.Add(cookPassword);
            }

        }

        private void clearCookies()
        {
            if (Response.Cookies["Username"] != null && Response.Cookies["Password"] != null)
            {
                Response.Cookies["Username"].Expires.AddDays(-1);
                Response.Cookies["Password"].Expires.AddDays(-1);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;

            tblUser user = ltktDAO.Users.getUser(strUsername, strPassword);

            if (user != null)
            {

                updateAccount(user);

                Application.Lock();
                Application["UserOnline"] = (Int32)Application["UserOnline"] + 1;
                Application.UnLock();

                if (chxRemember.Checked)
                {
                    saveInformationForNext(strUsername, strPassword);
                }
                else
                {
                    clearCookies();
                }

                checkUserState(user); 
            }
            else
            {
                //Đăng nhập thất bại
                Response.Redirect("~/Login.aspx");
            }

        }

        private void checkUserState(tblUser user)
        {
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;

            userStateTitle.Text = "Đăng nhập";
            loginPanel.Visible = true;
            userPanel.Visible = false;

            Application.Lock();
            Application["UserOnline"] = (Int32)Application["UserOnline"] - 1;
            Application.UnLock();

            Response.Redirect("~/Home.aspx");
        }
    }
}