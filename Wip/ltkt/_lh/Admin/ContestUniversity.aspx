<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ContestUniversity.aspx.cs" Inherits="ltkt.Admin.ContestUniversity" %>

<asp:Content ID="ContestForUniversityAdminHeader" ContentPlaceHolderID="cphAdminHeader"
    runat="Server">
    <%--<title>Quản lý đề thi đại học | Website luyện thi kinh tế</title>--%>
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    <link type="text/css" href="styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ContestForUniversityAdmin" ContentPlaceHolderID="cphAdminContent"
    runat="Server">
    <div id="div_content" class="block_text">
        <asp:Panel ID="ErrorMessagePanel" runat="server" Visible="false" CssClass="alert">
                <asp:Literal ID="liErrorMessage" runat="server"></asp:Literal>
        </asp:Panel>
        
        <asp:Panel ID="viewPanel" runat="server">
            <div style="float: left; width: 100%">
                <div align="left" style="float: left; width: 20%">
                    <h3>
                        Môn</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowAll" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&page=1">Tất cả </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowMath" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=math&page=1">Môn Toán </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowPhy" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=phy&page=1">Môn Lý </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowChem" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=chem&page=1">Môn Hóa </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowBio" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=bio&page=1">Môn Sinh </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 50%">
                    <h3>
                        &nbsp&nbsp&nbsp&nbsp</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowLit" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=lit&page=1">Môn văn </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowHis" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=his&page=1">Môn Sử </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowGeo" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=geo&page=1">Môn Địa </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowEng" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=el&page=1">Môn Anh </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float:left; width: 30%">
                <h3>
                    Trạng thái</h3>
                <ul>
                    <li>
                        <asp:HyperLink ID="hpkShowAllState" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=all&page=1">Tất cả </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowUncheck" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=0&page=1">Chưa duyệt </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowChecked" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=1&page=1">Đã duyệt </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowBad" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=2&page=1">Báo xấu </asp:HyperLink></li>
                </ul>
            </div>
            </div>
            
            <asp:Panel ID="messagePanel" runat="server" Visible="false" CssClass="alert">
                <asp:Literal ID="liMessage" runat="server"></asp:Literal>
             </asp:Panel>
            <br />
            <asp:Table ID="ContestTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="7">
                        <asp:Literal ID="liTableHeader" runat="server"></asp:Literal>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Tiêu đề</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Ngày đăng</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Môn</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Người gửi</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Trạng thái</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Thao tác</center></asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell CssClass="table-footer" ColumnSpan="7">
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
        
        
        <asp:Panel ID="detailPanel" runat="server" Visible="false">
        </asp:Panel>
    </div>
</asp:Content>
