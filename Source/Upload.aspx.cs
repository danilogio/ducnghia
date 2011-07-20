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
                //Response.Write("123");
                //txtboxcontactEmail.Visible = false;
            }
            else if (selectedIndex == 2)
            {
                //txtboxcontactEmail.Visible = true;
            }
            Response.End();
        }
    }
}
