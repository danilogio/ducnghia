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
    public partial class ContestUniversity : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.BaseServices bs = new ltktDAO.BaseServices();
        ltktDAO.Contest contestDAO = new ltktDAO.Contest();

        public const int NoOfContestPerPage = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_UNIVERSITY)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader(CommonConstants.PAGE_ADMIN_UNIVERSITY_NAME);

                    liTitle.Text = CommonConstants.PAGE_ADMIN_UNIVERSITY_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

                    liTableHeader.Text = CommonConstants.TXT_LIST_ARTICLE;

                    
                    pageLoad(sender, e, user);
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
            string action = Request.QueryString[CommonConstants.REQ_ACTION];
            string sPage = Request.QueryString[CommonConstants.REQ_PAGE];
            //bool isDeleted = false;
            if (BaseServices.isNullOrBlank(action))
            {
                action = CommonConstants.ACT_SEARCH;
            }
            if (BaseServices.isNullOrBlank(sPage))
            {
                sPage = CommonConstants.PAGE_NUMBER_FIRST;
            }

            int page = Convert.ToInt32(sPage);
            if (action == CommonConstants.ACT_SEARCH)
            {
                hpkShowAll.Text += "(" + contestDAO.count() + ")";
                hpkShowMath.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_MATHEMATICS_CODE) + ")";
                hpkShowPhy.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_PHYSICAL_CODE) + ")";
                hpkShowChem.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_CHEMICAL_CODE) + ")";
                hpkShowBio.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_BIOGRAPHY_CODE) + ")";
                hpkShowLit.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_LITERATURE_CODE) + ")";
                hpkShowHis.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_HISTORY_CODE) + ")";
                hpkShowGeo.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_GEOGRAPHY_CODE) + ")";
                hpkShowEng.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_ENGLISH_CODE) + ")";


                string key = Request.QueryString[CommonConstants.REQ_KEY];
                string state = Request.QueryString[CommonConstants.REQ_STATE];
                int totalRecord = 0;
                viewPanel.Visible = true;
                detailPanel.Visible = false;
                messagePanel.Visible = false;
                IEnumerable<tblContestForUniversity> lst = null;

                if (BaseServices.isNullOrBlank(key))
                {
                    key = CommonConstants.ALL;
                }
                else
                {
                    key = BaseServices.nullToBlank(key);
                }
                if (BaseServices.isNullOrBlank(state))
                {
                    state = CommonConstants.ALL;
                }
                changeViewState(key);
                if (key == CommonConstants.ALL)
                {
                    if (state == CommonConstants.ALL)// key = ALL and state = ALL
                    {
                        lst = contestDAO.fetchArticleList((page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.count();
                        string txt = hpkShowAllState.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowAllState.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_UNCHECK.ToString())// key = ALL and state = UNCHECk
                    {
                        lst = contestDAO.fetchArticleList(CommonConstants.STATE_UNCHECK, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK);

                        hpkShowAllState.Text += "(" + contestDAO.count() + ")";
                        string txt = hpkShowUncheck.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowUncheck.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                        hpkShowChecked.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_CHECKED.ToString())// key = ALL and state = CHECKED
                    {
                        lst = contestDAO.fetchArticleList(CommonConstants.STATE_CHECKED, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleByState(CommonConstants.STATE_CHECKED);

                        hpkShowAllState.Text += "(" + contestDAO.count() + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK) + ")";
                        string txt = hpkShowChecked.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowChecked.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                        hpkShowBad.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_BAD.ToString())// key = ALL and state = BAD
                    {
                        lst = contestDAO.fetchArticleList(CommonConstants.STATE_BAD, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleByState(CommonConstants.STATE_BAD);

                        hpkShowAllState.Text += "(" + contestDAO.count() + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_CHECKED) + ")";
                        string txt = hpkShowBad.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowBad.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                    }
                    
                }
                else //key != ALL
                {
                    string sub = key;
                    if (BaseServices.isNullOrBlank(sub))
                    {
                        sub = CommonConstants.SUB_MATHEMATICS_CODE;
                    }
                    //change state link
                    hpkShowAllState.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_CONTEST_URL,
                                                                                   CommonConstants.ACT_SEARCH, 
                                                                                   key, 
                                                                                   CommonConstants.ALL, 
                                                                                   CommonConstants.CONST_ONE);
                    hpkShowChecked.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_CONTEST_URL,
                                                                                   CommonConstants.ACT_SEARCH,
                                                                                   key,
                                                                                   CommonConstants.STATE_CHECKED.ToString(),
                                                                                   CommonConstants.CONST_ONE);
                    hpkShowUncheck.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_CONTEST_URL,
                                                                                   CommonConstants.ACT_SEARCH,
                                                                                   key,
                                                                                   CommonConstants.STATE_UNCHECK.ToString(),
                                                                                   CommonConstants.CONST_ONE);
                    hpkShowBad.NavigateUrl = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ADMIN_CONTEST_URL,
                                                                                   CommonConstants.ACT_SEARCH,
                                                                                   key,
                                                                                   CommonConstants.STATE_BAD.ToString(),
                                                                                   CommonConstants.CONST_ONE);

                    if (state == CommonConstants.ALL)//key != ALL and state = ALL
                    {
                        lst = contestDAO.fetchArticleList(sub.Trim(), (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleBySubject(sub.Trim());

                        
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD) + ")";
                        string txt = hpkShowAllState.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowAllState.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                    }
                    else if (state == CommonConstants.STATE_UNCHECK.ToString())//key != ALL and state = UNCHECK
                    {
                        lst = contestDAO.fetchArticleList(sub.Trim(), CommonConstants.STATE_UNCHECK, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleBySubjectAndState(sub.Trim(),CommonConstants.STATE_UNCHECK);
                        hpkShowAllState.Text += "(" + contestDAO.countArticleBySubject(sub.Trim()) + ")";
                       
                        hpkShowChecked.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD) + ")";
                        string txt = hpkShowUncheck.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowUncheck.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                    }
                    else if (state == CommonConstants.STATE_CHECKED.ToString())//key != ALL and state = CHECKED
                    {
                        lst = contestDAO.fetchArticleList(sub.Trim(), CommonConstants.STATE_CHECKED, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED);
                        hpkShowAllState.Text += "(" + contestDAO.countArticleBySubject(sub.Trim()) + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_UNCHECK) + ")";
                        string txt = hpkShowChecked.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowChecked.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                        hpkShowBad.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_BAD.ToString())//key != ALL and state = BAD
                    {
                        lst = contestDAO.fetchArticleList(sub.Trim(), CommonConstants.STATE_BAD, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD);

                        hpkShowAllState.Text += "(" + contestDAO.countArticleBySubject(sub.Trim()) + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED) + ")";
                        string txt = hpkShowBad.Text;
                        txt += "(" + totalRecord + ")";
                        hpkShowBad.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, txt);
                    }
                    else
                    {
                        
                    }
                   
                }
                //show data
                bool isOK = false;
                if (lst != null)
                {
                    if (lst.Count() > 0)
                    {
                        showContest(lst, totalRecord, page, action, key, state);
                        isOK = true;
                    }
                }
                if (!isOK)
                {
                    showInfoMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                    ContestTable.Visible = false;
                    return;
                }
            }
            else if (action == CommonConstants.ACT_EDIT || action == CommonConstants.ACT_VIEW)
            {
                viewPanel.Visible = false;
                detailPanel.Visible = true;
                messagePanel.Visible = false;

                int id = BaseServices.convertStringToInt(Request.QueryString[CommonConstants.REQ_ID]);
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
                detailPanel.Visible = true;
                messagePanel.Visible = false;

                if (ddlState.Items.Count == 0)
                {
                    showContestDetails(_id, action);
                }
                
                if (action == CommonConstants.ACT_VIEW)
                {
                    btnEdit.Visible = false;
                }

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
                
                int id = BaseServices.convertStringToInt(Request.QueryString[CommonConstants.REQ_ID]);
                bool isMatch = contestDAO.isState(id, CommonConstants.STATE_UNCHECK);
                if (contestDAO.deleteArticle(id, user.Username))
                {
                    if (isMatch)
                    {
                        ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                        statDAO.add(CommonConstants.SF_NUM_ARTICLE_ON_UNI, CommonConstants.CONST_ONE_NEGATIVE);
                    }
                    string mess = BaseServices.createMsgByTemplate(CommonConstants.MSG_I_ACTION_SUCCESSFUL, CommonConstants.ACT_DELETE);

                    ltktDAO.Alert.Show(mess);
                    //isDeleted = true;
                }

            }

        }

        private void showContestDetails(int _id, string action)
        {
            tblContestForUniversity cont = contestDAO.getContest(_id);
            if (cont != null)
            {
                txtTitle.Text = cont.Title.Trim();
                txtAuthor.Text = cont.tblUser.Username.Trim();
                txtPosted.Text = cont.Posted.ToString("HH:mm:ss 'ngày' dd/M/yyyy");
                showState(cont.State);
                showSticky(cont.StickyFlg);
                showContestType(cont.isUniversity);
                showBranch(cont.Branch);
                showSubject(cont.Subject);
                showYear(cont.Year);
                txtContent.Text = cont.Contents.Trim();
                txtTag.Text = cont.Tag.Trim();
                txtPoint.Text = Convert.ToString(cont.Point);
                txtScore.Text = Convert.ToString(cont.Score);
                showFileContent(cont.Location);
                showFileSolving(cont.Solving);
                showThumbnail(cont.Thumbnail);
                txtHtmlEmbed.Text = BaseServices.nullToBlank(cont.HtmlEmbedLink);
                txtHtmlPreview.Text = BaseServices.nullToBlank(cont.HtmlPreview);
            }
            else
            {
                detailPanel.Visible = false;
                showErrorMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
            }

            //enable or disable for edit
            if (action == CommonConstants.ACT_VIEW)
            {                
                disableEdit();
            }
            else if (action == CommonConstants.ACT_EDIT)
            {
                enableEdit();
            }
        }

        private void showFileContent(string location)
        {
            if (File.Exists(DBHelper.strCurrentPath + location))
            {
                liContent.Text = "&nbsp;&nbsp;<input type=\"button\" value=\"Mở\" class=\"formbutton\" onclick=\"openFile('" + location.Replace("\"","/") + "')\"/>";
            }
            else
                liContent.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
        }

        private void showFileSolving(string location)
        {
        }

        private void showThumbnail(string location)
        {
        }

        private void showYear(int year)
        {
            if (ddlYear.Items.Count == 0)
                for (int idx = 2002; idx <= DateTime.Now.Year; ++idx)
                    ddlYear.Items.Add(new ListItem(Convert.ToString(idx), Convert.ToString(idx)));

            if (ddlYear.Items.Count > 0)
                ddlYear.SelectedValue = Convert.ToString(year);
        }

        private void showSubject(string sub)
        {
            if (ddlSubject.Items.Count == 0)
            {
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_MATHEMATICS, CommonConstants.SUB_MATHEMATICS_CODE));
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_PHYSICAL, CommonConstants.SUB_PHYSICAL_CODE));
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_CHEMICAL, CommonConstants.SUB_CHEMICAL_CODE));
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_BIOGRAPHY, CommonConstants.SUB_BIOGRAPHY_CODE));
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_LITERATURE, CommonConstants.SUB_LITERATURE_CODE));
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_HISTORY, CommonConstants.SUB_HISTORY_CODE));
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_GEOGRAPHY, CommonConstants.SUB_GEOGRAPHY_CODE));
                ddlSubject.Items.Add(new ListItem(CommonConstants.SUB_ENGLISH, CommonConstants.SUB_ENGLISH_CODE));
            }

            if (ddlSubject.Items.Count > 0)
                ddlSubject.SelectedValue = sub;
        }

        private void showBranch(int branch)
        {
            if (ddlBranch.Items.Count == 0)
            {
                ddlBranch.Items.Add(new ListItem("Khối A", "0"));
                ddlBranch.Items.Add(new ListItem("Khối B", "1"));
                ddlBranch.Items.Add(new ListItem("Khối C", "2"));
                ddlBranch.Items.Add(new ListItem("Khối D", "3"));
            }

            if (ddlBranch.Items.Count > 0)
                ddlBranch.SelectedValue = Convert.ToString(branch);
        }

        private void showContestType(bool isUniversity)
        {
            if (ddlType.Items.Count == 0)
            {
                ddlType.Items.Add(new ListItem("Đại học", "True"));
                ddlType.Items.Add(new ListItem("Cao đẳng", "False"));
            }
            if (ddlType.Items.Count > 0)
                ddlType.SelectedValue = Convert.ToString(isUniversity);
        }

        private void showSticky(bool sticky)
        {
            if (ddlSticky.Items.Count == 0)
            {
                ddlSticky.Items.Add(new ListItem("Có", "True"));
                ddlSticky.Items.Add(new ListItem("Không", "False"));
            }

            if (ddlSticky.Items.Count > 0)
            {
                ddlSticky.SelectedValue = Convert.ToString(sticky);
            }
        }

        private void showState(int state)
        {
            if (ddlState.Items.Count == 0)
            {
                ddlState.Items.Add(new ListItem(CommonConstants.STATE_UNCHECK_NAME, CommonConstants.STATE_UNCHECK.ToString()));
                ddlState.Items.Add(new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
                ddlState.Items.Add(new ListItem(CommonConstants.STATE_BAD_NAME, CommonConstants.STATE_BAD.ToString()));
            }

            if (ddlState.Items.Count > 0)
            {
                ddlState.SelectedValue = state.ToString();
            }
        }

        private void disableEdit()
        {
            txtTitle.ReadOnly = true;
            txtAuthor.ReadOnly = true;
            txtPosted.ReadOnly = true;
            ddlState.Enabled = false;
            ddlSticky.Enabled = false;
            ddlType.Enabled = false;
            ddlBranch.Enabled = false;
            ddlSubject.Enabled = false;
            ddlYear.Enabled = false;
            txtContent.ReadOnly = true;
            txtTag.ReadOnly = true;
            txtPoint.ReadOnly = true;
            txtScore.ReadOnly = true;
            liContent.Text += "&nbsp;&nbsp;<input type=\"button\" disabled=\"disabled\" value=\"Tải tập tin nội dung\" class=\"formbutton\" onclick=\"uploadContent()\" />";
            txtHtmlEmbed.ReadOnly = true;
            txtHtmlPreview.ReadOnly = true;
        }

        private void enableEdit()
        {
            txtTitle.ReadOnly = false;
            txtAuthor.ReadOnly = false;
            txtPosted.ReadOnly = false;
            ddlState.Enabled = true;
            ddlSticky.Enabled = true;
            ddlType.Enabled = true;
            ddlBranch.Enabled = true;
            ddlSubject.Enabled = true;
            ddlYear.Enabled = true;
            txtContent.ReadOnly = false;
            txtTag.ReadOnly = false;
            txtPoint.ReadOnly = false;
            txtScore.ReadOnly = false;
            liContent.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải tập tin nội dung\" class=\"formbutton\" onclick=\"uploadContent()\" />";
            txtHtmlEmbed.ReadOnly = false;
            txtHtmlPreview.ReadOnly = false;   
        }

        private void showContest (IEnumerable <tblContestForUniversity> lst, int totalContest, int page, string action, string key, string state)
        {
            //int totalContest = lst.Count();
            // Computing total pages
            int totalPages;
            int mod = totalContest % NoOfContestPerPage;

            if (mod == 0)
            {
                totalPages = totalContest / NoOfContestPerPage;
            }
            else
            {
                totalPages = ((totalContest - mod) / NoOfContestPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblContestForUniversity contest = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "7px";
                noCell.Text = Convert.ToString(idx + 1 + (page - 1) * NoOfContestPerPage);

                TableCell titleCell = new TableCell();
                titleCell.CssClass = "table-cell";
                titleCell.Style["width"] = "200px";
                titleCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                  CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                  CommonConstants.ACT_VIEW,
                                                                  Convert.ToString (contest.ID),
                                                                  contest.Title);

                TableCell postedCell = new TableCell();
                postedCell.CssClass = "table-cell";
                postedCell.Style["width"] = "80px";
                postedCell.Text = bs.convertDateToString(contest.Posted);

                TableCell subjectCell = new TableCell();
                subjectCell.CssClass = "table-cell";
                subjectCell.Style["width"] = "40px";
                subjectCell.Text = BaseServices.getNameSubjectByCode(contest.Subject);

                TableCell authorCell = new TableCell();
                authorCell.CssClass = "table-cell";
                authorCell.Style["width"] = "40px";
                authorCell.Text = contest.Author;

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "40px";
                stateCell.Text = contestDAO.getState(contest.ID);

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                     CommonConstants.ACT_EDIT,
                                                                     Convert.ToString (contest.ID),
                                                                     CommonConstants.HTML_EDIT_ADMIN);

                actionCell.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                     CommonConstants.ACT_DELETE,
                                                                     Convert.ToString(contest.ID),
                                                                     CommonConstants.HTML_DELETE_ADMIN);


                TableRow contestRow = new TableRow();
                contestRow.Cells.Add(noCell);
                contestRow.Cells.Add(titleCell);
                contestRow.Cells.Add(postedCell);
                contestRow.Cells.Add(subjectCell);
                contestRow.Cells.Add(authorCell);
                contestRow.Cells.Add(stateCell);
                contestRow.Cells.Add(actionCell);
                
                ContestTable.Rows.AddAt(2 + idx, contestRow);
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
                                                                                CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                                param + (page - 1).ToString(),
                                                                                CommonConstants.TXT_PREVIOUS_PAGE);
                }
                if (page > 0 && page < totalPages)
                {
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_PAGING_LINK,
                                                                             CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                             param + (page + 1).ToString(),
                                                                             CommonConstants.TXT_NEXT_PAGE);
                }
            }
        }
        
        private void changeViewState(string subject)
        {
            switch (subject)
            {
                case CommonConstants.SUB_MATHEMATICS_CODE:
                    {
                        hpkShowMath.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowMath.Text);
                        break;
                    }
                case CommonConstants.SUB_PHYSICAL_CODE:
                    {
                        hpkShowPhy.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowPhy.Text);
                        break;
                    }
                case CommonConstants.SUB_CHEMICAL_CODE:
                    {
                        hpkShowChem.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowChem.Text);
                        break;
                    }
                case CommonConstants.SUB_LITERATURE_CODE:
                    {
                        hpkShowLit.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowLit.Text);
                        break;
                    }
                case CommonConstants.SUB_HISTORY_CODE:
                    {
                        hpkShowHis.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowHis.Text);
                        break;
                    }
                case CommonConstants.SUB_GEOGRAPHY_CODE:
                    {
                        hpkShowGeo.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowGeo.Text);
                        break;
                    }
                case CommonConstants.SUB_BIOGRAPHY_CODE:
                    {
                        hpkShowBio.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowBio.Text);
                        break;
                    }
                case CommonConstants.SUB_ENGLISH_CODE:
                    {
                        hpkShowEng.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowEng.Text);
                        break;
                    }
                case CommonConstants.ALL:
                    {
                        hpkShowAll.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowAll.Text);
                        break;
                    }
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
    }
}