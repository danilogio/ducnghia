using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;
using System.IO;

namespace ltkt.Admin
{
    public partial class Advertisement : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Ads adsDAO = new ltktDAO.Ads();
        ltktDAO.Control control = new ltktDAO.Control();
        BaseServices bs = new BaseServices();
        ltktDAO.Users userDAO = new ltktDAO.Users();

        public const int NoOfAdsPerPage = 10;


        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_ADS)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    AdminMaster pageAdmin = (AdminMaster)Master;
                    pageAdmin.updateHeader(CommonConstants.PAGE_ADMIN_ADS_NAME);

                    liTitle.Text = CommonConstants.PAGE_ADMIN_ADS_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);


                    pageLoad(sender, e, user);

                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_GENERAL);
                }
            }
        }

        private void pageLoad(object sender, EventArgs e, tblUser user)
        {
            try
            {
                int page = 1;

                if (Request.QueryString[CommonConstants.REQ_PAGE] != null)
                {
                    viewPanel.Visible = true;
                    detailsPanel.Visible = false;
                    messagePanel.Visible = false;

                    page = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_PAGE]);
                    showAds(page);
                }
                else if (Request.QueryString[CommonConstants.REQ_ACTION] != null)
                {
                    string action = Request.QueryString[CommonConstants.REQ_ACTION];
                    int _id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                    if (action == CommonConstants.ACT_VIEW || action == CommonConstants.ACT_EDIT)
                    {
                        viewPanel.Visible = false;
                        detailsPanel.Visible = true;
                        messagePanel.Visible = false;

                        if (ddlState.Items.Count == 0)
                        {
                            ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_STICKY_NAME, CommonConstants.STATE_STICKY.ToString()));
                            ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_PENDING_NAME, CommonConstants.STATE_PENDING.ToString()));
                            ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
                            ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_UNCHECK_NAME, CommonConstants.STATE_UNCHECK.ToString()));
                        }

                        showAdsDetails(_id, action);
                    }
                    else if (action == CommonConstants.ACT_DELETE)
                    {
                        //tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                        //Boolean completeDelete = adsDAO.deleteAds(_id, user.Username);

                        //if (completeDelete)
                        //{
                        //Response.Write(CommonConstants.ALERT_DELETE_SUCCESSFUL);

                        //Response.Redirect(CommonConstants.PAGE_ADMIN_ADS
                        //                  + CommonConstants.ADD_PARAMETER
                        //                  + CommonConstants.REQ_PAGE
                        //                  + CommonConstants.EQUAL
                        //                  + "1");
                        //}
                        //else
                        //{
                        //    Response.Write(CommonConstants.ALERT_DELETE_FAIL);
                        //}

                        if (adsDAO.deleteAds(_id, user.Username))
                        {
                            Page_Load(sender, e);
                        }
                    }
                }
                else
                {
                    Response.Redirect(CommonConstants.PAGE_ADMIN_ADS
                                              + CommonConstants.ADD_PARAMETER
                                              + CommonConstants.REQ_PAGE
                                              + CommonConstants.EQUAL
                                              + "1");
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, user.Username, CommonConstants.MSG_LINK_ERROR);
                log.writeLog(DBHelper.strPathLogFile, user.Username, ex.Message + CommonConstants.NEWLINE + ex.StackTrace);
                //Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_LINK_ERROR;
                Response.Redirect(CommonConstants.PAGE_ADMIN_ADS
                                              + CommonConstants.ADD_PARAMETER
                                              + CommonConstants.REQ_PAGE
                                              + CommonConstants.EQUAL
                                              + "1");
            }
        }

        private void showAdsDetails(int _id, string _action)
        {
            tblAdvertisement Ads = adsDAO.getAds(_id);

            //if (Ads != null && Session[CommonConstants.SES_EDIT_ADS] == null)
            //{
            if (Ads != null)
            {
                txtCompany.Text = Ads.Company.Trim();
                txtAddress.Text = Ads.Address.Trim();
                txtEmail.Text = Ads.Email.Trim();
                txtPhone.Text = Ads.Phone.Trim();
                txtFromDate.Text = Ads.fromDate.ToString();
                txtEndDate.Text = Ads.toDate.ToString();
                txtPrice.Text = Ads.Price.ToString();
                txtDescription.Text = BaseServices.nullToBlank(Ads.Description).Trim();
                txtNavigateUrl.Text = BaseServices.nullToBlank(Ads.NavigateUrl).Trim();
                txtClickCount.Text = Ads.ClickCount.ToString();
                txtSizeImg.Text = BaseServices.nullToBlank(Ads.Size).Trim();
                txtLocation.Text = BaseServices.nullToBlank(Ads.Location).Trim();

                ddlState.SelectedIndex = Ads.State;

                string filename = Server.MapPath("~") + "\\" + Ads.FilePath.Trim();
                if (File.Exists(filename))
                {
                    liAds.Text = "<input type=\"button\" value=\"Xem\" class=\"formbutton\" onclick=\"DisplayFullImage('../../" + Ads.FilePath.Trim() + "')\" />";
                    //liAds.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải hình\" class=\"formbutton\" onclick=\"upload()\" />";
                }
                else
                {
                    liAds.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                    //liAds.Text += "&nbsp;<input type=\"button\" value=\"Tải hình\" class=\"formbutton\" onclick=\"upload()\" />";
                }
            }
            else
            {
                messagePanel.Visible = true;
                detailsPanel.Visible = false;

                liMessage.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
            }

            if (_action == CommonConstants.ACT_EDIT)
            {
                Session[CommonConstants.SES_EDIT_ADS] = Ads;

                txtCompany.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtPhone.ReadOnly = false;
                txtFromDate.ReadOnly = false;
                txtEndDate.ReadOnly = false;
                txtFromDate.CssClass = "calendar";
                txtEndDate.CssClass = "calendar";
                txtPrice.ReadOnly = false;
                txtDescription.ReadOnly = false;
                ddlState.Enabled = true;
                txtNavigateUrl.ReadOnly = false;
                txtSizeImg.ReadOnly = false;
                txtLocation.ReadOnly = false;

                liAds.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải hình\" class=\"formbutton\" onclick=\"upload()\" />";
            }
            else
            {
                Session[CommonConstants.SES_EDIT_ADS] = null;

                txtCompany.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtPhone.ReadOnly = true;
                txtFromDate.ReadOnly = true;
                txtEndDate.ReadOnly = true;
                txtFromDate.CssClass = "";
                txtEndDate.CssClass = "";
                txtPrice.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtNavigateUrl.ReadOnly = true;
                txtSizeImg.ReadOnly = true;
                txtClickCount.ReadOnly = true;
                txtLocation.ReadOnly = true;

                ddlState.Enabled = false;

                liAds.Text += "&nbsp;&nbsp;<input type=\"button\" disabled=\"disabled\" value=\"Tải hình\" class=\"formbutton\" onclick=\"upload()\" />";
            }
        }

        private void showAds(int page)
        {
            int totalAds = adsDAO.countAds();
            // Computing total pages
            int totalPages;
            int mod = totalAds % NoOfAdsPerPage;

            IEnumerable<tblAdvertisement> lst = adsDAO.fetchAdsList(((page - 1) * NoOfAdsPerPage), NoOfAdsPerPage);

            if (mod == 0)
            {
                totalPages = totalAds / NoOfAdsPerPage;
            }
            else
            {
                totalPages = ((totalAds - mod) / NoOfAdsPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblAdvertisement ads = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "10px";
                noCell.Text = Convert.ToString(idx + 1);

                TableCell companyCell = new TableCell();
                companyCell.CssClass = "table-cell";
                companyCell.Style["width"] = "200px";
                //companyCell.Text = String.Format(DisplayNewsLink, ads.ID, ads.Company);
                companyCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ADS,
                                                                     CommonConstants.ACT_VIEW,
                                                                     ads.ID.ToString(),
                                                                     ads.Company);

                TableCell expiredCell = new TableCell();
                expiredCell.CssClass = "table-cell";
                expiredCell.Style["width"] = "80px";
                expiredCell.Text = bs.convertDateToString((DateTime)ads.toDate);

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "40px";
                stateCell.Text = adsDAO.convertStateToString((int)ads.State);

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ADS,
                                                                     CommonConstants.ACT_EDIT,
                                                                     ads.ID.ToString(),
                                                                     CommonConstants.HTML_EDIT_ADMIN);

                actionCell.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ADS,
                                                                     CommonConstants.ACT_DELETE,
                                                                     ads.ID.ToString(),
                                                                     CommonConstants.HTML_DELETE_ADMIN);


                TableRow adsRow = new TableRow();
                adsRow.Cells.Add(noCell);
                adsRow.Cells.Add(companyCell);
                adsRow.Cells.Add(expiredCell);
                adsRow.Cells.Add(stateCell);
                adsRow.Cells.Add(actionCell);

                NewsTable.Rows.AddAt(2 + idx, adsRow);
            }

            // Creating links to previous and next pages
            if (totalPages > 1)
            {
                if (page > 1)
                {
                    PreviousPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SELF_LINK,
                                                                                CommonConstants.PAGE_ADMIN_ADS,
                                                                                (page - 1).ToString(),
                                                                                CommonConstants.TXT_PREVIOUS_PAGE);
                }
                if (page > 0 && page < totalPages)
                {
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SELF_LINK,
                                                                             CommonConstants.PAGE_ADMIN_ADS,
                                                                             (page + 1).ToString(),
                                                                             CommonConstants.TXT_NEXT_PAGE);
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[CommonConstants.REQ_ACTION] == CommonConstants.ACT_VIEW)
            {
                txtFromDate.CssClass = "calendar";
                txtEndDate.CssClass = "calendar";

                Response.Redirect(CommonConstants.PAGE_ADMIN_ADS
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
                if (Session[CommonConstants.SES_EDIT_ADS] != null)
                {
                    tblAdvertisement Ads = (tblAdvertisement)Session[CommonConstants.SES_EDIT_ADS];

                    string _company = txtCompany.Text;
                    string _address = txtAddress.Text;
                    string _email = txtEmail.Text;
                    string _phone = txtPhone.Text;
                    DateTime _fromDate = DateTime.Parse(txtFromDate.Text);
                    DateTime _toDate = DateTime.Parse(txtEndDate.Text);
                    int _price = Convert.ToInt32(txtPrice.Text);
                    string _description = txtDescription.Text;
                    string _navigateUrl = txtNavigateUrl.Text;
                    string _size = txtSizeImg.Text;

                    int _state = CommonConstants.STATE_UNCHECK;
                    switch (Convert.ToInt32(ddlState.SelectedValue))
                    {
                        case CommonConstants.STATE_UNCHECK:
                            _state = CommonConstants.STATE_UNCHECK;
                            break;
                        case CommonConstants.STATE_CHECKED:
                            _state = CommonConstants.STATE_CHECKED;
                            break;
                        case CommonConstants.STATE_PENDING:
                            _state = CommonConstants.STATE_PENDING;
                            break;
                        case CommonConstants.STATE_STICKY:
                            _state = CommonConstants.STATE_STICKY;
                            break;
                        default:
                            break;
                    }

                    string fileSave = Ads.FilePath.Trim();
                    if (fileAds.HasFile)
                    {
                        string folder = CommonConstants.FOLDER_IMG_ADS;
                        string rootFolder = Server.MapPath("~") + "\\" + folder + "\\";
                        string filename = rootFolder + fileAds.FileName;
                        fileSave = folder + "/" + fileAds.FileName;
                        // save file
                        if (!Directory.Exists(rootFolder))
                        {
                            Directory.CreateDirectory(rootFolder);
                        }

                        fileAds.SaveAs(filename);
                    }

                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    bool isOK = adsDAO.updateAds(Ads.ID, user.Username,
                                                 _company,
                                                 _address,
                                                 _email,
                                                 _phone,
                                                 _fromDate,
                                                 _toDate,
                                                 _price,
                                                 fileSave,
                                                 _description,
                                                 _navigateUrl,
                                                 _size,
                                                 _state);

                    if (isOK)
                    {
                        Response.Write(CommonConstants.ALERT_UPDATE_SUCCESSFUL);
                    }
                    else
                    {
                        Response.Write(CommonConstants.ALERT_UPDATE_FAIL);
                    }

                    Session[CommonConstants.SES_EDIT_ADS] = null;
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Response.Redirect(CommonConstants.PAGE_ADMIN_ADS +
                               CommonConstants.ADD_PARAMETER +
                               CommonConstants.REQ_PAGE + "=1");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session[CommonConstants.SES_EDIT_ADS] = null;

            detailsPanel.Visible = false;
            viewPanel.Visible = true;
            Response.Redirect(CommonConstants.PAGE_ADMIN_ADS +
                               CommonConstants.ADD_PARAMETER +
                               CommonConstants.REQ_PAGE + "=1");


        }
    }
}