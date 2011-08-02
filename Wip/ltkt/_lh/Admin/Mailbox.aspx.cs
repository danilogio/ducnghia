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

namespace ltkt.Admin
{
    public partial class Mailbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster page = (AdminMaster)Master;
            page.updateHeader("Hộp thư");

            //IEnumerable<tblContact> lst = ltktDAO.Contact.getAll();
            //grdInbox.DataSource = lst;
            //grdInbox.DataBind();
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
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //Use 0 for anonymous
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "khanhtung010689@gmail.com");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "tKtUngGoogleAccount");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                message.To = strTo;
                message.From = "khanhtung010689@gmail.com";
                message.Subject = strSubject;
                message.BodyFormat = MailFormat.Html;
                message.Body = strContent;
                message.BodyEncoding = Encoding.UTF8;
                SmtpMail.SmtpServer = "smtp.gmail.com:465";

                SmtpMail.Send(message);

                Boolean isOK = ltktDAO.Contact.insertEmail("trungtamducnghia@gmail.com", strTo,
                strSubject, strContent, DateTime.Now);

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
}
}