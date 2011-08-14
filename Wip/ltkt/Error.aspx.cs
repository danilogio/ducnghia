using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string errorText = (string) Session["Error"];
        if (errorText != null)
        {
            lblError.Text = errorText;
            if (Request.UrlReferrer != null)
            {
                HpkPreviousPage.NavigateUrl = Request.UrlReferrer.ToString();
            }
            else
            {
                HpkPreviousPage.Visible = false;
            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
}
