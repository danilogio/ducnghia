<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Control.aspx.cs" Inherits="ltkt.Admin.Control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdminHeader" runat="Server">

    <script type="text/javascript" src="../../js/tinyMCE/tiny_mce.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui-1.8.14.custom.min.js"></script>

    <script type="text/javascript" language="javascript">
        tinyMCE.init({

            mode: "textareas",
            theme: "advanced",
            editor_deselector: "NoEditor",
            // Theme options

            theme_advanced_buttons1: "bold,italic,underline,strikethrough,formatselect,fontselect,fontsizeselect,forecolor,backcolor,link,image,bullist,numlist,justifyleft,justifycenter,justifyright,justifyfull",
            theme_advanced_buttons2: "",
            theme_advanced_buttons3: "",

            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "center"

        });
        var uploadLogoState = false;
        function init() {
            $('#uploadLogo').hide();
        }
        function uploadLogo() {
            if (uploadLogoState == false) {
                $('#uploadLogo').show();
                uploadLogoState = true;
            } else {
                $('#uploadLogo').hide();
                uploadLogoState = false;
            }
        }
        function DisplayFullImage(srcImg) {
            txtCode = "<HTML><HEAD>"
            + "</HEAD><BODY TOPMARGIN=0 LEFTMARGIN=0 MARGINHEIGHT=0 MARGINWIDTH=0><CENTER>"
            + "<IMG src='" + srcImg + "' BORDER=0 NAME=FullImage "
            + "onload='window.resizeTo(document.FullImage.width+50,document.FullImage.height+75)'>"
            + "</CENTER>"
            + "</BODY></HTML>";
            mywindow = window.open('', 'image', 'toolbar=0,location=0,menuBar=0,scrollbars=1,resizable=0,width=1,height=1');
            mywindow.document.open();
            mywindow.document.write(txtCode);
            mywindow.document.close();
        }

        function openFile(file) {
            alert(file);
            window.open(file)
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div id="div_content" class="block_text">
        <asp:Panel ID="detailPanel" runat="server" Visible="true">
            <div class="form_settings">
                <div id="divControlDetail">
                    <div id="divFunction">
                        <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" OnClick="btnEdit_Click" />
                        <hr />
                    </div>
                    <div id="divDetail">
                        <br />
                        <div style="float: left; width: 100%">
                            <span><b>Wellcome Text:</b></span><br />
                            <div id="composeContent" style="margin-left: 120px;">
                                <p>
                                    <asp:TextBox ID="txtWellcomeText" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </p>
                            </div>
                        </div>
                        <div id="divLeft" style="float: left; width: 50%; margin-left: 22px">
                            <br />
                            <p>
                                <span><b>Tiêu đề đầu trang:</b></span>
                                <asp:TextBox ID="txtTitleHeader" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Tiêu đề cuối trang:</b></span>
                                <asp:TextBox ID="txtTitleFooter" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Logo:</b></span>
                                <asp:TextBox ID="txtLogo" runat="server" ></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Chi tiết Logo</b></span><br />
                                <asp:Literal ID="liLogo" runat="server" Text="a"></asp:Literal>
                            </p>
                            <p id="uploadLogo">
                                <span><b>Tải tập tin logo</b></span>
                                <asp:FileUpload ID="fileLogo" runat="server" />
                            </p>
                            <p>
                                <span><b>Thông báo</b></span>
                                <asp:TextBox ID="txtAnouncement" runat="server" Enabled="true"></asp:TextBox>
                            </p>
                            <p>
                                <span title="Loại tập tin cho phép tải lên hệ thống"><b>Loại tập tin hợp lệ:</b></span>
                                <asp:TextBox ID="txtValidExtension" MaxLength="254" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Kích thước tập tin tối đa (MB):</b></span>
                                <asp:TextBox ID="txtMaxFileSize" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span title="Loại tập tin hình ảnh cho phép tải lên hệ thống"><b>Loại tập tin ảnh hợp
                                    lệ:</b></span>
                                <asp:TextBox ID="txtValidImageExtension" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Kích thước tập tin ảnh tối đa(KB):</b></span>
                                <asp:TextBox ID="txtMaxFileImgSize" MaxLength="254" runat="server"></asp:TextBox>
                            </p>
                        </div>
                        <div id="divRight" style="float: left; width: 47%">
                            <br />
                            <p>
                                <span title="Cấu hình email(không nên thay đổi)"><b>Cấu hình Email</b></span>
                                <asp:TextBox ID="txtEmailConfig" MaxLength="20" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Số bài hiển thị trên 1 trang Tiếng Anh:</b></span>
                                <asp:TextBox ID="txtNumArtOnEnglish" MaxLength="254" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Số bài hiển thị trên 1 trang Tin học:</b></span>
                                <asp:TextBox ID="txtNumArtOnInformatics" MaxLength="200" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Số bài hiển thị trên 1 trang LTĐH:</b></span>
                                <asp:TextBox ID="txtNumArtOnContest" MaxLength="200" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Số bài hiển thị trên 1 tab Trang chủ:</b></span>
                                <asp:TextBox ID="txtNumArtOnTab" MaxLength="200" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Số bài được sticky:</b></span>
                                <asp:TextBox ID="txtNumArtSticky" MaxLength="200" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span><b>Số bài liên quan được hiển thị:</b></span>
                                <asp:TextBox ID="txtNumRelativeArt" MaxLength="200" runat="server"></asp:TextBox>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
