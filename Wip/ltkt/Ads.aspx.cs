using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
using System.Windows.Forms;

public partial class Ads : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = BaseServices.nullToBlank( Request.QueryString[CommonConstants.REQ_ACTION]);
        string id = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_ID]);
        if (action == CommonConstants.ACT_CLICK)
        {
            if (id == CommonConstants.ADS_TOP_BANNER)
            {
                Response.Redirect("http://www.google.com");
            }
            else if (id == CommonConstants.ADS_TOP_LEADER_BANNER)
            {
                Response.Redirect("http://bongdaso.com");
            }
            else if (id == CommonConstants.ADS_TOP_RIGHT_BANNER)
            {
                MessageBox.Show("click top right");
                Response.Redirect("AdContact.aspx");
            }
            else if (id == CommonConstants.ADS_MIDDLE_RIGHT_BANNER)
            {
                MessageBox.Show("click middle right");
                Response.Redirect("AdContact.aspx");
            }
            else if (id == CommonConstants.ADS_BOTTOM_RIGHT_BANNER)
            {
                MessageBox.Show("click bottom right");
                Response.Redirect("AdContact.aspx");
            }
            else if (id == CommonConstants.ADS_TOP_LEFT_BANNER)
            {
                MessageBox.Show("click top left");
                Response.Redirect("AdContact.aspx");
            }
            else if (id == CommonConstants.ADS_MIDDLE_LEFT_BANNER)
            {
                MessageBox.Show("click middle letf");
                Response.Redirect("AdContact.aspx");
            }
            else if (id == CommonConstants.ADS_BOTTOM_LEFT_BANNER)
            {
                MessageBox.Show("click bottom left");
                Response.Redirect("AdContact.aspx");
            }
            else if (id == CommonConstants.ADS_BOTTOM_1_BANNER)
            {
                MessageBox.Show("click bottom 1 ");
                Response.Redirect("AdContact.aspx");
            }
            else if (id == CommonConstants.ADS_BOTTOM_2_BANNER)
            {
                MessageBox.Show("click bottom 2");
                Response.Redirect("AdContact.aspx");
            }
        }
    }
}
