<%@ Page Title="Quản lý chung" Language="C#" MasterPageFile="~/AdminMaster.master"
    AutoEventWireup="true" CodeFile="General.aspx.cs" Inherits="ltkt.Admin.General" %>

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
        <div id="Summary" class="block_text form_settings" style="margin: 5px;">
            <p>
                <span>Số thành viên:</span>
                <asp:Literal ID="sumUsers" runat="server"></asp:Literal>
            </p>
            <p>
                <span>Thành viên mới nhất:</span>
                <asp:Literal ID="latestUser" runat="server"></asp:Literal>
            </p>
            <p>
                <span>Thành viên đăng nhập gần nhất</span>
                <asp:ListBox ID="lstLatestUsers" runat="server">
                    <asp:ListItem Text="dvtrung" Value="dvtrung"></asp:ListItem>
                    <asp:ListItem Text="dvtrung" Value="dvtrung"></asp:ListItem>
                    <asp:ListItem Text="dvtrung" Value="dvtrung"></asp:ListItem>
                    <asp:ListItem Text="dvtrung" Value="dvtrung"></asp:ListItem>
                    <asp:ListItem Text="dvtrung" Value="dvtrung"></asp:ListItem>
                </asp:ListBox>
            </p>
            <p>
                <span>Số bài viết:</span>
                <asp:Literal ID="sumArticle" runat="server"></asp:Literal>
            </p>
            <p>
                <span>Lượt truy cập:</span>
                <asp:Literal ID="pageView" runat="server" Text="asdfasdf"></asp:Literal>
            </p>
        </div>
    </div>
</asp:Content>
