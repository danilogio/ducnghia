<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="ltkt.Admin.News" ValidateRequest="false" %>

<asp:Content ID="NewsAdminHeader" ContentPlaceHolderID="cphAdminHeader" runat="Server">
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
    <%--tinyMCE--%>

    <script type="text/javascript" src="../../js/tinyMCE/tiny_mce.js"></script>

    <script type="text/javascript" language="javascript">
        tinyMCE.init({

            mode: "textareas",
            theme: "advanced",
            editor_deselector: "NoEditor",
            // Theme options

            theme_advanced_buttons1: "bold,italic,underline,strikethrough,formatselect,fontselect,fontsizeselect,forecolor,backcolor,link,image,bullist,numlist,justifyleft,justifycenter,justifyright,justifyfull",
            theme_advanced_buttons2: "",
            theme_advanced_buttons3: "",

            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "center"

        });
    </script>

</asp:Content>
<asp:Content ID="NewsAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content" class="block_text">
        <asp:Panel ID="viewPanel" runat="server">
            <div id="addButton" class="form_settings">
                <asp:Button ID="btnAddNews" runat="server" Text="Thêm tin tức" CssClass="formbutton"
                    OnClick="btnAddNews_Click" />
            </div>
            <br />
            <div id="viewNews">
                <asp:Table ID="NewsTable" CssClass="table" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell CssClass="table-header" ColumnSpan="5">
                                Quản lý tin tức
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                        <asp:TableCell CssClass="table-header-cell">Tiêu đề</asp:TableCell>
                        <asp:TableCell CssClass="table-header-cell">Ngày đăng</asp:TableCell>
                        <asp:TableCell CssClass="table-header-cell">Người gửi</asp:TableCell>
                        <asp:TableCell CssClass="table-header-cell">Thao tác</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableFooterRow>
                        <asp:TableCell CssClass="table-footer" ColumnSpan="5">
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
            </div>
        </asp:Panel>
        <asp:Panel ID="addPanel" runat="server">
            <p>
                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
            </p>
            <div id="addNews" class="form_settings">
                <%--<asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />--%>
                <div id="composeFunction">
                    <asp:Button ID="btnSave" runat="server" Text="Thêm" CssClass="formbutton" OnClick="btnSave_Click" />&nbsp;
                    <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnSticky" runat="server" Text="Sticky" CssClass="formbutton" Visible="false" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Quay lại" CssClass="formbutton" OnClick="btnCancel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal ID="liMessage" runat="server" Text="" Visible="False"></asp:Literal>
                    <br />
                    <br />
                    <hr />
                </div>
                <div id="titleHeader">
                    <br />
                    <p>
                        <span>Tiêu đề</span>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqTitle" runat="server" ErrorMessage="Vui lòng nhập Tiêu đề"
                            ControlToValidate="txtTitle" Display="None">
                        </asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <span>Tóm tắt</span>
                        <asp:TextBox ID="txtChapeau" runat="server" TextMode="MultiLine" Rows="5" CssClass="NoEditor"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập Tóm tắt"
                            ControlToValidate="txtChapeau" Display="None">
                        </asp:RequiredFieldValidator>
                    </p>
                </div>
                <div id="composeContent">
                    <p>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="12"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vui lòng nhập Nội dung tin tức"
                            ControlToValidate="txtContent" Display="None">
                        </asp:RequiredFieldValidator>
                    </p>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
