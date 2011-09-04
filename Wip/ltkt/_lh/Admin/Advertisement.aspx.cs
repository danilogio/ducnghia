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
        ltktDAO.Ads adsDAO = new ltktDAO.Ads();

        public const int NoOfAdsPerPage = 10;
        public const string SelfLink = "<a href=\"Advertisement.aspx?page={0}\">{1}</a>";
        public const string DisplayNewsLink = "<a href=\"Advertisement.aspx?action=view&id={0}\" target=\"_blank\">{1}</a>";
        

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
                string action = Request.QueryString[CommonConstants.REQ_ACTION];
                int _id = Convert.ToInt32(Request.QueryString["id"]);

                if (action == "view")
                {

                }
                else if (action == "edit")
                {
                    viewPanel.Visible = false;
                }
                else if (action == "delete")
                {
                    Boolean completeDelete = adsDAO.deleteAds(_id);

                    if (completeDelete)
                    {
                        Response.Write("alert (\"Xóa thành công!\")");
                        Response.Redirect("Advertisement.aspx?page=1");
                    }
                    else
                    {
                        Response.Write("alert (\"Đã có lỗi xảy ra, xin vui lòng thử lại\")");
                    }
                }
            }
            else
            {
                Response.Redirect("Advertisement.aspx?page=1");
            }
        }

        private void showAds(int page)
        {
            int totalAds = adsDAO.countAds();
            // Computing total pages
            int totalPages;
            int mod = totalAds % NoOfAdsPerPage;
            
            IEnumerable<tblAdvertisement> lst = adsDAO.fetchAdsList(((page - 1) * NoOfAdsPerPage), NoOfAdsPerPage);

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
                //companyCell.Text = String.Format(DisplayNewsLink, ads.ID, ads.Company);
                companyCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ADS,
                                                                     CommonConstants.ACT_VIEW,
                                                                     ads.ID.ToString(),
                                                                     ads.Company);

                TableCell expiredCell = new TableCell();
                expiredCell.CssClass = "table-cell";
                expiredCell.Style["width"] = "80px";
                expiredCell.Text = BaseServices.convertDateToString((DateTime)ads.toDate);

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "40px";
                stateCell.Text = adsDAO.convertStateToString((int)ads.State);

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ADS,
                                                                     CommonConstants.ACT_EDIT,
                                                                     ads.ID.ToString(),
                                                                     CommonConstants.HTML_EDIT_ADMIN);

                actionCell.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_ADS,
                                                                     CommonConstants.ACT_DELETE,
                                                                     ads.ID.ToString(),
                                                                     CommonConstants.HTML_DELETE_ADMIN);

                
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
                {
                    PreviousPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SELF_LINK,
                                                                                (page - 1).ToString(),
                                                                                "Trang trước");
                }
                if (page > 0 && page < totalPages)
                {
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate (CommonConstants.TEMP_SELF_LINK,
                                                                             (page + 1).ToString(),
                                                                             "Trang sau");
                }
            }
        }
    }
}