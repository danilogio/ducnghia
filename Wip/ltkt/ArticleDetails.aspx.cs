using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using ltktDAO;

namespace ltkt
{
    public partial class ArticleDetails : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        ltktDAO.English englishDAO = new ltktDAO.English();
        ltktDAO.Contest contestDAO = new ltktDAO.Contest();
        ltktDAO.Control control = new ltktDAO.Control();
        BaseServices bs = new BaseServices();
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();
        ltktDAO.Statistics statisticsDAO = new ltktDAO.Statistics();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Title on header
            liTitle.Text += CommonConstants.SPACE + CommonConstants.HLINE
                                    + CommonConstants.SPACE
                                    + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

            //Turn on or off preview button
            if (adminDAO.isON(CommonConstants.AF_PREVIEW_ARTICLE))
                btnPreview.Visible = true;
            else
                btnPreview.Visible = false;


            try
            {
                pageLoad(sender, e);
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message
                                            + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }


            //if (Request.QueryString[CommonConstants.REQ_SECTION] != null)
            //{
            //    string sec = Request.QueryString[CommonConstants.REQ_SECTION];
            //    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

            //    if (checkDoOneTime(CommonConstants.LIKE, sec, id))
            //    {
            //        btnLike.Visible = false;
            //    }
            //    if (checkDoOneTime(CommonConstants.DISLIKE, sec, id))
            //    {
            //        btnDislike.Visible = false;
            //    }

            //    try
            //    {
            //        switch (sec)
            //        {
            //            case CommonConstants.SEC_UNIVERSITY_CODE:
            //                {
            //                    // do something
            //                    showContest(id);
            //                    break;
            //                }
            //            case CommonConstants.SEC_ENGLISH_CODE:
            //                {
            //                    // do something else
            //                    showEnglish(id);
            //                    break;
            //                }
            //            case CommonConstants.SEC_INFORMATICS_CODE:
            //                {
            //                    //do something
            //                    showInformatic(id);
            //                    break;
            //                }
            //            default:
            //                break;
            //        }

                    
            //    }
            //    catch (Exception ex)
            //    {
            //        tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            //        string username = CommonConstants.USER_GUEST;
            //        if (user != null)
            //        {
            //            username = user.Username;
            //        }

            //        log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

            //        Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
            //        Response.Redirect(CommonConstants.PAGE_ERROR);
            //    }

            //    if (txtPostedComment.Text == String.Empty)
            //    {
            //        txtPostedComment.Visible = false;
            //    }
            //    else
            //    {
            //        txtPostedComment.Visible = true;
            //    }

