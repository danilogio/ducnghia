<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleDetails.aspx.cs" Inherits="ArticleDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="main" class="block_text">
        <h2>
            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h2>
        <div id="overview">
            <h5>Có
                <asp:Label ID="lblLiker" runat="server" Text=""></asp:Label>
                người quan tâm tới bài viết này.
                <hr />
            </h5>
        </div>
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
                    <asp:HyperLink ID="HpkDownloadlink" runat="server">Đề thi đại học 2007</asp:HyperLink>
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
        <div id="postedComment">
            <asp:TextBox ID="txtboxPostedComment" runat="server" TextMode="MultiLine" Rows="10"
                Columns="73"></asp:TextBox>
        </div>
        <form method="post" action="ArticleDetails.aspx">
        <div id="postingComment" class="form_settings">
            <p>
                <span>Nội dung:</span><asp:TextBox ID="txtboxComment" runat="server" TextMode="MultiLine" Columns="40"
                    Rows="6"></asp:TextBox>
            </p>
            <p style="padding-top: 15px">
                <span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" CssClass="submit"
                    OnClick="btnSubmitContact_Click" /></p>
        </div>
        </form>
    </div>
</asp:Content>
