using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class English : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.BaseServices bs = new ltktDAO.BaseServices();
        ltktDAO.English englishDAO = new ltktDAO.English();
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
            bool isDeleted = false;
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
                    viewPanel.Visible = true;
                    detailPanel.Visible = false;
                    messagePanel.Visible = false;
                    IEnumerable<tblEnglish> lst = null;
                    string key = Request.QueryString[CommonConstants.REQ_KEY];
                    int totalRecord = 0;

                    hpkShowAll.Text += "(" + englishDAO.count() + ")";
                    hpkShow19.Text += "(" + englishDAO.countEnglishListWithClass(CommonConstants.AT_EL_CLASS_1_TO_9) +")";
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
                    
                    if (BaseServices.isNullOrBlank(key))
                    {
                        key = CommonConstants.ALL;
                    }
                    else
                    {
                        key = BaseServices.nullToBlank(key);
                    }
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
                    else
                    {
                        //change state link
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
                else if (action == CommonConstants.ACT_VIEW || action == CommonConstants.ACT_EDIT)
                {
                }
                else if (action == CommonConstants.ACT_DELETE)
                {
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
                                              + "1");
            }
            if (isDeleted)
            {
                Response.Redirect(CommonConstants.PAGE_ADMIN_INFORMATICS);
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
                                                                  CommonConstants.PAGE_ADMIN_UNIVERSITY,
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
                                                                     CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                     CommonConstants.ACT_EDIT,
                                                                     Convert.ToString(english.ID),
                                                                     CommonConstants.HTML_EDIT_ADMIN);

                actionCell.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_UNIVERSITY,
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
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        { }
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
        }
    }
}