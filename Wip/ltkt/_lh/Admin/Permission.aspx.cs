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
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
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
                    string action = Request.QueryString[CommonConstants.REQ_ACTION];
                    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                    switch (action)
                    {
                        case CommonConstants.ACT_VIEW:
                        case CommonConstants.ACT_EDIT:
                            showDetail(id, action);
                            break;
                        default:
                            break;
                    }

                    searchPanel.Visible = false;
                    detailPanel.Visible = true;
                }
                else
                {
                    searchPanel.Visible = true;
                    detailPanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, userAdmin.Username, CommonConstants.MSG_LINK_ERROR);
                log.writeLog(DBHelper.strPathLogFile, userAdmin.Username, ex.Message);

                Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);
            }
        }

        private void showDetail(int id, string action)
        {
            tblUser user = userDAO.getUser(id);
            if (user != null && Session[CommonConstants.SES_EDIT_USER] == null)
            {
                txtUsername.Text = user.Username.Trim();
                txtDisplayName.Text = user.DisplayName.Trim();

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

                switch (action)
                {
                    case CommonConstants.ACT_VIEW:
                        for (int inner = 0; inner < chxPermission.Items.Count; ++inner)
                            chxPermission.Items[inner].Enabled = false;

                        break;
                    case CommonConstants.ACT_EDIT:
                        {
                            tblUser userAdmin = (tblUser)Session[CommonConstants.SES_USER];
                            if (userDAO.isAllow(userAdmin.Permission, CommonConstants.P_A_FULL_CONTROL)
                                || userDAO.isAllow(user.Permission, CommonConstants.P_N_GENERAL))
                            {
                                for (int inner = 0; inner < chxPermission.Items.Count; ++inner)
                                    chxPermission.Items[inner].Enabled = true;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            else if (user == null)
            {
                messagePanel.Visible = true;
                detailPanel.Visible = false;

                liMessage.Text = CommonConstants.MSG_RESOURCE_NOT_FOUND;
            }

            if (action == CommonConstants.ACT_EDIT)
            {
                tblUser userEdit = userDAO.getUser(id);
                Session[CommonConstants.SES_EDIT_USER] = userEdit;
            }
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
                                                                      CommonConstants.ACT_VIEW,
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
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[CommonConstants.REQ_ACTION] == CommonConstants.ACT_VIEW)
            {
                Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION
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

                    userDAO.updatePermission(userAdmin.Username, userEdit.Username, permits);

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

            Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session[CommonConstants.SES_EDIT_USER] = null;

            Response.Redirect(CommonConstants.PAGE_ADMIN_PERMISSION);
        }

        protected void chxPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chxPermission.Items[chxPermission.Items.Count - 1].Selected)
            {
                for (int idx = 0; idx < chxPermission.Items.Count; ++idx)
                    chxPermission.Items[idx].Selected = true;
            }
            else
            {
                if (!chxPermission.Items[1].Selected)
                {
                    chxPermission.Items[0].Selected = true;
                    for (int idx = 2; idx < chxPermission.Items.Count - 1; ++idx)
                        chxPermission.Items[idx].Selected = false;
                }

                for (int idx = 2; idx < chxPermission.Items.Count - 1; ++idx)
                    if (chxPermission.Items[idx].Selected)
                        chxPermission.Items[1].Selected = true;
            }

        }
    }
}