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

using ltktDAO;
using System.Collections.Generic;

namespace ltkt.Admin
{
    public partial class Mailbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster page = (AdminMaster)Master;
            page.updateHeader("Hộp thư");

            //IEnumerable<tblContact> lst = ltktDAO.Contact.getAll();
            //grdInbox.DataSource = lst;
            //grdInbox.DataBind();
        }

        protected void btnInbox_Click(object sender, EventArgs e)
        {
        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
        }


    }
}