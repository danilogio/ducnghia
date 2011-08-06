<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleDetails.aspx.cs" Inherits="ltkt.ArticleDetails" ValidateRequest="false" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="ArticleDetailsHead" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title>Website Luyện thi Kinh tế</title>
    <style type="text/css">
        .comment
        {
            padding-bottom: 0.5em;
            margin-bottom: 1em;
        }
        .comment-byline
        {
            background: #3F84B4;
            padding: 0 0.75em;
            color: #FFF;
        }
        .comment-author
        {
            font-size: 14px;
            line-height: 24px;
            padding-left: 15px;
        }
        .comment-date
        {
            float: right;
            line-height: 24px;
            padding-right: 15px;
        }
        .comment-text
        {
            padding: 0.75em;
            border-bottom: 1px solid #CCC;
            background: #F5F5F5;
            min-height: 36px;
            padding-left: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="ArticleDetails" ContentPlaceHolderID="cphContent" runat="Server">
    <asp:Panel ID="invalidArticle" runat="server" Visible="false">
        <div class="block_text">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </div>
    </asp:Panel>
    <asp:Panel ID="viewArticle" runat="server">
        <div id="main" class="block_text">
            <h2>
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
            </h2>
            <div id="overview">
                <h5>
                    Có
                    <asp:Label ID="lblLiker" runat="server" Text=""></asp:Label>
                    người quan tâm tới bài viết này.
                </h5>
            </div>
            <hr />
            <br />
            <div id="content">
                <ul>
                    <li>
                        <h4>
                            Thông tin</h4>
                        <ul>
                            <li>Người gửi:<b>
                                <asp:Label ID="lblAuthor" runat="server" Text=""></asp:Label></b> </li>
                            <li>Ngày gửi:<asp:Label ID="lblPostedDate" runat="server" Text=""></asp:Label></li>
                            <li>Người kiểm duyệt:<b>
                                <asp:Label ID="lblChecker" runat="server" Text=""></asp:Label></b></li>
                            <li>Mục:<asp:Label ID="lblType" runat="server" Text=""></asp:Label></li>
                            <li>Ngành:<asp:Label ID="lblBranch" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblLevel" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label></li>
                            <li>Năm tạo:<asp:Label ID="lblYear" runat="server" Text=""></asp:Label></li>
                        </ul>
                    </li>
                    <li>
                        <h4>
                            Tóm tắt</h4>
                        <asp:Label ID="lblOverview" runat="server" Text=""></asp:Label>
                    </li>
                    <li>
                        <h4>
                            Download Link:</h4>
                        <asp:HyperLink ID="hpkDownloadlink" runat="server">Đề thi đại học 2007</asp:HyperLink>
                    </li>
                    <li>
                        <h4>
                            Gợi ý giải:</h4>
                        <asp:Label ID="lblResolve" runat="server" Text=""></asp:Label>
                    </li>
                </ul>
            </div>
            <hr />
            <br />
        </div>
    </asp:Panel>
    <asp:Panel ID="commentPanel" runat="server">
        <div class="block_text">
            <h4>
                Bình luận</h4>
            <hr />
            <br />
            <div id="postedComment">
                <asp:Label ID="txtPostedComment" runat="server" TextMode="MultiLine" ReadOnly="true"
                    Height="300px" Width="590px" BackColor="White" BorderColor="#444444" BorderWidth="1px">
                </asp:Label>
            </div>
            <p>
                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
            </p>
            <form method="post" action="ArticleDetails.aspx">
            <div id="postingComment" class="form_settings" style="padding-left: 45px;">
                <asp:Panel ID="nonUserPanel" runat="server">
                    <p>
                        <span>Họ tên:</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Email:</span><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </p>
                    <center>
                        <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5"
                            CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5"
                            CaptchaMaxTimeout="240" BorderColor="#333300" BorderWidth="2px" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#"
                            CaptchaFontWarping="Low" />
                    </center>
                    <span>Mã xác nhận:</span><asp:TextBox ID="txtboxCaptcha" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCaptcha" runat="server" ErrorMessage="Vui lòng nhập mã xác nhận"
                        ControlToValidate="txtboxCaptcha" Display="none">
                    </asp:RequiredFieldValidator>
                </asp:Panel>
                <p>
                    <br />
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnSubmitComment" runat="server" Text="Gửi bình luận" CssClass="submit"
                        OnClick="btnSubmitComment_Click" />
                </p>
            </div>
            </form>
        </div>
    </asp:Panel>
    <asp:Panel ID="relativePanel" runat="server">
        <div class="block_text">
            <h4>
                Bài viết liên quan</h4>
            <hr />
        </div>
    </asp:Panel>
</asp:Content>
