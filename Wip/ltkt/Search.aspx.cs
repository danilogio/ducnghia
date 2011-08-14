using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ltkt
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                        
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!recaptcha.IsValid)
            {
                return;
            }

            string keyWords = txtboxSearch.Text;
            int topic = Convert.ToInt32(ddlSubject.SelectedValue);

            // Luyện thi đại học
            if (topic == 0 || topic == 3)
            { }
            
            // Tin học
            if (topic == 1 || topic == 3)
            { }
            
            // Anh văn
            if (topic == 2 || topic == 3)
            { }


            
        }
    }
}