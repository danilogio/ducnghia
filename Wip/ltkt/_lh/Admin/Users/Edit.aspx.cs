using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _lh_Admin_Users_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage != null)
        {
            TextBox lklDelete = (TextBox)Page.PreviousPage.Form.FindControl("txtEmail");
            string id = lklDelete.Text;
        }
        
    }

    protected void btnSubmitUpdate_Click(object sender, EventArgs e)
    {

    }
}
