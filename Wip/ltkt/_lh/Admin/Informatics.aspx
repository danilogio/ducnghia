<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Informatics.aspx.cs" Inherits="ltkt.Admin.Informatics" %>

<asp:Content ID="InformacticAdminHeader" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    <link type="text/css" href="styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="InformaticsAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content" class="block_text">
        <asp:Panel ID="ErrorMessagePanel" runat="server" Visible="false" CssClass="alert">
            <asp:Literal ID="liErrorMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
            <div style="float: left; width: 100%">
                <div align="left" style="float: left; width: 20%">
                    <h3>
                        Chủ đề</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowAll" runat="server" NavigateUrl="~/_lh/Admin/Informatics.aspx?action=search&key=all&page=1">Tất cả </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowWord" runat="server" NavigateUrl="~/_lh/Admin/Informatics.aspx?action=search&key=4&page=1">Word </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowExcel" runat="server" NavigateUrl="~/_lh/Admin/Informatics.aspx?action=search&key=1&page=1">Excel </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowPP" runat="server" NavigateUrl="~/_lh/Admin/Informatics.aspx?action=search&key=2&page=1">Power Point </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowAccess" runat="server" NavigateUrl="~/_lh/Admin/Informatics.aspx?action=search&key=3&page=1">Access </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 50%">
                    <h3>
                        &nbsp&nbsp&nbsp&nbsp</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowSimTip" runat="server" NavigateUrl="~/_lh/Admin/Informatics.aspx?action=search&key=10&page=1">Thủ thuật căn bản </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowAdvTip" runat="server" NavigateUrl="~/_lh/Admin/Informatics.aspx?action=search&key=20&page=1">Thủ thuật nâng cao </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 30%;">
                    <h3>
                        Trạng thái
                    </h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowAllState" runat="server" NavigateUrl="Informatics.aspx?action=search&key=all&state=all&page=1">Tất cả </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowUncheck" runat="server" NavigateUrl="Informatics.aspx?action=search&key=all&state=0&page=1">Chưa duyệt </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowChecked" runat="server" NavigateUrl="Informatics.aspx?action=search&key=all&state=1&page=1">Đã duyệt </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowBad" runat="server" NavigateUrl="Informatics.aspx?action=search&key=all&state=2&page=1">Báo xấu </asp:HyperLink></li>
                    </ul>
                </div>
            </div>
            <asp:Panel ID="messagePanel" runat="server" Visible="false" CssClass="alert">
                <asp:Literal ID="liMessage" runat="server"></asp:Literal>
            </asp:Panel>
            <br />
            <asp:Table ID="InformaticsTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="7">
                        <asp:Literal ID="liTableHeader" runat="server"></asp:Literal>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Tiêu đề</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Ngày đăng</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Chủ đề</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Người gửi</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Trạng thái</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Thao tác</asp:TableCell>
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
            <div class="form_settings">
                <div id="divFunction">
                    <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" OnClick="btnEdit_Click" />
                    <hr />
                </div>
                <div id="divDetail">
                    <p>
                        <span>Tiêu đề:</span>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Tóm tắt:</span>
                        <asp:TextBox ID="txtChapeau" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Tác giả:</span>
                        <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Ngày đăng:</span>
                        <asp:TextBox ID="txtPosted" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Điểm:</span>
                        <asp:TextBox ID="txtPoint" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Tag:</span>
                        <asp:TextBox ID="txtTag" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Trạng thái:</span>
                        <asp:DropDownList ID="ddlState" runat="server">
                        </asp:DropDownList>
                    </p>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
