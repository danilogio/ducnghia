<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="ltkt.Login" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Login" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="loginForm" class="block_text">
        <h2>
            Đăng nhập tài khoản</h2>
        <hr />
        <p>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                HeaderText="Lỗi" />
        </p>
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
            <asp:Literal ID="lMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="loginPanel" runat="server">
            <%--<form action="Login.aspx" method="post">--%>
            <div class="form_settings">
                <p>
                    <span>Tên đăng nhập:</span><asp:TextBox ID="txtboxLoginName" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập tên đăng nhập"
                        ControlToValidate="txtboxLoginName" Display="None">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Tên đăng nhập từ 6 tới 20 kí tự và không được chứa khoảng trắng"
                        ControlToValidate="txtboxLoginName" Display="None" ValidationExpression="^[a-zA-Z'.\S]{6,20}$">
                    </asp:RegularExpressionValidator>
                </p>
                <p>
                    <span>Mật khẩu:</span><asp:TextBox ID="txtboxPassword" TextMode="Password" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vui lòng nhập mật khẩu"
                        ControlToValidate="txtboxPassword" Display="none">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <div align="center" style="margin-top:10px; margin-left:100px">
                   <recaptcha:RecaptchaControl ID="recaptcha" runat="server"  PublicKey="6LfZ4MYSAAAAACHZzxmZmcaLeBN7ywBD5e5TxEDA"
                        PrivateKey="6LfZ4MYSAAAAAE9Oe291w86KwMIT83fSvvEvBOPH"/>
                    </div>
                </p>
                <%--<center>
                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5"
                        CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5"
                        CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#" />
                </center>
                <span>Mã xác nhận:</span><asp:TextBox ID="txtboxCaptcha" runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Vui lòng nhập mã xác nhận"
                    ControlToValidate="txtboxCaptcha" Display="none">
                </asp:RequiredFieldValidator>--%>
                
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmitLogin" runat="server" OnClick="btnSubmitLogin_Click"
                        Text="Đăng nhập" CssClass="submit" /></p>
            </div>
           <%-- </form>--%>
            <p>
                <br />
                <br />
                Nếu bạn chưa có tài khoản, hãy nhấp vào
                <asp:HyperLink ID="hpkSignup" runat="server" NavigateUrl="~/Registry.aspx">Đăng ký</asp:HyperLink>
                <br />
                Hoặc bạn đã quên mật khẩu của tài khoản thì vui lòng nhấn vào
                <asp:HyperLink ID="hpkResetPassword" runat="server" NavigateUrl="~/ResetPassword.aspx">Lấy lại mật khẩu</asp:HyperLink>
            </p>
        </asp:Panel>
    </div>
    
</asp:Content>
