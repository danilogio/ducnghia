<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContestUniversity.aspx.cs" Inherits="ltkt.ContestUniversity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" Runat="Server">
    <style type="text/css">
    .productlist li
    {
    	display:inline;
    	float:left;
    	margin-left:15px;
    	margin-bottom:15px;
    }
    .style1
    {
        width: 100%;
        background-color:white;
    }
</style>
    <div id="content" class="block_text">
        <h2>Luyện thi đại học</h2>
        <hr />
        <br />
        <%--<table class="style1" bgcolor="White">
            <tr>
                <td>  
                    <ul class="productlist">
                        <li><a href="#"><img src="saved/1.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/2.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/3.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/4.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/5.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/6.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/7.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/8.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/9.jpg" alt=""/></a><br /> abc</li>
                        <li><a href="#"><img src="saved/10.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/11.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/12.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/13.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/14.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/15.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/16.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/17.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/18.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/19.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/20.jpg" alt="" /></a> %><br /> abc</li>
                        <li><a href="#"><img src="saved/21.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/22.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/23.jpg" alt="" /></a><br /> abc</li>
                        <li><a href="#"><img src="saved/24.jpg" alt="" /></a><br /> abc</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div>
                        <a href="#">&lt&lt</a>&nbsp<a href="#">&lt</a>&nbsp<a href="#">&gt</a>&nbsp<a href="#">&gt&gt</a>
                    </div>
                </td>
            </tr>
        </table>--%>
        <asp:ListView ID="productList" runat="server">
            
            <LayoutTemplate>
                <ul class="productlist">
                    <asp:PlaceHolder ID="itemContainer" runat="server" />
                </ul>
            </LayoutTemplate>
            
            <ItemTemplate>
                <li><a href="#"><img src="<%#Eval("Thumbnail")%>" alt="" /> <br /> <%#Eval("Title")%></a></li>
            </ItemTemplate>
            
            <EmptyDataTemplate>
                <div>
                    Hiện tại chưa có tài liệu nào
                </div>
            </EmptyDataTemplate>
        </asp:ListView>        
        <asp:DataPager ID="DataPager1" PageSize="5" PagedControlID="productList" runat="server">
            <Fields>
                <asp:NumericPagerField />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>

