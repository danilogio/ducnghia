using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string selIndex = Request["selIndex"];
        int selectedIndex;
        if (selIndex == null)
        {
            selectedIndex=0;
        }
        else{
             selectedIndex = Int32.Parse(selIndex);
            if (selectedIndex == 1)
            {
                Response.Write("<span>Email:</span><asp:TextBox ID='txtboxcontactEmail' runat='server' CssClass='contact'></asp:TextBox>");
                Response.End();
            }
        }
    }
}
