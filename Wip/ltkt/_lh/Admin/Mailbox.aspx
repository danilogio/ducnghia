<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Mailbox.aspx.cs" Inherits="ltkt.Admin.Mailbox" Title="Hộp thư" ValidateRequest="false" %>

<asp:Content ID="MailboxHeader" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>Hộp thư | Website luyện thi kinh tế</title>

    <script type="text/javascript" src="../../js/tinyMCE/tiny_mce.js"></script>

    <script type="text/javascript" language="javascript">

    tinyMCE.init({

        mode: "textareas",
        theme: "advanced",
        // Theme options

        theme_advanced_buttons1: "bold,italic,underline,strikethrough,formatselect,fontselect,fontsizeselect,forecolor,backcolor,link,image,bullist,numlist,justifyleft,justifycenter,justifyright,justifyfull",
        theme_advanced_buttons2: "",
        theme_advanced_buttons3: "",
        
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "center"  

    });

    </script>

    <style type="text/css">
        .emails-table
        {
            width: 600px;
            border: solid 1px #444444;
        }
        .emails-table-header
        {
            font-family: "Trebuchet MS";
            font-size: 9pt;
            background-color: #0099B9;
            color: white;
            border: solid 1px #444444;
        }
        .emails-table-header-cell
        {
            font-family: "Georgia";
            font-size: 9pt;
            font-weight: bold;
            border: solid 1px #666666;
            padding: 6px;
        }
        .emails-table-cell
        {
            font-family: "Georgia";
            font-size: 9pt;
            width: 500px;
            border: solid 1px #666666;
            padding: 6px;
        }
        .emails-table-footer
        {
            border: solid 1px #666666;
            padding: 3px;
            width: 50%;
        }
        .email-datetime
        {
            float: right;
            color: #666666;
        }
        a:hover
        {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Mailbox" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <%--<div id="mailbox" class="block_text">--%>
    <div class="form_settings">
        <asp:Panel ID="viewPanel" runat="server">
            <div id="viewHeader" class="form_settings">
                <asp:Button ID="btnCompose" runat="server" Text="Soạn thư" CssClass="formbutton"
                    OnClick="btnCompose_Click" />&nbsp;
                <asp:Button ID="btnCheck" runat="server" Text="Kiểm tra thư" CssClass="formbutton"
                    OnClick="btnCheck_Click" />&nbsp;
                <asp:Button ID="btnReply" runat="server" Text="Trả lời" CssClass="formbutton" />&nbsp;
                <asp:Button ID="btnForward" runat="server" Text="Chuyển tiếp" CssClass="formbutton" />&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="formbutton" />&nbsp;
                <asp:Button ID="btnConfig" runat="server" Text="Cấu hình" CssClass="formbutton" OnClick="btnConfig_Click" />
                <br />
                <br />
                <hr />
            </div>
            <div id="left" style="float: left; width: 15%;">
                <br />
                <asp:Button ID="btnInbox" runat="server" Text="Hộp thư đến" OnClick="btnInbox_Click"
                    CssClass="formbutton" />
                <br />
                <br />
                <asp:Button ID="btnSent" runat="server" Text="Hộp  thư  đi" OnClick="btnSent_Click"
                    CssClass="formbutton" />
            </div>
            <div id="right" style="float: left; width: 83%;">
                <asp:Table ID="EmailsTable" CssClass="emails-table" runat="server" Visible="false">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell CssClass="emails-table-header" ColumnSpan="4">
                                Hộp thư đến
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="emails-table-header-cell">#</asp:TableCell>
                        <asp:TableCell CssClass="emails-table-header-cell">Người gửi</asp:TableCell>
                        <asp:TableCell CssClass="emails-table-header-cell">Chủ đề</asp:TableCell>
                        <asp:TableCell CssClass="emails-table-header-cell">Ngày gửi</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableFooterRow>
                        <asp:TableCell CssClass="emails-table-footer" ColumnSpan="4">
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
                <asp:Table ID="EmailDetailTable" runat="server" CssClass="emails-table" Visible="true">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell CssClass="emails-table-header" ColumnSpan="2">
                            Email #<asp:Literal ID="EmailIdLiteral" runat="server" />
                        </asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="emails-table-header-cell">Ngày gửi</asp:TableCell>
                        <asp:TableCell CssClass="emails-table-cell">
                            <asp:Literal ID="DateLiteral" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="emails-table-header-cell">Người gửi</asp:TableCell>
                        <asp:TableCell CssClass="emails-table-cell">
                            <asp:Literal ID="FromLiteral" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell CssClass="emails-table-header-cell">Chủ đề</asp:TableCell>
                        <asp:TableCell CssClass="emails-table-cell">
                            <asp:Literal ID="SubjectLiteral" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <%--<asp:TableRow>
                            <asp:TableCell CssClass="emails-table-header-cell">Đính kèm</asp:TableCell>
                            <asp:TableCell CssClass="emails-table-cell">
                                <asp:Literal ID="AttachmentsLiteral" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>--%>
                    <asp:TableRow CssClass="emails-table-cell">
                        <asp:TableCell CssClass="emails-table-cell" ColumnSpan="2">
                            <asp:Literal ID="HeadersLiteral" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="emails-table-cell">
                        <asp:TableCell CssClass="emails-table-cell" ColumnSpan="2">
                            <asp:Literal ID="BodyLiteral" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </asp:Panel>
        <asp:Panel ID="composePanel" runat="server" Visible="false">
            <div id="composeFunction">
                <asp:Button ID="btnSend" runat="server" Text="Gửi" CssClass="formbutton" OnClick="btnSend_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="formbutton" OnClick="btnCancel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Literal ID="liMessage" runat="server" Text="" Visible="False"></asp:Literal>
                <br />
                <br />
                <hr />
            </div>
            <div id="titleHeader">
                <br />
                <p>
                    <span>Đến:</span>
                    <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Chủ đề:</span>
                    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                </p>
            </div>
            <div id="composeContent">
                <p>
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="13"></asp:TextBox>
                </p>
            </div>
        </asp:Panel>
        <asp:Panel ID="configPanel" runat="server" Visible="false">
            <div class="form_settings">
                <p>
                    <span>Tài khoản:</span>
                    <asp:TextBox ID="account" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Mật khẩu:</span>
                    <asp:TextBox ID="password" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnSubmitConfig" runat="server" CssClass="formbutton" Text="Cấu hình"
                        OnClick="btnSubmitConfig_Click" />
                </p>
            </div>
        </asp:Panel>
    </div>
    <%--    </div>--%>
</asp:Content>
