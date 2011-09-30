<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="English.aspx.cs" Inherits="ltkt.Admin.English" %>

<asp:Content ID="EnglishAdminHeader" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <%--<title>Quản lý chủ đề Anh văn | Website luyện thi kinh tế</title>--%>
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
    
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    
    <link type="text/css" href="styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="EnglishAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div class="block_text">
        <asp:Panel ID="messagePanel" runat="server" Visible="false" CssClass="alert">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
            <div align="left">
                <h3>
                    Xem nâng cao</h3>
                <ul>
                    <li><a href="Advertisement.aspx?action=search&key=all&page=1">Tất cả</a></li>
                    <li><a href="Advertisement.aspx?action=search&key=0&page=1">Chưa duyệt</a></li>
                    <li><a href="Advertisement.aspx?action=search&key=1&page=1">Đã duyệt</a></li>
                    <li><a href="Advertisement.aspx?action=search&key=10&page=1">Pending</a></li>
                    <li><a href="Advertisement.aspx?action=search&key=56&page=1">Khóa</a></li>
                    <li><a href="Advertisement.aspx?action=search&key=13&page=1">Sticky</a></li>
                    <li><a href="Advertisement.aspx?action=search&key=loc&page=1">Theo vị trí</a></li>
                </ul>
            </div>
            <asp:Table ID="EnglishTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="6">
                         <asp:Literal ID="liTableHeader" runat="server"></asp:Literal>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Tiêu đề</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Ngày đăng</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Người gửi</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Trạng thái</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Thao tác</asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell CssClass="table-footer" ColumnSpan="6">
                        <asp:Table ID="FooterTable" Width="100%" BorderWidth="0" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Literal ID="PreviousPageLiteral" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Right">
                                    <asp:Literal ID="NextPageLiteral" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
        </asp:Panel>
    </div>
</asp:Content>
