<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Advertisement.aspx.cs" Inherits="ltkt.Admin.Advertisement" %>

<asp:Content ID="AdvertisementAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <title>Quản lý quảng cáo | Website luyện thi kinh tế</title>
    
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

<asp:Content ID="AdvertisementAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="content">
        <h4>
            Quảng cáo</h4>
    </div>
</asp:Content>
