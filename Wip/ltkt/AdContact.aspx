<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdContact.aspx.cs" Inherits="AdContact" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="AdContact" ContentPlaceHolderID="cphContent" Runat="Server">
    <div id="Advertisement" class="block_text">
        <h2>Liên hệ quảng cáo</h2>
        <hr />
        <div id="divMessage" class="form_settings">
            <asp:Literal ID="liMessage" runat="server" Text="" Visible="False"></asp:Literal>
        </div>
        
        <form action="Contact.aspx" method="post">
        <asp:Panel ID="contactPanel" runat="server">
            <div class="form_settings">
                <p>
                    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
                </p>
                <p>
                    <span>Tên Công ty(*):</span><asp:TextBox ID="txtboxCompanyName" runat="server"></asp:TextBox>
                </p>
                <asp:RequiredFieldValidator ID="reqComName" runat="server" ErrorMessage="Vui lòng nhập tên công ty"
                    ControlToValidate="txtboxCompanyName" Display="None">
                </asp:RequiredFieldValidator>
               <%-- Address--%>
                <p>
                    <span>Địa chỉ(*):</span><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </p>
                <asp:RequiredFieldValidator ID="reqAddress" runat="server" ErrorMessage="Vui lòng nhập địa chỉ công ty"
                    ControlToValidate="txtAddress" Display="None">
                </asp:RequiredFieldValidator>
                <%--Email--%>
                <p>
                    <span>Email(*):</span><asp:TextBox ID="txtboxContactEmail" runat="server"></asp:TextBox>
                </p>
                <asp:RequiredFieldValidator ID="reqContactEmail" runat="server" ErrorMessage="Vui lòng nhập email liên lạc"
                    ControlToValidate="txtboxContactEmail" Display="none">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtboxContactEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không đúng định dạng"
                    Display="None" />
                <%--Phone--%>
                <p>
                    <span>Phone(*):</span><asp:TextBox ID="txtboxFone" runat="server"></asp:TextBox>
                </p>
                <asp:RequiredFieldValidator ID="reqContactTitle" runat="server" ErrorMessage="Vui lòng nhập số điện thoại"
                    ControlToValidate="txtboxFone" Display="None">
                </asp:RequiredFieldValidator>
                <%--From date - To Date--%>
                <p>
                    <span>Từ ngày:</span><asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox> - Đến ngày:<asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                </p>
                   
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

