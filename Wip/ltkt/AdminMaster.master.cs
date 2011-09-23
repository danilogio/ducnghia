using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        ltktDAO.Users userDAO = new ltktDAO.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_USER] != null)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                if (user.State != CommonConstants.STATE_DELETED
                    && user.State != CommonConstants.STATE_KIA_1M
                    && user.State != CommonConstants.STATE_KIA_3W
                    && user.State != CommonConstants.STATE_NON_ACTIVE
                    && user.Type == false)
                {
                    lLogonUser.Text = user.DisplayName;
                    lLogonUser.Visible = true;
                    userPanel.Visible = true;
                    checkPermission(user.Permission);
                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_LOGIN_FAILED;
                    //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }
            }
            else
            {
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }

        private void checkPermission(string permission)
        {
            if (userDAO.isAllow(permission, CommonConstants.P_A_GENERAL)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkGeneral.Visible = true;
                //HpkGeneral.NavigateUrl = CommonConstants.PAGE_ADMIN_GENERAL;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_USER)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkUser.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_NEWS)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkNews.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_AUTHORITY)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkPermisson.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_SECURITY)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkSecurity.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_CONTROL)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkControl.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_COMMENT)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkComment.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_UNIVERSITY)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkUniversity.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_ENGLISH)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkEnglish.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_INFORMATICS)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkIt.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_ADS)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkAds.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_CONTACT)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkContact.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_EMAIL)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkEmail.Visible = true;
            }
            if (userDAO.isAllow(permission, CommonConstants.P_A_LOG)
                    || userDAO.isAllow(permission, CommonConstants.P_A_FULL_CONTROL))
            {
                HpkLog.Visible = true;
            }

        }
        public void updateHeader(string _header)
        {
            lHeader.Text = _header;
        }
    }
}