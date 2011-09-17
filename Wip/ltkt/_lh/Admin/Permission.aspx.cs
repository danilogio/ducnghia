using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class Permission : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        EventLog log = new EventLog();
        ltktDAO.Permission permitDAO = new ltktDAO.Permission();

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
            if (userAdmin != null)
            {
                if (userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_AUTHORITY)
                    || userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster pageAdmin = (AdminMaster)Master;
                    pageAdmin.updateHeader(CommonConstants.PAGE_ADMIN_PERMISSION_NAME);

                    //title
                    liTitle.Text = CommonConstants.PAGE_ADMIN_PERMISSION_NAME;

                    pageLoad(sender, e, userAdmin);

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

        private void pageLoad(object sender, EventArgs e, tblUser userAdmin)
        {
            try
            {
                if (Request.QueryString[CommonConstants.REQ_ACTION] != null)
                {
                    searchPanel.Visible = false;
                    detailPanel.Visible = true;

                    string action = Request.QueryString[CommonConstants.REQ_ACTION];
                    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                    showDetail(id, action);

                    //switch (action)
                    //{
                    //    case CommonConstants.ACT_VIEW:
                    //    case CommonConstants.ACT_EDIT:
                    //        showDetail(id, action);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                else
                {
                    searchPanel.Visible = true;
                    detailPanel.Visible = false;

                    if (Session[CommonConstants.SES_PERMISSION_SEARCH] != null)
                    {
                        string[] session = (string[])Session[CommonConstants.SES_PERMISSION_SEARCH];
                        txtSearch.Text = session[0];
                        lblResult.Text = session[1];
                        lblResult.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, userAdmin.Username, CommonConstants.MSG_LINK_ERROR);
                log.writeLog(DBHelper.strPathLogFile, userAdmin.Username, ex.Message);

                Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);
            }
        }

        private void insertDataToCheckList()
        {
            if (chxPermission.Items.Count == 0)
            {
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_N_GENERAL),
                                                     CommonConstants.P_N_GENERAL));
                //chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_GENERAL),
                //                                     CommonConstants.P_A_GENERAL));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_ADS),
                                                     CommonConstants.P_A_ADS));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_USER),
                                                     CommonConstants.P_A_USER));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_NEWS),
                                                     CommonConstants.P_A_NEWS));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_UNIVERSITY),
                                                     CommonConstants.P_A_UNIVERSITY));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_ENGLISH),
                                                     CommonConstants.P_A_ENGLISH));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_INFORMATICS),
                                                     CommonConstants.P_A_INFORMATICS));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_SECURITY),
                                                     CommonConstants.P_A_SECURITY));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_CONTACT),
                                                     CommonConstants.P_A_CONTACT));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_COMMENT),
                                                     CommonConstants.P_A_COMMENT));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_LOG),
                                                     CommonConstants.P_A_LOG));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_CONTROL),
                                                     CommonConstants.P_A_CONTROL));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_EMAIL),
                                                     CommonConstants.P_A_EMAIL));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_AUTHORITY),
                                                     CommonConstants.P_A_AUTHORITY));
                chxPermission.Items.Add(new ListItem(permitDAO.getName(CommonConstants.P_A_FULL_CONTROL),
                                                     CommonConstants.P_A_FULL_CONTROL));
            }
        }

        private void showDetail(int id, string action)
        {
            insertDataToCheckList();

            if (Session[CommonConstants.SES_PERMISSION_EDIT] != null)
            {
                string[] session = (string[])Session[CommonConstants.SES_PERMISSION_EDIT];
                txtUsername.Text = session[0];
                txtDisplayName.Text = session[1];
                txtRole.Text = session[2];
                string[] permits = session[3].Split(Convert.ToChar(CommonConstants.COMMA));
                foreach (string permit in permits)
                {
                    int count = chxPermission.Items.Count;
                    for (int inner = 0; inner < count; ++inner)
                    {
                        if (chxPermission.Items[inner].Value.Trim() == permit)
                            chxPermission.Items[inner].Selected = true;

                        if (permit == CommonConstants.P_A_FULL_CONTROL)
                            chxPermission.Items[inner].Selected = true;
                    }
                }
            }
            else
            {
                tblUser user = userDAO.getUser(id);
                if (user != null /*&& Session[CommonConstants.SES_EDIT_USER] == null*/)
                {
                    txtUsername.Text = user.Username.Trim();
                    txtDisplayName.Text = user.DisplayName.Trim();
                    txtRole.Text = user.Role.Trim();

                    IList<tblPermission> lstPermits = userDAO.getPermissions(user.ID);
                    //string permits = CommonConstants.BLANK;
                    int sum = lstPermits.Count;
                    for (int outer = 0; outer < sum; ++outer)
                    {
                        int count = chxPermission.Items.Count;
                        for (int inner = 0; inner < count; ++inner)
                        {
                            if (chxPermission.Items[inner].Value.Trim() == lstPermits[outer].Code.Trim())
                            {
                                chxPermission.Items[inner].Selected = true;
                                //permits += chxPermission.Items[inner].Value.Trim();
                                //permits += CommonConstants.COMMA;
                            }

                            if (lstPermits[outer].Code.Trim() == CommonConstants.P_A_FULL_CONTROL)
                            {
                                chxPermission.Items[inner].Selected = true;
                                //permits += chxPermission.Items[inner].Value.Trim();
                                //permits += CommonConstants.COMMA;
                            }
                        }
                    }

                    string[] session = { user.Username.Trim(), user.DisplayName.Trim(), user.Role.Trim(), CommonConstants.BLANK };
                    Session[CommonConstants.SES_PERMISSION_EDIT] = session;

                    //switch (action)
                    //{
                    //    case CommonConstants.ACT_VIEW:
                    //        for (int inner = 0; inner < chxPermission.Items.Count; ++inner)
                    //            chxPermission.Items[inner].Enabled = false;

                    //        break;
                    //    case CommonConstants.ACT_EDIT:
                    //        {
                    //            tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
                    //            if (userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_FULL_CONTROL)
                    //                || userDAO.isAllow(user.Permission, CommonConstants.P_N_GENERAL))
                    //            {
                    //                for (int inner = 0; inner < chxPermission.Items.Count; ++inner)
                    //                    chxPermission.Items[inner].Enabled = true;
                    //            }
                    //            break;
                    //        }
                    //    default:
                    //        break;
                    //}
                }
                else if (user == null)
                {
                    messagePanel.Visible = true;
                    detailPanel.Visible = false;

                    liMessage.Text = CommonConstants.MSG_RESOURCE_NOT_FOUND;
                }
            }

            //if (action == CommonConstants.ACT_EDIT)
            //{
            //    tblUser userEdit = userDAO.getUser(id);
            //    Session[CommonConstants.SES_EDIT_USER] = userEdit;
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //resultPanel.Visible = true;
            string strKeyword = txtSearch.Text;
            IList<tblUser> lst = userDAO.search(strKeyword);

            lblResult.Text = "<ul>";
            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                string temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                      CommonConstants.PAGE_ADMIN_PERMISSION,
                                                                      CommonConstants.ACT_EDIT,
                                                                      Convert.ToString(lst[idx].ID),
                                                                      lst[idx].Username);
                lblResult.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG,
                                                                        temp);
            }

            lblResult.Text += "</ul>";

            if (lblResult.Text == "<ul></ul>")
            {
                lblResult.Text = CommonConstants.MSG_SEARCH_NOT_FOUND;
            }

            string[] result = { strKeyword, lblResult.Text };
            Session[CommonConstants.SES_PERMISSION_SEARCH] = result;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //if (Request.QueryString[CommonConstants.REQ_ACTION] == CommonConstants.ACT_VIEW)
            //{
            //    Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION
            //                       + CommonConstants.ADD_PARAMETER
            //                       + CommonConstants.REQ_ACTION
            //                       + CommonConstants.EQUAL
            //                       + CommonConstants.ACT_EDIT
            //                       + CommonConstants.AND
            //                       + CommonConstants.REQ_ID
            //                       + CommonConstants.EQUAL
            //                       + Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]));
            //}

            try
            {
                tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
                if (userAdmin != null)
                {
                    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                    tblUser userEdit = userDAO.getUser(id);//always exist

                    string permits = CommonConstants.BLANK;
                    for (int idx = 0; idx < chxPermission.Items.Count; ++idx)
                        if (chxPermission.Items[idx].Selected)
                        {
                            permits += Convert.ToString(permitDAO.getValue(chxPermission.Items[idx].Value));
                            permits += CommonConstants.COMMA;
                        }

                    //userDAO.updatePermission(userAdmin.Username, userEdit.Username, permits);

                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }


                //Session[CommonConstants.SES_EDIT_USER] = null;
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Session[CommonConstants.SES_EDIT_USER] = null;

            switch (btnContinue.Text)
            {
                case "Tiếp tục":
                    Session[CommonConstants.SES_PERMISSION_EDIT] = null;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);
                    break;
                case "Cập nhật":
                    Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION
                                      + CommonConstants.ADD_PARAMETER
                                      + CommonConstants.REQ_ACTION
                                      + CommonConstants.EQUAL
                                      + CommonConstants.ACT_EDIT
                                      + CommonConstants.AND
                                      + CommonConstants.REQ_ID
                                      + CommonConstants.EQUAL
                                      + Request.QueryString[CommonConstants.REQ_ID]);
                    break;
                default:
                    break;
            }


            //detailPanel.Visible = false;
            //searchPanel.Visible = true;
        }

        protected void chxPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chxPermission.Items[chxPermission.Items.Count - 1].Selected)
            {
                for (int idx = 0; idx < chxPermission.Items.Count; ++idx)
                    chxPermission.Items[idx].Selected = true;
            }

            
            //else
            //{
            //if (!chxPermission.Items[1].Selected)
            //{
            //    chxPermission.Items[0].Selected = true;
            //    for (int idx = 2; idx < chxPermission.Items.Count; ++idx)
            //        chxPermission.Items[idx].Selected = false;
            //}

            //int sum = chxPermission.Items.Count;
            //for (int idx = 2; idx < sum; ++idx)
            //    if (chxPermission.Items[idx].Selected)
            //        chxPermission.Items[1].Selected = true;
            //}


            int sum = chxPermission.Items.Count;
            for (int idx = 1; idx < sum; ++idx)
                if (chxPermission.Items[idx].Selected 
                    && (txtRole.Text == CommonConstants.BLANK || txtRole.Text == "Normal"))
                {
                    txtRole.Text = CommonConstants.ADMIN;
                    break;
                }


            if (Session[CommonConstants.SES_PERMISSION_EDIT] != null)
            {
                string[] session = (string[])Session[CommonConstants.SES_PERMISSION_EDIT];

                int count = chxPermission.Items.Count;
                for (int idx = 0; idx < count; ++idx)
                {
                    if (chxPermission.Items[idx].Selected)
                    {
                        session[3] += chxPermission.Items[idx].Value;
                        session[3] += CommonConstants.COMMA;
                    }
                }
                session[2] = txtRole.Text.Trim();
                Session[CommonConstants.SES_PERMISSION_EDIT] = session;
            }

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            switch (btnContinue.Text)
            {
                case "Tiếp tục":
                    //Session[CommonConstants.SES_PERMISSION_SEARCH] = null;
                    btnContinue.Text = "Cập nhật";
                    nextStep();
                    break;
                case "Cập nhật":
                    Session[CommonConstants.SES_PERMISSION_EDIT] = null;
                    Session[CommonConstants.SES_PERMISSION_SEARCH] = null;
                    btnContinue.Text = "Tiếp tục";
                    updatePermission();
                    break;
                default:
                    break;
            }
        }

        private void updatePermission()
        {
            try
            {
                tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
                if (userAdmin != null)
                {
                    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                    tblUser userEdit = userDAO.getUser(id);//always exist

                    string role = txtRole.Text;
                    string permits = CommonConstants.BLANK;
                    int count = chxPermission.Items.Count;
                    bool didIt = false;
                    for (int idx = 0; idx < count; ++idx)
                    {
                        if (chxPermission.Items[idx].Selected)
                        {
                            if (idx > 0 && !didIt)
                            {
                                permits += Convert.ToString(permitDAO.getValue(CommonConstants.P_A_GENERAL));
                                permits += CommonConstants.COMMA;

                                didIt = true;
                            }
                            
                            permits += Convert.ToString(permitDAO.getValue(chxPermission.Items[idx].Value));
                            permits += CommonConstants.COMMA;


                        }
                    }

                    if (permits.Contains("99"))
                        permits = "99";

                    userDAO.updatePermission(userAdmin.Username, userEdit.Username, permits, role);

                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }


                //Session[CommonConstants.SES_EDIT_USER] = null;
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);
        }

        private void nextStep()
        {
            try
            {
                tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
                if (userAdmin != null)
                {
                    //int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                    //tblUser userEdit = userDAO.getUser(id);//always exist


                    int count = chxPermission.Items.Count;
                    lblPermission.Text = "<ul>";
                    for (int idx = 0; idx < count; ++idx)
                        if (chxPermission.Items[idx].Selected)
                        {
                            string temp = Convert.ToString(permitDAO.getName(chxPermission.Items[idx].Value));
                            lblPermission.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, temp);
                        }

                    lblPermission.Text += "</ul>";

                    lblPermission.Visible = true;
                    chxPermission.Visible = false;

                    //userDAO.updatePermission(userAdmin.Username, userEdit.Username, permits);

                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }


                //Session[CommonConstants.SES_EDIT_USER] = null;
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            //Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);
        }
    }
}