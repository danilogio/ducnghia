<%@ Page Title="Quản lý chung" Language="C#" MasterPageFile="~/AdminMaster.master"
    AutoEventWireup="true" CodeFile="General.aspx.cs" Inherits="ltkt.Admin.General" %>

<asp:Content ID="GeneralAdminHead" ContentPlaceHolderID="cphAdminHeader" runat="server">
    <title>Quản lý chung | Website luyện thi kinh tế</title>
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
</asp:Content>
<asp:Content ID="GeneralAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <asp:Panel ID="statusMessagePanel" runat="server" Visible="false" CssClass="alert">
        <asp:Literal ID="liStatusMessage" runat="server"></asp:Literal>
    </asp:Panel>
    <div id="div_content">
        <div id="Summary" class="block_text" style="margin: 5px; height: 450px;">
            <div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Số thành viên:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumUsers" runat="server"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Thành viên mới nhất:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="latestUser" runat="server"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Số thành viên đăng ký mới nhất:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="latestRegistryNum" runat="server"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Thành viên đăng nhập gần nhất:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="latestLogin" runat="server" Text="asdf"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Tổng số bài viết:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumArticle" runat="server"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Tổng số đề thi Đại học/cao đẳng:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumContest" runat="server"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Tổng số bài viết Anh văn:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumEnglish" runat="server"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Tổng số bài viết Tin học:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumInformatics" runat="server"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Số bài viết Đại học/cao đẳng được sticky:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumStickyUni" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Số bài viết Tin hoc được sticky:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumStickyIT" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Số bài viết Anh văn được sticky:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumStickyEL" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Email mới:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="newsMails" runat="server" Text="Không"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Lượt truy cập:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="pageView" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Lượt truy cập trong ngày:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="pageViewADay" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Tổng lượt download trong ngày:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumDownload" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Tổng lượt upload:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumUpload" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Số comment trong ngày:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="sumCommentADay" runat="server" Text="None"></asp:Literal></div>
                </div>
                <div>
                    <div style="float: left; width: 30%">
                        <span>Số đăng kí quảng cáo mới:</span></div>
                    <div style="float: left; width: 69%">
                        <asp:Literal ID="newAdsContact" runat="server" Text="None"></asp:Literal></div>
                </div>
            </div>
            
            <br />
             <div class="form_settings" style="float: left; width: 100%; margin-top: 130px; margin-left: 5px;"
            align="left">
            <asp:Button ID="btnStatistic" runat="server" CssClass="formbutton" OnClick="btnStatistic_Click"
                Text="Thống kê" />
        </div>
        </div>
       
    </div>
</asp:Content>
