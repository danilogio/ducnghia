using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class AdContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmitContact_Click(object sender, EventArgs e)
    {
        if (!recaptcha.IsValid)
        {
            return;
        }

        string sDescription = getLocation(sender, e);
    }

    private string getLocation(object sender, EventArgs e)
    {
        string sLocation = "[Loc]";
        if (chkTop.Checked)
        {
            sLocation += "Top,";
        }
        if (chkBot.Checked)
        {
            sLocation += "Bot,";
        }
        if (chkLeft.Checked)
        {
            sLocation += "Left,";
        }
        if (chkRight.Checked)
        {
            sLocation += "Right,";
        }
        sLocation += "[Loc]";
        return sLocation;
    }
}
