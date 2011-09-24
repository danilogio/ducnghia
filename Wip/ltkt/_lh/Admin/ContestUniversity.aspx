<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ContestUniversity.aspx.cs" Inherits="ltkt.Admin.ContestUniversity" %>

<asp:Content ID="ContestForUniversityAdminHeader" ContentPlaceHolderID="cphAdminHeader"
    runat="Server">
    <%--<title>Quản lý đề thi đại học | Website luyện thi kinh tế</title>--%>
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    
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
<asp:Content ID="ContestForUniversityAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content">
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
        </asp:Panel>
        <asp:Panel ID="detailPanel" runat="server" Visible="false">
        </asp:Panel>
    </div>
</asp:Content>
