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
        ltktDAO.Statistics statisticDAO = new ltktDAO.Statistics();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_USER] != null)
            {
                Session[CommonConstants.SES_USER] = null;
            }
            string errorText = (string)Session[CommonConstants.SES_ERROR];
            if(!BaseServices.isNullOrBlank(errorText))
            {
                lMessage.Text = errorText;
                Session[CommonConstants.SES_ERROR] = null;
            }

        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string strUsername = txtboxLoginName.Text;
            string strPassword = txtboxPassword.Text;
            txtboxLoginName.Text = CommonConstants.BLANK;
            txtboxPassword.Text = CommonConstants.BLANK;
            tblUser user = userDAO.getUser(strUsername, strPassword, false);

            if (user != null)
            {
                if (user.State != CommonConstants.STATE_DELETED 
                    && user.State != CommonConstants.STATE_NON_ACTIVE)
                {
                    if (user.Type == false)
                    {
                        Session[CommonConstants.SES_USER] = user;
                        statisticDAO.addLatestLoginUser(user.Username);
                        Response.Redirect(CommonConstants.PAGE_ADMIN_GENERAL);
                    }
                    else
                    {
                        lMessage.Text = CommonConstants.MSG_ACCESS_DENIED;
                        lMessage.Visible = true;
                    }
                }
                else
                {
                    lMessage.Text = CommonConstants.MSG_LOGIN_FAILED;
                    lMessage.Visible = true;
                }
            }
            else
            {
                lMessage.Text = CommonConstants.MSG_LOGIN_FAILED;
                lMessage.Visible = true;
            }
        }
    }
}