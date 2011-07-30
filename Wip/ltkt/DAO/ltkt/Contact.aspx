<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Contact" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="contact" class="block_text">
        <h2>
            Liên hệ/Góp ý</h2>
        <hr />
        <div id="divMessage" class="form_settings">
            <asp:Literal ID="liMessage" runat="server" Text="" Visible="False"></asp:Literal>
        </div>
        <form action="Contact.aspx" method="post">
        <asp:Panel ID="contactPanel" runat="server">
            <p>
                Mọi thắc mắc/góp ý các bạn vui lòng gửi lại cho chúng tôi để có thể phục vụ các
                bạn tốt hơn:</p>
            <div class="form_settings">
                <p>
                    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
                </p>
                <p>
                    <span>Tên:</span><asp:TextBox ID="txtboxContactName" runat="server" CssClass="contact"></asp:TextBox></p>
                <asp:RequiredFieldValidator ID="reqcontactName" runat="server" ErrorMessage="Vui lòng nhập tên để chúng tôi tiện liên lạc"
                    ControlToValidate="txtboxContactName" Display="None">
                </asp:RequiredFieldValidator>
                <p>
                    <span>Email:</span><asp:TextBox ID="txtboxContactEmail" runat="server" CssClass="contact"></asp:TextBox></p>
                <asp:RequiredFieldValidator ID="reqContactEmail" runat="server" ErrorMessage="Vui lòng nhập email liên lạc"
                    ControlToValidate="txtboxContactEmail" Display="none">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtboxContactEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không đúng định dạng"
                    Display="None" />
                <p>
                    <span>Tiêu đề:</span><asp:TextBox ID="txtboxContactTitle" runat="server" CssClass="contact"></asp:TextBox></p>
                <asp:RequiredFieldValidator ID="reqContactTitle" runat="server" ErrorMessage="Vui lòng nhập tiêu đề email"
                    ControlToValidate="txtboxContactTitle" Display="None">
                </asp:RequiredFieldValidator>
                <p>
                    <span>Lời gửi:</span><asp:TextBox ID="txtboxContactMessage" runat="server" Columns="50"
                        Rows="8" CssClass="contact textarea" TextMode="MultiLine"></asp:TextBox></p>
                <asp:RequiredFieldValidator ID="reqContactMessage" runat="server" ErrorMessage="Vui lòng nhập nội dung"
                    ControlToValidate="txtboxContactMessage" Display="None">
                </asp:RequiredFieldValidator>
                <center>
                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5"
                        CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5"
                        CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#" />
                </center>
                <span>Mã xác nhận:</span><asp:TextBox ID="txtboxConfirm" runat="server" CssClass="contact"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqContactCaptcha" runat="server" ErrorMessage="Vui lòng nhập mã xác nhận"
                    ControlToValidate="txtboxConfirm" Display="none">
                </asp:RequiredFieldValidator>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" CssClass="submit"
                        OnClick="btnSubmitContact_Click" /></p>
            </div>
        </asp:Panel>
        </form>
    </div>
</asp:Content>
