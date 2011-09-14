<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="ltkt.Admin.Users" %>

<asp:Content ID="UsersAdminHead" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    <%--<title>Quản lý thành viên | Website luyện thi kinh tế</title>--%>
    <%--<link rel="stylesheet" href="styles.css" type="text/css" />
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
    </style>--%>
    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: white;
        }
    </style>
    <link rel="stylesheet" href="styles.css" type="text/css" />

    <script type="text/javascript" src="../../js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui-1.8.14.custom.min.js"></script>

    <link rel="stylesheet" type="text/css" media="all" href="../../css/calendar-blue.css" />
    <link type="text/css" href="../../css/redmond/jquery-ui-1.8.14.custom.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function() {
            $(".calendar").datepicker({
                dateFormat : 'dd-mm-yy'
            });
        }); 
    </script>

    <script type="text/javascript">
        $(document).ready(function() {
	        $('#<%= ddlState.ClientID %>').change(function(e) {
	            var selectedIndex = $('#<%= ddlState.ClientID%>').get(0).selectedIndex;
	            //var selectedValue = $('#<%= ddlState.ClientID%>').get(0).selectedValue;

                switch (selectedIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 8:
                        $('#KIADate').hide();
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        $('#KIADate').show();
                        break;
                }
	        });
	    });
	    
	    function init() {
	        //$('#KIADate').hide();
	        var selectedIndex = $('#<%= ddlState.ClientID%>').get(0).selectedIndex;
	            //var selectedValue = $('#<%= ddlState.ClientID%>').get(0).selectedValue;

                switch (selectedIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 8:
                        $('#KIADate').hide();
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        $('#KIADate').show();
                        break;
                }
	    }
    </script>

</asp:Content>
<asp:Content ID="UsersAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <%--<div id="divUsers" class="block_text">--%>
    <%--<form id="form1">--%>
    <asp:Panel ID="messagePanel" runat="server" Visible="false">
        <div class="block_text">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </div>
    </asp:Panel>
    <asp:Panel ID="viewPanel" runat="server" Visible="false">
        <div id="divUsers" class="block_text">
            <%--<h4>
                    Danh sách thành viên
                </h4>
                <hr />--%>
            <div class="form_settings">
                <p style="padding-left: 200px">
                    <span>Nhập tên tài khoản:</span>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Tìm" CssClass="formbutton" OnClick="btnSearch_Click" />
                </p>
                <%--<asp:Panel ID="resultPanel" runat="server" Visible="true">--%>
                <div id="searchUserResult">
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </div>
                <%--</asp:Panel>--%>
                <hr />
            </div>
            <br />
            <div>
                <div id="leftUsers" style="float: left; width: 25%;">
                    <br />
                    <asp:Button ID="btnNormal" runat="server" Text="Thành viên" CssClass="formbutton"
                        OnClick="btnNormal_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnKIA" runat="server" Text="Thành viên bị khóa" CssClass="formbutton"
                        OnClick="btnKIA_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnAdmin" runat="server" Text="Admin" CssClass="formbutton" OnClick="btnAdmin_Click" />
                </div>
                <div id="right" style="float: left; width: 74%;">
                    <asp:Table ID="listUsers" runat="server" CssClass="table" Width="620px">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="table-header" ColumnSpan="5">
                                <asp:Literal ID="liListTitle" runat="server" Text="Danh sách thành viên"></asp:Literal>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="table-header-cell">ID</asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">Username</asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">Tên hiển thị</asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">Trạng thái</asp:TableCell>
                            <asp:TableCell CssClass="table-header-cell">Thao tác</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableFooterRow>
                            <asp:TableCell CssClass="table-footer" ColumnSpan="5">
                                <asp:Table ID="normalFooter" Width="100%" BorderWidth="0" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Literal ID="liNormalPre" runat="server" />
                                        </asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Literal ID="liNormalNext" runat="server" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableFooterRow>
                    </asp:Table>
                </div>
            </div>
            <%--<div class="form_settings">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                </asp:GridView>
            </div>--%>
        </div>
    </asp:Panel>
    <asp:Panel ID="detailPanel" runat="server">
        <div class="block_text">
            <div id="divFunction">
                <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" OnClick="btnEdit_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Quay về" CssClass="formbutton" OnClick="btnCancel_Click" />
                <hr />
            </div>
            <div class="form_settings">
                <p>
                    <span>Tài khoản:</span>
                    <asp:TextBox ID="txtUsername" runat="server" ReadOnly="true"></asp:TextBox>
                </p>
                <p>
                    <span>Tên hiển thị:</span>
                    <asp:TextBox ID="txtDisplayName" runat="server" ReadOnly="true"></asp:TextBox>
                </p>
                <p>
                    <span>Giới tính:</span>
                    <asp:DropDownList ID="ddlSex" runat="server" Enabled="false">
                        <asp:ListItem Text="Nam" Value="true"></asp:ListItem>
                        <asp:ListItem Text="Nữ" Value="false"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <span>Mật khẩu:</span>
                    <asp:Button ID="btnResetPassword" Text="Đổi mật khẩu" runat="server" CssClass="formbutton"
                        Enabled="false" OnClick="btnResetPassword_Click" />
                </p>
                <p>
                    <span>Email:</span>
                    <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true"></asp:TextBox>
                </p>
                <%--<p>
                    <span>Vai trò (role):</span>
                    <asp:TextBox ID="txtRole" runat="server" ReadOnly="true"></asp:TextBox>
                </p>--%>
                <p>
                    <span>Quyền (permission):</span>
                </p>
                <%--<asp:Label ID="liPermission" runat="server" Text="asdf"></asp:Label>--%>
                <br />
                <div id="checkbox">
                    <asp:CheckBoxList ID="chxPermission" runat="server" CssClass="checkboxlist">
                    </asp:CheckBoxList>
                </div>
                <br />
                <p>
                    <span>Ngày đăng ký:</span>
                    <asp:TextBox ID="txtRegisterDate" runat="server" ReadOnly="true"></asp:TextBox>
                </p>
                <p>
                    <span>Trạng thái:</span>
                    <asp:DropDownList ID="ddlState" runat="server" Enabled="false">
                    </asp:DropDownList>
                </p>
                <p id="KIADate">
                    <span>Ngày KIA:</span>
                    <asp:TextBox ID="txtKIADate" runat="server" ReadOnly="true"></asp:TextBox>
                </p>
                <p>
                    <span>Số bài viết:</span>
                    <asp:TextBox ID="txtNumberOfArticles" runat="server" ReadOnly="true"></asp:TextBox>
                </p>
                <p>
                    <span>Ghi chú:</span>
                    <asp:TextBox ID="txtNote" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                </p>
            </div>
        </div>
    </asp:Panel>
    <%--</form>--%>
    <%--</div>--%>
</asp:Content>
