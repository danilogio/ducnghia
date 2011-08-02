<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Mailbox.aspx.cs" Inherits="ltkt.Admin.Mailbox" Title="Hộp thư" ValidateRequest="false" %>

<asp:Content ID="MailboxHeader" ContentPlaceHolderID="head" runat="Server">
    <title>Hộp thư</title>

    <script type="text/javascript" src="../../js/tinyMCE/tiny_mce.js"></script>

    <script type="text/javascript" language="javascript">

    tinyMCE.init({

        mode: "textareas",
        theme: "advanced",
        // Theme options

        theme_advanced_buttons1: "bold,italic,underline,strikethrough,formatselect,fontselect,fontsizeselect,forecolor,backcolor,link,image,bullist,numlist,justifyleft,justifycenter,justifyright,justifyfull",
        theme_advanced_buttons2: "",
        theme_advanced_buttons3: "",
        
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "center"  

    });

    </script>

</asp:Content>
<asp:Content ID="Security" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="mailbox" class="block_text">
        <div class="form_settings">
            <asp:Panel ID="viewPanel" runat="server" Visible="false">
                <div id="viewHeader" class="form_settings">
                    <asp:Button ID="btnCompose" runat="server" Text="Soạn thư" CssClass="formbutton"
                        OnClick="btnCompose_Click" />&nbsp;
                    <asp:Button ID="btnCheck" runat="server" Text="Kiểm tra thư" CssClass="formbutton" />&nbsp;
                    <asp:Button ID="btnReply" runat="server" Text="Trả lời" CssClass="formbutton" />&nbsp;
                    <asp:Button ID="btnForward" runat="server" Text="Chuyển tiếp" CssClass="formbutton" />&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="formbutton" />
                    <br />
                    <br />
                    <hr />
                </div>
                <div id="left" style="float: left; width: 20%;">
                    <br />
                    <asp:Button ID="btnInbox" runat="server" Text="Hộp thư đến" OnClick="btnInbox_Click"
                        CssClass="formbutton" />
                    <br />
                    <br />
                    <asp:Button ID="btnSent" runat="server" Text="Hộp  thư  đi" OnClick="btnSent_Click"
                        CssClass="formbutton" />
                </div>
                <div id="right" style="float: left; width: 78%;">
                </div>
            </asp:Panel>
            <asp:Panel ID="composePanel" runat="server">
                <div id="composeFunction">
                    <asp:Button ID="btnSend" runat="server" Text="Gửi" CssClass="formbutton" OnClick="btnSend_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="formbutton" OnClick="btnCancel_Click" />&nbsp;&nbsp;&nbsp;
                    <asp:Literal ID="liMessage" runat="server" Text="" Visible="False"></asp:Literal>
                    <br />
                    <br />
                    <hr />
                </div>
                <div id="to">
                    <br />
                    <p>
                        <span>Đến:</span>
                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <span>Chủ đề:</span>
                        <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                    </p>
                </div>
                <div id="composeContent">
                    <p>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                    </p>
                </div>
            </asp:Panel>
            <%----%>
        </div>
    </div>
</asp:Content>
