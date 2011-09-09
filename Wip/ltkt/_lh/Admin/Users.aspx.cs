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
        ltktDAO.Control control = new ltktDAO.Control();

        public const int NoOfUsesPerPage = 6;

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_USER)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster pageAdmin = (AdminMaster)Master;
                    pageAdmin.updateHeader(CommonConstants.PAGE_ADMIN_USERS_NAME);

                    //title
                    liTitle.Text = CommonConstants.PAGE_ADMIN_USERS_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

                    if (!IsPostBack)
                    {
                        //gvUsers.DataSource = ltktDAO.Users.getAll();
                        //gvUsers.DataBind();
                    }

                    int page = 1;
                    int id = 0;
                    if (Request.QueryString[CommonConstants.REQ_TYPE] != null)
                    {
                        page = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_PAGE]);

                        switch (Request.QueryString[CommonConstants.REQ_TYPE])
                        {
                            case CommonConstants.ACT_NORMAL:
                                showUsers(CommonConstants.ACT_NORMAL, page);
                                break;
                            case CommonConstants.ACT_KIA:
                                showUsers(CommonConstants.ACT_KIA, page);
                                break;
                            case CommonConstants.ACT_ADMIN:
                                showUsers(CommonConstants.ACT_ADMIN, page);
                                break;
                            default: break;
                        }
                        
                    }
                    else if (Request.QueryString[CommonConstants.REQ_ACTION] != null)
                    {
                        id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                        switch (Request.QueryString[CommonConstants.REQ_ACTION])
                        {
                            case CommonConstants.ACT_VIEW:
                                break;
                            case CommonConstants.ACT_EDIT:
                                break;
                            case CommonConstants.ACT_DELETE:
                                break;
                        }
                    }
                    else
                    {
                        Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                                           + CommonConstants.ADD_PARAMETER
                                           + CommonConstants.REQ_TYPE
                                           + CommonConstants.EQUAL
                                           + CommonConstants.ACT_NORMAL
                                           + CommonConstants.AND
                                           + CommonConstants.REQ_PAGE
                                           + CommonConstants.EQUAL + "1");
                    }
                    
                    //////////////////////////////////////////////////
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }

        private void showUsers(string type, int page)
        {
            int totalUsers = 0;
            IEnumerable<tblUser> lst = null;
            
            switch (type)
            {
                case CommonConstants.ACT_NORMAL:
                    {
                        liListTitle.Text = "Danh sách thành viên";
                        totalUsers = userDAO.sumNormalUser();
                        lst = userDAO.fetchUsesList(CommonConstants.ACT_NORMAL, ((page - 1) * NoOfUsesPerPage), NoOfUsesPerPage);
                        break;
                    }

                case CommonConstants.ACT_KIA:
                    {
                        liListTitle.Text = "Danh sách thành viên bị khóa";
                        totalUsers = userDAO.sumLockedUser();
                        lst = userDAO.fetchUsesList(CommonConstants.ACT_KIA, ((page - 1) * NoOfUsesPerPage), NoOfUsesPerPage);
                        break;
                    }
                case CommonConstants.ACT_ADMIN:
                    {
                        liListTitle.Text = "Danh sách thành viên quản trị";
                        totalUsers = userDAO.sumAdminUser();
                        lst = userDAO.fetchUsesList(CommonConstants.ACT_ADMIN, ((page - 1) * NoOfUsesPerPage), NoOfUsesPerPage);
                        break;
                    }
            }

            // Computing total pages
            int totalPages;
            int mod = totalUsers % NoOfUsesPerPage;

            if (mod == 0)
            {
                totalPages = totalUsers / NoOfUsesPerPage;
            }
            else
            {
                totalPages = ((totalUsers - mod) / NoOfUsesPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblUser user = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "20px";
                noCell.Text = Convert.ToString(user.ID);

                TableCell userCell = new TableCell();
                userCell.CssClass = "table-cell";
                //userCell.Style["width"] = "80px";
                userCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                      CommonConstants.PAGE_ADMIN_USERS,
                                                                      CommonConstants.ACT_VIEW,
                                                                      Convert.ToString(user.ID),
                                                                      user.Username);

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "80px";
                stateCell.Text = user.State.ToString();

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_USERS,
                                                                     CommonConstants.ACT_EDIT,
                                                                     Convert.ToString(user.ID),
                                                                     CommonConstants.HTML_EDIT_ADMIN);

                actionCell.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_USERS,
                                                                     CommonConstants.ACT_DELETE,
                                                                     Convert.ToString(user.ID),
                                                                     CommonConstants.HTML_DELETE_ADMIN);

                TableRow normalUserRow = new TableRow();
                normalUserRow.Cells.Add(noCell);
                normalUserRow.Cells.Add(userCell);
                normalUserRow.Cells.Add(stateCell);
                normalUserRow.Cells.Add(actionCell);

                listUsers.Rows.AddAt(2 + idx, normalUserRow);
            }
            
            // Creating links to previous and next pages
            if (totalPages > 1)
            {
                if (page > 1)
                    liNormalPre.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MINOR_SELF_LINK,
                                                                                CommonConstants.PAGE_ADMIN_USERS,
                                                                                type,
                                                                                (page - 1).ToString(),
                                                                                CommonConstants.TXT_PREVIOUS_PAGE);

                if (page > 0 && page < totalPages)
                    liNormalNext.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MINOR_SELF_LINK,
                                                                             CommonConstants.PAGE_ADMIN_USERS,
                                                                             type,
                                                                             (page + 1).ToString(),
                                                                             CommonConstants.TXT_NEXT_PAGE);
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


        protected void btnNormal_Click(object sender, EventArgs e)
        {
            Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                                           + CommonConstants.ADD_PARAMETER
                                           + CommonConstants.REQ_TYPE
                                           + CommonConstants.EQUAL
                                           + CommonConstants.ACT_NORMAL
                                           + CommonConstants.AND
                                           + CommonConstants.REQ_PAGE
                                           + CommonConstants.EQUAL + "1");
        }
        
        protected void btnKIA_Click(object sender, EventArgs e)
        {
            Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                                           + CommonConstants.ADD_PARAMETER
                                           + CommonConstants.REQ_TYPE
                                           + CommonConstants.EQUAL
                                           + CommonConstants.ACT_KIA
                                           + CommonConstants.AND
                                           + CommonConstants.REQ_PAGE
                                           + CommonConstants.EQUAL + "1");
        }
        
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                                           + CommonConstants.ADD_PARAMETER
                                           + CommonConstants.REQ_TYPE
                                           + CommonConstants.EQUAL
                                           + CommonConstants.ACT_ADMIN
                                           + CommonConstants.AND
                                           + CommonConstants.REQ_PAGE
                                           + CommonConstants.EQUAL + "1");
        }
}
}