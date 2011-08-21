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
        public const int NoOfNeswPerPage = 10;
        public const string SelfLink = "<a href=\"News.aspx?page={0}\">{1}</a>";
        public const string DisplayNewsLink = "<a href=\"../../News.aspx?id={0}\">{1}</a>";

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
                showNews(page);
            }
            else if (Request.QueryString["action"] != null)
            {
                string action = Request.QueryString["action"];
                int newsID = Convert.ToInt32(Request.QueryString["id"]);
                if (action == "edit")
                {
                    viewPanel.Visible = false;
                    tblNew editNews = ltktDAO.News.getNews(newsID);
                    Session["editNews"] = editNews;
                    btnSave.Text = "Sửa";
                    btnSticky.Visible = true;
                    addPanel.Visible = true;

                    txtTitle.Text = editNews.Title;
                    txtChapeau.Text = editNews.Chapaeu;
                    txtContent.Text = editNews.Contents;
                }
                else if (action == "delete")
                {
                    Boolean completeDelete = ltktDAO.News.deleteNews(newsID);
                    Response.Redirect("News.aspx?page=1");
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
            int mod = totalNews % NoOfNeswPerPage;
            String actionLink = "<span title=\"Sửa tin tức\"><a href = \"News.aspx?action=edit&id={0}\"><img width=\"24px\" height=\"24\" src=\"../../images/edit.png\"/></a></span>";
            actionLink += "&nbsp;&nbsp;<span title=\"Xóa tin tức\"><a href = \"News.aspx?action=delete&id={0}\"><img width=\"24px\" height=\"24\" src=\"../../images/delete.png\" onclick=\"return confirm('Do you want to delete?')\"/></a></span>";

            IEnumerable<tblNew> lst = ltktDAO.News.fetchEmailList(((page - 1) *
                NoOfNeswPerPage), NoOfNeswPerPage);

            if (mod == 0)
            {
                totalPages = totalNews / NoOfNeswPerPage;
            }
            else
            {
                totalPages = ((totalNews - mod) / NoOfNeswPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblNew news = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "news-table-cell";
                noCell.Style["width"] = "20px";
                noCell.Text = Convert.ToString(news.ID);

                TableCell titleCell = new TableCell();
                titleCell.CssClass = "news-table-cell";
                titleCell.Style["width"] = "300px";
                titleCell.Text = String.Format(DisplayNewsLink, news.ID, news.Title);

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "news-table-cell";
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strTitlte = txtTitle.Text;
            string strChapeau = txtChapeau.Text;
            string strContent = Server.HtmlDecode(txtContent.Text);

            try
            {
                tblNew editNews = (tblNew)Session["editNews"];
                if (editNews == null)//thêm mới
                {
                    if (Session["User"] != null)
                    {
                        tblUser author = (tblUser)Session["User"];
                        ltktDAO.News.insertNews(author.Username, strTitlte, strChapeau, strContent);

                        Page_Load(sender, e);
                    }
                    else
                    {
                        Response.Redirect("../Login.aspx");
                    }
                }
                else//edit
                {
 
                }
            }
            catch (Exception ex)
            {
                liMessage.Text = "Vui lòng kiểm tra tiêu đề, nội dung!";
                liMessage.Visible = true;
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
            { }
            

            addPanel.Visible = false;
            Response.Redirect("News.aspx?page=1");
        }

        protected void btnSticky_Click(object sender, EventArgs e)
        {

        }
    }
}