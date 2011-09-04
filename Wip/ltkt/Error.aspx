<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Error.aspx.cs" Inherits="Error" %>

<asp:Content ID="ErrorHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title><asp:Literal ID="liTitle" runat="server"></asp:Literal></title>
</asp:Content>
<asp:Content ID="ErrorContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="block_text">
    <h2>Lỗi</h2>
    <hr />
        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:HyperLink ID="HpkPreviousPage" runat="server">Quay về trang trước</asp:HyperLink>
        &nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Quay về trang chủ</asp:HyperLink>
    </div>
</asp:Content>
