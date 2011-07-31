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
            Luyện thi đại học</h2>
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
                        <center><%#Eval("Title")%></center></a></li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>
                        Hiện tại chưa có tài liệu nào
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
        <div class="datapager">
            <asp:DataPager ID="DataPager1" PageSize="6" PagedControlID="productList" runat="server">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
