using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ltktDAO;
public partial class AdContact : System.Web.UI.Page
{
    EventLog log = new EventLog();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void btnSubmitContact_Click(object sender, EventArgs e)
    {
        if (!recaptcha.IsValid)
        {
            return;
        }

        string _companyName = txtboxCompanyName.Text;
        string _address = txtAddress.Text;
        string _email = txtboxContactEmail.Text;
        string _phone = txtboxFone.Text;
        DateTime _fromDate = DateTime.Parse(txtFromDate.Text);
        DateTime _endDate = DateTime.Parse(txtToDate.Text);
        string _description = getLocation(sender, e);

        
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
