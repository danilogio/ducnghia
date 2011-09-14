<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Permisson.aspx.cs" Inherits="ltkt.Admin.Permission" %>

<asp:Content ID="PermissionAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <%--<title>Quản lý phân quyền | Website luyện thi kinh tế</title>--%>
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

<asp:Content ID="PermissonAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div class="block_text" >
        <asp:Panel ID="searchPanel" runat="server">
            <div class="form_settings">
                <p style="padding-left: 200px">
                    <span>Nhập tên tài khoản:</span>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Tìm" CssClass="formbutton" OnClick="btnSearch_Click" />
                </p>
                <div id="searchUserResult">
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </div>
                <hr />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
