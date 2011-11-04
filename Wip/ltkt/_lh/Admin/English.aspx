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
                            <asp:HyperLink ID="hpkShowAll" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=all&page=1">Tất cả </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShow19" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=19&page=1">Lớp 1->9 </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShow10" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=10&page=1">Lớp 10 </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShow11" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=11&page=1">Lớp 11 </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShow12" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=12&page=1">Lớp 12 </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 20%">
                    <h3>
                        &nbsp&nbsp&nbsp&nbsp</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowMath" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=20&page=1">CN Toán </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowEco" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=21&page=1">CN Kinh tế </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowChem" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=22&page=1">CN Hóa </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowBio" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=23&page=1">CN Sinh </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 20%">
                    <h3>
                        &nbsp&nbsp&nbsp&nbsp</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowMat" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=24&page=1">CN KHVL </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowPhy" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=25&page=1">CN Vật lý </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowCom" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=26&page=1">CN Viễn thông </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowIT" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=27&page=1">CN CNTT </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 20%">
                    <h3>
                        &nbsp&nbsp&nbsp&nbsp</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowToeic" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=4049&page=1">TOEIC </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowToefl" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=3039&page=1">TOEFL </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowIelts" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=5059&page=1">IELTS </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowABC" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=abc&page=1">Chứng Chỉ ABC </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 20%;">
                    <h3>
                        Trạng thái
                    </h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowAllState" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=all&state=all&page=1">Tất cả </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowUncheck" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=all&state=0&page=1">Chưa duyệt </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowChecked" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=all&state=1&page=1">Đã duyệt </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowBad" runat="server" NavigateUrl="~/_lh/Admin/English.aspx?action=search&key=all&state=2&page=1">Báo xấu </asp:HyperLink></li>
                    </ul>
                </div>
            </div>
            <asp:Panel ID="messagePanel" runat="server" Visible="false" CssClass="alert">
                <asp:Literal ID="liMessage" runat="server"></asp:Literal>
            </asp:Panel>
            <br />
            <asp:Table ID="EnglishTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="7">
                        <asp:Literal ID="liTableHeader" runat="server"></asp:Literal>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell" VerticalAlign="Middle"><center>#</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Tiêu đề</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Ngày đăng</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Chủ đề</center></asp:TableCell>
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
            <div class="form_settings">
                <div id="divEnglishDetail">
                    <div id="divFunction">
                        <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" OnClick="btnEdit_Click" />
                        <hr />
                    </div>
                    <div>
                        <div id="divDetail" style="float: left; width: 50%; margin-left: 20px">
                            <br />
                            <p>
                                <span><b>Tiêu đề(*):</b></span>
                                <asp:TextBox ID="txtTitle" MaxLength="254" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Tóm tắt:</b></span>
                                <asp:TextBox ID="txtChapeau" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Tác giả:</b></span>
                                <asp:TextBox ID="txtAuthor" runat="server" Enabled="false"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Ngày đăng(*):</b></span>
                                <asp:TextBox ID="txtPosted" runat="server" Enabled="false"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Số người quan tâm:</b></span>
                                <asp:TextBox ID="txtPoint" runat="server" Enabled ="false"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Tag:</b></span>
                                <asp:TextBox ID="txtTag" MaxLength="254" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Nơi lưu bài(*):</b></span>
                                <asp:TextBox ID="txtLocation" MaxLength="200" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span title="Để trống nếu người đánh giá là bạn"><b>Người đánh giá:</b></span>
                                <asp:TextBox ID="txtChecker" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Comment:</b></span>
                                <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            </p>
                        </div>
                        <div id="divRight" style="float: left; width: 48%">
                            <br />
                            <p>
                                <span><b>Thumbnail:</b></span>
                                <asp:TextBox ID="txtThumbnail" MaxLength="254" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Mã nhúng Html:</b></span>
                                <asp:TextBox ID="txtHtmlEmbbed" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Link xem trước:</b></span>
                                <asp:TextBox ID="txtHtmlPreviewLink" MaxLength="254" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Chủ đề:</b></span>
                                <asp:DropDownList ID="ddlClass" runat="server">
                                </asp:DropDownList>
                            </p>
                            <p>
                                <span><b>Loại:</b></span>
                                <asp:DropDownList ID="ddlType" runat="server">
                                </asp:DropDownList>
                            </p>
                            <p>
                                <span><b>Điểm đánh giá:</b></span>
                                <asp:DropDownList ID="ddlScore" runat="server">
                                </asp:DropDownList>
                            </p>
                            <p>
                                <span><b>Đánh giấu Sticky:</b></span>
                                <asp:DropDownList ID="ddlSticky" runat="server">
                                </asp:DropDownList>
                            </p>
                            <p>
                                <span><b>Trạng thái:</b></span>
                                <asp:DropDownList ID="ddlState" runat="server">
                                </asp:DropDownList>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
