using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class Contact : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_CONTACT)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader("Quản lý liên hệ");

                    string message = adminDAO.getReason(CommonConstants.AF_CONTACT);
                    if (!BaseServices.isNullOrBlank(message))
                    {
                        showStatusMessage(message);
                    }

                    ///////////////////////////////////////////////
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }
        private void showStatusMessage(string message)
        {
            liStatusMessage.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MARQUEE_TAG,
                                                                    CommonConstants.CS_ANNOUCEMENT_BGCOLOR,
                                                                    CommonConstants.CS_ANNOUCEMENT_TEXTCOLOR,
                                                                   CommonConstants.TXT_INFORM + CommonConstants.SPACE + message);
            statusMessagePanel.Visible = true;
        }
    }
}