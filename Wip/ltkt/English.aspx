<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="English.aspx.cs" Inherits="ltkt.English" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="EnglishHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title>Anh văn | Website luyện thi kinh tế</title>
</asp:Content>
<asp:Content ID="English" ContentPlaceHolderID="cphContent" Runat="Server">
    <div id="main" class="block_text">
        <h2>
            <asp:Literal ID="liTitle" runat="server"></asp:Literal>
        </h2>
        <hr />
        <br />
        
        <asp:Panel ID="messagePanel" runat="server">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="lessonPanel" runat="server">
            
        </asp:Panel>
        <asp:Panel ID="exercisePanel" runat="server">
        </asp:Panel>
        <asp:Panel ID="examPanel" runat="server">
        </asp:Panel>
    </div>
</asp:Content>

