<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Informatics.aspx.cs" Inherits="ltkt.Informatics" %>

<%--<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>--%>
<asp:Content ID="InformaticsHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: white;
        }
    </style>
    <script type="text/javascript">
        function hover(id) {
            //alert('' + id);
            $('div .temp').css("background-color", "white");
            $('#' + id).css("background-color", "#dce6f4");

        }
    </script>
</asp:Content>
<asp:Content ID="Informatics" ContentPlaceHolderID="cphContent" runat="Server">
    <%-- 
    <br /><br /><br /><h2><span>Power point</span></h2><br /><br /><br /><br /><br />
    <iframe src="https://docs.google.com/present/embed?id=dg9dkwz4_0hq94ndfj&size=m" frameborder="0" width="605" height="451"></iframe>
    
    <br /><br /><br /><h2><span>Excel</span></h2><br /><br /><br /><br />
    <iframe src="https://docs.google.com/spreadsheet/pub?hl=en_US&hl=en_US&key=0AnRSeUVWm2kqdGtLOXFzVG1CMXpadkc4YklHdnpaNXc&output=html" width="605" height="451"></iframe>
    
    <br /><br /><br /><h2><span>PDF</span></h2><br /><br />
    <iframe src="https://docs.google.com/document/pub?id=11TqBKufiNatQjWxxbcMH7ozp2ZwVyIWRCz_hL26OYxY&amp;embedded=true" width="605" height="451"></iframe>
    
    
--%>
    <%--<style type="text/css">
        .style1
        {
            width: 100%;
            background-color: white;
        }
    </style>--%>
    <div id="content" class="block_text">
        <h2>
            <asp:Label ID="lblSubTitle" runat="server" Text="Luyện Thi Đại Học"></asp:Label></h2>
        <hr />
        <br />
        <div>
           <%-- <asp:ListView ID="productList" runat="server">
                <LayoutTemplate>
                    <ul class="articleList">
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                     <li>
                        <div id='<%#Eval("ID")%>' onmouseover="hover(<%#Eval("ID")%>)" class="temp" >
                            <center><img src="<%#Eval("Thumbnail")%>" alt="" width="130px" height="120px" style="margin-top:10px;" /></center>
                            <br />
                            <br />
                            <a href="ArticleDetails.aspx?sec=uni&id=<%#Eval("ID")%>">
                                <center>
                                    <%#Eval("Title")%></center>
                            </a>
                            
                        </div>
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>
                        Hiện tại chưa có tài liệu nào
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>--%>
            
            <asp:Literal ID="list_items" runat="server">
            
            </asp:Literal>
            
        </div>
        <br />
        
        <div class="datapager">
           <%-- <asp:DataPager ID="DataPager1" OnPreRender="DataPagerArticles_PreRender" PageSize="6"
                PagedControlID="productList" runat="server">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>--%>
            
            <asp:Literal ID="lDataPager" runat ="server">
            
            </asp:Literal>
        </div>
    </div>
</asp:Content>
