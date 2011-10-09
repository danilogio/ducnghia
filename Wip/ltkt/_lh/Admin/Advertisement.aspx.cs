using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ltktDAO;
using System.IO;
using System.Windows.Forms;

namespace ltkt.Admin
{
    public partial class Advertisement : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Ads adsDAO = new ltktDAO.Ads();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.BaseServices bs = new ltktDAO.BaseServices();
        ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();

        public const int NoOfAdsPerPage = 12;


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

                    liTableHeader.Text = CommonConstants.PAGE_ADMIN_ADS_NAME;
                    string status = adminDAO.getReason(CommonConstants.AF_ADS);
                    if (!BaseServices.isNullOrBlank(status))
                    {
                        showStatusMessage(status);
                    }
                    //Check state ads before show
                    adsDAO.checkAds(user.Username);

                    hpkShowAll.Text += "(" + adsDAO.countAds()+ ")";
                    hpkShowBlock.Text += "(" + adsDAO.countAdsListByState(CommonConstants.STATE_BLOCK) + ")";
                    hpkShowChecked.Text += "(" + adsDAO.countAdsListByState(CommonConstants.STATE_CHECKED) + ")";
                    hpkShowPending.Text += "(" + adsDAO.countAdsListByState(CommonConstants.STATE_PENDING) + ")";
                    hpkShowSticky.Text += "(" + adsDAO.countAdsListByState(CommonConstants.STATE_STICKY) + ")";
                    hpkShowUncheck.Text += "(" + adsDAO.countAdsListByState(CommonConstants.STATE_UNCHECK) + ")";
                    hpkShowLoc.Text += "(" + adsDAO.countAdsListByLocation() + ")";

