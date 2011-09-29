<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Comment.aspx.cs" Inherits="ltkt.Admin.Comment" %>

<asp:Content ID="CommentAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <%--<title>Quản lý bình luận, comment | Website luyện thi kinh tế</title>--%>
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

<asp:Content ID="CommentAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content">
        <h4>
            Comment</h4>
    </div>
</asp:Content>
