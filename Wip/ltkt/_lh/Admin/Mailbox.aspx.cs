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
        //public const string Host = "pop.gmail.com";
        //public const int Port = 995;
        //public const string Email = "";
        //public const string Password = "";
        //public const string SmtpServer = "smtp.gmail.com";
        //public const string SmtpPort = "465";

        public const int NoOfEmailsPerPage = 6;
        //public const string SelfLink = "<a href=\"Mailbox.aspx?page={0}\">{1}</a>";
        //public const string DisplayEmailLink = "<a href=\"Mailbox.aspx?emailID={0}\">{1}</a>";

        private ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.Contact contactDAO = new ltktDAO.Contact();
        ltktDAO.EmailConf emailConf = new EmailConf();

        protected void Page_Load(object sender, EventArgs e)
        {
            //change title
            liTitle.Text = CommonConstants.PAGE_ADMIN_MAIL_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_EMAIL)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    AdminMaster pageMaster = (AdminMaster)Master;
                    pageMaster.updateHeader(CommonConstants.PAGE_ADMIN_MAIL_NAME);

                    if (getEmailConfig())
                    {

                        int page = 1;
                        int emailID = -1;

                        if (Request.QueryString[CommonConstants.REQ_TYPE] != null)
                        {
                            EmailsTable.Visible = true;
                            EmailDetailTable.Visible = false;

                            page = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_PAGE]);
                            switch (Request.QueryString[CommonConstants.REQ_TYPE])
                            {
                                case CommonConstants.ACT_INBOX:
                                    showEmail(page, true);
                                    break;
                                case CommonConstants.ACT_SENT:
                                    showEmail(page, false);
                                    break;
                                default: break;
                            }
                            
                        }
                        else if (Request.QueryString[CommonConstants.REQ_ACTION] != null)
                        {
                            string action = Request.QueryString[CommonConstants.REQ_ACTION];
                            emailID = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                            switch (action)
                            {
                                case CommonConstants.ACT_VIEW:
                                    showDetails(emailID);
                                    break;
                                case CommonConstants.ACT_DELETE:
                                    deleteEmail(emailID, user.Username);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (Request.QueryString[CommonConstants.REQ_PAGE] == null)
                        {
                            Response.Redirect(CommonConstants.PAGE_ADMIN_MAIL
                                              + CommonConstants.ADD_PARAMETER
                                              + CommonConstants.REQ_TYPE 
                                              + CommonConstants.EQUAL 
                                              + CommonConstants.ACT_INBOX
                                              + CommonConstants.AND
                                              + CommonConstants.REQ_PAGE
                                              + CommonConstants.EQUAL + "1");
                        }
                    }
                    else
                    {
                        viewPanel.Visible = false;
                        composePanel.Visible = false;
                        configPanel.Visible = true;
                    }
                    //////////////////////////////////////////////////
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }

        private void deleteEmail(int emailID, string username)
        {
            if (Session[CommonConstants.SES_USER] != null)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                bool isOK = contactDAO.deleteEmail(id, user.Username);

                if (isOK)
                {
                    Response.Redirect(CommonConstants.PAGE_ADMIN_MAIL
                                        + CommonConstants.ADD_PARAMETER
                                        + CommonConstants.REQ_PAGE
                                        + CommonConstants.EQUAL + "1");
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Session[CommonConstants.SES_EMAIL] = null;
        }

        private void showEmail(int page, bool isInbox)
        {
            string type = CommonConstants.BLANK;
            if (isInbox)
            {
                liHeaderTitle.Text = "Hộp thư đến";
                liFromTo.Text = "Người gửi";
                type = CommonConstants.ACT_INBOX;
            }
            else
            {
                liHeaderTitle.Text = "Hộp thư đi";
                liFromTo.Text = "Người nhận";
                type = CommonConstants.ACT_SENT;
            }

            int totalEmails = contactDAO.sumEmails();

            // Computing total pages
            int totalPages;
            int mod = totalEmails % NoOfEmailsPerPage;

            IEnumerable<tblContact> lst = contactDAO.fetchEmailList(isInbox, ((page - 1) * NoOfEmailsPerPage), NoOfEmailsPerPage);

            if (mod == 0)
            {
                totalPages = totalEmails / NoOfEmailsPerPage;
            }
            else
            {
                totalPages = ((totalEmails - mod) / NoOfEmailsPerPage) + 1;
            }

            if (EmailsTable.Rows.Count > 3)
            {
                int idx = 2;
                for (; idx < EmailsTable.Rows.Count -1; idx++)
                {
                    EmailsTable.Rows.RemoveAt(idx);
                }
                EmailsTable.Rows.RemoveAt(idx -1);
            }

            for (int idx = 0; idx < lst.Count(); ++idx)
            {
                tblContact email = lst.ElementAt(idx);

                TableCell noCell = new TableCell();
                noCell.CssClass = "table-cell";
                noCell.Style["width"] = "20px";
                noCell.Text = Convert.ToString(email.ID);

                TableCell fromCell = new TableCell();
                fromCell.CssClass = "table-cell";
                if (isInbox)
                {
                    
                    fromCell.Text = email.EmailFrom;
                }
                else
                {
                    
                    fromCell.Text = email.EmailTo;
                }

                TableCell subjectCell = new TableCell();
                subjectCell.CssClass = "table-cell";
                subjectCell.Style["width"] = "300px";
                //subjectCell.Text = String.Format(DisplayEmailLink, email.ID, email.Subject);
                subjectCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_MAIL,
                                                                     CommonConstants.ACT_VIEW,
                                                                     Convert.ToString(email.ID),
                                                                     email.Subject);


                TableCell dateCell = new TableCell();
                dateCell.CssClass = "table-cell";
                dateCell.Text = email.Posted.ToString();

                TableCell actionCell = new TableCell();
                actionCell.CssClass = "table-cell";
                actionCell.Style["width"] = "20px";
                actionCell.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DISPLAY_LINK,
                                                                     CommonConstants.PAGE_ADMIN_MAIL,
                                                                     CommonConstants.ACT_DELETE,
                                                                     Convert.ToString(email.ID),
                                                                     CommonConstants.HTML_DELETE_ADMIN);

                TableRow emailRow = new TableRow();
                emailRow.Cells.Add(noCell);
                emailRow.Cells.Add(fromCell);
                emailRow.Cells.Add(subjectCell);
                emailRow.Cells.Add(dateCell);
                emailRow.Cells.Add(actionCell);

                EmailsTable.Rows.AddAt(2 + idx, emailRow);
            }

            // Creating links to previous and next pages
            if (totalPages > 1)
            {
                if (page > 1)
                {
                    //PreviousPageLiteral.Text = String.Format(SelfLink, page - 1, "Previous Page");
                    PreviousPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MINOR_SELF_LINK,
                                                                                CommonConstants.PAGE_ADMIN_MAIL,
                                                                                type,
                                                                                (page - 1).ToString(),
                                                                                CommonConstants.TXT_PREVIOUS_PAGE);
                }

                if (page > 0 && page < totalPages)
                {
                    //NextPageLiteral.Text = String.Format(SelfLink, page + 1, "Next Page");
                    NextPageLiteral.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MINOR_SELF_LINK,
                                                                             CommonConstants.PAGE_ADMIN_MAIL,
                                                                             type,
                                                                             (page + 1).ToString(),
                                                                             CommonConstants.TXT_NEXT_PAGE);
                }
            }
        }

        private void showDetails(int emailID)
        {
            EmailsTable.Visible = false;

            tblContact email = contactDAO.getEmail(emailID);
            if (email != null)
            {
                btnReply.Visible = true;
                btnForward.Visible = true;
                btnDelete.Visible = true;

                EmailDetailTable.Visible = true;

                contactDAO.setRead(emailID, true);

                EmailIdLiteral.Text = email.ID.ToString();
                DateLiteral.Text = email.Posted.ToString();
                FromLiteral.Text = email.EmailFrom;
                SubjectLiteral.Text = email.Subject;
                BodyLiteral.Text = email.Contents;

                Session[CommonConstants.SES_EMAIL] = email;
            }
            else
            {
                Session[CommonConstants.SES_EMAIL] = null;

                EmailDetailTable.Visible = false;
                liMessageDetails.Visible = true;
                liMessageDetails.Text = CommonConstants.MSG_RESOURSE_NOT_FOUND;
            }
        }

        protected void btnInbox_Click(object sender, EventArgs e)
        {
            Response.Redirect(CommonConstants.PAGE_ADMIN_MAIL
                                              + CommonConstants.ADD_PARAMETER
                                              + CommonConstants.REQ_TYPE
                                              + CommonConstants.EQUAL
                                              + CommonConstants.ACT_INBOX
                                              + CommonConstants.AND
                                              + CommonConstants.REQ_PAGE
                                              + CommonConstants.EQUAL + "1");
        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
            Response.Redirect(CommonConstants.PAGE_ADMIN_MAIL
                                              + CommonConstants.ADD_PARAMETER
                                              + CommonConstants.REQ_TYPE
                                              + CommonConstants.EQUAL
                                              + CommonConstants.ACT_SENT
                                              + CommonConstants.AND
                                              + CommonConstants.REQ_PAGE
                                              + CommonConstants.EQUAL + "1");
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
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", emailConf.SmptServer);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", emailConf.SmptPort);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //Use 0 for anonymous
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", emailConf.Username);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", emailConf.Password);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                message.To = strTo;
                message.From = emailConf.Username;
                message.Subject = strSubject;
                message.BodyFormat = MailFormat.Html;
                message.Body = strContent;
                message.BodyEncoding = Encoding.UTF8;
                SmtpMail.SmtpServer = emailConf.SmptServer + ":" + emailConf.SmptPort;
                
                SmtpMail.Send(message);

                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                Boolean isOK = contactDAO.insertEmail(user.Username, emailConf.Username, strTo, strSubject, strContent, DateTime.Now);

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
            EmailsTable.Visible = false;
            EmailDetailTable.Visible = false;
            int page = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_PAGE]);
            try
            {
                List<Email> emails;

                using (Pop3Client client = new Pop3Client(emailConf.Host, emailConf.HostPort, emailConf.Username, emailConf.Password, true))
                {
                    client.Connect();

                    int totalEmails = client.GetEmailCount();
                    emails = client.FetchEmailList(((page - 1) * NoOfEmailsPerPage) + 1, NoOfEmailsPerPage);
                }
            }
            catch (Exception ex)
            {
                liMessageDetails.Text = CommonConstants.MSG_ERROR;
                liMessageDetails.Visible = true;

            }
        }

        protected void btnConfig_Click(object sender, EventArgs e)
        {
            viewPanel.Visible = false;
            composePanel.Visible = false;
            configPanel.Visible = true;

            txtAccount.Text = emailConf.Username;
            txtHost.Text = emailConf.Host;
            txtHostPort.Text = emailConf.HostPort;
            txtSmtpServer.Text = emailConf.SmptServer;
            txtSmtpPort.Text = emailConf.SmptPort;
        }

        protected void btnCancelConfig_Click(object sender, EventArgs e)
        {
            Response.Redirect(CommonConstants.PAGE_ADMIN_MAIL
                                   + CommonConstants.ADD_PARAMETER
                                   + CommonConstants.REQ_PAGE
                                   + CommonConstants.EQUAL + "1");
        }

        protected void btnSubmitConfig_Click(object sender, EventArgs e)
        {
            string _username = txtAccount.Text.Trim();
            string _password = txtPassword.Text;
            string _Host = txtHost.Text.Trim();
            string _HostPort = txtHostPort.Text.Trim();
            string _SmtpServer = txtSmtpServer.Text.Trim();
            string _SmptPort = txtSmtpPort.Text.Trim();

            //control.getValueString(CommonConstants.CF_EMAIL_CONFIG);
            //host - port; username; password; smtpserver - port;

            tblUser user = (tblUser)Session [CommonConstants.SES_USER];
            if (user != null)
            {
                control.updateValue(CommonConstants.CF_EMAIL_CONFIG,
                                     _Host + "-" + _HostPort + ";" + _username + ";" + _password + ";" + _SmtpServer + "-" + _SmptPort,
                                     user.Username);

                Response.Redirect(CommonConstants.PAGE_ADMIN_MAIL
                                   + CommonConstants.ADD_PARAMETER
                                   + CommonConstants.REQ_PAGE
                                   + CommonConstants.EQUAL + "1");

            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

        }

        private bool getEmailConfig()
        {
            emailConf = control.getEmailConfig();
            
            return true;
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_USER] != null)
            {
                if (Session[CommonConstants.SES_EMAIL] != null)
                {
                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                    tblContact contact = (tblContact)Session[CommonConstants.SES_EMAIL];

                    viewPanel.Visible = false;
                    composePanel.Visible = true;

                    txtTo.Text = contact.EmailFrom.Trim();
                    txtSubject.Text = "Re: " + contact.Subject.Trim();
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Session[CommonConstants.SES_EMAIL] = null;
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_USER] != null)
            {
                if (Session[CommonConstants.SES_EMAIL] != null)
                {
                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);
                    tblContact contact = (tblContact)Session[CommonConstants.SES_EMAIL];

                    viewPanel.Visible = false;
                    composePanel.Visible = true;

                    txtSubject.Text = "Fwd: " + contact.Subject.Trim();
                    txtContent.Text = "<br /><br />---------- Forwarded message ----------";
                    txtContent.Text += "<br />";
                    txtContent.Text += "Từ: ";
                    txtContent.Text += contact.EmailFrom.Trim();
                    txtContent.Text += "<br />";
                    txtContent.Text += "Ngày gửi: ";
                    txtContent.Text += contact.Posted.ToString();
                    txtContent.Text += "<br />";
                    txtContent.Text += "Tới: ";
                    txtContent.Text += contact.EmailTo.Trim();
                    txtContent.Text += "<br />";
                    txtContent.Text += "Chủ đề: ";
                    txtContent.Text += contact.Subject.Trim();
                    txtContent.Text += "<br />";
                    txtContent.Text += contact.Contents;
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Session[CommonConstants.SES_EMAIL] = null;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session[CommonConstants.SES_USER] != null)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                int id = Convert.ToInt32(Request.QueryString[CommonConstants.REQ_ID]);

                bool isOK = contactDAO.deleteEmail(id, user.Username);

                if (isOK)
                {
                    Response.Redirect(CommonConstants.PAGE_ADMIN_MAIL
                                        + CommonConstants.ADD_PARAMETER
                                        + CommonConstants.REQ_PAGE
                                        + CommonConstants.EQUAL + "1");
                }
            }
            else
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }

            Session[CommonConstants.SES_EMAIL] = null;
        }

    }
}