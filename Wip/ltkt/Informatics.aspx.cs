using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt
{
    public partial class Informatics : System.Web.UI.Page
    {
        ltktDAO.Control control = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_INFORMATICS_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
        }
        protected void DataPagerArticles_PreRender(object sender, EventArgs e)
        {

        }
    }
}