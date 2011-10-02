using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

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

                    hpkShowAll.Text += "(" + contestDAO.count() +")";
                    hpkShowMath.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_MATHEMATICS_CODE) + ")" ;
                    hpkShowPhy.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_PHYSICAL_CODE) + ")";
                    hpkShowChem.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_CHEMICAL_CODE) + ")";
                    hpkShowBio.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_BIOGRAPHY_CODE) + ")";
                    hpkShowLit.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_LITERATURE_CODE) + ")";
                    hpkShowHis.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_HISTORY_CODE) + ")";
                    hpkShowGeo.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_GEOGRAPHY_CODE) + ")";
                    hpkShowEng.Text += "(" + contestDAO.countArticleBySubject(CommonConstants.SUB_ENGLISH_CODE) + ")";

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

                if (key == CommonConstants.ALL)
                {
                    if (state == CommonConstants.ALL)// key = ALL and state = ALL
                    {
                        lst = contestDAO.fetchArticleList((page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.count();
                        hpkShowAllState.Text += "(" + totalRecord + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_UNCHECK.ToString())// key = ALL and state = UNCHECk
                    {
                        lst = contestDAO.fetchArticleList(CommonConstants.STATE_UNCHECK, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK);

                        hpkShowAllState.Text += "(" + contestDAO.count() + ")";
                        hpkShowUncheck.Text += "(" + totalRecord + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_CHECKED.ToString())// key = ALL and state = CHECKED
                    {
                        lst = contestDAO.fetchArticleList(CommonConstants.STATE_CHECKED, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleByState(CommonConstants.STATE_CHECKED);

                        hpkShowAllState.Text += "(" + contestDAO.count() + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + totalRecord + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_BAD.ToString())// key = ALL and state = BAD
                    {
                        lst = contestDAO.fetchArticleList(CommonConstants.STATE_BAD, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleByState(CommonConstants.STATE_BAD);

                        hpkShowAllState.Text += "(" + contestDAO.count() + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + totalRecord + ")";
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

                        hpkShowAllState.Text += "(" + totalRecord + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD) + ")"; 
                    }
                    else if (state == CommonConstants.STATE_UNCHECK.ToString())//key != ALL and state = UNCHECK
                    {
                        lst = contestDAO.fetchArticleList(sub.Trim(), CommonConstants.STATE_UNCHECK, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleBySubjectAndState(sub.Trim(),CommonConstants.STATE_UNCHECK);
                        hpkShowAllState.Text += "(" + contestDAO.countArticleBySubject(sub.Trim()) + ")";
                        hpkShowUncheck.Text += "(" + totalRecord + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD) + ")"; 
                    }
                    else if (state == CommonConstants.STATE_CHECKED.ToString())//key != ALL and state = CHECKED
                    {
                        lst = contestDAO.fetchArticleList(sub.Trim(), CommonConstants.STATE_CHECKED, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED);
                        hpkShowAllState.Text += "(" + contestDAO.countArticleBySubject(sub.Trim()) + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + totalRecord + ")";
                        hpkShowBad.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_BAD.ToString())//key != ALL and state = BAD
                    {
                        lst = contestDAO.fetchArticleList(sub.Trim(), CommonConstants.STATE_BAD, (page - 1) * NoOfContestPerPage, NoOfContestPerPage);
                        totalRecord = contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_BAD);

                        hpkShowAllState.Text += "(" + contestDAO.countArticleBySubject(sub.Trim()) + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + totalRecord + ")";
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
                        showContest(lst, totalRecord, page, action, key);
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
                string id = Request.QueryString[CommonConstants.REQ_ID];

            }
            else if (action == CommonConstants.ACT_DELETE)
            {
                string id = Request.QueryString[CommonConstants.REQ_ID];

            }

        }

        private void showContest (IEnumerable <tblContestForUniversity> lst, int totalContest, int page, string action, string key)
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
                                + key
                                + CommonConstants.AND
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