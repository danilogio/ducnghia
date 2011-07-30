using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Mail;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {   
            tblUser user = (tblUser)Session["User"];
            txtboxContactName.Text = user.DisplayName;
            txtboxContactEmail.Text = user.Email.Trim();
        }
    }

    protected void btnSubmitContact_Click(object sender, EventArgs e)
    {
        string strContactName = txtboxContactName.Text;
        string strContactEmail = txtboxContactEmail.Text;
        string strContactTitle = "";
        string strContactMessage = txtboxContactMessage.Text;

        try
        {
            MailMessage message = new MailMessage();
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //Use 0 for anonymous
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "trungtamducnghia@gmail.com");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "123456987");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
            message.To = "trungtamducnghia@gmail.com";
            message.From = strContactEmail;
            message.Subject = strContactTitle;
            message.BodyFormat = MailFormat.Text;
            message.Body = strContactEmail + ":\n " + strContactMessage;
            SmtpMail.SmtpServer = "smtp.gmail.com:465";

            SmtpMail.Send(message);

            liMessage.Visible = true;
            contactPanel.Visible = false;
            liMessage.Text = "Phản hồi của bạn đã được gửi thành công đến cho chúng tôi. Chân thành cảm ơn đóng góp của bạn!";
        }
        catch (Exception ex)
        {
            liMessage.Visible = true;
            liMessage.Text = String.Format("Phản hồi của bạn gửi không thành công. Xin vui lòng kiểm tra lại địa chỉ email của bạn ({0})", ex.Message);
            liMessage.Text += "\r\n <a href=\"Contact.aspx\">Thử lại</a>";
            contactPanel.Visible = false;
        }

    }
}
