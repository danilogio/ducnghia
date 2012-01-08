<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Mailbox.aspx.cs" Inherits="ltkt.Admin.Mailbox" Title="Hộp thư" ValidateRequest="false" %>

<asp:Content ID="MailboxHeader" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <%--<title>Hộp thư | Website luyện thi kinh tế</title>--%>
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal></title>
    <link rel="stylesheet" href="styles.css" type="text/css" />

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

</asp:Content>
<asp:Content ID="Mailbox" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="mailbox" class="block_text">
        <asp:Panel ID="viewPanel" runat="server">
            <div id="viewHeader" class="form_settings">
                <asp:Button ID="btnCompose" runat="server" Text="Soạn thư" CssClass="formbutton"
                    OnClick="btnCompose_Click" />&nbsp;
                <asp:Button ID="btnCheck" runat="server" Text="Kiểm tra thư" CssClass="formbutton"
                    OnClick="btnCheck_Click" />&nbsp;
                <asp:Button ID="btnReply" runat="server" Text="Trả lời" Visible="false" CssClass="formbutton"
                    OnClick="btnReply_Click" />&nbsp;
                <asp:Button ID="btnForward" runat="server" Text="Chuyển tiếp" Visible="false" CssClass="formbutton"
                    OnClick="btnForward_Click" />&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Xóa" Visible="false" CssClass="formbutton"
                    OnClick="btnDelete_Click" />&nbsp;
                <div style="float: right; padding-right: 20px;">
                    <asp:Button ID="btnConfig" runat="server" Text="Cấu hình" CssClass="formbutton" OnClick="btnConfig_Click" />
                </div>
                <br />
                <br />
                <hr />
            </div>
            <br />
            <div>
                <div id="leftMailbox" style="float: left; width: 15%;">
                    <br />
                    <asp:Button ID="btnInbox" runat="server" Text="Hộp thư đến" OnClick="btnInbox_Click"
                        CssClass="formbutton" />
                    <br />
                    <br />
                    <asp:Button ID="btnSent" runat="server" Text="Hộp thư đi" OnClick="btnSent_Click"
                        CssClass="formbutton" />
                </div>
                <div id="right" style="float: left; width: 83%;">
                    <asp:Literal ID="liMessageDetails" runat="server" Visible="false"></asp:Literal>
                    <asp:Table ID="EmailsTable" CssClass="table" runat="server" Visible="false">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="table-header" ColumnSpan="5">
                                <asp:Literal ID="liHeaderTitle" runat="server"></asp:Literal>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">
                                <asp:Literal ID="liFromTo" runat="server"></asp:Literal>
                            </asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">Tiêu đề</asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">Ngày gửi</asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">Xóa</asp:TableCell>
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
                    <asp:Table ID="EmailDetailTable" runat="server" CssClass="table" Visible="true" Width="700px">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="table-header" ColumnSpan="2">
                                Email #<asp:Literal ID="EmailIdLiteral" runat="server" />
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="table-header-cell" Width="80px">Ngày gửi</asp:TableCell>
                            <asp:TableCell CssClass="table-cell">
                                <asp:Literal ID="DateLiteral" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="table-header-cell" Width="80px">Người gửi</asp:TableCell>
                            <asp:TableCell CssClass="table-cell">
                                <asp:Literal ID="FromLiteral" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="table-header-cell" Width="80px">Tiêu đề</asp:TableCell>
                            <asp:TableCell CssClass="table-cell">
                                <asp:Literal ID="SubjectLiteral" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow CssClass="table-cell">
                            <asp:TableCell CssClass="table-cell" ColumnSpan="2">
                                <asp:Literal ID="BodyLiteral" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="composePanel" runat="server" Visible="false">
            <div class="form_settings">
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
                        <span>Tiêu đề:</span>
                        <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                    </p>
                </div>
                <div id="composeContent">
                    <p>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="13"></asp:TextBox>
                    </p>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="configPanel" runat="server" Visible="false">
            <div class="form_settings">
                <h3>
                    Cấu hình hộp thư</h3>
                <hr />
                <br />
                <p>
                    <span>Tài khoản:</span>
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Mật khẩu:</span>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </p>
                <p>
                    <span>Máy chủ nhận thư:</span>
                    <asp:TextBox ID="txtHost" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Cổng kết nối</span>
                    <asp:TextBox ID="txtHostPort" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Máy chủ gửi thư</span>
                    <asp:TextBox ID="txtSmtpServer" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Cổng kết nối</span>
                    <asp:TextBox ID="txtSmtpPort" runat="server"></asp:TextBox>
                </p>
                <p style="padding-left: 350px">
                    <asp:Button ID="btnSubmitConfig" runat="server" CssClass="formbutton" Text="Lưu Cấu hình"
                        OnClick="btnSubmitConfig_Click" />
                    <asp:Button ID="btnCancelConfig" runat="server" CssClass="formbutton" Text="Trở về"
                        OnClick="btnCancelConfig_Click" />
                </p>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
