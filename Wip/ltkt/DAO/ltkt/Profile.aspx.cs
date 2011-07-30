using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DAO;

namespace ltkt
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                tblUser user = (tblUser)Session["User"];

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void btnSubmitChangePassword_Click(object sender, EventArgs e)
        {
        }


        protected void btnChangePassword_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
        }

        protected void btnSubmitUpdateProfile_Click(object sender, EventArgs e)
        {
        }
    }
}
