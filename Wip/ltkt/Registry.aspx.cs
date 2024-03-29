﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ltktDAO;

namespace ltkt
{
    public partial class Registry : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_REGISTRY_NAME
                               + CommonConstants.SPACE + CommonConstants.HLINE
                               + CommonConstants.SPACE
                               + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

        }

        protected void btnRegistry_Click(object sender, EventArgs e)
        {
            try
            {
                string strUsername = txtboxLoginName.Text;
                if (!recaptcha.IsValid)
                {
                    return;
                }
                bool isExistedUsername = userDAO.existedUser(strUsername);

                if (isExistedUsername)
                {
                    liMessage.Text = CommonConstants.MSG_W_USERNAME_CONFLICT;
                    liMessage.Visible = true;
                }
                else
                {
                    string strDisplayName = txtboxDisplayName.Text;
                    bool isFemale = bool.Parse(ddlSex.SelectedValue);
                    string strPassword = txtboxPassword.Text;
                    string strEmail = txtboxEmail.Text;

                    string user = userDAO.existedEmail(strEmail);
                    if (user != null)
                    {
                        liMessage.Text = CommonConstants.MSG_W_EMAIL_CONFLICT;
                        liMessage.Visible = true;
                    }
                    else
                    { // Mọi điều kiện đã hợp lệ, bắt đầu đăng ký
                        bool success = userDAO.register(strUsername, strDisplayName, strEmail, isFemale, strPassword);

                        if (success)
                        {
                            liMessage.Text = CommonConstants.MSG_I_REGISTRY_SUCCESSFUL;
                            liMessage.Visible = true;
                            registerPanel.Visible = false;
                        }
                        else
                        {
                            liMessage.Text = CommonConstants.MSG_E_REGISTRY_FAILED;
                            liMessage.Visible = true;
                        }
                    }
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