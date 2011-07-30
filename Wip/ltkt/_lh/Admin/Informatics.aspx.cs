using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ltkt.Admin
{
    public partial class Informatics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster page = (AdminMaster)Master;
            page.updateHeader("Quản lý chủ đề Tin học");
        }
    }
}