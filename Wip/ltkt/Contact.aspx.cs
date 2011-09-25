using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
using System.Web.Mail;
using System.Text;


namespace ltkt
{
    public partial class Contact : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.Contact contactDAO = new ltktDAO.Contact();

        public const string Host = "pop.gmail.com";
        public const int Port = 995;
        public const string Email = "";
        public const string Password = "";
        public const string SmtpServer = "smtp.gmail.com";
        public const string SmtpPort = "465";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[CommonConstants.SES_USER] != null)
                {
                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    txtboxContactName.Text = user.DisplayName;
                    txtboxContactEmail.Text = user.Email.Trim();
                }

                liTitle.Text = CommonConstants.PAGE_CONTACT_NAME
                               + CommonConstants.SPACE + CommonConstants.HLINE
                               + CommonConstants.SPACE
                               + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        protected void btnSubmitContact_Click(object sender, EventArgs e)
        {
            string strContactName = txtboxContactName.Text;
            string strContactEmail = txtboxContactEmail.Text;
            string strContactTitle = txtboxContactTitle.Text;
            string strContactMessage = txtboxContactMessage.Text;

            if (!recaptcha.IsValid)
            {
                return;
            }

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
                message.To = Email;
                message.From = strContactEmail;
                message.Subject = strContactTitle;
                message.BodyFormat = MailFormat.Text;
                message.Body = strContactEmail + ":\n " + strContactMessage;
                message.BodyEncoding = Encoding.UTF8;
                SmtpMail.SmtpServer = SmtpServer + ":" + SmtpPort;

                SmtpMail.Send(message);

                liMessage.Visible = true;
                contactPanel.Visible = false;
                liMessage.Text = CommonConstants.MSG_I_REPLY_SUCCESSFUL;

                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                Boolean isOK = contactDAO.insertEmail(user.Username, strContactEmail, Email,
                                                      strContactTitle, message.Body, DateTime.Now);
            }
            catch (Exception ex)
            {
                liMessage.Visible = true;
                liMessage.Text = CommonConstants.MSG_E_REPLY_FAILED;
                contactPanel.Visible = false;

                //Write to log
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }

        }
    }
}