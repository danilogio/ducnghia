<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="ltkt.Admin.Users" %>

<asp:Content ID="UsersAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
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
        .userlist li
        {
            display: inline;
            float: left;
            margin-left: 15px;
            margin-bottom: 15px;
            width: 150px;
            height: 150px;
        }
        .style1
        {
            width: 100%;
            background-color: white;
        }
    </style>
    <div id="div_content">
        <h4>
            Người dùng</h4>
        <div class="block_text">
            <h5>
                Danh sách thành viên</h5>
            <div class="form_settings">
                <form id="form1">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" BackColor="Black"
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                    GridLines="Vertical" AllowSorting="True" AllowPaging="True" CellSpacing="0" EditRowStyle-Wrap="True"
                    EnableSortingAndPagingCallbacks="false" Font-Size="Medium" RowStyle-Height="15px"
                    RowStyle-Wrap="True" RowStyle-BorderStyle="NotSet" ShowFooter="True" Width="520px"
                    SelectedRowStyle-BackColor="#0066FF" OnRowCancelingEdit="gvUsers_RowCancelingEdit"
                    OnRowEditing="gvUsers_RowEditing" OnRowUpdating="gvUsers_RowUpdating" OnPageIndexChanging="gvUsers_PageIndexChanging" PageSize="4">
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
                        
                        <asp:TemplateField HeaderText="Email" >
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
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right"  />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle Wrap="True"></EditRowStyle>
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <%--<asp:DataPager ID="DataPager1" runat="server" PagedControlID="gvUsers" PageSize="4">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>--%>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
