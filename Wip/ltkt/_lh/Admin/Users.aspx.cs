using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;
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
                //gvUsers.DataSource = ltktDAO.Users.getAll();
                //gvUsers.DataBind();
            }
        }
        /*
        protected void gvUsers_RowUpdating(object sender, EventArgs e)
        {
        }
        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            DataBindGrid();
        }
        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            DataBindGrid();
        }


        protected void AddNewUser(object sender, EventArgs e)
        {

        }
        protected void DeleteUser(object sender, EventArgs e)
        {
            LinkButton lklDelete = sender as LinkButton;

            // string strId = lklDelete.CommandArgument;
            // //HttpContext.Current.Response.Write(
            // ASCIIEncoding encoding = new ASCIIEncoding();
            // string postData = "id=" + strId;
            // byte[] data = encoding.GetBytes(postData);

            //// Response.
            // // Prepare web request...
            // HttpWebRequest myRequest =
            //   (HttpWebRequest)WebRequest.Create("~/Users/Edit.aspx");
            // myRequest.Method = "POST";
            // myRequest.ContentType = "application/x-www-form-urlencoded";
            // myRequest.ContentLength = data.Length;
            // Stream newStream = myRequest.GetRequestStream();
            // // Send the data.
            // newStream.Write(data, 0, data.Length);
            // newStream.Close();
            Server.Transfer("./Users/Edit.aspx");
        }
        protected void gvUsers_PageIndexChanging(object sender, EventArgs e)
        {
        }
        private void DataBindGrid()
        {
            this.gvUsers.DataSource = ltktDAO.Users.getAll();
            this.gvUsers.DataBind();
        }
        */


    }
}