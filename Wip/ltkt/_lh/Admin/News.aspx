<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="ltkt.Admin.News" %>

<asp:Content ID="NewsAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <title>Quản lý tin tức | Website luyện thi kinh tế</title>
    
    <link rel="stylesheet" href="styles.css" type="text/css" />
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
    </style>
</asp:Content>
<asp:Content ID="NewsAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    
    <div id="div_content">
        <asp:Panel ID="viewPanel" runat="server">
            <div id="addButton">
                <asp:Button ID="btnAddNews" runat="server" Text="Thêm tin tức" CssClass="searchform" />
            </div>
            <div id="viewNews" class="block_text">
            </div>
        </asp:Panel>
        
        <asp:Panel ID="editPanel" runat="server">
        </asp:Panel>
        
        <asp:Panel ID="addPanel" runat="server"></asp:Panel>
    </div>
</asp:Content>
