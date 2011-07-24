using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
public partial class Registry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistry_Click(object sender, EventArgs e)
    {
        
        ccJoin.ValidateCaptcha(txtboxCaptcha.Text);
        if (!ccJoin.UserValidated)
        {
            txtboxEmail.Text = "wrong";
            Response.Write(txtboxEmail.Text);
        }

        //MessageBox.Show(txtboxDisplayName.Text);
    }
}
