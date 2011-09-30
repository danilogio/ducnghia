<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Comment.aspx.cs" Inherits="ltkt.Admin.Comment" %>

<asp:Content ID="CommentAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <%--<title>Quản lý bình luận, comment | Website luyện thi kinh tế</title>--%>
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    
    
</asp:Content>

<asp:Content ID="CommentAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content" class="block_text">
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
        </asp:Panel>
    </div>
</asp:Content>
