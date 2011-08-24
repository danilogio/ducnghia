using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int newsID = 1;
                try
                {
                    newsID = Convert.ToInt32(Request.QueryString["id"]);
                }
                catch (Exception ex)
                {
                    Session["Error"] = "Đường dẫn trang web không hợp lệ, xin vui lòng kiểm tra lại!";
                    Response.Redirect("Error.aspx");
                }
                tblNew news = ltktDAO.News.getNews(newsID);
                if (news != null)
                {

                    liTitle.Text = news.Title;
                    liPosted.Text = ltktDAO.BaseServices.convertDateToString((DateTime)news.Posted);
                    liAuthor.Text = ltktDAO.News.getAuthor(newsID);

                    lblContent.Text = news.Contents;


                    IList<tblNew> lst = ltktDAO.News.getLatestNewsByDate(CommonConstants.NUMBER_RECORD_ON_TAB).ToList();
                    lblRelative.Text = "<ul>";
                    for (int i = 0; i < lst.Count; i++)
                    {
                        lblRelative.Text += "<li>";
                        lblRelative.Text += "<a href='News.aspx?id=" + lst[i].ID + "'>" + lst[i].Title.Trim() + "</a>";
                        lblRelative.Text += "(" + lst[i].Posted + ")";
                        lblRelative.Text += "</li>";
                    }
                    lblRelative.Text += "</ul>";

                    messagePanel.Visible = false;
                    newsPanel.Visible = true;
                }
                else
                {
                    liMessage.Text = "Tin tức không tồn tại hoặc đã bị xóa!";
                    liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
                    messagePanel.Visible = true;
                    newsPanel.Visible = false;
                }
            }
            else
            {
                Response.Redirect("News.aspx?id=1");
            }

        }
    }
}