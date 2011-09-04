using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

public partial class Error : System.Web.UI.Page
{
    ltktDAO.Control control = new ltktDAO.Control();

    protected void Page_Load(object sender, EventArgs e)
    {
        liTitle.Text = CommonConstants.PAGE_ERROR_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

        string errorText = (string) Session[CommonConstants.SES_ERROR];
        if (errorText != null)
        {
            lblError.Text = "<br />";
            lblError.Text += errorText;
            lblError.Text += "<br /><br />";

            if (Request.UrlReferrer != null)
            {
                HpkPreviousPage.NavigateUrl = Request.UrlReferrer.ToString();
            }
            else
            {
                HpkPreviousPage.Visible = false;
            }
            Session[CommonConstants.SES_ERROR] = null;
        }
        else
        {
            Response.Redirect(CommonConstants.PAGE_HOME);
        }
    }
}
