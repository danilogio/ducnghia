<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="_lh_Admin_Users_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Edit user</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminContent" Runat="Server">
    <link rel="stylesheet" href="../../../styles.css" type="text/css" />
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
   </style>
   
   <div id="editUser" class="block_text">
        <div class="form_settings">
            <h5>Cập nhật thông tin thành viên</h5>
            <p>
                <span>Username:</span><asp:TextBox ID="txtboxUsername" runat="server" ReadOnly="true">dvtrung</asp:TextBox>
            </p>
            <p>
                <span>Tên hiển thị:</span><asp:TextBox runat="server" ID="txtboxDisplayname"></asp:TextBox> 
            </p>
            <p>
                <span>Mật khẩu mới:</span><asp:TextBox runat="server" ID="txtboxNewPassword" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <span>Nhâp lại mật khẩu mới:</span><asp:TextBox runat="server" ID="txtboxConfirmPassword" TextMode="Password"></asp:TextBox>
            </p>
            
            <p>
                <span>Email:</span><asp:TextBox runat="server" ID="txtboxEmail"></asp:TextBox>
            </p>
            
            <p>
                <span>Giới tính:</span><asp:DropDownList ID="lblSex" runat="server">
                    <asp:ListItem Value="0" Text="Nam"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Nữ"></asp:ListItem>
                </asp:DropDownList>
            </p>
            
            <p>
                <span>Ghi chú:</span><asp:TextBox runat="server" ID="txtUserNote" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </p>
            
            <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" CssClass="submit"
                        OnClick="btnSubmitUpdate_Click" OnClientClick="return confirm('Do you want to update?')" />
           </p>
        </div>
   </div>
</asp:Content>

