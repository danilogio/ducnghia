<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResetPassword.aspx.cs" Inherits="ltkt.ResetPassword" %>


<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="SearchHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title>Lấy lại mật khẩu | Website luyện thi kinh tế</title>
</asp:Content>

<asp:Content ID="ResetPassword" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="contact" class="block_text">
        <h2>
            Lấy lại mật khẩu</h2>
        <hr />
        
        <p>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                HeaderText="Lỗi" />
        </p>
        <form action="ResetPassword.aspx" method="post">
        <asp:Panel runat="server" ID="requestPassword">
            <div id="divBusiness" class="form_settings">
            <p>
            Vui lòng nhập email đăng ký. Chúng tôi sẽ gửi lại mật khẩu vào email sau ít phút:</p>
                <p>
                    <span>Email:</span><asp:TextBox ID="txtboxRegistryEmail" runat="server" CssClass="contact"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Vui lòng nhập email liên lạc"
                        ControlToValidate="txtboxRegistryEmail" Display="none">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtboxRegistryEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không đúng định dạng"
                        Display="None" />
                </p>
                 <p>
                    <div align="center" style="margin-top: 10px; margin-left: 100px">
                        <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LfZ4MYSAAAAACHZzxmZmcaLeBN7ywBD5e5TxEDA"
                            PrivateKey="6LfZ4MYSAAAAAE9Oe291w86KwMIT83fSvvEvBOPH" />
                    </div>
                </p>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnResetPassword" OnClick='btnResetPassword_Click'
                        runat="server" Text="Gửi" CssClass="submit" /></p>
            </div>
        </asp:Panel>
        
        </form>
        
        <div id="divMessage" class="form_settings">
            <asp:Literal ID="liMessage" runat="server" Text="" Visible="False"></asp:Literal>
        </div>
    </div>
</asp:Content>
