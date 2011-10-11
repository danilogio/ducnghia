<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="ltkt.Admin.Contact" %>

<asp:Content ID="ContactAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <title>Quản lý liên hệ | Website luyện thi kinh tế</title>
    
    <%--<link rel="stylesheet" href="styles.css" type="text/css" />
    <style type="text/css">
        body
        {
            background: white;
            margin: 0;
            padding: 0;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #444;
        }
        .footer-content1
        {
            padding: 20px 5px;
        }
    </style>--%>
</asp:Content>

<asp:Content ID="ContactAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <asp:Panel ID="statusMessagePanel" runat="server" Visible="false" CssClass="alert">
        <asp:Literal ID="liStatusMessage" runat="server"></asp:Literal>
    </asp:Panel>
    <div id="div_content" class="block_text">
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
        
        </asp:Panel>
    </div>
</asp:Content>
