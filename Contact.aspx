<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="contact" class="block_text">
        <h2>Liên hệ/Góp ý</h2>
        <hr />
        <p>Mọi thắc mắc/góp ý các bạn vui lòng gửi lại cho chúng tôi để có thể phục vụ các bạn tốt hơn:</p>
        <form action="Contact.aspx" method="post">
          <div class="form_settings">
            <p><span>Tên:</span><asp:TextBox ID="txtboxContactName" runat="server" CssClass="contact"></asp:TextBox></p>
            <p><span>Email:</span><asp:TextBox ID="txtboxcontactEmail" runat="server" CssClass="contact"></asp:TextBox></p>
            <p><span>Lời gửi:</span><asp:TextBox ID="txtboxContactMessage" runat="server" Columns="50" Rows="8" CssClass="contact textarea" TextMode="MultiLine"></asp:TextBox></p>
            <p><center><cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="none" CaptchaLength="5" CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" /></center><span>Mã xác nhận:</span><asp:TextBox ID="TextBox1" runat="server" CssClass="contact"></asp:TextBox></p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" CssClass="submit" /></p>
          </div>
        </form>
        <p><br /><br />Lưu ý: Các bạn vui lòng để lại email của mình để chúng tôi tiện liên lạc.</p>
    </div>
</asp:Content>

