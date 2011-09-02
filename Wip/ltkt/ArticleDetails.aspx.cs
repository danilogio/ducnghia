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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[CommonConstants.REQ_SECTION] != null)
            {
                string sec = Request.QueryString[CommonConstants.REQ_SECTION];
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                
                if (checkDoOneTime(CommonConstants.LIKE, sec, id))
                {
                    btnLike.Visible = false;
                }
                if( checkDoOneTime(CommonConstants.DISLIKE, sec, id))
                {
                    btnDislike.Visible = false;
                }
                
                try
                {
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
                }
                catch (Exception ex)
                {
                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    string username = CommonConstants.USER_GUEST;
                    if (user != null)
                    {
                        username = user.Username;
                    }

                    log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                    Response.Redirect(CommonConstants.PAGE_ERROR);
                }

                if (txtPostedComment.Text == String.Empty)
                {
                    txtPostedComment.Visible = false;
                }
                else
                {
                    txtPostedComment.Visible = true;
                }

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
                liMessage.Text = "Bài viết này không có hoặc đã bị xóa!";
                liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
            }

        }

        private void showContest(int id)
        {
            try
            {
                tblContestForUniversity contest = ltktDAO.Contest.getContest(id);
                if (contest != null)
                {
                    liTitle.Text = contest.Title;

                    lblTitle.Text = contest.Title;
                    lblLiker.Text = contest.Point.ToString();

                    lblAuthor.Text = ltktDAO.Contest.getAuthor(id);
                    lblPostedDate.Text = ltktDAO.BaseServices.convertDateToString(contest.Posted);
                    lblChecker.Text = contest.Checker;

                    lblOverview.Text = contest.Contents.Replace("\n", "<br />");

                    hpkDownloadlink.Text = contest.Title;
                    hpkDownloadlink.NavigateUrl = contest.Location.Replace("\\", "/");

                    if (contest.Solving != null)
                    {
                        lblResolve.Text = "<a href=\"" + contest.Solving.Replace("\\", "/") + "\">Hướng dẫn giải</a>";
                    }

                    txtPostedComment.Text = contest.Comment;

                    IList<tblContestForUniversity> items = contestDAO.getRelativeByYear(contest.Year, CommonConstants.NUMBER_RECORD_RELATIVE);
                    lblRelative.Text = "<ul>";
                    for (int i = 0; i < items.Count; i++)
                    {
                        lblRelative.Text += "<li>";
                        lblRelative.Text += "<a href='ArticleDetails.aspx?sec=uni&id=" + items[i].ID + "'>" + items[i].Title.Trim() + "</a>";
                        lblRelative.Text += "(" + items[i].Posted + ")";
                        lblRelative.Text += "</li>";
                    }
                    lblRelative.Text += "</ul>";

                }
                else
                {
                    viewArticle.Visible = false;
                    commentPanel.Visible = false;
                    relativePanel.Visible = false;
                    invalidArticle.Visible = true;
                    liMessage.Text = "Bài viết này không có hoặc đã bị xóa!";
                    liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
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

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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
                    liTitle.Text = english.Title;

                    lblTitle.Text = english.Title;
                    lblLiker.Text = english.Point.ToString();

                    lblAuthor.Text = ltktDAO.English.getAuthor(id);
                    lblPostedDate.Text = ltktDAO.BaseServices.convertDateToString(english.Posted);
                    lblChecker.Text = english.Checker;

                    lblOverview.Text = english.Contents.Replace("\n", "<br />");

                    hpkDownloadlink.Text = english.Title;
                    hpkDownloadlink.NavigateUrl = english.Location.Replace("\\", "/");

                    IList<tblEnglish> items = englishDAO.getRelativeByType(english.Type, CommonConstants.NUMBER_RECORD_RELATIVE);
                    lblRelative.Text = "<ul>";
                    for (int i = 0; i < items.Count; i++)
                    {
                        lblRelative.Text += "<li>";
                        lblRelative.Text += "<a href='ArticleDetails.aspx?sec=el&id=" + items[i].ID + "'>" + items[i].Title.Trim() + "</a>";
                        lblRelative.Text += "(" + items[i].Posted + ")";
                        lblRelative.Text += "</li>";
                    }
                    lblRelative.Text += "</ul>";

                    txtPostedComment.Text = english.Comment;

                }
                else
                {
                    viewArticle.Visible = false;
                    commentPanel.Visible = false;
                    relativePanel.Visible = false;
                    invalidArticle.Visible = true;
                    liMessage.Text = "Bài viết này không có hoặc đã bị xóa!";
                    liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
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

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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
                    liTitle.Text = informatic.Title;

                    lblTitle.Text = informatic.Title;
                    lblLiker.Text = informatic.Point.ToString();

                    lblAuthor.Text = ltktDAO.Informatics.getAuthor(id);
                    lblPostedDate.Text = ltktDAO.BaseServices.convertDateToString(informatic.Posted);
                    lblChecker.Text = informatic.Checker;

                    lblOverview.Text = informatic.Contents.Replace("\n", "<br />");

                    hpkDownloadlink.Text = informatic.Title;
                    hpkDownloadlink.NavigateUrl = informatic.Location.Replace("\\", "/");

                    IList<tblInformatic> items = informaticsDAO.getRelativeByType(informatic.Type, CommonConstants.NUMBER_RECORD_RELATIVE);
                    lblRelative.Text = "<ul>";
                    for (int i = 0; i < items.Count; i++)
                    {
                        lblRelative.Text += "<li>";
                        lblRelative.Text += "<a href='ArticleDetails.aspx?sec=it&id=" + items[i].ID + "'>" + items[i].Title.Trim() + "</a>";
                        lblRelative.Text += "(" + items[i].Posted + ")";
                        lblRelative.Text += "</li>";
                    }
                    lblRelative.Text += "</ul>";


                    txtPostedComment.Text = informatic.Comment;

                }
                else
                {
                    viewArticle.Visible = false;
                    commentPanel.Visible = false;
                    relativePanel.Visible = false;
                    invalidArticle.Visible = true;
                    liMessage.Text = "Bài viết này không có hoặc đã bị xóa!";
                    liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
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

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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
                    author = user.DisplayName;
                    currentUser = user.Username;
                }
                else
                {
                    author = txtName.Text;
                    currentUser = author;
                }

                date = ltktDAO.BaseServices.convertDateToString(DateTime.Now);
                comment = txtContent.Text.Replace("\n", "<br />");

                newComment += "<span>";
                newComment += "<b>" + author + "</b>" + " (" + date + ")";
                newComment += "<br />";
                newComment += comment;
                newComment += "</span>";

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
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT ;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            txtName.Text = CommonConstants.BLANK;
            txtEmail.Text = CommonConstants.BLANK; ;
            txtContent.Text = CommonConstants.BLANK; ;

            Page_Load(sender, e);
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

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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
            switch(sec)
            {
                case CommonConstants.SEC_UNIVERSITY_CODE:
                    {
                        if (Request.Cookies[type + sec] != null && str != null)
                        {
                            if(str.Contains(id.ToString()))
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
            if (Request.Cookies[ type + sec] != null)
            {
                string str = readCookie(type + sec);
                str += id.ToString()  + CommonConstants.COMMA;
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

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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