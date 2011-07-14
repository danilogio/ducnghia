<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="contact" class="block_text">
        <h2>Lấy lại mật khẩu</h2>
        <hr />
        <p>Vui lòng nhập email đăng ký. Chúng tôi sẽ gửi lại mật khẩu vào email sau ít phút:</p>
        <form action="Contact.aspx" method="post">
          <div class="form_settings">
            <p><span>Email:</span><asp:TextBox ID="txtboxRegistryEmail" runat="server" CssClass="contact"></asp:TextBox></p>
            <p><center><cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5" CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#"/></center><span>Mã xác nhận:</span><asp:TextBox ID="TextBox1" runat="server" CssClass="contact"></asp:TextBox></p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" CssClass="submit" /></p>
          </div>
        </form>
    </div>
</asp:Content>

