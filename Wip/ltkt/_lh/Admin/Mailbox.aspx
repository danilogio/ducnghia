<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Mailbox.aspx.cs" Inherits="ltkt.Admin.Mailbox" Title="Hộp thư" %>

<asp:Content ID="MailboxHeader" ContentPlaceHolderID="head" runat="Server">
    <title>Hộp thư</title>
</asp:Content>
<asp:Content ID="Security" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="mailbox" class="block_text">
        <div class="form_settings">
            <div id="functionHeader" class="form_settings">
                <asp:Button ID="btnCompose" runat="server" Text="Soạn thư" CssClass="formbutton" />&nbsp;
                <asp:Button ID="btnCheck" runat="server" Text="Kiểm tra thư" CssClass="formbutton" />&nbsp;
                <asp:Button ID="btnReply" runat="server" Text="Trả lời" CssClass="formbutton" />&nbsp;
                <asp:Button ID="btnForward" runat="server" Text="Chuyển tiếp" CssClass="formbutton" />&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="formbutton" />
                <br />
                <br />
                <hr />
            </div>
            <asp:Panel ID="viewPanel" runat="server" Visible="false">
                <div id="left" style="float: left; width: 20%;">
                    <br />
                    <asp:Button ID="btnInbox" runat="server" Text="Hộp thư đến" OnClick="btnInbox_Click"
                        CssClass="formbutton" />
                    <br />
                    <br />
                    <asp:Button ID="btnSent" runat="server" Text="Hộp  thư  đi" OnClick="btnSent_Click"
                        CssClass="formbutton" />
                </div>
                <div id="right" style="float: left; width: 78%;">
                </div>
            </asp:Panel>
            <br />
            <asp:Panel ID="composePanel" runat="server">
                <div id="to">
                    <p>
                        <span>Đến:</span>
                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Chủ đề:</span>
                        <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Nội dung:</span>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                    </p>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
