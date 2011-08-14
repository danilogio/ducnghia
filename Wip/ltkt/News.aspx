<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="ltkt.News" %>

<asp:Content ID="newsHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title>Tin tức | Website luyện thi kinh tế</title>
</asp:Content>
<asp:Content ID="newsContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="block_text">
        <asp:Panel ID="messagePanel" runat="server">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="newsPanel" runat="server">
            <h2>
                <asp:Literal ID="liTitle" runat="server" Text=""></asp:Literal>
            </h2>
            <h5>
                Đăng lên lúc
                <asp:Literal ID="liPosted" runat="server" Text=""></asp:Literal>
                bởi <b>
                    <asp:Literal ID="liAuthor" runat="server" Text=""></asp:Literal>
                </b>
            </h5>
            <hr />
            <br />
            <div id="divContent">
                <asp:Label ID="lblContent" runat="server"></asp:Label>
            </div>
            <br />
            <h4>
                Các tin tức khác
            </h4>
            <hr />
            <br />
            <div id="other_news">
                <asp:Label ID="lblRelative" runat="server"></asp:Label>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
