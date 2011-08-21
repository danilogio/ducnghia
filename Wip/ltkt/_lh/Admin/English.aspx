<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="English.aspx.cs" Inherits="ltkt.Admin.English" %>

<asp:Content ID="EnglishAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <title>Quản lý chủ đề Anh văn | Website luyện thi kinh tế</title>
    
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

<asp:Content ID="EnglishAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content">
        <h4>
            Tiếng Anh</h4>
    </div>
</asp:Content>
