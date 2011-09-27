<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ImportData.aspx.cs" Inherits="ltkt.Admin.ImportData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHeader" runat="Server">
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>

    <script type="text/javascript" src="../../js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui-1.8.10.custom.min.js"></script>

    <script type="text/javascript">
        $(function() {
            
            $("#divLoader").hide();
        });

        function showLoading() {
            if (document.getElementById('<%=fileContent.ClientID%>').value != null
            && document.getElementById('<%=fileContent.ClientID%>').value != "") {
                $("#divLoader").show();
            }
            else {
                alert("Vui lòng nhập đường dẫn tập tin");
                return false;
            }
        }
       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div class="block_text">
        <div class="form_settings">
            <p>
                <span>Mục</span><asp:DropDownList ID="ddlSubject" runat="server">
                    <asp:ListItem Text="Luyện thi đại học" Value="uni"></asp:ListItem>
                    <asp:ListItem Text="Tin học" Value="it"></asp:ListItem>
                    <asp:ListItem Text="Anh văn" Value="el"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <span>File Path<asp:Literal ID="liFileSize" runat="server"></asp:Literal></span>
                <asp:FileUpload ID="fileContent" runat="server" CssClass="contact"></asp:FileUpload>
                <asp:RequiredFieldValidator ID="reqFileContent" runat="server" ErrorMessage="Vui lòng nhập đường dẫn tập tin"
                    ControlToValidate="fileContent" Display="None"></asp:RequiredFieldValidator>
            </p>
            <p style="padding-top: 15px;">
                <span>&nbsp;</span><asp:Button ID="btnImport" runat="server" Text="Import" CssClass="submit"
                    OnClick="btnImport_Click" OnClientClick="showLoading()" />
            </p>
            <center>
                <div id="divLoader" style="margin-left: -265px;">
                    <img id="imgLoader" src="../../images/loader.gif" alt="" />
                </div>
            </center>
        </div>
    </div>
</asp:Content>
