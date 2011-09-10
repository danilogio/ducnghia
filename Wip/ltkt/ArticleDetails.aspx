<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleDetails.aspx.cs" Inherits="ltkt.ArticleDetails" ValidateRequest="false" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="ArticleDetailsHead" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title><asp:Literal ID="liTitle" runat="server"></asp:Literal></title>
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
    <div id="main" class="block_text">
        <asp:Panel ID="invalidArticle" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewArticle" runat="server">
            <h2>
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
            </h2>
            <div id="feedback" style="float: right;">
            <br />
                <asp:Button ID="btnLike" runat="server" Text="Thích" CssClass="formbutton" OnClick="btnLike_Click" />
                &nbsp;<asp:Button ID="btnDislike" runat="server" Text="Báo xấu" CssClass="formbutton" OnClick="btnDislike_Click" />
                <%--<asp:ImageButton ID="btnLike" runat="server" ImageUrl="~/images/like-hand-blue.png" Width="32px" Height="32px" OnClick="btnLike_Click"/>
                <asp:ImageButton ID="btnDislike" runat="server" ImageUrl="~/images/dislike-hand-blue.png" Width="32px" Height="32px"  OnClick="btnDislike_Click"/>--%>
                </div>
            <div id="overview">
                <h5>
                    Có
                    <asp:Label ID="lblLiker" runat="server" Text=""></asp:Label>
                    người quan tâm tới bài viết này.
                </h5>
                <img src="images/star-y.png" alt="" width="15px" height="15px"/>
                <img src="images/star-y.png" alt="" width="15px" height="15px"/>
                <img src="images/star-y.png" alt="" width="15px" height="15px"/>
                <img src="images/star-g.png" alt="" width="15px" height="15px"/>
                <img src="images/star-g.png" alt="" width="15px" height="15px"/>
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
                        <asp:HyperLink ID="hpkDownloadlink" runat="server" OnPreRender="hpkDownloadLink_PreRender"></asp:HyperLink>
                    </li>
                    <li>
                        <h4>
                            Gợi ý giải:</h4>
                        <asp:Label ID="lblResolve" runat="server" Text=""></asp:Label>
                    </li>
                </ul>
            </div>
            <br />
            <div id="divPreviewButton" style="float: left;">
                <asp:Button ID="btnPreview" runat="server" 
                    Text="Xem trước >>>" CssClass="formbutton" 
                    onclick="btnPreview_Click" />
            </div>
            <div id="divPreviewText">
                <h4>
                    &nbsp;
                </h4>
                <hr />
            </div>
        </asp:Panel>
        <asp:Panel ID="previewPanel" runat="server" Visible="false">
            <div id="previewContent">Nội dung preview<br /><br /><br />
            </div>
        </asp:Panel>
        <asp:Panel ID="relativePanel" runat="server">
            <h4>
                Bài viết liên quan</h4>
            <hr />
            <div>
                <asp:Label ID="lblRelative" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <asp:Panel ID="commentPanel" runat="server">
            <h4>
                Gửi ý kiến thảo luận</h4>
            <hr />
            <br />
            <div id="postedComment">
                <asp:Label ID="txtPostedComment" runat="server" BackColor="White">
                </asp:Label>
            </div>
            <div>
                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
                <div id="postingComment" class="form_settings" style="padding-left: 45px;">
                    <asp:Panel ID="nonUserPanel" runat="server">
                        <p>
                            Hãy <a href="Registry.aspx" title="Đăng ký thành viên">đăng ký thành viên</a> để 
                            gửi ý kiến thảo luận đơn giản hơn.
                            <br />
                            Nếu bạn đã đăng ký, hãy <a href="Login.aspx" title="Đăng nhập">đăng nhập tại đây</a>.
                        </p>
                        <p>
                            <span>Họ tên:</span><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <span>Email:</span><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </p>
                    </asp:Panel>
                    <p>
                        <asp:TextBox ID="txtContent" runat="server" Rows="2" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    </p>
                    <p style="padding-left: 200px;">
                        <asp:Button ID="btnSubmitComment" runat="server" CssClass="submit" OnClick="btnSubmitComment_Click"
                            Text="Gửi bình luận" />
                    </p>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
