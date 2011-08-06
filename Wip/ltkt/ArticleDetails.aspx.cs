using System;
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
            //this.lblTitle.Text = "Đề thi đại học năm 2007";
            //this.lblPostedDate.Text = "1/1/2011";
            //this.lblChecker.Text = "<a href=\"#\">Việt Trung</a>";
            //this.lblAuthor.Text = "<a href=\"#\">thầy Đức Nghĩa</a>";
            //lblBranch.Text = "Kinh tế";
            //lblLevel.Text = "Khối A";
            //lblLiker.Text = "1231";
            //lblYear.Text = "2007";
            //lblSubject.Text = "môn Toán";
            //lblType.Text = "<a href=\"./ContestUniversity.aspx\">Luyện Thi Đại Học</a>";

            //lblResolve.Text = "<a href=\"#\">Gợi ý giải đề</a>";
            //lblOverview.Text = "Hóa học là khoa học nghiên cứu các chất, sự biến đổi và ứng dụng của chúng."
            //                    + "\nEm hãy kể tên một số đồ dùng được sản xuất từ nhôm, sắt, đồng, chất dẻo…?";
            //txtboxPostedComment.Text = "Trần Minh Nhật(2/1/2011 9:06PM)\n\n"
            //                            + "Hiện tại vẫn chưa có nhiều thông tin về cấu hình của Transformer 2, tuy nhiên nếu thật sự nó hỗ trợ Kal-El, người dùng sẽ sớm có 1 chiếc tablet với sức mạnh và đồ họa tốt, đồng thời lúc đó hoặc Transformer 2 sẽ nặng và dày hơn (pin lớn hơn) hoặc thời gian dùng pin thấp hơn, vì càng khỏe (mạnh) thì ăn (điện) càng nhiều."
            //                            + "\n\nNguyễn Anh Khoa(2/1/2011 11:07PM)\n\n"
            //                            + "Chiếc tablet Eee Pad Transformer nhiều khả năng sẽ không có mặt sớm, lý do vì Transformer vẫn đang làm tốt nhiệm vụ của mình với chip NVIDIA Tegra 2 cùng màn hình trang bị panel IPS cao cấp. Với mức giá hiện tại của Transformer khoảng 420 bảng Anh (683 USD), người dùng sẽ sở hữu 1 chiếc tablet mạnh mẽ cùng bàn phím rời – một lựa chọn thay thế tốt cho netbook với kích thước nhỏ hơn, nhẹ hơn và gọn gàng hơn.";



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
                                lblPostedDate.Text = convertDateToString(contest.Posted);
                                lblChecker.Text = "<a href=\"#\">Việt Trung</a>";
                                lblAuthor.Text = ltktDAO.Contest.getAuthor(id);
                                lblBranch.Text = ltktDAO.Contest.getBranch(id);
                                lblLiker.Text = contest.Point.ToString();
                                lblType.Text = "<a href=\"./ContestUniversity.aspx\">Luyện Thi Đại Học</a>";
                                lblYear.Text = Convert.ToString(contest.Year);
                                

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
                            { }
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
                            { }
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


            txtPostedComment.Text += "<br /><br />";
            txtPostedComment.Text += "<span>";
            txtPostedComment.Text += "<b>" + author + "\t(" + date + ")" + "</b>";
            txtPostedComment.Text += "<br />";
            txtPostedComment.Text += comment;
            txtPostedComment.Text += "</span>";

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

    }
}