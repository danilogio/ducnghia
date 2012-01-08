<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Security.aspx.cs" Inherits="ltkt.Admin.Security" Title="Untitled Page" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="SecurityHead" ContentPlaceHolderID="cphAdminHeader" runat="server">
    <title>Quản lý bảo mật | Website luyện thi kinh tế</title>
    <link rel="stylesheet" href="styles.css" type="text/css" />
</asp:Content>
<asp:Content ID="Security" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
    <div id="div_Admin" class="block_text">
        <asp:Panel ID="detailPanel" runat="server" Visible="true">
            <div class="form_settings">
                <asp:Panel ID="ErrorMessagePanel" runat="server" Visible="false" CssClass="alert">
                    <asp:Literal ID="liErrorMessage" runat="server"></asp:Literal>
                </asp:Panel>
                <div id="divFunction">
                    <asp:Button ID="btnUpdate" runat="server" Text="Lưu" CssClass="formbutton" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
                    <hr />
                </div>
                <br />
                <div id="divDetail" style="margin-left: 300px;">
                    <p>
                        <span><b>Thao tác</b></span><br />
                        <asp:DropDownList ID="ddlAction" runat="server" AutoPostBack="true" OnSelectedIndexChanged="btnSelectedChange_Click">
                            <asp:ListItem Text="---Please select---" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Bảo trì Website" Value="UNDERCONS"></asp:ListItem>
                            <asp:ListItem Text="Thông báo" Value="ANOUNCEMENT"></asp:ListItem>
                            <asp:ListItem Text="Comment" Value="COMMENT"></asp:ListItem>
                            <asp:ListItem Text="Comment nhanh" Value="COMMENT_EASY"></asp:ListItem>
                            <asp:ListItem Text="Liên hệ" Value="CONTACT"></asp:ListItem>
                            <asp:ListItem Text="Download all" Value="DOWNLOAD"></asp:ListItem>
                            <asp:ListItem Text="Download EL" Value="DOWNLOAD_EL"></asp:ListItem>
                            <asp:ListItem Text="Download IT" Value="DOWNLOAD_IT"></asp:ListItem>
                            <asp:ListItem Text="Download Uni" Value="DOWNLOAD_UNI"></asp:ListItem>
                            <asp:ListItem Text="Upload" Value="UPLOAD"></asp:ListItem>
                            <asp:ListItem Text="Upload EL" Value="UPLOAD_EL"></asp:ListItem>
                            <asp:ListItem Text="Upload IT" Value="UPLOAD_IT"></asp:ListItem>
                            <asp:ListItem Text="Upload Uni" Value="UPLOAD_UNI"></asp:ListItem>
                            <asp:ListItem Text="Gửi email" Value="EMAIL_SEND"></asp:ListItem>
                            <asp:ListItem Text="Đăng nhập" Value="LOGIN"></asp:ListItem>
                            <asp:ListItem Text="Gửi Tin tức" Value="NEWS_POST"></asp:ListItem>
                            <asp:ListItem Text="Xem Tin tức" Value="NEWS_VIEW"></asp:ListItem>
                            <asp:ListItem Text="Xem trước" Value="PREVIEW_ARTICLE"></asp:ListItem>
                            <asp:ListItem Text="Đăng ký tài khoản" Value="REGISTRY"></asp:ListItem>
                            <asp:ListItem Text="Tìm kiếm" Value="SEARCH"></asp:ListItem>
                            <asp:ListItem Text="Quảng cáo" Value="ADS"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p>
                        <span><b>Trạng thái</b></span><br />
                        <asp:DropDownList ID="ddlState" runat="server">
                            <asp:ListItem Text="Bật" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Tắt" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p>
                        <span><b>Message</b></span><br />
                        <span title="Lý do">
                            <asp:TextBox ID="txtReason" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        </span>
                    </p>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <p>
                        <span><b>Chỉ dẫn</b></span><br />
                        <span title="Ý nghĩa chức năng">
                            <asp:TextBox ID="txtGuidline" runat="server" Rows="5" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                        </span>
                    </p>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
