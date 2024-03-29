﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt
{
    public partial class Login : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            MasterPage page = (MasterPage)Master;
            page.hideLoginSidebar();

            liTitle.Text = CommonConstants.PAGE_LOGIN_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

            string errorText = (string)Session[CommonConstants.SES_ERROR];
            if (!BaseServices.isNullOrBlank(errorText))
            {
                lMessage.Text = errorText;
                messagePanel.Visible = true;
                Session[CommonConstants.SES_USER] = null;
            }
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
            if (!recaptcha.IsValid)
            {
                return;
            }
            try
            {
                tblUser user = userDAO.getUser(strUsername, strPassword, false);

                if (user != null)
                {
                    if (user.State != CommonConstants.STATE_DELETED 
                        && user.State != CommonConstants.STATE_NON_ACTIVE)
                    {
                        //Đăng nhập thành công
                        MasterPage page = (MasterPage)Master;
                        page.updateAccount(user);

                        Response.Redirect(CommonConstants.PAGE_HOME);
                    }
                }
                else
                {
                    //Đăng nhập thất bại
                    lMessage.Text = CommonConstants.MSG_E_LOGIN_FAILED;
                    lMessage.Visible = true;
                    messagePanel.Visible = true;

                    Response.Redirect(CommonConstants.PAGE_HOME);
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), CommonConstants.USER_GUEST, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }
    }
}