using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt.Admin
{
    public partial class News : System.Web.UI.Page
    {
        EventLog log = new EventLog();

        public const int NoOfNewsPerPage = 10;
        public const string SelfLink = "<a href=\"News.aspx?page={0}\">{1}</a>";
        public const string DisplayNewsLink = "<a href=\"../../News.aspx?id={0}\" target=\"_blank\">{1}</a>";

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster pageMaster = (AdminMaster)Master;
            pageMaster.updateHeader("Quản lý tin tức");

            int page = 1;

            if (Request.QueryString["page"] != null)
            {
                viewPanel.Visible = true;
                addPanel.Visible = false;

                page = Convert.ToInt32(Request.QueryString["page"]);
                btnSave.Text = "Thêm tin tức";
                showNews(page);
            }
            else if (Request.QueryString["action"] != null)
            {
                string action = Request.QueryString["action"];
                int newsID = Convert.ToInt32(Request.QueryString["id"]);
                
                if (action == "edit")
                {
                    viewPanel.Visible = false;
                    editNews(newsID);
                }
                else if (action == "delete")
                {
                    Boolean completeDelete = ltktDAO.News.deleteNews(newsID);

                    if (completeDelete)
                    {
                        Response.Redirect("News.aspx?page=1");
                    }
                    else
                    {
                        Response.Write("alert (\"Đã có lỗi xảy ra, xin vui lòng thử lại\")");
                    }
                }
            }
            else
            {
                Response.Redirect("News.aspx?page=1");
            }
        }
                
        private void showNews(int page)
        {
            int totalNews = ltktDAO.News.countNews();
            // Computing total pages
            int totalPages;
            int mod = totalNews % NoOfNewsPerPage;
            String actionLink = "<span title=\"Sửa tin tức\"><a href = \"News.aspx?action=edit&id={0}\"><img width=\"24px\" height=\"24\" src=\"../../images/edit.png\"/></a></span>";
            actionLink += "&nbsp;&nbsp;<span title=\"Xóa tin tức\"><a href = \"News.aspx?action=delete&id={0}\"><img width=\"24px\" height=\"24\" src=\"../../images/delete.png\" onclick=\"return confirm('Do you want to delete?')\"/></a></span>";

            IEnumerable<tblNew> lst = ltktDAO.News.fetchNewsList(((page - 1) * NoOfNewsPerPage), NoOfNewsPerPage);

            if (mod == 0)
            {
                totalPages = totalNews / NoOfNewsPerPage;
            }
            else
            {
                totalPages = ((totalNews - mod) / NoOfNewsPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblNew news = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "20px";
                noCell.Text = Convert.ToString(news.ID);

                TableCell titleCell = new TableCell();
                titleCell.CssClass = "table-cell";
                titleCell.Style["width"] = "300px";
                titleCell.Text = String.Format(DisplayNewsLink, news.ID, news.Title);

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = String.Format(actionLink, news.ID);

                TableRow newsRow = new TableRow();
                newsRow.Cells.Add(noCell);
                newsRow.Cells.Add(titleCell);
                newsRow.Cells.Add(actionCell);

                NewsTable.Rows.AddAt(2 + idx, newsRow);
            }

            // Creating links to previous and next pages
            if (totalPages > 1)
            {
                if (page > 1)
                    PreviousPageLiteral.Text = String.Format(SelfLink, page - 1, "Previous Page");

                if (page > 0 && page < totalPages)
                    NextPageLiteral.Text = String.Format(SelfLink, page + 1, "Next Page");
            }
        }

        protected void btnAddNews_Click(object sender, EventArgs e)
        {
            viewPanel.Visible = false;
            addPanel.Visible = true;
            btnAddNews.Text = "Thêm bài viết";
            btnSticky.Visible = false;
            Session["editNews"] = null;
        }

        private void editNews (int newsID)
        {
            if (Session["editNews"] == null)
            {
                tblNew editNews = ltktDAO.News.getNews(newsID);
                Session["editNews"] = editNews;

                btnSave.Text = "Sửa";
                btnSticky.Visible = true;
                addPanel.Visible = true;

                txtTitle.Text = editNews.Title;
                txtChapeau.Text = editNews.Chapaeu;
                txtContent.Text = editNews.Contents;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strTitlte = txtTitle.Text;
            string strChapeau = txtChapeau.Text;
            string strContent = Server.HtmlDecode(txtContent.Text);

            if (Session["User"] != null)
            {
                tblUser author = (tblUser)Session["User"];
                try
                {
                    tblNew editNews = (tblNew)Session["editNews"];
                    if (editNews == null)//thêm mới
                    {
                        ltktDAO.News.insertNews(author.Username, strTitlte, strChapeau, strContent);
                        Page_Load(sender, e);
                    }
                    else//edit
                    {
                        ltktDAO.News.updateNews(editNews.ID, author.Username, strTitlte, strChapeau, strContent);
                        Session["editNews"] = null;
                        Response.Redirect("News.aspx?page=1");
                    }
                }
                catch (Exception ex)
                {
                    liMessage.Text = "Vui lòng kiểm tra tiêu đề, nội dung!";
                    liMessage.Visible = true;

                    tblUser user = (tblUser)Session["User"];
                    string username = CommonConstants.USER_GUEST;
                    if (user != null)
                    {
                        username = user.Username;
                    }

                    log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                    Session[CommonConstants.SES_ERROR] = CommonConstants.COMMON_ERROR_TEXT;
                    Response.Redirect(CommonConstants.PAGE_ERROR);
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tblNew editNews = (tblNew)Session["editNews"];
            if (editNews == null)//thêm mới
            {
                txtTitle.Text = "";
                txtChapeau.Text = "";
                txtContent.Text = Server.HtmlEncode("");
            }
            else//edit
            {
                Session["editNews"] = null;
            }
            

            addPanel.Visible = false;
            Response.Redirect("News.aspx?page=1");
        }
    }
}