using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class Comment : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_COMMENT)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader(CommonConstants.PAGE_ADMIN_COMMENT_NAME);

                    liTitle.Text = CommonConstants.PAGE_ADMIN_COMMENT_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
                    string message = adminDAO.getReason(CommonConstants.AF_COMMENT);
                    if (!BaseServices.isNullOrBlank(message))
                    {
                        showStatusMessage(message);
                    }
                    //////////////////////////////////////////////////
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