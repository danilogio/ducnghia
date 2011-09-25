using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
namespace ltkt.Admin
{
    public partial class ImportData : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            bool isValid = false;
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    isValid = true;
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader("Import data");

                    //////////////////////////////////////////////////
                }
            }
            if(!isValid)
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            string url = fileContent.FileName;
            if (!BaseServices.isNullOrBlank(url))
            {
                string idx = ddlSubject.SelectedValue;
                if (idx == CommonConstants.SEC_UNIVERSITY_CODE)
                {

                }
                else if(idx == CommonConstants.SEC_ENGLISH_CODE)
                {

                }
                else if (idx == CommonConstants.SEC_INFORMATICS_CODE)
                {

                }
            }
        }
    }
}
