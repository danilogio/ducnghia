using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt
{
    public partial class UnderConstruction : System.Web.UI.Page
    {
        ltktDAO.Control control = new ltktDAO.Control();
        protected void Page_Load(object sender, EventArgs e)
        {
            tit.Text = CommonConstants.PAGE_UNDERCONSTRUCTION_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            string errorTxt = (string) Session[CommonConstants.SES_ERROR];
            if (!BaseServices.isNullOrBlank(errorTxt))
            {
                lMessage.Text = errorTxt;
                Session[CommonConstants.SES_ERROR] = null;
            }
            else
            {
                lMessage.Text = CommonConstants.MSG_UNDERCONSTRUCTION;
            }
        }
    }
}
