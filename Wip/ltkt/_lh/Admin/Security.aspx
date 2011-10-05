<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Security.aspx.cs" Inherits="ltkt.Admin.Security" Title="Untitled Page" %>

<asp:Content ID="SecurityHead" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>Quản lý bảo mật | Website luyện thi kinh tế</title>
    <link rel="stylesheet" href="styles.css" type="text/css" />
</asp:Content>
<asp:Content ID="Security" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_Admin" class="block_text">
        <div id="divFunction">
            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="formbutton" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
            <hr />
        </div>
        <br />
        <div id="left" align="left" style="float: left; width: 50%;">
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkAds" Text="Bật/tắt chức năng quảng cáo" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtAdsReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox1" Text="Bật/Tắt hiện thông báo" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox1" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox2" Text="Bật/Tắt Comment bài viết" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox2" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox3" Text="Bật/Tắt chức năng Comment không cần duyệt" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox3" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox4" Text="Bật/Tắt chức năng liên hệ" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox4" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox5" Text="Bật/Tắt Download toàn Website" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox5" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox6" Text="Bật/Tắt Download cho trang English" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox6" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox7" Text="Bật/Tắt Download cho trang IT" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox7" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox8" Text="Bật/Tắt Download cho trang Uni" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox8" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox19" Text="Bật/Tắtchức năng gửi email" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox19" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
        </div>
        <div id="right" align="left" style="float: left; width: 50%;">
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox9" Text="Bật/Tắtchức năng Đăng nhập" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox9" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox10" Text="Bật/Tắtchức năng gửi tin tức" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox10" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox11" Text="Bật/Tắtchức năng xem tin tức" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox11" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox12" Text="Bật/Tắt Xem trước" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox12" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox13" Text="Bật/Tắt Đăng ký thành viên" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox13" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox14" Text="Bật/Tắt chức năng tìm kiếm" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox14" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox15" Text="Bật/Tắt Website" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox15" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox16" Text="Bật/Tắt chức năng Upload" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox16" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox17" Text="Bật/Tắt Upload cho trang English" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox17" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox18" Text="Bật/Tắt Upload cho trang IT" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox18" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="CheckBox20" Text="Bật/Tắt Upload cho trang IT" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="TextBox20" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
        </div>
    </div>
</asp:Content>
