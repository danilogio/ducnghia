<%@ Page Title="Quản lý chung" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="General.aspx.cs" Inherits="ltkt.Admin.General" %>

<asp:Content ID="GeneralAdminHead" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý chung</title>
</asp:Content>
<asp:Content ID="GeneralAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
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
    
    <div id="div_content">
        <h4>Chung</h4>
        <hr />
        
        <div id="divContent">
        </div>
    </div>
</asp:Content>
