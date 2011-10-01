<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Informatics.aspx.cs" Inherits="ltkt.Admin.Informatics" %>

<asp:Content ID="InformacticAdminHeader" ContentPlaceHolderID="cphAdminHeader" Runat="Server">
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    
    <link type="text/css" href="styles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="InformaticsAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content" class="block_text">
        <asp:Panel ID="messagePanel" runat="server" Visible="false" CssClass="alert">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
            <div align="left" style="float:left; width: 15%;">
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
            <asp:Table ID="InformaticsTable" CssClass="table" runat="server">
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
    </div>
</asp:Content>
