using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
using System.Collections;
using System.IO;

namespace ltkt.Admin
{
    public partial class English : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        private ltktDAO.Control control = new ltktDAO.Control();
        private ltktDAO.BaseServices bs = new ltktDAO.BaseServices();
        private ltktDAO.English englishDAO = new ltktDAO.English();
        private ltktDAO.Statistics statDAO = new ltktDAO.Statistics();

        EventLog log = new EventLog();

        private const int NoOfEnglishPerPage = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_ENGLISH)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader(CommonConstants.PAGE_ADMIN_ENGLISH_NAME);

                    liTitle.Text = CommonConstants.PAGE_ADMIN_ENGLISH_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

                    liTableHeader.Text = CommonConstants.TXT_LIST_ARTICLE;
                    int numDeletedFile = englishDAO.countDeletedArticles();
                    if (numDeletedFile > 0)
                    {
                        btnClear.Text = CommonConstants.TXT_CLEAR_DATA;
                        btnClear.Text += CommonConstants.SPACE;
                        btnClear.Text += "(" + numDeletedFile + ")";
                        btnClear.Visible = true;
                    }
                    else
                    {
                        btnClear.Visible = false;
                    }
                    pageLoad(sender, e, user);
                    string inform = (string)Session[CommonConstants.SES_INFORM];
                    if (!BaseServices.isNullOrBlank(inform))
                    {
                        showErrorMessage(inform);
                        Session[CommonConstants.SES_INFORM] = null;
                    }
                    
                    //////////////////////////////////////////////////
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
            bool isEditError = false;
            bool isDeletedSuccessful = false;
            bool isSearchFreeNOK = false;
            tblUser savedUser = null;
            try
            {
                int page = 1;
                string action = Request.QueryString[CommonConstants.REQ_ACTION];
                string sPage = Request.QueryString[CommonConstants.REQ_PAGE];
                string state = Request.QueryString[CommonConstants.REQ_STATE];
                if (BaseServices.isNullOrBlank(action))
                {
                    action = CommonConstants.ACT_SEARCH;
                }
                if (BaseServices.isNullOrBlank(sPage))
                {
                    sPage = CommonConstants.PAGE_NUMBER_FIRST;
                }
                if (BaseServices.isNullOrBlank(state))
                {
                    state = CommonConstants.ALL;
                }
                page = Convert.ToInt32(sPage);
                 //action is Search
                if (action == CommonConstants.ACT_SEARCH)
                {
                    if (Page.IsPostBack)
                    {
                        return;
                    }
                    viewPanel.Visible = true;
                    detailPanel.Visible = false;
                    messagePanel.Visible = false;
                    IEnumerable<tblEnglish> lst = null;
                    string key = Request.QueryString[CommonConstants.REQ_KEY];
                    int totalRecord = 0;

                    showCountingArticle();
                    
                    if (BaseServices.isNullOrBlank(key))
                    {
                        key = CommonConstants.ALL;
                    }
                    else
                    {
                        key = BaseServices.nullToBlank(key);
                    }
                    key = key.ToLower();
                    changeViewState(key);
                    if (key == CommonConstants.ALL)
                    {
                        if (state == CommonConstants.ALL)// key = ALL and state = ALL
                        {
                            lst = englishDAO.fetchEnglishList(((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.count();
                            hpkShowAllState.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowAllState.Text+ "(" + totalRecord + ")");
                            hpkShowBad.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_BAD) + ")";
                            hpkShowChecked.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_CHECKED) + ")";
                            hpkShowUncheck.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_UNCHECK) + ")";
                            statDAO.setValue(CommonConstants.SF_NUM_ARTICLE_ON_EL, totalRecord.ToString());
                        }
                        else if (state == CommonConstants.STATE_UNCHECK.ToString())// key = ALL and state = UNCHECk
                        {
                            lst = englishDAO.fetchEnglishList(CommonConstants.STATE_UNCHECK, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countEnglishList(CommonConstants.STATE_UNCHECK);
                            hpkShowAllState.Text += "(" + englishDAO.count() +")";
                            hpkShowUncheck.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowUncheck.Text + "(" + totalRecord + ")");
                            hpkShowChecked.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_CHECKED) + ")";
                            hpkShowBad.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_BAD) + ")";
                        }
                        else if (state == CommonConstants.STATE_CHECKED.ToString())// key = ALL and state = CHECKED
                        {
                            lst = englishDAO.fetchEnglishList(CommonConstants.STATE_CHECKED, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countEnglishList(CommonConstants.STATE_CHECKED);
                            hpkShowAllState.Text += "(" + englishDAO.count() + ")";
                            hpkShowBad.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_BAD) + ")";
                            hpkShowChecked.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowChecked.Text + "(" + totalRecord + ")");
                            hpkShowUncheck.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_UNCHECK) + ")";

                        }
                        else if (state == CommonConstants.STATE_BAD.ToString())// key = ALL and state = BAD
                        {
                            lst = englishDAO.fetchEnglishList(CommonConstants.STATE_BAD, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countEnglishList(CommonConstants.STATE_BAD);
                            hpkShowAllState.Text += "(" + englishDAO.count() + ")";
                            hpkShowUncheck.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_UNCHECK) + ")";
                            hpkShowChecked.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_CHECKED) + ")";
                            hpkShowBad.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowBad.Text + "(" + totalRecord + ")");

                        }
                    }
                    else if (key == CommonConstants.TXT_STICKY.ToLower())
                    {
                        //change state link
                        changeStateLink(key);
                        if (state == CommonConstants.ALL)// key == sticky and state = ALL
                        {
                            lst = englishDAO.fetchStickyEnglishList(((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countStickyArticle();
                            hpkShowAllState.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowAllState.Text + "(" + totalRecord + ")");
                            hpkShowBad.Text += "(" + englishDAO.countStickyEnglishList(CommonConstants.STATE_BAD) + ")";
                            hpkShowChecked.Text += "(" + englishDAO.countStickyEnglishList(CommonConstants.STATE_CHECKED) + ")";
                            hpkShowUncheck.Text += "(" + englishDAO.countStickyEnglishList(CommonConstants.STATE_UNCHECK) + ")";

                        }
                        else if (state == CommonConstants.STATE_UNCHECK.ToString())// key == sticky and state = UNCHECk
                        {
                            lst = englishDAO.fetchStickyEnglishList(CommonConstants.STATE_UNCHECK, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countStickyEnglishList(CommonConstants.STATE_UNCHECK);
                            hpkShowAllState.Text += "(" + englishDAO.countStickyArticle() + ")";
                            hpkShowUncheck.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowUncheck.Text + "(" + totalRecord + ")");
                            hpkShowChecked.Text += "(" + englishDAO.countStickyEnglishList(CommonConstants.STATE_CHECKED) + ")";
                            hpkShowBad.Text += "(" + englishDAO.countStickyEnglishList(CommonConstants.STATE_BAD) + ")";
                        }
                        else if (state == CommonConstants.STATE_CHECKED.ToString())// key = sticky and state = CHECKED
                        {
                            lst = englishDAO.fetchStickyEnglishList(CommonConstants.STATE_CHECKED, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countStickyEnglishList(CommonConstants.STATE_CHECKED);
                            hpkShowAllState.Text += "(" + englishDAO.countStickyArticle() + ")";
                            hpkShowBad.Text += "(" + englishDAO.countStickyEnglishList( CommonConstants.STATE_BAD) + ")";
                            hpkShowChecked.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowChecked.Text + "(" + totalRecord + ")");
                            hpkShowUncheck.Text += "(" + englishDAO.countStickyEnglishList( CommonConstants.STATE_UNCHECK) + ")";

                        }
                        else if (state == CommonConstants.STATE_BAD.ToString())// key = sticky and state = BAD
                        {
                            lst = englishDAO.fetchStickyEnglishList(CommonConstants.STATE_BAD, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countStickyEnglishList(CommonConstants.STATE_BAD);
                            hpkShowAllState.Text += "(" + englishDAO.countStickyArticle() + ")";
                            hpkShowUncheck.Text += "(" + englishDAO.countStickyEnglishList(CommonConstants.STATE_UNCHECK) + ")";
                            hpkShowChecked.Text += "(" + englishDAO.countStickyEnglishList(CommonConstants.STATE_CHECKED) + ")";
                            hpkShowBad.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowBad.Text + "(" + totalRecord + ")");

                        }
                    }
                    else
                    {
                        //change state link
                        changeStateLink(key);

                        if (state == CommonConstants.ALL)// key != ALL and state = ALL
                        {
                            lst = englishDAO.fetchEnglishListWithClass(key, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countEnglishListWithClass(key);
                            hpkShowAllState.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowAllState.Text + "(" + totalRecord + ")");
                            hpkShowBad.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_BAD) + ")";
                            hpkShowChecked.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_CHECKED) + ")";
                            hpkShowUncheck.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_UNCHECK) + ")";

                        }
                        else if (state == CommonConstants.STATE_UNCHECK.ToString())// key = ALL and state = UNCHECk
                        {
                            lst = englishDAO.fetchEnglishList(key, CommonConstants.STATE_UNCHECK, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countEnglishList(key, CommonConstants.STATE_UNCHECK);
                            hpkShowAllState.Text += "(" + englishDAO.countEnglishListWithClass(key) + ")";
                            hpkShowUncheck.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowUncheck.Text + "(" + totalRecord + ")");
                            hpkShowChecked.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_CHECKED) + ")";
                            hpkShowBad.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_BAD) + ")";
                        }
                        else if (state == CommonConstants.STATE_CHECKED.ToString())// key = ALL and state = CHECKED
                        {
                            lst = englishDAO.fetchEnglishList(key, CommonConstants.STATE_CHECKED, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countEnglishList(key, CommonConstants.STATE_CHECKED);
                            hpkShowAllState.Text += "(" + englishDAO.countEnglishListWithClass(key) + ")";
                            hpkShowBad.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_BAD) + ")";
                            hpkShowChecked.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowChecked.Text + "(" + totalRecord + ")");
                            hpkShowUncheck.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_UNCHECK) + ")";

                        }
                        else if (state == CommonConstants.STATE_BAD.ToString())// key = ALL and state = BAD
                        {
                            lst = englishDAO.fetchEnglishList(key, CommonConstants.STATE_BAD, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                            totalRecord = englishDAO.countEnglishList(key, CommonConstants.STATE_BAD);
                            hpkShowAllState.Text += "(" + englishDAO.countEnglishListWithClass(key) + ")";
                            hpkShowUncheck.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_UNCHECK) + ")";
                            hpkShowChecked.Text += "(" + englishDAO.countEnglishList(key, CommonConstants.STATE_CHECKED) + ")";
                            hpkShowBad.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowBad.Text + "(" + totalRecord + ")");

                        }
                    }
                    // show data
                    bool isOK = false;
                    if (lst != null)
                    {
                        if (lst.Count() > 0)
                        {
                            showEnglishs(lst, totalRecord, page, action, key, state);
                            isOK = true;
                        }

                    }
                    if (!isOK)
                    {
                        showInfoMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                        EnglishTable.Visible = false;
                        return;
                    }
                }
                else if (action == CommonConstants.ACT_SEARCH_FREE)
                {
                    if (Page.IsPostBack)
                    {
                        return;
                    }

                    showCountingArticle();
                    showCountingState();

                    string keyword = Request.QueryString[CommonConstants.REQ_KEY];
                    if (!BaseServices.isNullOrBlank(keyword))
                    {
                        int totalRecord = englishDAO.countArticles(keyword);
                        IEnumerable<tblEnglish> lst = englishDAO.searchArticles(keyword, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                        showEnglishs(lst, totalRecord, page, CommonConstants.ACT_SEARCH_FREE, keyword, CommonConstants.ALL);
                        txtKeyword.Text = keyword;
                    }
                    else
                    {
                        isSearchFreeNOK = true;
                    }
                }
                else if (action == CommonConstants.ACT_VIEW || action == CommonConstants.ACT_EDIT)
                {
                    if (Page.IsPostBack)
                    {
                        return;
                    }
                    Session[CommonConstants.SES_OLD_PAGE] = Request.UrlReferrer.ToString();
                    detailPanel.Visible = true;
                    viewPanel.Visible = false;
                    if (Request.QueryString[CommonConstants.REQ_ID] != null)
                    {
                        int id = BaseServices.convertStringToInt(Request.QueryString[CommonConstants.REQ_ID].ToString());
                        Session[CommonConstants.SES_ID] = id;
                        tblEnglish article = englishDAO.getArticle(id);
                        if (article != null)
                        {
                            initial();

                            txtTitle.Text = BaseServices.nullToBlank(article.Title);
                            txtChapeau.Text = BaseServices.nullToBlank(article.Contents);
                            txtAuthor.Text = BaseServices.nullToBlank(article.Author);
                            txtPosted.Text = BaseServices.formatDateTimeString(article.Posted);
                            txtTag.Text = BaseServices.nullToBlank(article.Tag);
                            txtPoint.Text = article.Point.ToString();
                            txtChecker.Text = BaseServices.nullToBlank(article.Checker);
                            txtHtmlEmbbed.Text = BaseServices.nullToBlank(article.HtmlPreview);
                            txtHtmlPreviewLink.Text = BaseServices.nullToBlank(article.HtmlEmbedLink);
                            txtLocation.Text = BaseServices.nullToBlank(article.Location);
                            txtChecker.Text = BaseServices.nullToBlank(article.Checker);
                            txtThumbnail.Text = BaseServices.nullToBlank(article.Thumbnail);
                            txtComment.Text = BaseServices.nullToBlank(article.Comment);
                            txtFolderId.Text = BaseServices.nullToBlank(article.FolderID);
                            showFileContent(article.Location);
                            showThumbnail(article.Thumbnail);
                            ddlState.SelectedValue = article.State.ToString();
                            if (article.StickyFlg)
                            {
                                ddlSticky.SelectedValue = CommonConstants.CONST_ONE;
                            }
                            ddlType.SelectedValue = article.Type.ToString();
                            ddlClass.SelectedValue = article.Class.ToString();
                            ddlScore.SelectedValue = article.Score.ToString();

                            if (action == CommonConstants.ACT_VIEW)
                            {
                                btnEdit.Visible = false;
                                changeState(false);
                                liContent.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải tập tin nội dung\" class=\"formbutton\" onclick=\"uploadContent()\" />";
                                liThumbnail.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải hình thu nhỏ\" class=\"formbutton\" onclick=\"uploadThumbnail()\" />";
                            }
                            else
                            {
                                changeState(true);
                                liContent.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải tập tin nội dung\" class=\"formbutton\" onclick=\"uploadContent()\" />";
                                liThumbnail.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải hình thu nhỏ\" class=\"formbutton\" onclick=\"uploadThumbnail()\" />";
                            }
                        }
                        else
                        {
                            isEditError = true;
                        }

                    }
                    else
                    {
                        isEditError = true;
                    }


                }
                else if (action == CommonConstants.ACT_DELETE)
                {
                    if (Request.QueryString[CommonConstants.REQ_ID] != null)
                    {
                        savedUser = (tblUser)Session[CommonConstants.SES_USER];
                        int id = BaseServices.convertStringToInt((string)Request.QueryString[CommonConstants.REQ_ID]); 

                        isDeletedSuccessful = englishDAO.setDeleteFlagArticle(id);

                        isDeleted = true;
                    }
                }
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

                Response.Redirect(CommonConstants.PAGE_ADMIN_INFORMATICS
                                              + CommonConstants.ADD_PARAMETER
                                              + CommonConstants.REQ_PAGE
                                              + CommonConstants.EQUAL
                                              + CommonConstants.PAGE_NUMBER_FIRST);
            }
            if (isDeleted)
            {
                
                if (isDeletedSuccessful)
                {
                    Session[CommonConstants.SES_INFORM] = BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_SUCCESSFUL, CommonConstants.ACT_DELETE);
                    statDAO.add(CommonConstants.SF_NUM_ARTICLE_ON_EL, CommonConstants.CONST_ONE_NEGATIVE);
                    Session[CommonConstants.SES_USER] = savedUser;
                }
                else
                {
                    Session[CommonConstants.SES_INFORM] = BaseServices.createMsgByTemplate(CommonConstants.MSG_E_ACTION_FAILED, CommonConstants.ACT_DELETE);
                }
                //Response.Redirect(Request.UrlReferrer.ToString());
                Response.Redirect(CommonConstants.PAGE_ADMIN_ENGLISH);
            }
            if (isSearchFreeNOK)
            {
                Session[CommonConstants.SES_INFORM] = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                Response.Redirect(CommonConstants.PAGE_ADMIN_ENGLISH);
            }
            if (isEditError)
            {
                detailPanel.Visible = false;
                viewPanel.Visible = false;
                showErrorMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                
            }
        }
        private void showEnglishs(IEnumerable<tblEnglish> lst, int totalEnglish, int page, string action, string key, string state)
        {
            // Computing total pages
            int totalPages;
            int mod = totalEnglish % NoOfEnglishPerPage;

            if (mod == 0)
            {
                totalPages = totalEnglish / NoOfEnglishPerPage;
            }
            else
            {
                totalPages = ((totalEnglish - mod) / NoOfEnglishPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblEnglish english = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "10px";
                noCell.Text = Convert.ToString(idx + 1 + (page - 1) * NoOfEnglishPerPage);

                TableCell titleCell = new TableCell();
                titleCell.CssClass = "table-cell";
                titleCell.Style["width"] = "200px";
                titleCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                  CommonConstants.PAGE_ADMIN_ENGLISH,
                                                                  CommonConstants.ACT_VIEW,
                                                                  Convert.ToString(english.ID),
                                                                  english.Title);

                TableCell postedCell = new TableCell();
                postedCell.CssClass = "table-cell";
                postedCell.Style["width"] = "80px";
                postedCell.Text = bs.convertDateToString(english.Posted);

                TableCell classCell = new TableCell();
                classCell.CssClass = "table-cell";
                classCell.Style["width"] = "80px";
                classCell.Text = englishDAO.getClassName(english.Class);

                TableCell authorCell = new TableCell();
                authorCell.CssClass = "table-cell";
                authorCell.Style["width"] = "60px";
                authorCell.Text = english.Author;

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "40px";
                stateCell.Text = englishDAO.getState(english.ID);


                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ENGLISH,
                                                                     CommonConstants.ACT_EDIT,
                                                                     Convert.ToString(english.ID),
                                                                     CommonConstants.HTML_EDIT_ADMIN);

                actionCell.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ENGLISH,
                                                                     CommonConstants.ACT_DELETE,
                                                                     Convert.ToString(english.ID),
                                                                     CommonConstants.HTML_DELETE_ADMIN);


                TableRow englishRow = new TableRow();
                englishRow.Cells.Add(noCell);
                englishRow.Cells.Add(titleCell);
                englishRow.Cells.Add(postedCell);
                englishRow.Cells.Add(classCell);
                englishRow.Cells.Add(authorCell);
                englishRow.Cells.Add(stateCell);
                englishRow.Cells.Add(actionCell);

                EnglishTable.Rows.AddAt(2 + idx, englishRow);
                string totatRecord = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, totalEnglish.ToString());
                NumRecordLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.MSG_I_NUM_SEARCHED_RECORD, totatRecord);
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
                                + key;
                if (!BaseServices.isNullOrBlank(state))
                {
                    param += CommonConstants.AND
                               + CommonConstants.REQ_STATE
                               + CommonConstants.EQUAL
                               + state;
                }
                param += CommonConstants.AND
                       + CommonConstants.REQ_PAGE
                       + CommonConstants.EQUAL;

                if (page > 1)
                {

                    PreviousPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_PAGING_LINK,
                                                                                CommonConstants.PAGE_ADMIN_ENGLISH,
                                                                                param + (page - 1).ToString(),
                                                                                CommonConstants.TXT_PREVIOUS_PAGE);
                }
                if (page > 0 && page < totalPages)
                {
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_PAGING_LINK,
                                                                             CommonConstants.PAGE_ADMIN_ENGLISH,
                                                                             param + (page + 1).ToString(),
                                                                             CommonConstants.TXT_NEXT_PAGE);
                }
                //pagingLink.Text = BaseServices.createPagingLink(CommonConstants.PAGE_ADMIN_ENGLISH + CommonConstants.ADD_PARAMETER + param, 
                //                                                page, 
                //                                                totalPages);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //showErrorMessage("search");
            string keyword = txtKeyword.Text;
            int page = 1;
            if (!BaseServices.isNullOrBlank(keyword))
            {
                int totalRecord = englishDAO.countArticles(keyword);
                
                IEnumerable<tblEnglish> lst = englishDAO.searchArticles(keyword, ((page - 1) * NoOfEnglishPerPage), NoOfEnglishPerPage);
                if (lst.Count() > 0)
                {
                    EnglishTable.Visible = true;
                    messagePanel.Visible = false;
                    showEnglishs(lst, totalRecord, page, CommonConstants.ACT_SEARCH_FREE, keyword, CommonConstants.ALL);
                    resetDefaultLabel();
                    showCountingArticle();
                    showCountingState();
                }
                else
                {
                    //Session[CommonConstants.SES_INFORM] = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                    //Response.Redirect(CommonConstants.PAGE_ADMIN_ENGLISH);
                    showInfoMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                    EnglishTable.Visible = false;
                    return;
                }
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_ID] == null)
            {
                string message = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                message += CommonConstants.TEMP_BR_TAG;
                message += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_ACTION_FAILED, CommonConstants.ACT_EDIT);
                showErrorMessage(message);
                return;
            }
            string sError = validateForm();
            if (!BaseServices.isNullOrBlank(sError))
            {
                showErrorMessage(sError);
                return;
            }
            tblEnglish item = new tblEnglish();
            item.Contents = txtChapeau.Text.Trim();
            item.Posted = BaseServices.getDateTimeFromString(txtPosted.Text) ;
            item.Title = txtTitle.Text.Trim();
            item.Tag = txtTag.Text.Trim();
            item.Location = txtLocation.Text.Trim();
            item.Author = txtAuthor.Text;
            int score = BaseServices.convertStringToInt( ddlScore.SelectedValue);
            item.Score = score;
            //get checker when score > 0.
            if (score != 0)
            {
                if (BaseServices.isNullOrBlank(txtChecker.Text))
                {
                    item.Checker = getCurrentUser();
                }
                else
                {
                    item.Checker = txtChecker.Text.Trim();
                }
            }
            else
            {
                item.Checker = null;
            }
            item.Comment = txtComment.Text.Trim();
            item.Thumbnail = txtThumbnail.Text.Trim();
            item.HtmlEmbedLink = txtHtmlEmbbed.Text.Trim();
            item.HtmlPreview = txtHtmlPreviewLink.Text.Trim();
            int type = BaseServices.convertStringToInt(ddlType.SelectedValue.ToString());
            item.Type = type;
            item.Class = BaseServices.convertStringToInt(ddlClass.SelectedValue.ToString());
            item.FolderID = txtFolderId.Text.Trim();
            //sticky item
            if (ddlSticky.SelectedValue.ToString() == CommonConstants.CONST_ZERO)
            {
                item.StickyFlg = false;
            }
            else
            {
                int stickied = englishDAO.countStickyArticle();
                int noOfEnglishOnPage = control.getValueByInt(CommonConstants.CF_NUM_ARTICLE_ON_EL);
                if (stickied > noOfEnglishOnPage / 2)
                {
                    showErrorMessage(BaseServices.createMsgByTemplate(CommonConstants.MSG_E_OVER_NUMBER, 
                        CommonConstants.TXT_STICKY, 
                        stickied.ToString(), 
                        CommonConstants.TXT_ONE_HALF + 
                        CommonConstants.SPACE + 
                        CommonConstants.CF_NUM_ARTICLE_ON_EL_NAME,
                        noOfEnglishOnPage.ToString()));
                    return;
                }
                item.StickyFlg = true;
            }
            //state
            string sState = ddlState.SelectedValue.ToString();
            int iState = BaseServices.convertStringToInt(sState);
            if (iState == CommonConstants.STATE_CHECKED && item.Class == CommonConstants.AT_UNCLASSIFIED)
            {
                string message = BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, CommonConstants.TXT_SUBJECT);
                showErrorMessage(message);
                return;
            }
            item.State = iState;
            
            int id = (Int32)Session[CommonConstants.SES_ID];
            //upload file
            string _fileContentSave = BaseServices.nullToBlank(txtLocation.Text);
            string _fileThumbnailSave = BaseServices.nullToBlank(txtThumbnail.Text);
            string _fileContent = CommonConstants.BLANK;
            string _fileThumbnail = CommonConstants.BLANK;
            string _folderID = txtFolderId.Text.Trim();
            bool _fileContentGood = false;
            bool _fileThumbnailGood = false;
            //root folder
            string rootFolder = Server.MapPath("~") + "/" + CommonConstants.FOLDER_EL + _folderID;
            //file type allow
            string fileTypes = control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);

            //size in MB
            int fileSizeMax = control.getValueByInt(CommonConstants.CF_MAX_FILE_SIZE); ;
            fileSizeMax = 1024 * 1024 * fileSizeMax;

            //upload file content
            if (fileContent.HasFile)
            {
                //check file existed: keep both
                _fileContent = bs.fileNameToSave(rootFolder + "/" + fileContent.FileName);
                //filename = newFileName;

                //check filetype
                if (!bs.checkFileType(fileContent.FileName, fileTypes))
                {
                    showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_NOT_ALLOW);
                    return;
                }
                //check filesize max (MB)
                if (fileContent.PostedFile.ContentLength > fileSizeMax)
                {
                    showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_TOO_LARGE);
                    return;
                }
                _fileContentSave = _fileContent.Substring(_fileContent.LastIndexOf(CommonConstants.FOLDER_DATA));
                _fileContentGood = true;
                item.Location = _fileContentSave;
            }
            else
            {
                if (_fileContentSave.LastIndexOf("/") > 0)
                    _fileContent = rootFolder + _fileContentSave.Substring(_fileContentSave.LastIndexOf("/"));
                else
                    _fileContent = rootFolder + _fileContentSave.Substring(_fileContentSave.LastIndexOf("\\"));

                if (!File.Exists(_fileContent))
                {
                    string src = Server.MapPath("~") + "/" + _fileContentSave;
                    File.Copy(src, _fileContent);
                    File.Delete(src);
                    _fileContentSave = _fileContent.Substring(_fileContent.LastIndexOf(CommonConstants.FOLDER_DATA));
                    item.Location = _fileContentSave;
                }
            }

            //upload thumbnail
            if (fileThumbnail.HasFile)
            {
                //check file existed: keep both
                _fileThumbnail = Path.GetFileNameWithoutExtension(_fileContentSave) +
                            "_thumbnail" + Path.GetExtension(fileThumbnail.FileName);

                _fileThumbnail = bs.fileNameToSave(rootFolder + "/" + _fileThumbnail);
                //filename = rootFolder + newFileName;

                //check filetype
                fileTypes = control.getValueString(CommonConstants.CF_IMG_FILE_TYPE_ALLOW);
                if (!bs.checkFileType(fileThumbnail.FileName, fileTypes))
                {
                    showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_NOT_ALLOW);
                    return;
                }
                //check filesize max (KB)
                fileSizeMax = control.getValueByInt(CommonConstants.CF_IMG_FILE_SIZE_MAX);
                fileSizeMax = 1024 * fileSizeMax;
                if (fileThumbnail.PostedFile.ContentLength > fileSizeMax)
                {
                    showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_TOO_LARGE);
                    return;
                }
                _fileThumbnailSave = _fileThumbnail.Substring(_fileContent.LastIndexOf(CommonConstants.FOLDER_DATA));
                _fileThumbnailGood = true;
                item.Thumbnail = _fileThumbnailSave;
            }
            else if (_fileThumbnailSave != CommonConstants.BLANK)
            {
                if (!_fileThumbnailSave.Contains(CommonConstants.FOLDER_DEFAULT_IMG))
                {
                    if (_fileThumbnailSave.LastIndexOf("/") > 0)
                        _fileThumbnail = rootFolder + _fileThumbnailSave.Substring(_fileThumbnailSave.LastIndexOf("/"));
                    else
                        _fileThumbnail = rootFolder + _fileThumbnailSave.Substring(_fileThumbnailSave.LastIndexOf("\\"));

                    if (!File.Exists(_fileThumbnail))
                    {
                        string src = Server.MapPath("~") + "/" + _fileThumbnailSave;
                        File.Copy(src, _fileThumbnail);
                        File.Delete(src);
                        _fileThumbnailSave = _fileThumbnail.Substring(_fileThumbnail.LastIndexOf(CommonConstants.FOLDER_DATA));
                        item.Thumbnail = _fileThumbnailSave;
                    }
                }
            }

            //end
            bool isOk = false;

            try
            {
                isOk = englishDAO.updateEnglish(id, item);
            }
            catch (Exception ex)
            {
                writeException(ex);
            }

            if (isOk)
            {
                if (_fileContentGood)
                {
                    string folder = Path.GetDirectoryName(_fileContent);
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    fileContent.SaveAs(_fileContent);
                }
                if (_fileThumbnailGood)
                {
                    string folder = Path.GetDirectoryName(_fileThumbnail);
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    fileThumbnail.SaveAs(_fileThumbnail);
                }

                int stickiedArticle = englishDAO.countStickyArticle();
                statDAO.setValue(CommonConstants.SF_NUM_STICKED_ON_EL, stickiedArticle.ToString());
                Session[CommonConstants.SES_INFORM] = BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_SUCCESSFUL, CommonConstants.ACT_EDIT);
            }
            else
            {
                Session[CommonConstants.SES_INFORM] = BaseServices.createMsgByTemplate(CommonConstants.MSG_E_ACTION_FAILED, CommonConstants.ACT_EDIT);
            }
            Response.Redirect(CommonConstants.PAGE_ADMIN_ENGLISH);
            
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_OLD_PAGE] != null)
            {
                Response.Redirect((string)Session[CommonConstants.SES_OLD_PAGE]);
            }
            else
            {
                Response.Redirect(CommonConstants.PAGE_ADMIN_ENGLISH);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            IEnumerable<tblEnglish> lst = englishDAO.getDeletedArticleList();
            string path = CommonConstants.BLANK;
            bool fileDeleted = false;
            int totalFileDeleted = 0;
            bool deleteSuccessful = false;

            //build list path to delete
            ArrayList strPathList = new ArrayList();
            foreach (var item in lst)
            {
                strPathList.Add(item.FolderID.Trim());
            }
            try
            {
                if (lst != null)
                {
                    deleteSuccessful = englishDAO.deleteArticles();
                    if (deleteSuccessful)
                    {
                        foreach (var item in strPathList)
                        {
                            path = DBHelper.strCurrentPath;
                            path += CommonConstants.FOLDER_EL;
                            path += item;
                            fileDeleted = BaseServices.deleteFolder(path);
                            if (fileDeleted)
                            {
                                totalFileDeleted++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                writeException(ex);
            }
            if (deleteSuccessful)
            {
                string message = BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_SUCCESSFUL, 
                    CommonConstants.ACT_DELETE);
                message += CommonConstants.TEMP_BR_TAG;
                message += BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_DETAIL, 
                                                            CommonConstants.ACT_DELETE, 
                                                            totalFileDeleted.ToString(), 
                                                            CommonConstants.TXT_ARTICLE_NAME);
                EnglishTable.Visible = false;
                showErrorMessage(message);
                return;
                
            }
        }
        private string validateForm()
        {
            string sError = CommonConstants.BLANK;
            if (BaseServices.isNullOrBlank(txtPosted.Text))
            {
                sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, CommonConstants.TXT_POSTED_DATE);
                sError += CommonConstants.TEMP_BR_TAG;
            }
            else
            {
                if (!BaseServices.isDateTime(txtPosted.Text))
                {
                    sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_RIGHT_FORMAT, 
                        CommonConstants.TXT_POSTED_DATE, CommonConstants.DEFAULT_DATE_FORMAT);
                    sError += CommonConstants.TEMP_BR_TAG;
                }
            }
            if (BaseServices.isNullOrBlank(txtTitle.Text))
            {
                sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, CommonConstants.TXT_TITLE);
                sError += CommonConstants.TEMP_BR_TAG;
            }
            else
            {
                if (txtTitle.Text.Trim().Length > 254)
                {
                    sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_MAX_LENGTH, 
                        CommonConstants.TXT_TITLE, CommonConstants.BLANK + 254);
                    sError += CommonConstants.TEMP_BR_TAG;
                }
            }
            if (BaseServices.isNullOrBlank(txtLocation.Text))
            {
                sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_PLEASE_INPUT_DATA, CommonConstants.TXT_LOCATION);
                sError += CommonConstants.TEMP_BR_TAG;
            }
            if (txtThumbnail.Text.Trim().Length > 254)
            {
                sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_MAX_LENGTH,
                        CommonConstants.TXT_THUMBNAIL, CommonConstants.BLANK + 254);
                sError += CommonConstants.TEMP_BR_TAG;
            }
            if (txtTag.Text.Trim().Length > 254)
            {
                sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_MAX_LENGTH,
                        CommonConstants.TXT_TAG, CommonConstants.BLANK + 254);
                sError += CommonConstants.TEMP_BR_TAG;
            }
            if (txtLocation.Text.Trim().Length > 200)
            {
                sError += BaseServices.createMsgByTemplate(CommonConstants.MSG_E_MAX_LENGTH,
                        CommonConstants.TXT_LOCATION, CommonConstants.BLANK + 200);
                sError += CommonConstants.TEMP_BR_TAG;
            }
            
            return sError;
        }
        /// <summary>
        /// get current username
        /// </summary>
        /// <returns></returns>
        private string getCurrentUser()
        {
            if (Session[CommonConstants.SES_USER] != null)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                return user.Username;
            }
            return CommonConstants.BLANK;
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
        private void showFileContent(string location)
        {
            if (File.Exists(DBHelper.strCurrentPath + location))
            {
                liContent.Text = "&nbsp;&nbsp;<br/><input type=\"button\" value=\"Mở\" class=\"formbutton\" onclick=\"openFile('../../" + location.Replace("\\", "/") + "')\"/>";
            }
            else
                liContent.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
        }
        private void showThumbnail(string location)
        {
            if (File.Exists(DBHelper.strCurrentPath + location))
            {
                liThumbnail.Text = "&nbsp;&nbsp;<br /><input type=\"button\" value=\"Mở\" class=\"formbutton\" onclick=\"DisplayFullImage('../../" + location.Replace("\\", "/") + "')\"/>";
            }
            else
                liThumbnail.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
        }
        private void initial()
        {
            ddlState.Items.Add(new ListItem(CommonConstants.STATE_UNCHECK_NAME, CommonConstants.STATE_UNCHECK.ToString()));
            ddlState.Items.Add(new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
            ddlState.Items.Add(new ListItem(CommonConstants.STATE_BAD_NAME, CommonConstants.STATE_BAD.ToString()));
            //Sticky
            ddlSticky.Items.Add(new ListItem(CommonConstants.TXT_UNSTICKY, CommonConstants.CONST_ZERO));
            ddlSticky.Items.Add(new ListItem(CommonConstants.TXT_STICKY, CommonConstants.CONST_ONE));
            //Type
            ddlType.Items.Add(new ListItem(CommonConstants.TXT_PLEASE_SELECT, CommonConstants.CONST_ONE_NEGATIVE));
            ddlType.Items.Add(new ListItem(CommonConstants.AT_LECTURE_NAME.ToString(), CommonConstants.AT_LECTURE.ToString()));
            ddlType.Items.Add(new ListItem(CommonConstants.AT_PRACTISE_NAME, CommonConstants.AT_PRACTISE.ToString()));
            ddlType.Items.Add(new ListItem(CommonConstants.AT_EXAM_NAME, CommonConstants.AT_EXAM.ToString()));
            //Score
            ddlScore.Items.Add(new ListItem(CommonConstants.TXT_PLEASE_SELECT, CommonConstants.CONST_ZERO));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_ONE, CommonConstants.CONST_ONE));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_TWO, CommonConstants.CONST_TWO));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_THREE, CommonConstants.CONST_THREE));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_FOUR, CommonConstants.CONST_FOUR));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_FIVE, CommonConstants.CONST_FIVE));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_SIX, CommonConstants.CONST_SIX));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_SEVEN, CommonConstants.CONST_SEVEN));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_EIGHT, CommonConstants.CONST_EIGHT));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_NINE, CommonConstants.CONST_NINE));
            ddlScore.Items.Add(new ListItem(CommonConstants.CONST_TEN, CommonConstants.CONST_TEN));
            //Class
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_UNCLASSIFIED_NAME, CommonConstants.AT_UNCLASSIFIED.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_1_NAME, CommonConstants.AT_EL_CLASS_1_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_2_NAME, CommonConstants.AT_EL_CLASS_2_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_3_NAME, CommonConstants.AT_EL_CLASS_3_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_4_NAME, CommonConstants.AT_EL_CLASS_4_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_5_NAME, CommonConstants.AT_EL_CLASS_5_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_6_NAME, CommonConstants.AT_EL_CLASS_6_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_7_NAME, CommonConstants.AT_EL_CLASS_7_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_8_NAME, CommonConstants.AT_EL_CLASS_8_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_9_NAME, CommonConstants.AT_EL_CLASS_9_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_10_NAME, CommonConstants.AT_EL_CLASS_10_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_11_NAME, CommonConstants.AT_EL_CLASS_11_CODE));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CLASS_12_NAME, CommonConstants.AT_EL_CLASS_12_CODE));

            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_MATH_NAME, CommonConstants.AT_EL_MJ_MATH.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_PHY_NAME, CommonConstants.AT_EL_MJ_PHY.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_CHEM_NAME, CommonConstants.AT_EL_MJ_CHEM.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_BIO_NAME, CommonConstants.AT_EL_MJ_BIO.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_MATERIAL_NAME, CommonConstants.AT_EL_MJ_MATERIAL.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_TELE_NAME, CommonConstants.AT_EL_MJ_TELE.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_IT_NAME, CommonConstants.AT_EL_MJ_IT.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_MJ_ECO_NAME, CommonConstants.AT_EL_MJ_ECO.ToString()));

            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEFL_NAME, CommonConstants.AT_EL_TOEFL.ToString()));

            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEIC_300_NAME, CommonConstants.AT_EL_TOEIC_300.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEIC_400_NAME, CommonConstants.AT_EL_TOEIC_400.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEIC_500_NAME, CommonConstants.AT_EL_TOEIC_500.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEIC_600_NAME, CommonConstants.AT_EL_TOEIC_600.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEIC_700_NAME, CommonConstants.AT_EL_TOEIC_700.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEIC_800_NAME, CommonConstants.AT_EL_TOEIC_800.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_TOEIC_900_NAME, CommonConstants.AT_EL_TOEIC_900.ToString()));

            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_IELTS_NAME, CommonConstants.AT_EL_IELTS.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CERT_A_NAME, CommonConstants.AT_EL_CERT_A.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CERT_B_NAME, CommonConstants.AT_EL_CERT_B.ToString()));
            ddlClass.Items.Add(new ListItem(CommonConstants.AT_EL_CERT_C_NAME, CommonConstants.AT_EL_CERT_C.ToString()));

        }
        /// <summary>
        /// change state of control
        /// </summary>
        /// <param name="state"></param>
        private void changeState(bool state)
        {
            txtTitle.Enabled = state;
            txtChapeau.Enabled = state;
            txtTag.Enabled = state;
            txtChecker.Enabled = state;
            ddlState.Enabled = state;
            ddlSticky.Enabled = state;
            ddlType.Enabled = state;
            ddlClass.Enabled = state;
            ddlScore.Enabled = state;
            txtHtmlEmbbed.Enabled = state;
            txtHtmlPreviewLink.Enabled = state;
            txtLocation.Enabled = state;
            txtChecker.Enabled = state;
            txtThumbnail.Enabled = state;
        }
        /// <summary>
        /// write exception to log file
        /// </summary>
        /// <param name="ex"></param>
        private void writeException(Exception ex)
        {
            string username = getCurrentUser();
            if (username == CommonConstants.BLANK)
                username = CommonConstants.USER_GUEST;
            log.writeLog(DBHelper.strPathLogFile, username, ex.Message
                                                    + CommonConstants.NEWLINE
                                                    + ex.Source
                                                    + CommonConstants.NEWLINE
                                                    + ex.StackTrace
                                                    + CommonConstants.NEWLINE
                                                    + ex.HelpLink);
            return;
        }
        private void changeStateLink(string key)
        {
            hpkShowAllState.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_EL_URL,
                                                                                       CommonConstants.ACT_SEARCH,
                                                                                       key,
                                                                                       CommonConstants.ALL,
                                                                                       CommonConstants.CONST_ONE);
            hpkShowChecked.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_EL_URL,
                                                                           CommonConstants.ACT_SEARCH,
                                                                           key,
                                                                           CommonConstants.STATE_CHECKED.ToString(),
                                                                           CommonConstants.CONST_ONE);
            hpkShowUncheck.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_EL_URL,
                                                                           CommonConstants.ACT_SEARCH,
                                                                           key,
                                                                           CommonConstants.STATE_UNCHECK.ToString(),
                                                                           CommonConstants.CONST_ONE);
            hpkShowBad.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_EL_URL,
                                                                           CommonConstants.ACT_SEARCH,
                                                                           key,
                                                                           CommonConstants.STATE_BAD.ToString(),
                                                                           CommonConstants.CONST_ONE);

        }
        /// <summary>
        /// count by class
        /// </summary>
        private void showCountingArticle()
        {
            hpkShowAll.Text += "(" + englishDAO.count() + ")";
            hpkShow19.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CLASS_1_TO_9) + ")";
            hpkShow10.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CLASS_10_CODE) + ")";
            hpkShow11.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CLASS_11_CODE) + ")";
            hpkShow12.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CLASS_12_CODE) + ")";
            hpkShowMath.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_MATH.ToString()) + ")";
            hpkShowPhy.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_PHY.ToString()) + ")";
            hpkShowChem.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_CHEM.ToString()) + ")";
            hpkShowBio.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_BIO.ToString()) + ")";
            hpkShowCom.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_TELE.ToString()) + ")";
            hpkShowEco.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_ECO.ToString()) + ")";
            hpkShowMat.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_MATERIAL.ToString()) + ")";
            hpkShowToefl.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CERT_TOEFL) + ")";
            hpkShowToeic.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CERT_TOEIC) + ")";
            hpkShowIelts.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CERT_IELTS) + ")";
            hpkShowIT.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_MJ_IT.ToString()) + ")";
            hpkShowABC.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_ABC) + ")";
            hpkShowSticky.Text += "(" + englishDAO.countStickyArticle() + ")";

        }
        /// <summary>
        /// count by state
        /// </summary>
        private void showCountingState()
        {
            hpkShowAllState.Text += "(" + englishDAO.count() + ")";
            hpkShowBad.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_BAD) + ")";
            hpkShowChecked.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_CHECKED) + ")";
            hpkShowUncheck.Text += "(" + englishDAO.countEnglishList(CommonConstants.STATE_UNCHECK) + ")";

        }
        /// <summary>
        /// reset all label to default value
        /// </summary>
        private void resetDefaultLabel()
        {

            hpkShowAll.Text = CommonConstants.TXT_ALL;
            hpkShow19.Text = CommonConstants.AT_EL_CLASS_1_TO_9_NAME + CommonConstants.SPACE;
            hpkShow10.Text = CommonConstants.AT_EL_CLASS_10_NAME + CommonConstants.SPACE;
            hpkShow11.Text = CommonConstants.AT_EL_CLASS_11_NAME + CommonConstants.SPACE;
            hpkShow12.Text = CommonConstants.AT_EL_CLASS_12_NAME + CommonConstants.SPACE;
            hpkShowMath.Text = CommonConstants.AT_EL_MJ_MATH_NAME + CommonConstants.SPACE;
            hpkShowPhy.Text = CommonConstants.AT_EL_MJ_PHY_NAME + CommonConstants.SPACE;
            hpkShowChem.Text = CommonConstants.AT_EL_MJ_CHEM_NAME + CommonConstants.SPACE;
            hpkShowBio.Text = CommonConstants.AT_EL_MJ_BIO_NAME + CommonConstants.SPACE;
            hpkShowCom.Text = CommonConstants.AT_EL_MJ_TELE_NAME + CommonConstants.SPACE;
            hpkShowEco.Text = CommonConstants.AT_EL_MJ_ECO_NAME + CommonConstants.SPACE;
            hpkShowMat.Text = CommonConstants.AT_EL_MJ_MATERIAL_NAME + CommonConstants.SPACE;
            hpkShowToefl.Text = CommonConstants.AT_EL_TOEFL_NAME + CommonConstants.SPACE;
            hpkShowToeic.Text = CommonConstants.AT_EL_TOEIC_NAME + CommonConstants.SPACE;
            hpkShowIelts.Text = CommonConstants.AT_EL_IELTS_NAME + CommonConstants.SPACE;
            hpkShowIT.Text = CommonConstants.AT_EL_MJ_IT_NAME + CommonConstants.SPACE;
            hpkShowABC.Text = CommonConstants.AT_EL_ABC_NAME + CommonConstants.SPACE;
            hpkShowSticky.Text = CommonConstants.TXT_STICKY + CommonConstants.SPACE;
            hpkShowAllState.Text = CommonConstants.TXT_ALL + CommonConstants.SPACE;
            hpkShowBad.Text = CommonConstants.STATE_BAD_NAME + CommonConstants.SPACE;
            hpkShowChecked.Text = CommonConstants.STATE_CHECKED_NAME + CommonConstants.SPACE;
            hpkShowUncheck.Text = CommonConstants.STATE_UNCHECK_NAME + CommonConstants.SPACE;

        }
        /// <summary>
        /// change text of hyperlink
        /// </summary>
        /// <param name="linkID"></param>
        private void changeViewState(string _class)
        {
            if (_class == CommonConstants.AT_EL_CLASS_1_TO_9)
            {
                hpkShow19.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShow19.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_CLASS_10_CODE)
            {
                hpkShow10.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShow10.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_CLASS_11_CODE)
            {
                hpkShow11.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShow11.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_CLASS_12_CODE)
            {
                hpkShow12.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShow12.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_CERT_TOEIC)
            {
                hpkShowToeic.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowToeic.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_ABC)
            {
                hpkShowABC.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowABC.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_CERT_IELTS)
            {
                hpkShowIelts.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowIelts.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_CERT_TOEFL)
            {
                hpkShowToefl.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowToefl.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_BIO.ToString())
            {
                hpkShowBio.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowBio.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_CHEM.ToString())
            {
                hpkShowChem.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowChem.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_PHY.ToString())
            {
                hpkShowPhy.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowPhy.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_MATH.ToString())
            {
                hpkShowMath.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowMath.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_MATERIAL.ToString())
            {
                hpkShowMat.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowMat.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_TELE.ToString())
            {
                hpkShowCom.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowCom.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_IT.ToString())
            {
                hpkShowIT.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowIT.Text);
                return;
            }
            else if (_class == CommonConstants.AT_EL_MJ_ECO.ToString())
            {
                hpkShowEco.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowEco.Text);
                return;
            }
            else if (_class == CommonConstants.ALL)
            {
                hpkShowAll.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowAll.Text);
                return;
            }
            else if (_class == CommonConstants.TXT_STICKY.ToLower())
            {
                hpkShowSticky.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowSticky.Text);
                return;
            }
        }
    }
}