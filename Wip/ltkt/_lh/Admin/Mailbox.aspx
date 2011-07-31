<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Mailbox.aspx.cs" Inherits="ltkt.Admin.Mailbox" Title="Hộp thư" %>

<asp:Content ID="MailboxHeader" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Mailbox" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <title>Hộp thư</title>
    <div class="block_text" style="margin:5px;">
        <div id="funtionHeader">
            <asp:Button ID="btnNewMail" runat="server" Text="Soạn thư" />
            <asp:Button ID="btnCheckMail" runat="server" Text="Kiểm tra thư" />
            <asp:Button ID="btnReply" runat="server" Text="Trả lời" />
            <asp:Button ID="btnForward" runat="server" Text="Chuyể tiếp" />
            <asp:Button ID="btnDelete" runat="server" Text="Xóa" />
            <hr />
        </div>
        <div id="leftSidebar">
            
        </div>
        <div id="rightSidebar">
        </div>
    </div>
</asp:Content>
