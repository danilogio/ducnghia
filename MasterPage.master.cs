using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltsItem.Items.Add("-- Tất cả danh mục  --");
        ltsItem.Items.Add("Luyện thi đại học");
        ltsItem.Items.Add("Anh văn");
        ltsItem.Items.Add("Tin học");
        ltsItem.Width = 163;
    }
}
