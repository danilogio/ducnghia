<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="ltkt.Admin.Users" %>

<asp:Content ID="UsersAdminHead" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>Quản lý thành viên | Website luyện thi kinh tế</title>
    
    <link rel="stylesheet" href="styles.css" type="text/css" />
    <style type="text/css">
        body
        {
            background: white;
            margin: 0;
            padding: 0;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #444;
        }
        .footer-content1
        {
            padding: 20px 5px;
        }
        .style1
        {
            width: 100%;
            background-color: white;
        }
    </style>
    
    <style type="text/css">
        .users-table
        {
            border: solid 1px #444444;
        }
        .users-table-header
        {
            font-family: "Trebuchet MS";
            font-size: 9pt;
            background-color: #0099B9;
            color: white;
            border: solid 1px #444444;
        }
        .users-table-header-cell
        {
            font-family: "Georgia";
            font-size: 9pt;
            font-weight: bold;
            border: solid 1px #666666;
            padding: 6px;
        }
        .users-table-cell
        {
            font-family: "Georgia";
            font-size: 9pt;
            width: 300px;
            border: solid 1px #666666;
            padding: 6px;
        }
        .users-table-footer
        {
            border: solid 1px #666666;
            padding: 3px;
            width: 50%;
        }
        .users-datetime
        {
            float: right;
            color: #666666;
        }
        a:hover
        {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="UsersAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content">
        <%--<form id="form1">--%>
        <div class="block_text">
            <h5>
                Danh sách thành viên</h5>
            <div class="form_settings">
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" BackColor="Black"
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                    GridLines="Vertical" AllowSorting="True" AllowPaging="True" CellSpacing="0" EditRowStyle-Wrap="True"
                    EnableSortingAndPagingCallbacks="false" Font-Size="Medium" RowStyle-Height="15px"
                    RowStyle-Wrap="True" RowStyle-BorderStyle="NotSet" ShowFooter="True" Width="520px"
                    SelectedRowStyle-BackColor="#0066FF" OnRowCancelingEdit="gvUsers_RowCancelingEdit"
                    OnRowEditing="gvUsers_RowEditing" OnRowUpdating="gvUsers_RowUpdating" OnPageIndexChanging="gvUsers_PageIndexChanging"
                    PageSize="4">
                    <FooterStyle BackColor="#CCCC99" />
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:TemplateField HeaderText="Họ Tên">
                            <ItemTemplate>
                                <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtUsernameEdt" runat="server" Text='<%# Eval("Username")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên hiển thị">
                            <ItemTemplate>
                                <asp:Label ID="lblDisplayname" runat="server" Text='<%# Eval("DisplayName")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDisplayNameEdt" runat="server" Text='<%# Eval("DisplayName")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblEmal" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email")%>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" OnClick="DeleteUser" OnClientClick="return confirm('Do you want to delete?')"
                                    Text="Delete" CommandArgument='<%# Eval("ID")%>'>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle Wrap="True"></EditRowStyle>
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>--%>
                
            </div>
        </div>
        <div class="block_text">
            <h5>
                Thành viên bị khóa</h5>
        </div>
        <div class="block_text">
            <h5>
                Thành viên quản trị</h5>
        </div>
        <%--</form>--%>
    </div>
</asp:Content>
