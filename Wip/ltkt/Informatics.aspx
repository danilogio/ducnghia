<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Informatics.aspx.cs" Inherits="ltkt.Informatics" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Informatics" ContentPlaceHolderID="cphContent" runat="Server">
    <%-- 
    <br /><br /><br /><h2><span>Power point</span></h2><br /><br /><br /><br /><br />
    <iframe src="https://docs.google.com/present/embed?id=dg9dkwz4_0hq94ndfj&size=m" frameborder="0" width="605" height="451"></iframe>
    
    <br /><br /><br /><h2><span>Excel</span></h2><br /><br /><br /><br />
    <iframe src="https://docs.google.com/spreadsheet/pub?hl=en_US&hl=en_US&key=0AnRSeUVWm2kqdGtLOXFzVG1CMXpadkc4YklHdnpaNXc&output=html" width="605" height="451"></iframe>
    
    <br /><br /><br /><h2><span>PDF</span></h2><br /><br />
    <iframe src="https://docs.google.com/document/pub?id=11TqBKufiNatQjWxxbcMH7ozp2ZwVyIWRCz_hL26OYxY&amp;embedded=true" width="605" height="451"></iframe>
    
    
--%>
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
                        <br />
                        <div class="block_details_text">
                            <center><%#Eval("Year")%></center>
                        </div>
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
