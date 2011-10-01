using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt.Admin
{
    public partial class Informatics : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.BaseServices bs = new ltktDAO.BaseServices();
        ltktDAO.Informatics infDAO = new ltktDAO.Informatics();
        private const int NoOfInformacticsPerPage = 7;

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_INFORMATICS)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader(CommonConstants.PAGE_ADMIN_INFORMATICS_NAME);

                    liTitle.Text = CommonConstants.PAGE_ADMIN_INFORMATICS_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

                    liTableHeader.Text = CommonConstants.PAGE_ADMIN_INFORMATICS_NAME;
                    //////////////////////////////////////////////////
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }

        private void showInformactics(IEnumerable<tblInformatic> lst, int page, string action, string key)
        {
            int totalInformactic = 0;
            // Computing total pages
            int totalPages;
            int mod = totalInformactic % NoOfInformacticsPerPage;

            if (mod == 0)
            {
                totalPages = totalInformactic / NoOfInformacticsPerPage;
            }
            else
            {
                totalPages = ((totalInformactic - mod) / NoOfInformacticsPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblInformatic inf = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "10px";
                noCell.Text = Convert.ToString(idx + 1);

                TableCell titleCell = new TableCell();
                titleCell.CssClass = "table-cell";
                titleCell.Style["width"] = "200px";
                titleCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                  CommonConstants.PAGE_ADMIN_INFORMATICS,
                                                                  CommonConstants.ACT_VIEW,
                                                                  Convert.ToString(inf.ID),
                                                                  inf.Title);

                TableCell postedCell = new TableCell();
                postedCell.CssClass = "table-cell";
                postedCell.Style["width"] = "80px";
                postedCell.Text = bs.convertDateToString(inf.Posted);

                TableCell authorCell = new TableCell();
                authorCell.CssClass = "table-cell";
                authorCell.Style["width"] = "60px";
                authorCell.Text = infDAO.getAuthor(inf.ID);

                TableCell stateCell = new TableCell();
                stateCell.CssClass = "table-cell";
                stateCell.Style["width"] = "40px";
                stateCell.Text = infDAO.getState(inf.ID);


                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "40px";
                actionCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                     CommonConstants.ACT_EDIT,
                                                                     Convert.ToString(inf.ID),
                                                                     CommonConstants.HTML_EDIT_ADMIN);

                actionCell.Text += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_UNIVERSITY,
                                                                     CommonConstants.ACT_DELETE,
                                                                     Convert.ToString(inf.ID),
                                                                     CommonConstants.HTML_DELETE_ADMIN);


                TableRow infRow = new TableRow();
                infRow.Cells.Add(noCell);
                infRow.Cells.Add(titleCell);
                infRow.Cells.Add(postedCell);
                infRow.Cells.Add(authorCell);
                infRow.Cells.Add(stateCell);
                infRow.Cells.Add(actionCell);

                InformaticsTable.Rows.AddAt(2 + idx, infRow);
            }

            // Creating links to previous and next pages
            if (totalPages > 1)
            {
                string param = CommonConstants.REQ_ACTION
                                + CommonConstants.EQUAL
                                + action
                                + CommonConstants.AND
                                + CommonConstants.REQ_KEY
                                + CommonConstants.EQUAL
                                + key
                                + CommonConstants.AND
                                + CommonConstants.REQ_PAGE
                                + CommonConstants.EQUAL;

                if (page > 1)
                {

                    PreviousPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_PAGING_LINK,
                                                                                CommonConstants.PAGE_ADMIN_INFORMATICS,
                                                                                param + (page - 1).ToString(),
                                                                                CommonConstants.TXT_PREVIOUS_PAGE);
                }
                if (page > 0 && page < totalPages)
                {
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_PAGING_LINK,
                                                                             CommonConstants.PAGE_ADMIN_INFORMATICS,
                                                                             param + (page + 1).ToString(),
                                                                             CommonConstants.TXT_NEXT_PAGE);
                }
            }
        }

    }
}