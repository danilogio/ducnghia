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
        private ltktDAO.Users userDAO = new ltktDAO.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_USER)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader("Quản lý thành viên");

                    if (!IsPostBack)
                    {
                        //gvUsers.DataSource = ltktDAO.Users.getAll();
                        //gvUsers.DataBind();
                    }
                    //////////////////////////////////////////////////
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
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