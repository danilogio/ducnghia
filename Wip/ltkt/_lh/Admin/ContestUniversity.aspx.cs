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
        ltktDAO.EventLog log = new EventLog();

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
                if (Page.IsPostBack)
                {
                    return;
                }
                showCountingArticle();

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
                else if (key == CommonConstants.TXT_STICKY.ToLower())
                {
                    changeStateLink(key);
                    if (state == CommonConstants.ALL)// key == sticky and state = ALL
                    {
                        lst = contestDAO.fetchStickyContestList(((page - 1) * NoOfContestPerPage), NoOfContestPerPage);
                        totalRecord = contestDAO.countStickyArticle();
                        hpkShowAllState.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowAllState.Text + "(" + totalRecord + ")");
                        hpkShowBad.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_BAD) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_UNCHECK) + ")";

                    }
                    else if (state == CommonConstants.STATE_UNCHECK.ToString())// key == sticky and state = UNCHECk
                    {
                        lst = contestDAO.fetchStickyContestList(CommonConstants.STATE_UNCHECK, ((page - 1) * NoOfContestPerPage), NoOfContestPerPage);
                        totalRecord = contestDAO.countStickyContestList(CommonConstants.STATE_UNCHECK);
                        hpkShowAllState.Text += "(" + contestDAO.countStickyArticle() + ")";
                        hpkShowUncheck.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowUncheck.Text + "(" + totalRecord + ")");
                        hpkShowChecked.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_BAD) + ")";
                    }
                    else if (state == CommonConstants.STATE_CHECKED.ToString())// key = sticky and state = CHECKED
                    {
                        lst = contestDAO.fetchStickyContestList(CommonConstants.STATE_CHECKED, ((page - 1) * NoOfContestPerPage), NoOfContestPerPage);
                        totalRecord = contestDAO.countStickyContestList(CommonConstants.STATE_CHECKED);
                        hpkShowAllState.Text += "(" + contestDAO.countStickyArticle() + ")";
                        hpkShowBad.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_BAD) + ")";
                        hpkShowChecked.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowChecked.Text + "(" + totalRecord + ")");
                        hpkShowUncheck.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_UNCHECK) + ")";

                    }
                    else if (state == CommonConstants.STATE_BAD.ToString())// key = sticky and state = BAD
                    {
                        lst = contestDAO.fetchStickyContestList(CommonConstants.STATE_BAD, ((page - 1) * NoOfContestPerPage), NoOfContestPerPage);
                        totalRecord = contestDAO.countStickyContestList(CommonConstants.STATE_BAD);
                        hpkShowAllState.Text += "(" + contestDAO.countStickyArticle() + ")";
                        hpkShowUncheck.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_UNCHECK) + ")";
                        hpkShowChecked.Text += "(" + contestDAO.countStickyContestList(CommonConstants.STATE_CHECKED) + ")";
                        hpkShowBad.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowBad.Text + "(" + totalRecord + ")");

                    }
                }
                else //key != ALL
                {
                    changeStateLink(key);
                    string sub = key;
                    if (BaseServices.isNullOrBlank(sub))
                    {
                        sub = CommonConstants.SUB_MATHEMATICS_CODE;
                    }
                    
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
                        totalRecord = contestDAO.countArticleBySubjectAndState(sub.Trim(), CommonConstants.STATE_UNCHECK);
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
                if (Page.IsPostBack)
                {
                    return;
                }
                initial();
                viewPanel.Visible = false;
                detailPanel.Visible = true;
                messagePanel.Visible = false;
                Session[CommonConstants.SES_OLD_PAGE] = Request.UrlReferrer.ToString();
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
                txtFolderId.Text = cont.FolderID;
                txtLocation.Text = cont.Location;
                txtSolve.Text = cont.Solving;
                txtComment.Text = cont.Comment;
                showState(cont.State);
                showSticky(cont.StickyFlg);
                showContestType(cont.isUniversity);
                showBranch(cont.Branch);
                showSubject(cont.Subject);
                showYear(cont.Year);
                txtContent.Text = BaseServices.nullToBlank(cont.Contents);
                txtTag.Text = BaseServices.nullToBlank(cont.Tag);
                txtPoint.Text = Convert.ToString(cont.Point);
                ddlScore.SelectedValue = cont.Score.ToString();
                //txtScore.Text = Convert.ToString(cont.Score);
                showFileContent(cont.Location);
                showFileSolving(cont.Solving);
                showThumbnail(cont.Thumbnail);
                txtHtmlEmbed.Text = BaseServices.nullToBlank(cont.HtmlEmbedLink);
                txtHtmlPreview.Text = BaseServices.nullToBlank(cont.HtmlPreview);
                txtChecker.Text = cont.Checker;
            }
            else
            {
                detailPanel.Visible = false;
                showErrorMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
            }

            //enable or disable for edit
            if (action == CommonConstants.ACT_VIEW)
            {
                Session[CommonConstants.SES_EDIT_CONTEST] = null;
                disableEdit();
            }
            else if (action == CommonConstants.ACT_EDIT)
            {
                Session[CommonConstants.SES_EDIT_CONTEST] = cont;
                enableEdit();
            }
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

        private void showFileSolving(string location)
        {
            if (File.Exists(DBHelper.strCurrentPath + location))
            {
                liSolving.Text = "&nbsp;&nbsp;<br /><input type=\"button\" value=\"Mở\" class=\"formbutton\" onclick=\"openFile('../../" + location.Replace("\\", "/") + "')\"/>";
            }
            else
                liSolving.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
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
            //txtScore.ReadOnly = true;
            liContent.Text += "&nbsp;&nbsp;<input type=\"button\" disabled=\"disabled\" value=\"Tải tập tin nội dung\" class=\"formbutton\" onclick=\"uploadContent()\" />";
            liSolving.Text += "&nbsp;&nbsp;<input type=\"button\" disabled=\"disabled\" value=\"Tải tập tin hướng dẫn\" class=\"formbutton\" onclick=\"uploadSolving()\" />";
            liThumbnail.Text += "&nbsp;&nbsp;<input type=\"button\" disabled=\"disabled\" value=\"Tải hình thu nhỏ\" class=\"formbutton\" onclick=\"uploadThumbnail()\" />";
            txtHtmlEmbed.ReadOnly = true;
            txtHtmlPreview.ReadOnly = true;
        }

        private void enableEdit()
        {
            txtTitle.ReadOnly = false;
            //txtAuthor.ReadOnly = false;
            //txtPosted.ReadOnly = false;
            ddlState.Enabled = true;
            ddlSticky.Enabled = true;
            ddlType.Enabled = true;
            ddlBranch.Enabled = true;
            ddlSubject.Enabled = true;
            ddlYear.Enabled = true;
            txtContent.ReadOnly = false;
            txtTag.ReadOnly = false;
            //txtPoint.ReadOnly = false;
            //txtScore.ReadOnly = false;
            liContent.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải tập tin nội dung\" class=\"formbutton\" onclick=\"uploadContent()\" />";
            liSolving.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải tập tin hướng dẫn\" class=\"formbutton\" onclick=\"uploadSolving()\" />";
            liThumbnail.Text += "&nbsp;&nbsp;<input type=\"button\" value=\"Tải hình thu nhỏ\" class=\"formbutton\" onclick=\"uploadThumbnail()\" />";
            txtHtmlEmbed.ReadOnly = false;
            txtHtmlPreview.ReadOnly = false;
        }
        private void initial()
        {
            //ddlState.Items.Add(new ListItem(CommonConstants.STATE_UNCHECK_NAME, CommonConstants.STATE_UNCHECK.ToString()));
            //ddlState.Items.Add(new ListItem(CommonConstants.STATE_CHECKED_NAME, CommonConstants.STATE_CHECKED.ToString()));
            //ddlState.Items.Add(new ListItem(CommonConstants.STATE_BAD_NAME, CommonConstants.STATE_BAD.ToString()));
            //Sticky
            //ddlSticky.Items.Add(new ListItem(CommonConstants.TXT_UNSTICKY, CommonConstants.CONST_ZERO));
            //ddlSticky.Items.Add(new ListItem(CommonConstants.TXT_STICKY, CommonConstants.CONST_ONE));
            //Type
            //ddlType.Items.Add(new ListItem(CommonConstants.TXT_PLEASE_SELECT, CommonConstants.CONST_ONE_NEGATIVE));
            //ddlType.Items.Add(new ListItem(CommonConstants.AT_LECTURE_NAME.ToString(), CommonConstants.AT_LECTURE.ToString()));
            //ddlType.Items.Add(new ListItem(CommonConstants.AT_PRACTISE_NAME, CommonConstants.AT_PRACTISE.ToString()));
            //ddlType.Items.Add(new ListItem(CommonConstants.AT_EXAM_NAME, CommonConstants.AT_EXAM.ToString()));
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
        }
        private void showContest(IEnumerable<tblContestForUniversity> lst, int totalContest, int page, string action, string key, string state)
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
                                                                  Convert.ToString(contest.ID),
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
                                                                     Convert.ToString(contest.ID),
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
                string totatRecord = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, totalContest.ToString());
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
            subject = subject.ToLower();
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
                case CommonConstants.TXT_STICKY_TOLOWER:
                    {
                        hpkShowSticky.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, hpkShowSticky.Text);
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
        protected void btnClear_Click(object sender, EventArgs e)
        {
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text;
            int page = 1;
            if (!BaseServices.isNullOrBlank(keyword))
            {
                int totalRecord = contestDAO.countArticles(keyword);

                IEnumerable<tblContestForUniversity> lst = contestDAO.searchArticles(keyword, ((page - 1) * NoOfContestPerPage), NoOfContestPerPage);
                if (lst.Count() > 0)
                {
                    ContestTable.Visible = true;
                    messagePanel.Visible = false;
                    showContest(lst, totalRecord, page, CommonConstants.ACT_SEARCH_FREE, keyword, CommonConstants.ALL);
                    resetDefaultLabel();
                    showCountingArticle();
                    showCountingState();
                }
                else
                {
                    //Session[CommonConstants.SES_INFORM] = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                    //Response.Redirect(CommonConstants.PAGE_ADMIN_contest);
                    showInfoMessage(CommonConstants.MSG_E_RESOURCE_NOT_FOUND);
                    ContestTable.Visible = false;
                    return;
                }
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_OLD_PAGE] != null)
            {
                Response.Redirect((string)Session[CommonConstants.SES_OLD_PAGE]);
            }
            else
            {
                Response.Redirect(CommonConstants.PAGE_ADMIN_UNIVERSITY);
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                tblContestForUniversity cont = (tblContestForUniversity)Session[CommonConstants.SES_EDIT_CONTEST];

                string _title = txtTitle.Text;
                int _state = int.Parse(ddlState.SelectedValue);
                bool _isSticky = bool.Parse(ddlSticky.SelectedValue);
                bool _isUniversity = bool.Parse(ddlType.SelectedValue);
                int _branch = int.Parse(ddlBranch.SelectedValue);
                string _sub = ddlSubject.SelectedValue;
                int _year = int.Parse(ddlYear.SelectedValue);
                string _content = txtContent.Text;
                string _tag = txtTag.Text;
                int _score = BaseServices.convertStringToInt(ddlScore.SelectedValue);
                string checker = CommonConstants.BLANK;
                //get checker when score > 0.
                if (_score != 0)
                {
                    if (BaseServices.isNullOrBlank(txtChecker.Text))
                    {
                        checker = getCurrentUser();
                    }
                    else
                    {
                        checker = txtChecker.Text.Trim();
                    }
                }
                else
                {
                    checker = null;
                }
                string _htmlPreview = txtHtmlPreview.Text;
                string _htmlEmbed = txtHtmlEmbed.Text;
                string _fileContentSave = BaseServices.nullToBlank(cont.Location);
                string _fileSolvingSave = BaseServices.nullToBlank(cont.Solving);
                string _fileThumbnailSave = BaseServices.nullToBlank(cont.Thumbnail);
                
                string _fileContent = CommonConstants.BLANK;
                string _fileSolving = CommonConstants.BLANK;
                string _fileThumbnail = CommonConstants.BLANK;

                string rootFolder = Server.MapPath("~") + "/" + CommonConstants.FOLDER_UNI + "/" + _year;
                rootFolder += "/" + bs.getSubjectFolder(_sub);


                bool _fileContentGood = false;
                bool _fileSolvingGood = false;
                bool _fileThumbnailGood = false;
                //string newFileName = CommonConstants.BLANK;
                string fileTypes = control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);
                
                //size in MB
                int fileSizeMax = control.getValueByInt(CommonConstants.CF_MAX_FILE_SIZE); ;
                fileSizeMax = 1024 * 1024 * fileSizeMax;

                if (fileContent.HasFile)
                {
                    //check file existed: keep both
                    _fileContent = bs.fileNameToSave(rootFolder + "/" + fileContent.FileName);
                    //filename = newFileName;

                    //check filetype
                    // fileTypes = control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);
                    if (!bs.checkFileType(fileContent.FileName, fileTypes))
                    {
                        showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_NOT_ALLOW);
                        return;
                    }
                    //check filesize max (MB)
                    //fileSizeMax = control.getValueByInt(CommonConstants.CF_MAX_FILE_SIZE);
                    //fileSizeMax = 1024 * 1024* fileSizeMax;
                    if (fileContent.PostedFile.ContentLength > fileSizeMax)
                    {
                        showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_TOO_LARGE);
                        return;
                    }
                    _fileContentSave = _fileContent.Substring(_fileContent.LastIndexOf(CommonConstants.FOLDER_DATA));
                    _fileContentGood = true;
                }
                else
                {
                    if (_fileContentSave.LastIndexOf("/") >0)
                        _fileContent = rootFolder + _fileContentSave.Substring(_fileContentSave.LastIndexOf("/"));
                    else
                        _fileContent = rootFolder + _fileContentSave.Substring(_fileContentSave.LastIndexOf("\\"));
                    
                    if (!File.Exists(_fileContent))
                    {
                        string src = Server.MapPath("~") + "/" + _fileContentSave;
                        File.Copy(src, _fileContent);
                        File.Delete(src);
                        _fileContentSave = _fileContent.Substring(_fileContent.LastIndexOf(CommonConstants.FOLDER_DATA));
                    }
                }

                if (fileSolving.HasFile)
                {
                    //check file existed: keep both
                    _fileSolving = Path.GetFileNameWithoutExtension(_fileContentSave) +
                                "_solved" + Path.GetExtension(fileSolving.FileName);

                    _fileSolving = bs.fileNameToSave(rootFolder + "/" + _fileSolving);
                    //filename = rootFolder + newFileName;

                    //check filetype
                    // fileTypes = control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);
                    if (!bs.checkFileType(fileSolving.FileName, fileTypes))
                    {
                        showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_NOT_ALLOW);
                        return;
                    }
                    //check filesize max (MB)
                    //fileSizeMax = control.getValueByInt(CommonConstants.CF_MAX_FILE_SIZE);
                    //fileSizeMax = 1024 * 1024 * fileSizeMax;
                    if (fileSolving.PostedFile.ContentLength > fileSizeMax)
                    {
                        showErrorMessage(CommonConstants.MSG_E_FILE_SIZE_IS_TOO_LARGE);
                        return;
                    }
                    _fileSolvingSave = _fileSolving.Substring(_fileContent.LastIndexOf(CommonConstants.FOLDER_DATA));
                    _fileSolvingGood = true;
                }
                else if (_fileSolvingSave != CommonConstants.BLANK)
                {
                    if (_fileSolvingSave.LastIndexOf("/") > 0)
                        _fileSolving = rootFolder + _fileSolvingSave.Substring(_fileSolvingSave.LastIndexOf("/"));
                    else
                        _fileSolving = rootFolder + _fileSolvingSave.Substring(_fileSolvingSave.LastIndexOf("\\"));

                    if (!File.Exists(_fileSolving))
                    {
                        string src = Server.MapPath("~") + "/" + _fileSolvingSave;
                        File.Copy(src, _fileSolving);
                        File.Delete(src);
                        _fileSolvingSave = _fileSolving.Substring(_fileSolving.LastIndexOf(CommonConstants.FOLDER_DATA));
                    }
                }

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
                        }
                    }
                }

                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                bool isOK = contestDAO.updateContest(cont.ID, user.Username,
                                                        _title,
                                                        _state,
                                                        _isSticky,
                                                        _isUniversity,
                                                        _branch,
                                                        _sub,
                                                        _year,
                                                        _content,
                                                        _tag,
                                                        _score,
                                                        _fileContentSave,
                                                        _fileSolvingSave,
                                                        _fileThumbnailSave,
                                                        _htmlPreview,
                                                        _htmlEmbed,
                                                        checker);

                if (isOK)
                {

                    if (_fileContentGood)
                    {
                        string folder = Path.GetDirectoryName (_fileContent);
                        if(!Directory.Exists (folder))
                            Directory.CreateDirectory (folder);

                        fileContent.SaveAs (_fileContent);
                    }

                    if (_fileSolvingGood)
                    {
                        string folder = Path.GetDirectoryName(_fileSolving);
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        fileSolving.SaveAs(_fileSolving);
                    }

                    if (_fileThumbnailGood)
                    {
                        string folder = Path.GetDirectoryName(_fileThumbnail);
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        fileThumbnail.SaveAs(_fileThumbnail);
                    }
                }
                else
                {
                    
                }

                Session[CommonConstants.SES_EDIT_CONTEST] = null;

            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];

                log.writeLog(Server.MapPath(CommonConstants.PATH_ADMIN_LOG_FILE), user.Username, ex.Message
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.Source
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.StackTrace
                                                                                        + CommonConstants.NEWLINE
                                                                                        + ex.HelpLink);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Response.Redirect(CommonConstants.PAGE_ADMIN_UNIVERSITY);
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
        /// change state of link
        /// </summary>
        /// <param name="key"></param>
        private void changeStateLink(string key)
        {
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

        }
        /// <summary>
        /// count by class
        /// </summary>
        private void showCountingArticle()
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
            hpkShowSticky.Text += "(" + contestDAO.countStickyArticle() + ")";
        }
        /// <summary>
        /// reset all label to default value
        /// </summary>
        private void resetDefaultLabel()
        {

            hpkShowAll.Text = CommonConstants.TXT_ALL;
            hpkShowMath.Text = CommonConstants.SUB_MATHEMATICS + CommonConstants.SPACE;
            hpkShowPhy.Text = CommonConstants.SUB_PHYSICAL + CommonConstants.SPACE;
            hpkShowChem.Text = CommonConstants.SUB_CHEMICAL + CommonConstants.SPACE;
            hpkShowBio.Text = CommonConstants.SUB_BIOGRAPHY + CommonConstants.SPACE;
            hpkShowSticky.Text = CommonConstants.TXT_STICKY + CommonConstants.SPACE;
            hpkShowAllState.Text = CommonConstants.TXT_ALL + CommonConstants.SPACE;
            hpkShowBad.Text = CommonConstants.STATE_BAD_NAME + CommonConstants.SPACE;
            hpkShowChecked.Text = CommonConstants.STATE_CHECKED_NAME + CommonConstants.SPACE;
            hpkShowUncheck.Text = CommonConstants.STATE_UNCHECK_NAME + CommonConstants.SPACE;

        }
        /// <summary>
        /// count by state
        /// </summary>
        private void showCountingState()
        {
            hpkShowAllState.Text += "(" + contestDAO.count() + ")";
            hpkShowBad.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_BAD) + ")";
            hpkShowChecked.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_CHECKED) + ")";
            hpkShowUncheck.Text += "(" + contestDAO.countArticleByState(CommonConstants.STATE_UNCHECK) + ")";

        }
    }
}