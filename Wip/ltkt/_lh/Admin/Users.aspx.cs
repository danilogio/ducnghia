using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
namespace ltkt.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster page = (AdminMaster)Master;
            page.updateHeader("Quản lý thành viên");

            if (!IsPostBack)
            {
                gvUsers.DataSource = ltktDAO.Users.getAll();
                gvUsers.DataBind();
            }
        }
        protected void gvUsers_RowUpdating(object sender, EventArgs e)
        {
        }
        protected void gvUsers_RowCancelingEdit(object sender, EventArgs e)
        {

        }
        protected void gvUsers_RowEditing(object sender, EventArgs e)
        {
        }
        protected void AddNewUser(object sender, EventArgs e)
        {

        }
        protected void DeleteUser(object sender, EventArgs e)
        {

        }
        protected void gvUsers_PageIndexChanging(object sender, EventArgs e)
        {
        }

    }
}