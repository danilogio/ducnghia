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
        ltktDAO.Control control = new ltktDAO.Control();
        BaseServices bs = new BaseServices();
        ltktDAO.News newsDAO = new ltktDAO.News();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitleHeader.Text = CommonConstants.PAGE_NEWS_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

            if (Request.QueryString[CommonConstants.REQ_ID] != null)
            {
                int newsID = 1;
                try
                {
                    newsID = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                }
                catch (Exception ex)
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_NEWS_ERROR;
                    Response.Redirect(CommonConstants.PAGE_ERROR);
                }
                tblNew news = newsDAO.getNews(newsID);
                if (news != null)
                {

                    liTitle.Text = news.Title;
                    liPosted.Text = bs.convertDateToString((DateTime)news.Posted);
                    liAuthor.Text = newsDAO.getAuthor(newsID);

                    lblContent.Text = news.Contents;

                    IList<tblNew> lst = newsDAO.getLatestNewsByDate(CommonConstants.NUMBER_RECORD_ON_TAB).ToList();
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
                    liMessage.Text = CommonConstants.MSG_NEWS_NOT_FOUND;
                    liMessage.Text += CommonConstants.MSG_BACK_TO_HOME;
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