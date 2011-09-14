using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class Permission : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
            if (userAdmin != null)
            {
                if (userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_AUTHORITY)
                    || userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster pageAdmin = (AdminMaster)Master;
                    pageAdmin.updateHeader(CommonConstants.PAGE_ADMIN_PERMISSION_NAME);
                    
                    //title
                    liTitle.Text = CommonConstants.PAGE_ADMIN_PERMISSION_NAME;
                    
                    //////////////////////////////////////////////////
                }
                else
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
            }
            else
            {
                //Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //resultPanel.Visible = true;
            string strKeyword = txtSearch.Text;
            IList<tblUser> lst = userDAO.search(strKeyword);

            lblResult.Text = "<ul>";
            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                string temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                      CommonConstants.PAGE_ADMIN_USERS,
                                                                      CommonConstants.ACT_VIEW,
                                                                      Convert.ToString(lst[idx].ID),
                                                                      lst[idx].Username);
                lblResult.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG,
                                                                        temp);
            }

            lblResult.Text += "</ul>";

            if (lblResult.Text == "<ul></ul>")
            {
                lblResult.Text = CommonConstants.MSG_SEARCH_NOT_FOUND;
            }
        }
    }
}