using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAO;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltsItem.Items.Add("-- Tất cả danh mục  --");
        ltsItem.Items.Add("Luyện thi đại học");
        ltsItem.Items.Add("Anh văn");
        ltsItem.Items.Add("Tin học");
        ltsItem.Width = 150;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strUsername = txtUsername.Text;
        string strPassword = txtPassword.Text;

        Boolean loginState = DAO.UsersDAO.isUser(strUsername, strPassword);        
        
    }
}