            //    if (Session[CommonConstants.SES_USER] != null)
            //    {
            //        nonUserPanel.Visible = false;
            //    }
            //    else
            //    {
            //        nonUserPanel.Visible = true;
            //    }
            //}
            //else
            //{
            //    viewArticle.Visible = false;
            //    commentPanel.Visible = false;
            //    relativePanel.Visible = false;
            //    invalidArticle.Visible = true;
            //    //20110911 TrungDV change create message START
            //    //liMessage.Text = "Bài viết này không có hoặc đã bị xóa!";
            //    //liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
            //    liMessage.Text = CommonConstants.MSG_RESOURCE_NOT_FOUND;
            //    liMessage.Text += CommonConstants.TEMP_BR_TAG
            //                        + CommonConstants.TEMP_BR_TAG
            //                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG,
            //                                                            CommonConstants.PAGE_HOME,
            //                                                            CommonConstants.TXT_BACK_TO_HOME);
            //    //20110911 TrungDV change create message END
            //}

        }

        private void pageLoad(object sender, EventArgs e)
        {
            if (Request.QueryString[CommonConstants.REQ_SECTION] != null)
            {
                string sec = Request.QueryString[CommonConstants.REQ_SECTION];
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                if (checkDoOneTime(CommonConstants.LIKE, sec, id))
                {
                    btnLike.Visible = false;
                }
                if (checkDoOneTime(CommonConstants.DISLIKE, sec, id))
                {
                    btnDislike.Visible = false;
                }


                switch (sec)
                {
                    case CommonConstants.SEC_UNIVERSITY_CODE:
                        {
                            // do something
                            showContest(id);
                            break;
                        }
                    case CommonConstants.SEC_ENGLISH_CODE:
                        {
                            // do something else
                            showEnglish(id);
                            break;
                        }
                    case CommonConstants.SEC_INFORMATICS_CODE:
                        {
                            //do something
                            showInformatic(id);
                            break;
                        }
                    default:
                        break;
                }


                //if (adminDAO.isON(CommonConstants.AF_COMMENT))
                //    showComment(txtPostedComment.Text);

                //if (txtPostedComment.Text == String.Empty)
                //{
                //    txtPostedComment.Visible = false;
                //}
                //else
                //{
                //    txtPostedComment.Visible = true;
                //}

                if (Session[CommonConstants.SES_USER] != null)
                {
                    nonUserPanel.Visible = false;
                }
                else
                {
                    nonUserPanel.Visible = true;
                }

            }
            else
            {
                viewArticle.Visible = false;
                commentPanel.Visible = false;
                relativePanel.Visible = false;
                invalidArticle.Visible = true;
                //20110911 TrungDV change create message START
                //liMessage.Text = "Bài viết này không có hoặc đã bị xóa!";
                //liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
                liMessage.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                liMessage.Text += CommonConstants.TEMP_BR_TAG
                                    + CommonConstants.TEMP_BR_TAG
                                    + BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG,
                                                                        CommonConstants.PAGE_HOME,
                                                                        CommonConstants.TXT_BACK_TO_HOME);
                //20110911 TrungDV change create message END
            }
        }

        private void showComment(string comments)
        {
            if (comments == null)
                comments = CommonConstants.BLANK;

            string[] arrComment = comments.Split(';');
            txtPostedComment.Text = CommonConstants.BLANK;

            foreach (string comment in arrComment)
            {
                if (!comment.StartsWith("*"))
                {
                    txtPostedComment.Text += comment;
                }
            }

            if (txtPostedComment.Text != CommonConstants.BLANK)
                txtPostedComment.Visible = true;
            else
                txtPostedComment.Visible = false;
        }

        public string createRatingBar(int score)
        {
            return bs.createRatingBar(score % 10, 10);
        }

        private void showContest(int id)
        {
            try
            {
                tblContestForUniversity contest = ltktDAO.Contest.getContest(id);
                if (contest != null)
                {
                    liTitle.Text = BaseServices.nullToBlank(contest.Title);

                    lblTitle.Text = BaseServices.nullToBlank(contest.Title);
                    lblLiker.Text = BaseServices.nullToBlank(contest.Point.ToString());

                    lblAuthor.Text = BaseServices.nullToBlank(ltktDAO.Contest.getAuthor(id));
                    lblPostedDate.Text = BaseServices.nullToBlank(bs.convertDateToString(contest.Posted));
                    lblChecker.Text = BaseServices.nullToBlank(contest.Checker);

                    lblOverview.Text = BaseServices.nullToBlank(contest.Contents.Replace("\n", "<br />"));

                    hpkDownloadlink.Text = BaseServices.nullToBlank(contest.Title);
                    hpkDownloadlink.NavigateUrl = BaseServices.nullToSharp(contest.Location.Replace("\\", "/"));

                    if (!BaseServices.isNullOrBlank(contest.Solving))
                    {
                        //lblResolve.Text = "<a href=\"" + contest.Solving.Replace("\\", "/") + "\">Hướng dẫn giải</a>";
                        lblResolve.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG,
                                                                        contest.Solving.Replace("\\", "/"),
                                                                        CommonConstants.TXT_RESOLVING);
                    }

                    //txtPostedComment.Text = BaseServices.nullToBlank(contest.Comment);
                    showComment(contest.Comment);
                    
                    int numberRecordRelative = control.getValueByInt(CommonConstants.CF_NUM_RECORD_RELATIVE);
                    IList<tblContestForUniversity> items = contestDAO.getRelativeByYear(contest.Year, numberRecordRelative);
                    lblRelative.Text = "<ul>";
                    for (int i = 0; i < items.Count; i++)
                    {
                        //20110911 TrungDV change creation relative START
                        string temp = CommonConstants.BLANK;
                        temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK, CommonConstants.SEC_UNIVERSITY_CODE, items[i].ID.ToString(), items[i].Title.Trim());
                        temp += "(" + items[i].Posted + ")";
                        lblRelative.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, temp);

                        /*lblRelative.Text += "<li>";
                        lblRelative.Text += "<a href='ArticleDetails.aspx?sec=el&id=" + items[i].ID + "'>" + items[i].Title.Trim() + "</a>";
                        lblRelative.Text += "(" + items[i].Posted + ")";
                        lblRelative.Text += "</li>";*/
                        //20110911 TrungDV change creation relative END
                    }
                    lblRelative.Text += "</ul>";

                    int score = contestDAO.getScore(id);
                    lRatingBar.Text = createRatingBar(score);

                }
                else
                {
                    viewArticle.Visible = false;
                    commentPanel.Visible = false;
                    relativePanel.Visible = false;
                    invalidArticle.Visible = true;
                    lRatingBar.Visible = false;
                    //20110911 TrungDV change create message START
                    //liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
                    liMessage.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                    liMessage.Text += CommonConstants.TEMP_BR_TAG
                                        + CommonConstants.TEMP_BR_TAG
                                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG,
                                                                            CommonConstants.PAGE_HOME,
                                                                            CommonConstants.TXT_BACK_TO_HOME);
                    //20110911 TrungDV change create message END
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message
                                            + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        private void showEnglish(int id)
        {
            try
            {
                tblEnglish english = ltktDAO.English.getEnglish(id);
                if (english != null)
                {
                    liTitle.Text = BaseServices.nullToBlank(english.Title);

                    lblTitle.Text = BaseServices.nullToBlank(english.Title);
                    lblLiker.Text = english.Point.ToString();

                    lblAuthor.Text = BaseServices.nullToBlank(ltktDAO.English.getAuthor(id));
                    lblPostedDate.Text = BaseServices.nullToBlank(bs.convertDateToString(english.Posted));
                    lblChecker.Text = BaseServices.nullToBlank(english.Checker);

                    lblOverview.Text = BaseServices.nullToBlank(english.Contents.Replace("\n", "<br />"));

                    hpkDownloadlink.Text = BaseServices.nullToBlank(english.Title);
                    hpkDownloadlink.NavigateUrl = BaseServices.nullToSharp(english.Location.Replace("\\", "/"));

                    IList<tblEnglish> items = englishDAO.getRelativeByType(english.Type, CommonConstants.DEFAULT_NUMBER_RECORD_RELATIVE);
                    lblRelative.Text = "<ul>";
                    for (int i = 0; i < items.Count; i++)
                    {
                        //20110911 TrungDV change creation relative START
                        string temp = CommonConstants.BLANK;
                        temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK, CommonConstants.SEC_ENGLISH_CODE, items[i].ID.ToString(), items[i].Title.Trim());
                        temp += "(" + items[i].Posted + ")";
                        lblRelative.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, temp);

                        /*lblRelative.Text += "<li>";
                        lblRelative.Text += "<a href='ArticleDetails.aspx?sec=el&id=" + items[i].ID + "'>" + items[i].Title.Trim() + "</a>";
                        lblRelative.Text += "(" + items[i].Posted + ")";
                        lblRelative.Text += "</li>";*/
                        //20110911 TrungDV change creation relative END
                    }
                    lblRelative.Text += "</ul>";

                    //txtPostedComment.Text = BaseServices.nullToBlank(english.Comment);
                    showComment(english.Comment);

                    int score = englishDAO.getScore(id);
                    lRatingBar.Text = createRatingBar(score);

                }
                else
                {
                    viewArticle.Visible = false;
                    commentPanel.Visible = false;
                    relativePanel.Visible = false;
                    invalidArticle.Visible = true;
                    lRatingBar.Visible = false;

                    //20110911 TrungDV change creation relative START
                    //liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
                    liMessage.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                    liMessage.Text += CommonConstants.TEMP_BR_TAG
                                        + CommonConstants.TEMP_BR_TAG
                                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG,
                                                                            CommonConstants.PAGE_HOME,
                                                                            CommonConstants.TXT_BACK_TO_HOME);
                    //20110911 TrungDV change creation relative END
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message
                                            + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        private void showInformatic(int id)
        {
            try
            {
                tblInformatic informatic = ltktDAO.Informatics.getInformatic(id);
                if (informatic != null)
                {
                    liTitle.Text = BaseServices.nullToBlank(informatic.Title);

                    lblTitle.Text = BaseServices.nullToBlank(informatic.Title);
                    lblLiker.Text = BaseServices.nullToBlank(informatic.Point.ToString());

                    lblAuthor.Text = BaseServices.nullToBlank(ltktDAO.Informatics.getAuthor(id));
                    lblPostedDate.Text = BaseServices.nullToBlank(bs.convertDateToString(informatic.Posted));
                    lblChecker.Text = BaseServices.nullToBlank(informatic.Checker);

                    lblOverview.Text = BaseServices.nullToBlank(informatic.Contents.Replace("\n", "<br />"));

                    hpkDownloadlink.Text = BaseServices.nullToBlank(informatic.Title);
                    hpkDownloadlink.NavigateUrl = BaseServices.nullToSharp(informatic.Location.Replace("\\", "/"));

                    int numberRelativeRecord = control.getValueByInt(CommonConstants.CF_NUM_RECORD_RELATIVE);

                    IList<tblInformatic> items = informaticsDAO.getRelativeByType(informatic.Type, numberRelativeRecord);
                    lblRelative.Text = "<ul>";
                    for (int i = 0; i < items.Count; i++)
                    {
                        //20110911 TrungDV change creation relative START
                        string temp = CommonConstants.BLANK;
                        temp = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                                CommonConstants.SEC_INFORMATICS_CODE,
                                                                items[i].ID.ToString(),
                                                                items[i].Title.Trim());
                        temp += "(" + items[i].Posted + ")";
                        lblRelative.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, temp);

                        /*lblRelative.Text += "<li>";
                        lblRelative.Text += "<a href='ArticleDetails.aspx?sec=it&id=" + items[i].ID + "'>" + items[i].Title.Trim() + "</a>";
                        lblRelative.Text += "(" + items[i].Posted + ")";
                        lblRelative.Text += "</li>";*/
                        //20110911 TrungDV change creation relative END
                    }
                    lblRelative.Text += "</ul>";


                    //txtPostedComment.Text = informatic.Comment;
                    showComment(informatic.Comment);


                    int score = informaticsDAO.getScore(id);
                    lRatingBar.Text = createRatingBar(score);

                }
                else
                {
                    viewArticle.Visible = false;
                    commentPanel.Visible = false;
                    relativePanel.Visible = false;
                    invalidArticle.Visible = true;
                    //20110911 TrungDV change creation relative START
                    //liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
                    liMessage.Text = CommonConstants.MSG_E_RESOURCE_NOT_FOUND;
                    liMessage.Text += CommonConstants.TEMP_BR_TAG
                                        + CommonConstants.TEMP_BR_TAG
                                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG,
                                                                            CommonConstants.PAGE_HOME,
                                                                            CommonConstants.TXT_BACK_TO_HOME);
                    //20110911 TrungDV change creation relative END
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message
                                            + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        protected void hpkDownloadLink_PreRender(object sender, EventArgs e)
        {

        }

        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            string author = CommonConstants.BLANK;
            string date = CommonConstants.BLANK;
            string comment = CommonConstants.BLANK;
            string newComment = CommonConstants.BLANK;
            string currentUser = CommonConstants.BLANK;
            
            
            try
            {
                if (Session[CommonConstants.SES_USER] != null)
                {
                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    author = BaseServices.nullToBlank(user.DisplayName);
                    currentUser = BaseServices.nullToBlank(user.Username);
                }
                else
                {
                    author = BaseServices.nullToBlank(txtName.Text);
                    currentUser = BaseServices.nullToBlank(author);
                }

                date = bs.convertDateToString(DateTime.Now);
                comment = txtContent.Text.Replace(CommonConstants.NEWLINE, CommonConstants.TEMP_BR_TAG);

                //newComment += "<span>";
                //newComment += "<b>" + author + "</b>" + " (" + date + ")";
                //newComment += "<br />";
                //newComment += comment;
                //newComment += "</span>";

                newComment = BaseServices.createMsgByTemplate(CommonConstants.TEMP_B_TAG, author);
                newComment += " (" + date + ")";
                newComment += CommonConstants.TEMP_BR_TAG;
                newComment += comment;
                newComment = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SPAN_TAG, newComment);

                if (!adminDAO.isON (CommonConstants.AF_COMMENT_EASY))
                    newComment = "*" + newComment;

                // Write comment to db
                string sec = Request.QueryString[CommonConstants.REQ_SECTION];
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                switch (sec)
                {
                    case CommonConstants.SEC_UNIVERSITY_CODE:
                        {
                            contestDAO.insertComment(id, newComment);
                            break;
                        }
                    case CommonConstants.SEC_ENGLISH_CODE:
                        {
                            englishDAO.insertComment(id, newComment);
                            break;
                        }
                    case CommonConstants.SEC_INFORMATICS_CODE:
                        {
                            informaticsDAO.insertComment(id, newComment, currentUser);
                            break;
                        }
                    default:
                        break;
                }

                statisticsDAO.add(CommonConstants.SF_NUM_COMMENT_A_DAY, "1");

                txtName.Text = CommonConstants.BLANK;
                txtEmail.Text = CommonConstants.BLANK; ;
                txtContent.Text = CommonConstants.BLANK; ;

                //Response.Redirect(CommonConstants.PAGE_ARTICLE_DETAILS
                //                   + CommonConstants.ADD_PARAMETER
                //                   + CommonConstants.REQ_SECTION
                //                   + CommonConstants.EQUAL
                //                   + sec
                //                   + CommonConstants.AND
                //                   + CommonConstants.REQ_ID
                //                   + CommonConstants.EQUAL
                //                   + Convert.ToString(id));
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message
                                            + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            //txtName.Text = CommonConstants.BLANK;
            //txtEmail.Text = CommonConstants.BLANK; ;
            //txtContent.Text = CommonConstants.BLANK; ;

            //Page_Load(sender, e);
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            try
            {
                //// Write comment to db
                string sec = Request.QueryString[CommonConstants.REQ_SECTION];
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                //Check article haven't liked before
                if (!checkDoOneTime(CommonConstants.LIKE, sec, id))
                {
                    switch (sec)
                    {
                        case CommonConstants.SEC_UNIVERSITY_CODE:
                            {
                                contestDAO.Like(id);
                                updateCookie(CommonConstants.LIKE, sec, id);
                                btnLike.Visible = false;
                                break;
                            }
                        case CommonConstants.SEC_ENGLISH_CODE:
                            {
                                englishDAO.Like(id);
                                updateCookie(CommonConstants.LIKE, sec, id);
                                btnLike.Visible = false;
                                break;
                            }
                        case CommonConstants.SEC_INFORMATICS_CODE:
                            {
                                informaticsDAO.Like(id);
                                updateCookie(CommonConstants.LIKE, sec, id);
                                btnLike.Visible = false;
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    btnLike.Visible = false;
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            Page_Load(sender, e);
        }

        private bool checkDoOneTime(string type, string sec, int id)
        {
            //uni:1,2,3,4
            //it:1,2,3,4
            //el:1,2,3,4
            string str = readCookie(type + sec);
            switch (sec)
            {
                case CommonConstants.SEC_UNIVERSITY_CODE:
                    {
                        if (Request.Cookies[type + sec] != null && str != null)
                        {
                            if (str.Contains(id.ToString()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                        break;
                    }
                case CommonConstants.SEC_ENGLISH_CODE:
                    {
                        if (Request.Cookies[type + sec] != null && str != null)
                        {
                            if (str.Contains(id.ToString()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                        break;
                    }
                case CommonConstants.SEC_INFORMATICS_CODE:
                    {
                        if (Request.Cookies[type + sec] != null && str != null)
                        {
                            if (str.Contains(id.ToString()))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                        break;
                    }
            }
            return false;
        }

        private void updateCookie(string type, string sec, int id)
        {
            //update
            if (Request.Cookies[type + sec] != null)
            {
                string str = readCookie(type + sec);
                str += id.ToString() + CommonConstants.COMMA;
                writeCookie(type + sec, str);
            }
            else //write new
            {
                writeCookie(type + sec, id.ToString());
            }
        }

        //Do not use this method directly
        private string readCookie(string name)
        {
            if (Request.Cookies[name] != null)
            {
                return Server.HtmlEncode(Request.Cookies[name].Value);
            }
            return CommonConstants.BLANK;
        }

        //Do not use this method directly
        private void writeCookie(string name, string value)
        {
            Response.Cookies[name].Value = value;
            //Response.Cookies[name].Domain = "www.luyenthikinhte.com";
            Response.Cookies[name].Expires = DateTime.Now.AddDays(14);
        }

        protected void btnDislike_Click(object sender, EventArgs e)
        {
            // Write comment to db
            try
            {
                string sec = Request.QueryString[CommonConstants.REQ_SECTION];
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                //Check article haven't disliked before
                if (!checkDoOneTime(CommonConstants.DISLIKE, sec, id))
                {
                    switch (sec)
                    {
                        case CommonConstants.SEC_UNIVERSITY_CODE:
                            {
                                contestDAO.Dislike(id);
                                updateCookie(CommonConstants.DISLIKE, sec, id);
                                btnDislike.Visible = false;
                                break;
                            }
                        case CommonConstants.SEC_ENGLISH_CODE:
                            {
                                englishDAO.Dislike(id);
                                updateCookie(CommonConstants.DISLIKE, sec, id);
                                btnDislike.Visible = false;
                                break;
                            }
                        case CommonConstants.SEC_INFORMATICS_CODE:
                            {
                                informaticsDAO.Dislike(id);
                                updateCookie(CommonConstants.DISLIKE, sec, id);
                                btnDislike.Visible = false;
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {
                    btnDislike.Visible = false;
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            Page_Load(sender, e);
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (previewPanel.Visible == true)
            {
                previewPanel.Visible = false;
            }
            else
            {
                previewPanel.Visible = true;
            }
        }
    }
}