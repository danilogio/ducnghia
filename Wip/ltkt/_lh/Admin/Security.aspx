<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Security.aspx.cs" Inherits="ltkt.Admin.Security" Title="Untitled Page" %>

<asp:Content ID="SecurityHead" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>Quản lý bảo mật | Website luyện thi kinh tế</title>
    <link rel="stylesheet" href="styles.css" type="text/css" />
</asp:Content>
<asp:Content ID="Security" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_Admin" class="block_text">
        <asp:Panel ID="ErrorMessagePanel" runat="server" Visible="false" CssClass="alert">
            <asp:Literal ID="liErrorMessage" runat="server"></asp:Literal>
        </asp:Panel>
        
        <div id="divFunction">
            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="formbutton" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
            <hr />
        </div>
        <br />
        <div id="left" align="left" style="float: left; width: 50%;">
           
             <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkUndercontruction" Text="1.Bật/Tắt Website" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtUndercontructionReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkAnnoucement" Text="2.Bật/Tắt hiện thông báo" runat="server" /></div>
            <div style="background: white;">
                <span title="Nội dung thông báo">
                    <asp:TextBox ID="txtAnnoucementMessage" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
             <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkComment" Text="3.Bật/Tắt Comment bài viết" runat="server" /></div>
            <div style="background: white;">
                <span title="Nội dung thông báo">
                    <asp:TextBox ID="txtCommentReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkCommentEasy" Text="Bật/Tắt chức năng Comment không cần duyệt" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtCommentEasyReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
             <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkContact" Text="Bật/Tắt chức năng liên hệ" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtContactReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
             <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkDownloadAll" Text="Bật/Tắt Download toàn Website" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtDownloadAllReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
             <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkDownloadEnglish" Text="Bật/Tắt Download cho trang English" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtDownloadEnglishReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkDownloadIT" Text="Bật/Tắt Download cho trang IT" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtDownloadITReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkDownloadUni" Text="Bật/Tắt Download cho trang Uni" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtDownloadUniReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
             <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkEmailSending" Text="Bật/Tắt chức năng gửi email" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtEmailSendReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
        </div>
        
        <div id="right" align="left" style="float: left; width: 50%;">
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkLogin" Text="Bật/Tắtchức năng Đăng nhập" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtLoginReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkNewsPost" Text="Bật/Tắtchức năng gửi tin tức" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtNewsPostReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkNewsView" Text="Bật/Tắtchức năng xem tin tức" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtNewsViewReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkPreview" Text="Bật/Tắt Xem trước" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtPreviewReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkRegistry" Text="Bật/Tắt Đăng ký thành viên" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtRegistryReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkSearch" Text="Bật/Tắt chức năng tìm kiếm" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtSearchReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkAds" Text="Bật/tắt chức năng quảng cáo" runat="server"/></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtAdsReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkUploadAll" Text="Bật/Tắt chức năng Upload" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtUploadAllReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkUploadEnglish" Text="Bật/Tắt Upload cho trang English" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtUploadEnglishReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
           
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkUploadIT" Text="Bật/Tắt Upload cho trang IT" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtUploadITReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
            
            <!-- checkbox -->
            <div style="float: left; width: 100%;">
                <asp:CheckBox ID="chkUploadUni" Text="Bật/Tắt Upload cho trang Uni" runat="server" /></div>
            <div style="background: white;">
                <span title="Lý do">
                    <asp:TextBox ID="txtUploadUniReason" runat="server" Rows="2" Columns="55" TextMode="MultiLine"
                        CssClass="multiline"></asp:TextBox></span></div>
        </div>
    </div>
</asp:Content>
