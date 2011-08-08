﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt
{
    public partial class ArticleDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sec"] != null)
            {
                string sec = Request.QueryString["sec"];
                int id = Convert.ToInt32(Request.QueryString["id"]);

                switch (sec)
                {
                    case "uni":
                        {
                            // do something
                            tblContestForUniversity contest = ltktDAO.Contest.getContest(id);
                            if (contest != null)
                            {
                                lblTitle.Text = contest.Title;
                                lblLiker.Text = contest.Point.ToString();

                                lblAuthor.Text = ltktDAO.Contest.getAuthor(id);
                                lblPostedDate.Text = convertDateToString(contest.Posted);
                                lblChecker.Text = contest.Checker;
                                lblType.Text = "<a href=\"./ContestUniversity.aspx\">Luyện Thi Đại Học</a>";

                                lblSubject.Text = contest.Subject;
                                lblBranch.Text = ltktDAO.Contest.getBranch(id);
                                lblYear.Text = Convert.ToString(contest.Year);

                                txtPostedComment.Text = contest.Comment;

                                infoContest.Visible = true;
                                infoEnglish.Visible = false;
                                infoInformatic.Visible = false;
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
                            break;
                        }
                    case "el":
                        {
                            // do something else
                            tblEnglish english = ltktDAO.English.getEnglish(id);
                            if (english != null)
                            {
                                lblTitle.Text = english.Title;
                                lblLiker.Text = english.Point.ToString();

                                lblAuthor.Text = ltktDAO.English.getAuthor(id);
                                lblPostedDate.Text = convertDateToString(english.Posted);
                                lblChecker.Text = english.Checker;
                                lblType.Text = "<a href=\"./English.aspx\">Anh văn</a>";

                                infoContest.Visible = false;
                                infoEnglish.Visible = true;
                                infoInformatic.Visible = false;
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
                            break;
                        }
                    case "it":
                        {
                            //do something
                            tblInformatic informatic = ltktDAO.Informatics.getInformatic(id);
                            if (informatic != null)
                            {
                                lblTitle.Text = informatic.Title;
                                lblLiker.Text = informatic.Point.ToString();

                                lblAuthor.Text = ltktDAO.Informatics.getAuthor(id);
                                lblPostedDate.Text = convertDateToString(informatic.Posted);
                                lblChecker.Text = informatic.Checker;
                                lblType.Text = "<a href=\"./Informatics.aspx\">Tin học</a>";


                                infoContest.Visible = false;
                                infoEnglish.Visible = false;
                                infoInformatic.Visible = true;
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
                            break;
                        }
                    default:
                        break;
                }

                if (txtPostedComment.Text == String.Empty)
                {
                    txtPostedComment.Visible = false;
                }
                else
                {
                    txtPostedComment.Visible = true;
                }

                if (Session["User"] != null)
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

        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            string author = "";
            string date = "";
            string comment = "";
            string newComment = "";

            if (Session["User"] != null)
            {
                tblUser user = (tblUser)Session["User"];
                author = user.DisplayName;
            }
            else
            {
                author = txtName.Text;
            }

            date = convertDateToString(DateTime.Now);
            comment = txtContent.Text.Replace("\n", "<br />");

            newComment += "<span>";
            newComment += "<b>" + author + "</b>" + " (" + date + ")";
            newComment += "<br />";
            newComment += comment;
            newComment += "</span>";

            // Write comment to db
            string sec = Request.QueryString["sec"];
            int id = Convert.ToInt32(Request.QueryString["id"]);

            switch (sec)
            {
                case "uni":
                    {
                        ltktDAO.Contest.insertComment(id, newComment);
                        break;
                    }
                case "el":
                    {
                        ltktDAO.English.insertComment(id, newComment);
                        break;
                    }
                case "it":
                    {
                        ltktDAO.Informatics.insertComment(id, newComment);
                        break;
                    }
                default:
                    break;
            }

            txtName.Text = "";
            txtEmail.Text = "";
            txtContent.Text = "";

            Page_Load(sender, e);
        }

        private string convertDateToString(DateTime date)
        {
            string strDate = "";

            strDate += date.ToShortTimeString();
            strDate += " ngày ";
            strDate += Convert.ToString(date.Day);
            strDate += "/";
            strDate += Convert.ToString(date.Month);
            strDate += "/";
            strDate += Convert.ToString(date.Year);

            return strDate;
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            // Write comment to db
            string sec = Request.QueryString["sec"];
            int id = Convert.ToInt32(Request.QueryString["id"]);

            switch (sec)
            {
                case "uni":
                    {
                        ltktDAO.Contest.Like(id);
                        break;
                    }
                case "el":
                    {
                        ltktDAO.English.Like(id);
                        break;
                    }
                case "it":
                    {
                        ltktDAO.Informatics.Like(id);
                        break;
                    }
                default:
                    break;
            }

            Page_Load(sender, e);
        }

        protected void btnDislike_Click(object sender, EventArgs e)
        {
            // Write comment to db
            string sec = Request.QueryString["sec"];
            int id = Convert.ToInt32(Request.QueryString["id"]);

            switch (sec)
            {
                case "uni":
                    {
                        ltktDAO.Contest.Dislike(id);
                        break;
                    }
                case "el":
                    {
                        ltktDAO.English.Dislike(id);
                        break;
                    }
                case "it":
                    {
                        ltktDAO.Informatics.Dislike(id);
                        break;
                    }
                default:
                    break;
            }

            Page_Load(sender, e);
        }
    }
}