                    pageLoad(sender, e, user);

                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.PAGE_ADMIN_GENERAL);
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }

        private void pageLoad(object sender, EventArgs e, tblUser user)
        {
            bool isDeleted = false;
            try
            {
                int page = 1;
                string action = Request.QueryString[CommonConstants.REQ_ACTION];
                string sPage = Request.QueryString[CommonConstants.REQ_PAGE];
                if (BaseServices.isNullOrBlank(action))
                {
                    action = CommonConstants.ACT_SEARCH;
                }
                if (BaseServices.isNullOrBlank(sPage))
                {
                    sPage = CommonConstants.PAGE_NUMBER_FIRST;
                }

                page = Convert.ToInt32(sPage);

                //action is Search
                if (action == CommonConstants.ACT_SEARCH)
                {
                    viewPanel.Visible = true;
                    detailsPanel.Visible = false;
                    messagePanel.Visible = false;
                    IEnumerable<tblAdvertisement> lst = null;
                    //page = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_PAGE]);
                    string key = Request.QueryString[CommonConstants.REQ_KEY];
                    if (BaseServices.isNullOrBlank(key))
                    {
                        key = CommonConstants.ALL;
                    }
                    else
                    {
                        key = BaseServices.nullToBlank(key);
                    }
                    if (key == CommonConstants.ALL)
                    {
                       lst = adsDAO.fetchAdsList(((page - 1) * NoOfAdsPerPage), NoOfAdsPerPage);
                    }
                    else if (key == CommonConstants.STATE_UNCHECK.ToString() 
                        || key == CommonConstants.STATE_STICKY.ToString() 
                        || key == CommonConstants.STATE_PENDING.ToString()
                        || key == CommonConstants.STATE_BLOCK.ToString()
                        || key == CommonConstants.STATE_CHECKED.ToString())
                    {
                        lst = adsDAO.fetchAdsList(Convert.ToInt32(key), ((page - 1) * NoOfAdsPerPage), NoOfAdsPerPage);
                    }
                    else if (key == CommonConstants.PARAM_LOCATION)
                    {
                        lst = adsDAO.fetchAdsListByLocation(((page - 1) * NoOfAdsPerPage), NoOfAdsPerPage);
                    }

                    // show data
                    bool isOK = false;
                    if (lst != null)
                    {
                        if (lst.Count() > 0)
                        {
                            showAds(lst, page, action, key);
                            isOK = true;
                        }

                    }
                    if(!isOK)
                    {
                        showInfoMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                        NewsTable.Visible = false;
                        return;
                    }
                }
                //else if (Request.QueryString[CommonConstants.REQ_ACTION] != null)
                //{
                //string action = Request.QueryString[CommonConstants.REQ_ACTION];
                //

                else if (action == CommonConstants.ACT_VIEW || action == CommonConstants.ACT_EDIT)
                {
                    if (Request.QueryString[CommonConstants.REQ_ID] == null)
                    {
                        showErrorMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                        return;
                    }
                    if (!BaseServices.isNumeric(Request.QueryString[CommonConstants.REQ_ID]))
                    {
                        showErrorMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                        return;
                    }
                    int _id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                    viewPanel.Visible = false;
                    detailsPanel.Visible = true;
                    messagePanel.Visible = false;

                    if (ddlState.Items.Count == 0)
                    {
                        //ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_STICKY_NAME, CommonConstants.STATE_STICKY.ToString()));
                        //ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_PENDING_NAME, CommonConstants.STATE_PENDING.ToString()));
                        //ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
                        //ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_UNCHECK_NAME, CommonConstants.STATE_UNCHECK.ToString()));

                        showAdsDetails(_id, action);
                    }
                    if (action == CommonConstants.ACT_VIEW)
                    {
                        btnEdit.Visible = false;
                    }


                    //showAdsDetails(_id, action);
                }
                else if (action == CommonConstants.ACT_DELETE)
                {
                    if (Request.QueryString[CommonConstants.REQ_ID] == null)
                    {
                        showErrorMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                        return;
                    }
                    if (!BaseServices.isNumeric(Request.QueryString[CommonConstants.REQ_ID]))
                    {
                        showErrorMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                        return;
                    }
                    int _id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
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
                    bool isMatch = adsDAO.isState(_id, CommonConstants.STATE_UNCHECK);
                    if (adsDAO.deleteAds(_id, user.Username))
                    {
                        if (isMatch)
                        {
                            ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                            statDAO.add(CommonConstants.SF_NUM_NEW_ADV_CONTACT, CommonConstants.CONST_ONE_NEGATIVE);
                        }
                        string mess = BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_SUCCESSFUL, CommonConstants.ACT_DELETE);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mess + "');", true);
                        //MessageBox.Show(mess);
                        //Response.End();
                        ltktDAO.Alert.Show(mess);
                        isDeleted = true;
                        //showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_SUCCESSFUL, CommonConstants.ACT_DELETE));
                        
                    }
                }
                //}
                //else
                //{
                //   Response.Redirect(CommonConstants.PAGE_ADMIN_ADS
                //                              + CommonConstants.ADD_PARAMETER
                //                              + CommonConstants.REQ_PAGE
                //                              + CommonConstants.EQUAL
                //                              + "1");
                //}
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, user.Username, CommonConstants.MSG_E_LINK_INVALID);
                log.writeLog(DBHelper.strPathLogFile, user.Username, ex.Message
                                                        + CommonConstants.NEWLINE
                                                        + ex.Source
                                                        + CommonConstants.NEWLINE
                                                        + ex.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + ex.HelpLink);
                //Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_LINK_ERROR;
                Response.Redirect(CommonConstants.PAGE_ADMIN_ADS
                                              + CommonConstants.ADD_PARAMETER
                                              + CommonConstants.REQ_PAGE
                                              + CommonConstants.EQUAL
                                              + "1");
            }
            if (isDeleted)
            {
                Response.Redirect(CommonConstants.PAGE_ADMIN_ADS);
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

                if (Ads.State == CommonConstants.STATE_UNCHECK)
                {
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_UNCHECK_NAME, CommonConstants.STATE_UNCHECK.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_STICKY_NAME, CommonConstants.STATE_STICKY.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
                }
                else if (Ads.State == CommonConstants.STATE_CHECKED)
                {
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_BLOCK_NAME, CommonConstants.STATE_BLOCK.ToString()));
                }
                else if (Ads.State == CommonConstants.STATE_BLOCK)
                {
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_BLOCK_NAME, CommonConstants.STATE_BLOCK.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_UNCHECK_NAME, CommonConstants.STATE_UNCHECK.ToString()));
                }
                else if (Ads.State == CommonConstants.STATE_STICKY)
                {
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_STICKY_NAME, CommonConstants.STATE_STICKY.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
                }
                else if (Ads.State == CommonConstants.STATE_PENDING)
                {
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_PENDING_NAME, CommonConstants.STATE_PENDING.ToString()));
                    ddlState.Items.Insert(0, new ListItem(CommonConstants.STATE_BLOCK_NAME, CommonConstants.STATE_BLOCK.ToString()));
                }
                ddlState.SelectedValue = Ads.State.ToString();

                ArrayList lst = adsDAO.getFreeLocationList();
                //Adv is pending or checked or block
                if (Ads.State != CommonConstants.STATE_STICKY && Ads.State != CommonConstants.STATE_UNCHECK && Ads.State != CommonConstants.STATE_BLOCK)
                {
                    if (!BaseServices.isNullOrBlank(Ads.Code))
                    {
                        lst.Add(Ads.Code.Trim());
                    }
                }
                else
                {
                    lst.Add(CommonConstants.CONST_ONE_NEGATIVE);
                }

                //Add items for combobox
                for (int i = lst.Count - 1; i >= 0; i--)
                {
                    ddlLocation.Items.Insert(0, new ListItem(adsDAO.getNameOfLocation(lst[i].ToString()), lst[i].ToString()));
                }

                //set default selected value for Location
                if (Ads.State != CommonConstants.STATE_STICKY && Ads.State != CommonConstants.STATE_UNCHECK && Ads.State != CommonConstants.STATE_BLOCK)
                {
                    if (!BaseServices.isNullOrBlank(Ads.Code))
                    {
                        ddlLocation.SelectedValue = Ads.Code.Trim();
                    }
                }
                else
                {
                    ddlLocation.SelectedValue = CommonConstants.CONST_ONE_NEGATIVE;
                }
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
                detailsPanel.Visible = false;

                showInfoMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
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
                ddlLocation.Enabled = true;
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
                ddlLocation.Enabled = false;
                ddlState.Enabled = false;

                liAds.Text += "&nbsp;&nbsp;<input type=\"button\" disabled=\"disabled\" value=\"Tải hình\" class=\"formbutton\" onclick=\"upload()\" />";
            }
        }

        private void showAds(IEnumerable<tblAdvertisement> lst, int page, string action, string key)
        {
            int totalAds = adsDAO.countAds();
            // Computing total pages
            int totalPages;
            int mod = totalAds % NoOfAdsPerPage;

            //IEnumerable<tblAdvertisement> lst = adsDAO.fetchAdsList(((page - 1) * NoOfAdsPerPage), NoOfAdsPerPage);

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
                noCell.Text = Convert.ToString(idx + 1 + (page-1) * NoOfAdsPerPage);

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
                string param = CommonConstants.REQ_ACTION 
                                + CommonConstants.EQUAL 
                                + action
                                + CommonConstants.AND
                                + CommonConstants.REQ_KEY
                                + CommonConstants.EQUAL 
                                + key
                                + CommonConstants.AND
                                + CommonConstants.REQ_PAGE
                                + CommonConstants.EQUAL;

                if (page > 1)
                {
                    
                    PreviousPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_PAGING_LINK,
                                                                                CommonConstants.PAGE_ADMIN_ADS,
                                                                                param + (page - 1).ToString(),
                                                                                CommonConstants.TXT_PREVIOUS_PAGE);
                }
                if (page > 0 && page < totalPages)
                {
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_PAGING_LINK,
                                                                             CommonConstants.PAGE_ADMIN_ADS,
                                                                             param + (page + 1).ToString(),
                                                                             CommonConstants.TXT_NEXT_PAGE);
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //if (Request.QueryString[CommonConstants.REQ_ACTION] == CommonConstants.ACT_VIEW)
            //{
            //    txtFromDate.CssClass = "calendar";
            //    txtEndDate.CssClass = "calendar";

            //    Response.Redirect(CommonConstants.PAGE_ADMIN_ADS
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
                tblAdvertisement Ads = (tblAdvertisement)Session[CommonConstants.SES_EDIT_ADS];

                string _company = txtCompany.Text;
                string _address = txtAddress.Text;
                string _email = txtEmail.Text;
                string _phone = txtPhone.Text;

                DateTime _fromDate = DateTime.Parse(txtFromDate.Text);
                DateTime _toDate = DateTime.Parse(txtEndDate.Text);
                if (_toDate.CompareTo(_fromDate) == -1)
                {
                    showErrorMessage(CommonConstants.MSG_E_INVALID_TO_DATE);
                    return;
                }
                int _price = Convert.ToInt32(txtPrice.Text);
                string _description = txtDescription.Text;
                string _navigateUrl = txtNavigateUrl.Text;
                string _size = txtSizeImg.Text;
                string _location = txtLocation.Text;
                bool _fileGood = false;
                string rootFolder = CommonConstants.BLANK;
                string filename = CommonConstants.BLANK;

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
                    case CommonConstants.STATE_BLOCK:
                        {
                            _state = CommonConstants.STATE_BLOCK;
                            break;
                        }
                    default:
                        break;
                }
                //if change state to CHECKED
                if (_state == CommonConstants.STATE_CHECKED)
                {
                    if (_fromDate.CompareTo(DateTime.Today) == -1)
                    {
                        showErrorMessage(CommonConstants.MSG_E_INVALID_FROM_DATE);
                        return;
                    }
                    
                }
                string fileSave = Ads.FilePath.Trim();
                if (fileAds.HasFile)
                {
                    string folder = CommonConstants.FOLDER_IMG_ADS;
                    rootFolder = Server.MapPath("~") + "\\" + folder + "\\";

                    //check file existed: keep both
                    string newFileName = bs.fileNameToSave(fileAds.FileName);
                    filename = rootFolder + newFileName;

                    //check filetype
                    string fileTypes = control.getValueString(CommonConstants.CF_IMG_FILE_TYPE_ALLOW);
                    if (!bs.checkFileType(fileAds.FileName, fileTypes))
                    {
                        showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_NOT_ALLOW);
                        return;
                    }
                    //check filesize max
                    int fileSizeMax = control.getValueByInt(CommonConstants.CF_IMG_FILE_SIZE_MAX);
                    fileSizeMax = 1024 * fileSizeMax;
                    if (fileAds.PostedFile.ContentLength > fileSizeMax)
                    {
                        showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_TOO_LARGE);
                        return;
                    }
                    fileSave = folder + "/" + newFileName;
                    _fileGood = true;

                }

                string _code = ddlLocation.SelectedValue;
                string _oldCode = Ads.Code;

                if (_state != CommonConstants.STATE_UNCHECK && _state != CommonConstants.STATE_STICKY && _state != CommonConstants.STATE_BLOCK)
                {
                    if (_code == CommonConstants.CONST_ONE_NEGATIVE)
                    {
                        showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_SELECT_ONE_ITEM, CommonConstants.TXT_ADS_LOCATION));
                        return;
                    }
                    if (BaseServices.isNullOrBlank(_navigateUrl))
                    {
                        showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, CommonConstants.TXT_ADS_NAVIGATE_URL));
                        return;
                    }
                    if (BaseServices.isNullOrBlank(fileSave))
                    {
                        showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, CommonConstants.TXT_ADS_IMAGE_URL));
                        return;
                    }
                    if (BaseServices.isNullOrBlank(_size))
                    {
                        showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, CommonConstants.TXT_ADS_IMAGE_SIZE));
                        return;
                    }
                    else
                    {
                        if (!BaseServices.checkSizePattern(_size, CommonConstants.X))
                        {
                            showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_RIGHT_FORMAT,
                                                                            CommonConstants.TXT_ADS_IMAGE_SIZE,
                                                                            CommonConstants.DEFAULT_SIZE_FORMAT));
                            return;
                        }
                    }

                    //if state is pending: keep location
                    if (_state == CommonConstants.STATE_PENDING)
                    {
                        _code = Ads.Code;
                    }
                }
                else//state is uncheck or sticky or blocked
                {
                    _code = CommonConstants.ADS_INACTIVE;
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
                                             _location,
                                             _size,
                                             _state,
                                             _code);


                if (isOK)
                {
                    if (_fileGood)
                    {
                        // save file
                        if (!Directory.Exists(rootFolder))
                        {
                            Directory.CreateDirectory(rootFolder);
                        }
                        fileAds.SaveAs(filename);
                    }
                    // update statistic
                    ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                    if (_state == CommonConstants.STATE_UNCHECK)
                    {
                        statDAO.add(CommonConstants.SF_NUM_NEW_ADV_CONTACT, CommonConstants.CONST_ONE);
                    }
                    else if (_state == CommonConstants.STATE_CHECKED)
                    {
                        statDAO.add(CommonConstants.SF_NUM_NEW_ADV_CONTACT, CommonConstants.CONST_ONE_NEGATIVE);
                    }
                    Response.Write(CommonConstants.ALERT_UPDATE_SUCCESSFUL);
                }
                else
                {
                    Response.Write(CommonConstants.ALERT_UPDATE_FAIL);
                }

                Session[CommonConstants.SES_EDIT_ADS] = null;

            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.Source
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.StackTrace
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.HelpLink);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Response.Redirect(CommonConstants.PAGE_ADMIN_ADS);
        }
        protected void btnClone_Click(object sender, EventArgs e)
        {
            bool isOK = false;
            int id = -1;
            try
            {
                string _comName = txtCompany.Text;
                string _address = txtAddress.Text;
                string _email = txtEmail.Text;
                string _phone = txtPhone.Text;
                string _description = txtDescription.Text;
                string _navigateUrl = txtNavigateUrl.Text;
                DateTime _fromDate = DateTime.Parse(txtFromDate.Text);
                DateTime _toDate = DateTime.Parse(txtEndDate.Text);
                string _location = txtLocation.Text;
                if (_toDate.CompareTo(_fromDate) == -1)
                {
                    showErrorMessage(CommonConstants.MSG_E_INVALID_TO_DATE);
                    return;
                }
                  id = adsDAO.cloneAds(_comName,
                                        _address,
                                        _email,
                                        _phone,
                                        _fromDate,
                                        _toDate,
                                        _location,
                                        _navigateUrl,
                                        _description);
                if (id > 0)
                {
                    ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                    statDAO.add(CommonConstants.SF_NUM_NEW_ADV_CONTACT, CommonConstants.CONST_ONE);
                    isOK = true;
                }
                else
                {
                    showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_ACTION_FAILED, CommonConstants.ACT_CLONE));
                    return;
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.Source
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.StackTrace
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.HelpLink);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Session[CommonConstants.SES_USER] = null;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            if (isOK)
            {
                string url = CommonConstants.PAGE_ADMIN_ADS
                                        + CommonConstants.ADD_PARAMETER
                                        + CommonConstants.REQ_ACTION
                                        + CommonConstants.EQUAL
                                        + CommonConstants.ACT_EDIT
                                        + CommonConstants.AND
                                        + CommonConstants.REQ_ID
                                        + CommonConstants.EQUAL
                                        + id.ToString();
                ltktDAO.Alert.Show(BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_SUCCESSFUL, CommonConstants.ACT_CLONE));
                
                Response.Redirect(url);
            }

        }
        /// <summary>
        /// use to show message information on mode SEARCH, DELETE
        /// </summary>
        /// <param name="errorText"></param>
        private void showInfoMessage(string infoText)
        {
            liMessage.Text = infoText;
            messagePanel.Visible = true;
        }
        /// <summary>
        /// use to show message error on mode EDIT, VIEW
        /// </summary>
        /// <param name="errorText"></param>
        private void showErrorMessage(string errorText)
        {
            liErrorMessage.Text = errorText;
            ErrorMessagePanel.Visible = true;
        }
        private void showStatusMessage(string message)
        {
            liStatusMessage.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MARQUEE_TAG,
                                                                    CommonConstants.CS_ANNOUCEMENT_BGCOLOR,
                                                                    CommonConstants.CS_ANNOUCEMENT_TEXTCOLOR,
                                                                   CommonConstants.TXT_INFORM + CommonConstants.SPACE + message);
           // liStatusMessage.Text += CommonConstants.BAR;
            //liStatusMessage.Text += message;
            statusMessagePanel.Visible = true;
        }
    }
}