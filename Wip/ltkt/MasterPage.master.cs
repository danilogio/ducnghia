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
        ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Statistics statisticDAO = new ltktDAO.Statistics();
        ltktDAO.Control controlDAO = new ltktDAO.Control();
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!adminDAO.isON(CommonConstants.AF_UNDERCONTRUCTION))
            {
                ltsItem.Width = 240;
                string[] sInformation = readInformation();
                //get cookie successful
                if (sInformation != null)
                {
                    tblUser user = userDAO.getUser(sInformation[0], sInformation[1], true);
                    chxRemember.Checked = true;
                    if (user != null)
                    {
                        if (user.State != CommonConstants.STATE_DELETED
                            && user.State != CommonConstants.STATE_NON_ACTIVE)
                        {
                            updateAccount(user);
                        }
                    }
                    lblFooterTitle.Text = controlDAO.getValueString(CommonConstants.CF_TITLE_ON_FOOTER);
                    string va = controlDAO.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
                    lblAddress.Text = controlDAO.getValueString(CommonConstants.CF_ADDRESS);
                    imgLogo.ImageUrl = controlDAO.getValueString(CommonConstants.CF_LOGO);
                }

                if (Session[CommonConstants.SES_USER] == null)
                {
                    userStateTitle.Text = "Đăng nhập";
                    loginPanel.Visible = true;
                    userPanel.Visible = false;
                }
                else
                {
                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    userStateTitle.Text = "Thông tin tài khoản";
                    loginUser.Text = user.DisplayName;
                    loginPanel.Visible = false;
                    userPanel.Visible = true;
                    HpkUpload.Visible = true;
                }
                //display annoucement
                if (adminDAO.isON(CommonConstants.AF_ANNOUCEMENT))
                {
                    string annouceText = controlDAO.getValueString(CommonConstants.CF_ANNOUCEMENT);
                    if (!BaseServices.isNullOrBlank(annouceText))
                    {
                        panelAnnoucement.Visible = true;
                        ltAnnoucement.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MARQUEE_TAG,
                                                                            CommonConstants.CS_ANNOUCEMENT_BGCOLOR,
                                                                            CommonConstants.CS_ANNOUCEMENT_TEXTCOLOR,
                                                                            annouceText);
                    }
                }
            }
            else
            {
                string reason = adminDAO.getReason(CommonConstants.AF_UNDERCONTRUCTION);
                if (!BaseServices.isNullOrBlank(reason))
                {
                    Session[CommonConstants.SES_ERROR] = reason;
                    //Response.Redirect(CommonConstants.PAGE_UNDERCONSTRUCTION);
                }
            }
        }
        //public void updateTitle(string title)
        //{
        //    lblHeaderTitle = new System.Web.UI.WebControls.Label();
        //    lblHeaderTitle.Text = title;
        //    lblHeaderTitle.Visible = true;
        //}
        public void hideLoginSidebar()
        {
            loginSidebar.Visible = false;
        }

        public void updateAccount(tblUser _user)
        {
            Session[CommonConstants.SES_USER] = _user;
            loginUser.Text = _user.DisplayName;
            userStateTitle.Text = "Thông tin tài khoản";
            loginPanel.Visible = false;
            HpkUpload.Visible = true;
            userPanel.Visible = true;
            if (_user.Type == false)
            {
                HpkAdmin.Visible = true;
            }
            statisticDAO.addLatestLoginUser(_user.Username);
        }

        private string[] readInformation()
        {
            string[] inform = new string[2] { "", "" };
            if (Request.Cookies["Username"] != null
                && Request.Cookies["Password"] != null)
            {
                string sUsername = Server.HtmlEncode( Request.Cookies["Username"].Value);
                string sPassword = Server.HtmlEncode(Request.Cookies["Password"].Value);
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
                cookPassword.Value = userDAO.encryptPassword(sPassword);

                cookUsername.Expires = DateTime.Now.AddDays(14);
                cookPassword.Expires = DateTime.Now.AddDays(14);

                Response.Cookies.Add(cookUsername);
                Response.Cookies.Add(cookPassword);
            }

        }

        private void clearCookies()
        {
            if (Response.Cookies["Username"] != null && Response.Cookies["Password"] != null)
            {
                Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;

            tblUser user = userDAO.getUser(strUsername, strPassword, false);

            if (user != null)
            {
                if (user.State != CommonConstants.STATE_DELETED
                    && user.State != CommonConstants.STATE_NON_ACTIVE)
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
                }
                else
                {
                    checkUserState(user);
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_LOGIN_FAILED;
                    //Đăng nhập thất bại
                    Response.Redirect(CommonConstants.PAGE_LOGIN);
                }
            }
            else
            {
                Session[CommonConstants.SES_USER] = CommonConstants.MSG_LOGIN_FAILED;
                //Đăng nhập thất bại
                Response.Redirect(CommonConstants.PAGE_LOGIN);
            }
        }

        private void checkUserState(tblUser user)
        {
            switch (user.State)
            {
                case CommonConstants.STATE_NON_ACTIVE: //Tài khoản chưa kích hoạt
                    {
                        // Thông báo là tài khoản chưa kích hoạt.

                        //Response.Redirect("~/Login.aspx?state=non-active");

                        break;
                    }
                case CommonConstants.STATE_ACTIVE: // Tài khoản đã kích hoạt, đăng nhập ok
                case CommonConstants.STATE_WARNING: // Bị báo xấu, đăng nhập ok
                    {
                        updateAccount(user);
                        break;
                    }
                case CommonConstants.STATE_KIA_3D: // KIA 3 ngày
                case CommonConstants.STATE_KIA_1W: // KIA 1 tuần
                case CommonConstants.STATE_KIA_2W: // KIA 2 tuần
                case CommonConstants.STATE_KIA_3W: // KIA 3 tuần
                case CommonConstants.STATE_KIA_1M: // KIA 1 tháng
                    {
                        // Kiểm tra ngày KIA

                        // Kiểm tra xem hết chưa. nếu hết thì mở khóa

                        break;
                    }
                    
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session[CommonConstants.SES_USER] = null;

            clearCookies();
            userStateTitle.Text = "Đăng nhập";
            loginPanel.Visible = true;
            userPanel.Visible = false;
            HpkUpload.Visible = false;

            Application.Lock();
            Application["UserOnline"] = (Int32)Application["UserOnline"] - 1;
            Application.UnLock();

            Response.Redirect(CommonConstants.PAGE_HOME);
        }
        
    }
}