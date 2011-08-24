using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using ltktDAO;
using System.Collections.Generic;
using System.Web.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace ltkt.Admin
{
    public partial class Mailbox : System.Web.UI.Page
    {
        public const string Host = "pop.gmail.com";
        public const int Port = 995;
        public const string Email = "";
        public const string Password = "";
        public const string SmtpServer = "smtp.gmail.com";
        public const string SmtpPort = "465";

        public const int NoOfEmailsPerPage = 6;
        public const string SelfLink = "<a href=\"Mailbox.aspx?page={0}\">{1}</a>";
        public const string DisplayEmailLink = "<a href=\"Mailbox.aspx?emailID={0}\">{1}</a>";

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster pageMaster = (AdminMaster)Master;
            pageMaster.updateHeader("Hộp thư");

            if (getEmailConfig())
            {

                int page = 1;
                int emailID = -1;

                if (Request.QueryString["page"] != null)
                {
                    EmailsTable.Visible = true;
                    EmailDetailTable.Visible = false;

                    page = Convert.ToInt32(Request.QueryString["page"]);
                    showEmail(page);
                }
                else if (Request.QueryString["emailID"] != null)
                {
                    EmailsTable.Visible = false;
                    EmailDetailTable.Visible = true;

                    emailID = Convert.ToInt32(Request.QueryString["emailID"]);
                    ltktDAO.Contact.setRead(emailID, true);
                    showDetails(emailID);
                }
                else if (Request.QueryString["page"] == null)
                {
                    Response.Redirect("Mailbox.aspx?page=1");
                }
            }
            else
            {
                viewPanel.Visible = false;
                composePanel.Visible = false;
                configPanel.Visible = true;
            }
        }

        private void showEmail(int page)
        {
            IEnumerable<tblContact> lst = ltktDAO.Contact.getAll();

            int totalEmails = ltktDAO.Contact.sumEmails();

            // Computing total pages
            int totalPages;
            int mod = totalEmails % NoOfEmailsPerPage;

            if (mod == 0)
            {
                totalPages = totalEmails / NoOfEmailsPerPage;
            }
            else
            {
                totalPages = ((totalEmails - mod) / NoOfEmailsPerPage) + 1;
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblContact email = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "emails-table-cell";
                noCell.Style["width"] = "20px";
                noCell.Text = Convert.ToString(email.ID);

                TableCell fromCell = new TableCell();
                fromCell.CssClass = "emails-table-cell";
                fromCell.Text = email.EmailFrom;

                TableCell subjectCell = new TableCell();
                subjectCell.CssClass = "emails-table-cell";
                subjectCell.Style["width"] = "300px";
                subjectCell.Text = String.Format(DisplayEmailLink, email.ID, email.Subject);

                TableCell dateCell = new TableCell();
                dateCell.CssClass = "emails-table-cell";
                dateCell.Text = email.Posted.ToString();

                TableRow emailRow = new TableRow();
                emailRow.Cells.Add(noCell);
                emailRow.Cells.Add(fromCell);
                emailRow.Cells.Add(subjectCell);
                emailRow.Cells.Add(dateCell);

                EmailsTable.Rows.AddAt(2 + idx, emailRow);
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

        private void showDetails(int emailID)
        {
            tblContact email = ltktDAO.Contact.getEmail(emailID);
            if (email != null)
            {
                EmailIdLiteral.Text = email.ID.ToString();
                DateLiteral.Text = email.Posted.ToString();
                FromLiteral.Text = email.EmailFrom;
                SubjectLiteral.Text = email.Subject;
                BodyLiteral.Text = email.Contents;
            }
        }

        protected void btnInbox_Click(object sender, EventArgs e)
        {
        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            composePanel.Visible = false;
            viewPanel.Visible = true;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string strTo = txtTo.Text;
            string strSubject = txtSubject.Text;
            string strContent = Server.HtmlDecode(txtContent.Text);
            //string strContent = txtContent.Text;

            try
            {
                MailMessage message = new MailMessage();
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", SmtpServer);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", SmtpPort);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //Use 0 for anonymous
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", Email);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Password);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                message.To = strTo;
                message.From = Email;
                message.Subject = strSubject;
                message.BodyFormat = MailFormat.Html;
                message.Body = strContent;
                message.BodyEncoding = Encoding.UTF8;
                SmtpMail.SmtpServer = SmtpServer + ":" + SmtpPort;

                SmtpMail.Send(message);

                Boolean isOK = ltktDAO.Contact.insertEmail(Email, strTo, strSubject, strContent, DateTime.Now);

                composePanel.Visible = false;
                viewPanel.Visible = true;
            }
            catch (Exception ex)
            {
                liMessage.Text = "Vui lòng kiểm tra lại địa chỉ email";
                liMessage.Visible = true;
            }
        }

        protected void btnCompose_Click(object sender, EventArgs e)
        {
            viewPanel.Visible = false;

            txtTo.Text = "";
            txtSubject.Text = "";
            txtContent.Text = "";
            composePanel.Visible = true;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            EmailDetailTable.Visible = false;
            EmailsTable.Visible = true;
            Response.Redirect("Mailbox.aspx?page=1");
        }

        protected void btnConfig_Click(object sender, EventArgs e)
        {
            viewPanel.Visible = false;
            composePanel.Visible = false;
            configPanel.Visible = true;
        }

        protected void btnSubmitConfig_Click(object sender, EventArgs e)
        {

        }

        private bool getEmailConfig()
        {
            return true;
        }
    }
}