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
        EventLog log = new EventLog();
        ltktDAO.Permission permitDAO = new ltktDAO.Permission();

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

                    pageLoad(sender, e, user);


                    //////////////////////////////////////////////////
                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_GENERAL);
                }

            }
            else
            {
                //Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }

        private void pageLoad(object sender, EventArgs e, tblUser user)
        {
            int page = 1;
            int id = 0;

            try
            {
                if (Request.QueryString[CommonConstants.REQ_TYPE] != null)
                {
                    viewPanel.Visible = true;
                    detailPanel.Visible = false;

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
                        case CommonConstants.ACT_EDIT:
                        case CommonConstants.ACT_VIEW:
                            {
                                showUserDetail(id, Request.QueryString[CommonConstants.REQ_ACTION]);
                            }
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
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, user.Username, CommonConstants.MSG_LINK_ERROR);
                log.writeLog(DBHelper.strPathLogFile, user.Username, ex.Message);
                //Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_LINK_ERROR;
                Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                               + CommonConstants.ADD_PARAMETER
                               + CommonConstants.REQ_TYPE
                               + CommonConstants.EQUAL
                               + CommonConstants.ACT_NORMAL
                               + CommonConstants.AND
                               + CommonConstants.REQ_PAGE
                               + CommonConstants.EQUAL + "1");
            }
        }

        private void showUserDetail(int id, string action)
        {
            tblUser user = userDAO.getUser(id);
            if (user != null && Session[CommonConstants.SES_EDIT_USER] == null)
            {
                txtUsername.Text = user.Username.Trim();
                txtDisplayName.Text = user.DisplayName.Trim();
                ddlSex.SelectedIndex = (user.Sex == true ? 1 : 0);
                txtEmail.Text = user.Email.Trim();

                //if (user.Role != null)
                //    txtRole.Text = user.Role.Trim();

                IList<tblPermission> lstPermits = userDAO.getPermissions(user.ID);
                if (chxPermission.Items.Count == 0)
                {
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_N_GENERAL),
                                                         CommonConstants.P_N_GENERAL, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_GENERAL),
                                                         CommonConstants.P_A_GENERAL, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_ADS),
                                                         CommonConstants.P_A_ADS, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_USER),
                                                         CommonConstants.P_A_USER, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_NEWS),
                                                         CommonConstants.P_A_NEWS, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_UNIVERSITY),
                                                         CommonConstants.P_A_UNIVERSITY, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_ENGLISH),
                                                         CommonConstants.P_A_ENGLISH, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_INFORMATICS),
                                                         CommonConstants.P_A_INFORMATICS, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_SECURITY),
                                                         CommonConstants.P_A_SECURITY, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_CONTACT),
                                                         CommonConstants.P_A_CONTACT, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_COMMENT),
                                                         CommonConstants.P_A_COMMENT, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_LOG),
                                                         CommonConstants.P_A_LOG, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_CONTROL),
                                                         CommonConstants.P_A_CONTROL, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_EMAIL),
                                                         CommonConstants.P_A_EMAIL, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_AUTHORITY),
                                                         CommonConstants.P_A_AUTHORITY, false));
                    chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_FULL_CONTROL),
                                                         CommonConstants.P_A_FULL_CONTROL, false));
                }


                for (int outer = 0; outer < lstPermits.Count; ++outer)
                {
                    for (int inner = 0; inner < chxPermission.Items.Count; ++inner)
                    {
                        if (chxPermission.Items[inner].Value.Trim() == lstPermits[outer].Code.Trim())
                        {
                            chxPermission.Items[inner].Selected = true;
                        }

                        if (lstPermits[outer].Code.Trim() == CommonConstants.P_A_FULL_CONTROL)
                            chxPermission.Items[inner].Selected = true;
                    }
                }

                txtRegisterDate.Text = user.RegisterDate.ToString();
                if (user.KIADate != null)
                    txtKIADate.Text = user.KIADate.ToString();

                if (ddlState.Items.Count == 0)
                {
                    //ddlState.Items.RemoveAt(0);
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_DELETED_NAME, CommonConstants.STATE_DELETED.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_KIA_1M_NAME, CommonConstants.STATE_KIA_1M.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_KIA_3W_NAME, CommonConstants.STATE_KIA_3W.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_KIA_2W_NAME, CommonConstants.STATE_KIA_2W.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_KIA_1W_NAME, CommonConstants.STATE_KIA_1W.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_KIA_3D_NAME, CommonConstants.STATE_KIA_3D.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_WARNING_NAME, CommonConstants.STATE_WARNING.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_ACTIVE_NAME, CommonConstants.STATE_ACTIVE.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_NON_ACTIVE_NAME, CommonConstants.STATE_NON_ACTIVE.ToString()));
                }
                for (int idx = 0; idx < ddlState.Items.Count; ++idx)
                {
                    if (ddlState.Items[idx].Value == user.State.ToString())
                    {
                        ddlState.SelectedIndex = idx;
                    }
                }

                txtNumberOfArticles.Text = Convert.ToString(user.NumberOfArticles);
                txtNote.Text = user.Note.Trim();


                switch (action)
                {
                    case CommonConstants.ACT_VIEW:
                        {
                            txtDisplayName.ReadOnly = true;
                            ddlSex.Enabled = false;
                            txtEmail.ReadOnly = true;
                            //txtRole.ReadOnly = true;
                            btnResetPassword.Enabled = false;
                            txtRegisterDate.ReadOnly = true;
                            txtKIADate.ReadOnly = true;
                            txtRegisterDate.CssClass = "";
                            txtKIADate.CssClass = "";
                            ddlState.Enabled = false;
                            txtNumberOfArticles.ReadOnly = true;
                            txtNote.ReadOnly = true;
                            break;
                        }
                    case CommonConstants.ACT_EDIT:
                        {
                            txtDisplayName.ReadOnly = false;
                            //ddlSex.Enabled = true;
                            txtEmail.ReadOnly = false;
                            //txtRole.ReadOnly = false;
                            //txtRegisterDate.ReadOnly = false;
                            txtKIADate.ReadOnly = false;
                            //txtRegisterDate.CssClass = "calendar";
                            txtKIADate.CssClass = "calendar";
                            //ddlState.Enabled = true;
                            txtNumberOfArticles.ReadOnly = false;
                            txtNote.ReadOnly = false;

                            tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
                            if (userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_FULL_CONTROL))
                            {
                                btnResetPassword.Enabled = true;
                                ddlState.Enabled = true;
                            }
                            else if (userDAO.isAllow(user.Permission, CommonConstants.P_N_GENERAL))
                            {
                                btnResetPassword.Enabled = true;
                                ddlState.Enabled = true;
                            }

                            break;
                        }
                }

            }
            else if (user == null)
            {
                messagePanel.Visible = true;
                detailPanel.Visible = false;

                liMessage.Text = CommonConstants.MSG_RESOURCE_NOT_FOUND;
            }

            if (Request.QueryString[CommonConstants.REQ_ACTION] == CommonConstants.ACT_EDIT)
            {
                tblUser userEdit = userDAO.getUser(id);
                Session[CommonConstants.SES_EDIT_USER] = userEdit;
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
                userCell.Style["width"] = "80px";
                userCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                      CommonConstants.PAGE_ADMIN_USERS,
                                                                      CommonConstants.ACT_VIEW,
                                                                      Convert.ToString(user.ID),
                                                                      user.Username);

                TableCell displayCell = new TableCell();
                displayCell.CssClass = "table-cell";
                displayCell.Style["width"] = "180px";
                displayCell.Text = user.DisplayName.Trim();

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "80px";
                stateCell.Text = user.State.ToString();

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "60px";
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
                normalUserRow.Cells.Add(displayCell);
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[CommonConstants.REQ_ACTION] == CommonConstants.ACT_VIEW)
            {
                //txtFromDate.CssClass = "calendar";
                //txtEndDate.CssClass = "calendar";
                //int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                //tblUser userEdit = userDAO.getUser(id);
                //Session[CommonConstants.SES_EDIT_USER] = userEdit;

                Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                                   + CommonConstants.ADD_PARAMETER
                                   + CommonConstants.REQ_ACTION
                                   + CommonConstants.EQUAL
                                   + CommonConstants.ACT_EDIT
                                   + CommonConstants.AND
                                   + CommonConstants.REQ_ID
                                   + CommonConstants.EQUAL
                                   + Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]));
            }

            try
            {
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
                if (userAdmin != null)
                {
                    tblUser userEdit = userDAO.getUser(id);//always exist

                    string displayName = txtDisplayName.Text;
                    string email = txtEmail.Text;
                    string note = txtNote.Text;

                    if (userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_FULL_CONTROL)
                        || userDAO.isAllow (userEdit.Permission,CommonConstants.P_N_GENERAL))
                    {
                        int state = Convert.ToInt32(ddlState.SelectedValue);
                        DateTime KIADate = DateTime.Now;
                        if ((state > CommonConstants.STATE_KIA_3D 
                            && state < CommonConstants.STATE_KIA_1M)
                            && txtKIADate.Text != CommonConstants.BLANK)
                        {
                            KIADate = DateTime.Parse (txtKIADate.Text);
                        }

                        userDAO.updateUser(userAdmin.Username, userEdit.Username, displayName, email, state, KIADate, note);
                        
                        detailPanel.Visible = false;
                        viewPanel.Visible = true;
                    }
                    else
                    {
                        userDAO.updateUser(userAdmin.Username, userEdit.Username, displayName, email, note);
                        
                        detailPanel.Visible = false;
                        viewPanel.Visible = true;
                    }
                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }

                Session[CommonConstants.SES_EDIT_USER] = null;
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                              + CommonConstants.ADD_PARAMETER
                              + CommonConstants.REQ_TYPE
                              + CommonConstants.EQUAL
                              + CommonConstants.ACT_NORMAL
                              + CommonConstants.AND
                              + CommonConstants.REQ_PAGE + "1");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session[CommonConstants.SES_EDIT_USER] = null;

            detailPanel.Visible = false;
            viewPanel.Visible = true;

            Response.Redirect(CommonConstants.PAGE_ADMIN_USERS
                               + CommonConstants.ADD_PARAMETER
                               + CommonConstants.REQ_TYPE
                               + CommonConstants.EQUAL
                               + CommonConstants.ACT_NORMAL
                               + CommonConstants.AND
                               + CommonConstants.REQ_PAGE
                               + CommonConstants.EQUAL + "1");
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
            if (userAdmin != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                    tblUser userEdit = userDAO.getUser(id);

                    if (userEdit != null)
                    {
                        // Phát sinh mật khẩu bất kỳ
                        string strNewPassword = userDAO.generatePassword();

                        // Gửi mật khẩu đến email
                        userDAO.sendNewPassword(userEdit.Username.Trim(), strNewPassword, userEdit.Email.Trim());

                        //Response.Write(CommonConstants.ALERT_UPDATE_SUCCESSFUL);
                    }
                }
                catch (Exception ex)
                {
                    log.writeLog(DBHelper.strPathLogFile, userAdmin.Username, ex.Message);
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }
    }
}