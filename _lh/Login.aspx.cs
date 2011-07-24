using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _lh_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        return;
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        ccJoin.ValidateCaptcha(txtboxCaptcha.Text);
        if (!ccJoin.UserValidated)
        {
            
            //Response.End();
            return;
        }
        else
        {
            Response.Redirect("./Admin/General.aspx");
        }
    }
}
