<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registry.aspx.cs" Inherits="Registry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="div_boudarySignupForm" class="block_text">
        <h2>Tạo tài khoản</h2>
        <div>
            <div>
                <div style="width: 30%;float:left">
                    <asp:Label ID="lblLoginName" runat="server" Text="Tên đăng nhập:"></asp:Label> 
                </div>
                <div style="width: 69%;float:left">
                    
                    <asp:TextBox ID="txtboxLoginName" runat="server" Width="250px"></asp:TextBox>
                    
                </div>
            </div>
            
            <div>
                <div style="width: 30%;float:left">
                    <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu:"></asp:Label>
                </div>
                <div style="width: 69%;float:left">
                    <asp:TextBox ID="txtboxPassword" TextMode="Password" runat="server" Width="250px"></asp:TextBox>
                </div>
            </div>
            
            <div>
                <div style="width: 30%;float:left">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Nhập lại mật khẩu:"></asp:Label>
                </div>
                <div style="width: 69%;float:left">
                    <asp:TextBox ID="txtboxConfirmPassword" TextMode="Password" runat="server" Width="250px"></asp:TextBox>
                </div>
            </div>
            
            <div>
                <div style="width: 30%;float:left">
                    <asp:Label ID="lblDisplayName" runat="server" Text="Họ và tên:"></asp:Label>
                </div>
                <div style="width: 69%;float:left">
                    <asp:TextBox ID="txtboxDisplayName" runat="server" Width="250px"></asp:TextBox>
                </div>
            </div>
            
            <div>
                <div style="width: 30%;float:left">
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                </div>
                <div style="width: 69%;float:left">
                    <asp:TextBox ID="txtboxEmail" runat="server" Width="250px"></asp:TextBox>
                </div>
            </div>
        </div>    
        
    </div>
</asp:Content>

