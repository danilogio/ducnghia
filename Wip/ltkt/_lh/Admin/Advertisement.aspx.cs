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
        ltktDAO.Control control = new ltktDAO.Control();

        public const int NoOfAdsPerPage = 10;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster pageAdmin = (AdminMaster)Master;
            pageAdmin.updateHeader(CommonConstants.PAGE_ADMIN_ADS_NAME);

            liTitle.Text = CommonConstants.PAGE_ADMIN_ADS_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE 
                           + control.getValueString (CommonConstants.CF_TITLE_ON_HEADER);

            int page = 1;

            if (Request.QueryString[CommonConstants.REQ_PAGE] != null)
            {
                viewPanel.Visible = true;
                detailsPanel.Visible = false;
                messagePanel.Visible = false;

                page = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_PAGE]);
                showAds(page);
            }
            else if (Request.QueryString[CommonConstants.REQ_ACTION] != null)
            {
                string action = Request.QueryString[CommonConstants.REQ_ACTION];
                int _id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                if (action == CommonConstants.ACT_VIEW || action == CommonConstants.ACT_EDIT)
                {
                    viewPanel.Visible = false;
                    detailsPanel.Visible = true;
                    messagePanel.Visible = false;

                    showAdsDetails(_id);
                }
                else if (action == CommonConstants.ACT_DELETE)
                {
                    Boolean completeDelete = adsDAO.deleteAds(_id);

                    if (completeDelete)
                    {
                        Response.Write(CommonConstants.ALERT_DELETE_SUCCESSFUL);
                        Response.Redirect("Advertisement.aspx?page=1");
                    }
                    else
                    {
                        Response.Write(CommonConstants.ALERT_DELETE_FAIL);
                    }
                }
            }
            else
            {
                Response.Redirect("Advertisement.aspx?page=1");
            }
        }

        private void showAdsDetails(int _id)
        {
            tblAdvertisement Ads = adsDAO.getAds(_id);

            if (Ads != null)
            {
                txtCompany.Text = Ads.Company;
                txtAddress.Text = Ads.Address;
                txtEmail.Text = Ads.Email;
                txtPhone.Text = Ads.Phone;
                txtFromDate.Text = Ads.fromDate;
                txtEndDate.Text = Ads.toDate;
                txtPrice.Text = Ads.Price.ToString();
                txtDescription.Text = Ads.Description;
                
            }
            else
            {
                messagePanel.Visible = true;
                detailsPanel.Visible = false;

                liMessage.Text = CommonConstants.MSG_RESOURSE_NOT_FOUND;

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
                                                                                CommonConstants.PREVIOUS_PAGE);
                }
                if (page > 0 && page < totalPages)
                {
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate (CommonConstants.TEMP_SELF_LINK,
                                                                             (page + 1).ToString(),
                                                                             CommonConstants.NEXT_PAGE);
                }
            }
        }
        
        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
}
}