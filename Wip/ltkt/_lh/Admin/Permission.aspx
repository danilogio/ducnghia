<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Permission.aspx.cs" Inherits="ltkt.Admin.Permission" %>

<asp:Content ID="PermissionAdminHeader" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>

    <script type="text/javascript">
        $(document).ready(function() {
	        $('#<%= chxPermission.ClientID %>').change(function(e) {
	            alert ("asdf");
	        });
	    });
	    
	    function init() {}
    </script>

</asp:Content>
<asp:Content ID="PermissonAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div class="block_text">
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="searchPanel" runat="server">
            <div class="form_settings">
                <p style="padding-left: 200px">
                    <span>Nhập tên tài khoản:</span>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Tìm" CssClass="formbutton" OnClick="btnSearch_Click" />
                </p>
                <div id="searchUserResult">
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="detailPanel" runat="server" Visible="false">
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
                    <span>Vai trò:</span>
                    <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Quyền (permission):</span>
                </p>
                <br />
                <div id="checkbox">
                    <asp:CheckBoxList ID="chxPermission" runat="server" CssClass="checkboxlist" OnSelectedIndexChanged="chxPermission_SelectedIndexChanged">
                    </asp:CheckBoxList>
                    <asp:Label ID="lblPermission" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
            <div id="divFunction">
                <br />
                <hr /><span style="padding-left: 180px;"></span>
                    <asp:Button ID="btnCancel" runat="server" CssClass="formbutton" OnClick="btnCancel_Click"
                        Text="Quay về" />&nbsp;&nbsp;
                    <asp:Button ID="btnContinue" runat="server" Text="Tiếp tục" CssClass="formbutton"
                        OnClick="btnContinue_Click" />
            </div>
        </asp:Panel>
    </div>

    <script type="text/javascript"></script>

</asp:Content>
