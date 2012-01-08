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
        ltktDAO.Ads adsDAO = new ltktDAO.Ads();
        EventLog log = new EventLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!adminDAO.isON(CommonConstants.AF_UNDERCONTRUCTION))
                {
                    ltsItem.Width = 240;
                    lblFooterTitle.Text = controlDAO.getValueString(CommonConstants.CF_TITLE_ON_FOOTER);
                    string va = controlDAO.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
                    lblAddress.Text = controlDAO.getValueString(CommonConstants.CF_ADDRESS);
                    imgLogo.ImageUrl = controlDAO.getValueString(CommonConstants.CF_LOGO);
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
                        
                    }

                    if (Session[CommonConstants.SES_USER] == null)
                    {
                        userStateTitle.Text = CommonConstants.TXT_LOGIN;
                        loginPanel.Visible = true;
                        userPanel.Visible = false;
                    }
                    else
                    {
                        tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                        userStateTitle.Text = CommonConstants.TXT_ACCOUNT_INFOR;
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
                        else
                        {
                            ltAnnoucement.Visible = false;
                        }
                    }
                    else
                    {
                        ltAnnoucement.Visible = false;
                    }

                    //display advertisement
                    //top right
                    if (adsDAO.isExisted(CommonConstants.ADS_TOP_RIGHT_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_TOP_RIGHT_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdRightTop.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            HpkAdRightTop.Target = "_blank";
                            HpkAdRightTop.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_TOP_RIGHT_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdRightTop.Width = size[0];
                                    imgAdRightTop.Height = size[1];
                                }
                            }
                        }
                    }
                    //middle right
                    if (adsDAO.isExisted(CommonConstants.ADS_MIDDLE_RIGHT_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_MIDDLE_RIGHT_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdRightMiddle.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            hpkAdRightMiddle.Target = "_blank";
                            hpkAdRightMiddle.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_MIDDLE_RIGHT_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdRightMiddle.Width = size[0];
                                    imgAdRightMiddle.Height = size[1];
                                }
                            }
                        }
                    }
                    //bottom right
                    if (adsDAO.isExisted(CommonConstants.ADS_BOTTOM_RIGHT_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_BOTTOM_RIGHT_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdRightBottom.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            HpkAdRightBottom.Target = "_blank";
                            HpkAdRightBottom.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_BOTTOM_RIGHT_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdRightBottom.Width = size[0];
                                    imgAdRightBottom.Height = size[1];
                                }
                            }
                        }
                    }
                    //top left
                    if (adsDAO.isExisted(CommonConstants.ADS_TOP_LEFT_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_TOP_LEFT_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdLeftBottom.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            HpkAdLeftBottom.Target = "_blank";
                            HpkAdLeftBottom.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_TOP_LEFT_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdLeftBottom.Width = size[0];
                                    imgAdLeftBottom.Height = size[1];
                                }
                            }
                        }
                    }
                    //middle left
                    if (adsDAO.isExisted(CommonConstants.ADS_MIDDLE_LEFT_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_MIDDLE_LEFT_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdLeftMiddle.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            HpkAdLeftMiddle.Target = "_blank";
                            HpkAdLeftMiddle.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_MIDDLE_LEFT_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdLeftMiddle.Width = size[0];
                                    imgAdLeftMiddle.Height = size[1];
                                }
                            }
                        }
                    }
                    //bottom left
                    if (adsDAO.isExisted(CommonConstants.ADS_BOTTOM_LEFT_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_BOTTOM_LEFT_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdLeftBottom.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            HpkAdLeftBottom.Target = "_blank";
                            HpkAdLeftBottom.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_BOTTOM_LEFT_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdLeftBottom.Width = size[0];
                                    imgAdLeftBottom.Height = size[1];
                                }
                            }
                        }

                    }
                    //bottom 1 banner
                    if (adsDAO.isExisted(CommonConstants.ADS_BOTTOM_1_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_BOTTOM_1_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdBottom1.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            hpkAdBottom1.Target = "_blank";
                            hpkAdBottom1.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_BOTTOM_1_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdBottom1.Width = size[0];
                                    imgAdBottom1.Height = size[1];
                                }
                            }
                        }
                    }
                    //bottom 2 banner
                    if (adsDAO.isExisted(CommonConstants.ADS_BOTTOM_2_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_BOTTOM_2_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdBottom2.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            hpkAdBottom2.Target = "_blank";
                            hpkAdBottom2.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_BOTTOM_2_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdBottom2.Width = size[0];
                                    imgAdBottom2.Height = size[1];
                                }
                            }
                        }
                    }
                    //top
                    if (adsDAO.isExisted(CommonConstants.ADS_TOP_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_TOP_BANNER);
                        if (ads.State == CommonConstants.STATE_CHECKED || ads.State == CommonConstants.STATE_PENDING)
                        {
                            imgAdTopUp.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                            HpkAdTopUp.Target = "_blank";
                            HpkAdTopUp.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                            CommonConstants.ADS_TOP_BANNER,
                                                                                            BaseServices.nullToBlank(ads.NavigateUrl));
                            if (!BaseServices.isNullOrBlank(ads.Size))
                            {
                                if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                                {
                                    int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                    imgAdTopUp.Width = size[0];
                                    imgAdTopUp.Height = size[1];
                                }
                            }
                        }
                    }
                    //top leader
                    if (adsDAO.isExisted(CommonConstants.ADS_TOP_LEADER_BANNER))
                    {
                        tblAdvertisement ads = adsDAO.getAds(CommonConstants.ADS_TOP_LEADER_BANNER);
                        imgAdTopLeader.ImageUrl = BaseServices.nullToBlank(ads.FilePath);
                        HpkAdTopLeader.Target = "_blank";
                        HpkAdTopLeader.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADS_URL,
                                                                                        CommonConstants.ADS_TOP_LEADER_BANNER,
                                                                                        BaseServices.nullToBlank(ads.NavigateUrl));
                        if (!BaseServices.isNullOrBlank(ads.Size))
                        {
                            if (ads.Size != CommonConstants.DEFAULT_ADS_IMG_SIZE)
                            {
                                int[] size = BaseServices.getSizeFromPattern(ads.Size, CommonConstants.X);
                                imgAdTopLeader.Width = size[0];
                                imgAdTopLeader.Height = size[1];
                            }
                        }

                    }
                }
                else
                {
                    string reason = adminDAO.getReason(CommonConstants.AF_UNDERCONTRUCTION);
                    if (!BaseServices.isNullOrBlank(reason))
                    {
                        Session[CommonConstants.SES_ERROR] = reason;
                        Response.Redirect(CommonConstants.PAGE_UNDERCONSTRUCTION);
                    }
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
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
            userStateTitle.Text = CommonConstants.TXT_ACCOUNT_INFOR;
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
            string[] inform = new string[2] { CommonConstants.BLANK, CommonConstants.BLANK };
            if (Request.Cookies[CommonConstants.COOKIE_USERNAME] != null
                && Request.Cookies[CommonConstants.COOKIE_PASSWORD] != null)
            {
                string sUsername = Server.HtmlEncode( Request.Cookies[CommonConstants.COOKIE_USERNAME].Value);
                string sPassword = Server.HtmlEncode(Request.Cookies[CommonConstants.COOKIE_PASSWORD].Value);
                inform[0] = sUsername;
                inform[1] = sPassword;
                return inform;
            }
            return null;

        }
        private void saveInformationForNext(string sUsername,string sPassword)
        {
            //if cookie has'nt been written for 2 weeks.
            if (Response.Cookies[CommonConstants.COOKIE_USERNAME] != null && Response .Cookies[CommonConstants.COOKIE_PASSWORD] != null)
            {
                HttpCookie cookUsername = new HttpCookie(CommonConstants.COOKIE_USERNAME);
                HttpCookie cookPassword = new HttpCookie(CommonConstants.COOKIE_PASSWORD);

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
            if (Response.Cookies[CommonConstants.COOKIE_USERNAME] != null && Response.Cookies[CommonConstants.COOKIE_PASSWORD] != null)
            {
                Response.Cookies[CommonConstants.COOKIE_USERNAME].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies[CommonConstants.COOKIE_PASSWORD].Expires = DateTime.Now.AddDays(-1);
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
                    Application[CommonConstants.APP_USER_ONLINE] = (Int32)Application[CommonConstants.APP_USER_ONLINE] + 1;
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
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_LOGIN_FAILED;
                    //Đăng nhập thất bại
                    Response.Redirect(CommonConstants.PAGE_LOGIN);
                }
            }
            else
            {
                Session[CommonConstants.SES_USER] = CommonConstants.MSG_E_LOGIN_FAILED;
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
            userStateTitle.Text = CommonConstants.TXT_LOGIN;
            loginPanel.Visible = true;
            userPanel.Visible = false;
            HpkUpload.Visible = false;

            Application.Lock();
            Application[CommonConstants.APP_USER_ONLINE] = (Int32)Application[CommonConstants.APP_USER_ONLINE] - 1;
            Application.UnLock();

            Response.Redirect(CommonConstants.PAGE_HOME);
        }
        public string loadMaxPointArticle()
        {
            string data = CommonConstants.BLANK;
            string temp = CommonConstants.BLANK;
            string sum = CommonConstants.BLANK;
            ltktDAO.Contest contestDAO = new ltktDAO.Contest();
            ltktDAO.English englishDAO = new ltktDAO.English();
            ltktDAO.Informatics inforDAO = new ltktDAO.Informatics();
            BaseServices bs = new BaseServices();

            tblContestForUniversity uni = contestDAO.getMaxPoint();
            tblEnglish el = englishDAO.getMaxPoint();
            tblInformatic it = inforDAO.getMaxPoint();
            if (uni != null)
            {
                temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK, 
                                                        CommonConstants.SEC_UNIVERSITY_CODE, 
                                                        uni.ID.ToString(), 
                                                        BaseServices.createMsgByTemplate(CommonConstants.TEMP_STRONG_TAG, 
                                                                                        uni.Title.Trim()));

                sum = uni.Contents.Trim();
                if (!BaseServices.isNullOrBlank(sum))
                {
                    temp += CommonConstants.SPACE + bs.subString(sum);
                }
                data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, temp);
            }
            if (el != null)
            {
                temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                        CommonConstants.SEC_UNIVERSITY_CODE,
                                                        el.ID.ToString(),
                                                        BaseServices.createMsgByTemplate(CommonConstants.TEMP_STRONG_TAG,
                                                                                       el.Title.Trim()));
                sum = el.Contents.Trim();
                if (!BaseServices.isNullOrBlank(sum))
                {
                    temp += CommonConstants.SPACE + bs.subString(sum);
                }
                data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, temp);
            }
            if (it != null)
            {
                temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                        CommonConstants.SEC_UNIVERSITY_CODE,
                                                        it.ID.ToString(),
                                                        BaseServices.createMsgByTemplate(CommonConstants.TEMP_STRONG_TAG,
                                                                                        it.Title.Trim()));
                sum = it.Contents.Trim();
                if (!BaseServices.isNullOrBlank(sum))
                {
                    temp += CommonConstants.SPACE + bs.subString(sum);
                }
                data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, temp);
            }
            return data;
        }
    }
}