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
                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_LOGIN_FAILED;
                    Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                }
            }
            else
            {
                Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }

        public void updateHeader(string _header)
        {
            lHeader.Text = _header;
        }
    }
}