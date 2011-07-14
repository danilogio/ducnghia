<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div id="loginForm" class="block_text">
        <h2>Đăng nhập tài khoản</h2>
        <hr />
        
        <form action="Login.aspx" method="post">
          <div class="form_settings">
            <p><span>Tên đăng nhập:</span><asp:TextBox ID="txtboxLoginName" runat="server" CssClass="contact"></asp:TextBox></p>
            <p><span>Mật khẩu:</span><asp:TextBox ID="txtboxPassword" TextMode="Password" runat="server" CssClass="contact"></asp:TextBox></p>
            <p><center><cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5" CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#"/></center><span>Mã xác nhận:</span><asp:TextBox ID="TextBox1" runat="server" CssClass="contact"></asp:TextBox></p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button ID="btnSubmitLogin" runat="server" Text="Đăng nhập" CssClass="submit" /></p>
          </div>
        </form>
        <p><br /><br />Nếu bạn chưa có tài khoản, hãy nhấp vào 
            <asp:HyperLink ID="hpkSignup" runat="server" NavigateUrl="~/Registry.aspx">Đăng ký</asp:HyperLink> 
            <br />Hoặc bạn đã quên mật khẩu của tài khoản thì vui lòng nhấn vào 
            <asp:HyperLink ID="hpkResetPassword" runat="server" NavigateUrl="~/ResetPassword.aspx">Lấy lại mật khẩu</asp:HyperLink></p>
    </div>
</asp:Content>

