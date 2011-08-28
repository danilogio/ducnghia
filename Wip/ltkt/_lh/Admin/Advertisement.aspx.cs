using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt.Admin
{
    public partial class Advertisement : System.Web.UI.Page
    {
        EventLog log = new EventLog();

        public const int NoOfAdsPerPage = 10;
        public const string SelfLink = "<a href=\"Advertisement.aspx?page={0}\">{1}</a>";
        public const string DisplayNewsLink = "<a href=\"Advertisement.aspx?id={0}\" target=\"_blank\">{1}</a>";

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster pageAdmin = (AdminMaster)Master;
            pageAdmin.updateHeader("Quản lý quảng cáo");

            int page = 1;

            if (Request.QueryString["page"] != null)
            {
                viewPanel.Visible = true;

                page = Convert.ToInt32(Request.QueryString["page"]);
                showAds(page);
            }
            else if (Request.QueryString["action"] != null)
            {
                string action = Request.QueryString["action"];
                int _id = Convert.ToInt32(Request.QueryString["id"]);

                if (action == "edit")
                {
                    viewPanel.Visible = false;
                }
                else if (action == "delete")
                {
                }
            }
            else
            {
                Response.Redirect("Advertisement.aspx?page=1");
            }
        }

        private void showAds(int page)
        {
            int totalAds = ltktDAO.Ads.countAds();
            // Computing total pages
            int totalPages;
            int mod = totalAds % NoOfAdsPerPage;
            String actionLink = "<span title=\"Sửa tin tức\"><a href = \"News.aspx?action=edit&id={0}\"><img width=\"24px\" height=\"24\" src=\"../../images/edit.png\"/></a></span>";
            actionLink += "&nbsp;&nbsp;<span title=\"Xóa tin tức\"><a href = \"News.aspx?action=delete&id={0}\"><img width=\"24px\" height=\"24\" src=\"../../images/delete.png\" onclick=\"return confirm('Do you want to delete?')\"/></a></span>";

            IEnumerable<tblAdvertisement> lst = ltktDAO.Ads.fetchAdsList(((page - 1) * NoOfAdsPerPage), NoOfAdsPerPage);

            if (mod == 0)
            {
                totalPages = totalAds / NoOfAdsPerPage;
            }
            else
            {
                totalPages = ((totalAds - mod) / NoOfAdsPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblAdvertisement ads = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "10px";
                noCell.Text = Convert.ToString(ads.ID);

                TableCell companyCell = new TableCell();
                companyCell.CssClass = "table-cell";
                companyCell.Style["width"] = "200px";
                companyCell.Text = String.Format(DisplayNewsLink, ads.ID, ads.Company);

                TableCell expiredCell = new TableCell();
                expiredCell.CssClass = "table-cell";
                expiredCell.Style["width"] = "80px";
                expiredCell.Text = BaseServices.convertDateToString((DateTime)ads.toDate);

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "30px";
                stateCell.Text = ads.State.ToString();

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = String.Format(actionLink, ads.ID);

                TableRow adsRow = new TableRow();
                adsRow.Cells.Add(noCell);
                adsRow.Cells.Add(companyCell);
                adsRow.Cells.Add(expiredCell);
                adsRow.Cells.Add(stateCell);
                adsRow.Cells.Add(actionCell);

                NewsTable.Rows.AddAt(2 + idx, adsRow);
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
    }
}