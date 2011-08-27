<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ContestUniversity.aspx.cs" Inherits="ltkt.ContestUniversity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: white;
        }
    </style>
    <div id="content" class="block_text">
        <h2>
            <asp:Label ID="lblTitle" runat="server" Text="Luyện Thi Đại Học"></asp:Label></h2>
        <hr />
        <br />
        <div>
            <asp:ListView ID="productList" runat="server">
                <LayoutTemplate>
                    <ul class="articleList">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li><a href="ArticleDetails.aspx?sec=uni&id=<%#Eval("ID")%>">
                        <img src="<%#Eval("Thumbnail")%>" alt="" />
                        <br />
                        <center><%#Eval("Title")%></center>
                    </a></li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>
                        Hiện tại chưa có tài liệu nào
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div class="datapager">
            <asp:DataPager ID="DataPager1" OnPreRender="DataPagerArticles_PreRender" PageSize="6"
                PagedControlID="productList" runat="server">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
