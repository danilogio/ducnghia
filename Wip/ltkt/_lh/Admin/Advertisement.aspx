<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Advertisement.aspx.cs" Inherits="ltkt.Admin.Advertisement" %>

<asp:Content ID="AdvertisementAdminHeader" ContentPlaceHolderID="cphAdminHeader"
    runat="Server">
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
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
	    function init() {
	        $('#upload').hide();
	    }
	    
	    function upload()
	    {
	    $('#upload').show();
	    }
    </script>

    <script type="text/javascript">
    function DisplayFullImage(srcImg) 
    { 
        txtCode = "<HTML><HEAD>" 
        +  "</HEAD><BODY TOPMARGIN=0 LEFTMARGIN=0 MARGINHEIGHT=0 MARGINWIDTH=0><CENTER>"   
        + "<IMG src='" + srcImg + "' BORDER=0 NAME=FullImage " 
        + "onload='window.resizeTo(document.FullImage.width+45,document.FullImage.height+65)'>"  
        + "</CENTER>"   
        + "</BODY></HTML>"; 
        mywindow= window.open  ('','image',  'toolbar=0,location=0,menuBar=0,scrollbars=1,resizable=0,width=1,height=1'); 
        mywindow.document.open(); 
        mywindow.document.write(txtCode); 
        mywindow.document.close();
    }
    </script>

</asp:Content>
<asp:Content ID="AdvertisementAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <div class="block_text">
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
            <asp:Table ID="NewsTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="5">
                                Quản lý quảng cáo
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Tên công ty</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Ngày hết hạn</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Trạng thái</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Thao tác</asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell CssClass="table-footer" ColumnSpan="5">
                        <asp:Table ID="FooterTable" Width="100%" BorderWidth="0" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Literal ID="PreviousPageLiteral" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Right">
                                    <asp:Literal ID="NextPageLiteral" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="detailsPanel" runat="server" Visible="false">
            <div id="divFunction">
                <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" OnClick="btnEdit_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Quay về" CssClass="formbutton" OnClick="btnCancel_Click" />
                <hr />
            </div>
            <div id="divDetails" class="form_settings">
                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
                <p>
                    <span>Tên công ty:</span>
                    <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqCompany" runat="server" ErrorMessage="Vui lòng nhập tên công ty"
                        ControlToValidate="txtCompany" Display="None"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Địa chỉ:</span>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAddress" runat="server" ErrorMessage="Vui lòng nhập địa chỉ"
                        ControlToValidate="txtAddress" Display="None"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Email:</span>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="Vui lòng nhập email liên lạc"
                        ControlToValidate="txtEmail" Display="none">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không đúng định dạng"
                        Display="None" />
                </p>
                <p>
                    <span>Điện thoại:</span>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPhone" runat="server" ErrorMessage="Vui lòng nhập số điện thoại"
                        ControlToValidate="txtPhone" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valPhone" runat="server" ErrorMessage="Xin vui lòng kiểm tra lại số điện thoại"
                        ControlToValidate="txtPhone" Display="None" ValidationExpression="^['0-9'.\S]{10,11}$">
                    </asp:RegularExpressionValidator>
                </p>
                <p>
                    <span>Bắt đầu quảng cáo từ ngày:</span>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="calendar"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFromDate" runat="server" ErrorMessage="Vui lòng nhập ngày bắt đầu"
                        ControlToValidate="txtFromDate" Display="None"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Kết thúc quảng cáo vào ngày:</span>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="calendar"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEndDate" runat="server" ErrorMessage="Vui lòng nhập ngày kết thúc"
                        ControlToValidate="txtEndDate" Display="None"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Giá:</span>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Tập tin quảng cáo:</span>
                    <%--<asp:FileUpload ID="fileAds" runat="server" />--%>
                    <asp:Literal ID="liAds" runat="server" Text="ad"></asp:Literal>
                </p>
                <p id="upload">
                    <span>Tải hình lên</span>
                    <asp:FileUpload ID="fileAds" runat="server" />
                </p>
                <p>
                    <span>Mô tả:</span>
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Trạng thái:</span>
                    <asp:DropDownList ID="ddlState" runat="server">
                    </asp:DropDownList>
                </p>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
