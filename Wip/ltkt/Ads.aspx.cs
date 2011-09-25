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
        string red = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_REDIRECT]);
        ltktDAO.Ads adsDAO = new ltktDAO.Ads();

        if (red == CommonConstants.BLANK)
        {
            red = CommonConstants.PAGE_ADCONTACT;
        }
        if (action == CommonConstants.ACT_CLICK)
        {
            if (id == CommonConstants.ADS_TOP_BANNER)
            {
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_TOP_LEADER_BANNER)
            {
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_TOP_RIGHT_BANNER)
            {
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_MIDDLE_RIGHT_BANNER)
            {
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_BOTTOM_RIGHT_BANNER)
            {
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_TOP_LEFT_BANNER)
            {
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_MIDDLE_LEFT_BANNER)
            {
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_BOTTOM_LEFT_BANNER)
            {
                adsDAO.addClickCount(CommonConstants.ADS_BOTTOM_LEFT_BANNER);
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_BOTTOM_1_BANNER)
            {
                adsDAO.addClickCount(CommonConstants.ADS_BOTTOM_1_BANNER);
                Response.Redirect(red);
            }
            else if (id == CommonConstants.ADS_BOTTOM_2_BANNER)
            {
                adsDAO.addClickCount(CommonConstants.ADS_BOTTOM_2_BANNER);
                Response.Redirect(red);
            }
        }
    }
}
