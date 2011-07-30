<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="DucNghia.Admin.Admin_News" %>

<asp:Content ID="NewsAdmin" ContentPlaceHolderID="cphAdminContent" Runat="Server">
    <link rel="stylesheet" href="styles.css" type="text/css" />
    <style type="text/css">
       body {
	            background: white;
	            margin:0;
	            padding:0;
	            font-family: Arial, Helvetica, sans-serif;
	            font-size: 13px;
	            color: #444;
            }
   .footer-content1 {
	       
	        padding: 20px 5px;
        }
    </style>
    
    <div id="div_content">
        <asp:Panel ID="addNewsPanel" runat="server">
        </asp:Panel>
        
        <asp:Panel ID="viewPanel" runat="server">
        </asp:Panel>
    </div>
</asp:Content>

