using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContestUniversity : System.Web.UI.Page
{
    public void Page_Load(object sender, EventArgs e)
    {
        productList.DataSource = DucNghia.DAO.UsersDAO.getAll();
        productList.DataBind();

    }
}
