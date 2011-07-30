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
            if (Session["User"] != null)
            {
                tblUser user = (tblUser)Session["User"];
                lLogonUser.Text = user.DisplayName;
                lLogonUser.Visible = true;
                userPanel.Visible = true;
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        public void updateHeader(string _header)
        {
            lHeader.Text = _header;
        }
    }
}