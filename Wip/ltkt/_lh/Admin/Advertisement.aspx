﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
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
                dateFormat: 'mm/dd/yy'
            });
        }); 
    </script>

    <script type="text/javascript">
        var uploadThumbnailState = false;
        function init() {
            $('#upload').hide();
        }

        function upload() {
            if (uploadThumbnailState == false) {
                $('#upload').show();
                uploadThumbnailState = true;
            } else {
                $('#upload').hide();
                uploadThumbnailState = false;
            }
        }
    </script>

    <script type="text/javascript">
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
    </script>

    <script type="text/javascript">
        function DisplayAdsImage() {
            txtCode = "<HTML><HEAD>"
        + "</HEAD><BODY TOPMARGIN=0 LEFTMARGIN=0 MARGINHEIGHT=0 MARGINWIDTH=0><CENTER>"
        + "<IMG src='" + "../../images/Ads.jpg" + "' BORDER=0 NAME=FullImage "
        + "onload='window.resizeTo(document.FullImage.width+50,700)'>"
        + "</CENTER>"
        + "</BODY></HTML>";
            mywindow = window.open('', 'image', 'toolbar=0,location=0,menuBar=0,scrollbars=1,resizable=0,width=1,height=1');
            mywindow.document.open();
            mywindow.document.write(txtCode);
            mywindow.document.close();
        }
    </script>

</asp:Content>
<asp:Content ID="AdvertisementAdmin" ContentPlaceHolderID="cphAdminContent" runat="Server">
    <asp:Panel ID="statusMessagePanel" runat="server" Visible="false" CssClass="alert">
        <asp:Literal ID="liStatusMessage" runat="server"></asp:Literal>
    </asp:Panel>
    <div class="block_text">
        <asp:Panel ID="ErrorMessagePanel" runat="server" Visible="false" CssClass="alert">
            <asp:Literal ID="liErrorMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
            <div align="left" style="float: left; width: 15%">
                <h3>
                    Xem nâng cao</h3>
                <ul>
                    <li>
                        <asp:HyperLink ID="hpkShowAll" runat="server" NavigateUrl="Advertisement.aspx?action=search&key=all&page=1">Tất cả </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowUncheck" runat="server" NavigateUrl="Advertisement.aspx?action=search&key=0&page=1">Chưa duyệt </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowChecked" runat="server" NavigateUrl="Advertisement.aspx?action=search&key=1&page=1">Đã duyệt </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowPending" runat="server" NavigateUrl="Advertisement.aspx?action=search&key=10&page=1">Pending </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowBlock" runat="server" NavigateUrl="Advertisement.aspx?action=search&key=56&page=1">Khóa </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowSticky" runat="server" NavigateUrl="Advertisement.aspx?action=search&key=13&page=1">Sticky </asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpkShowLoc" runat="server" NavigateUrl="Advertisement.aspx?action=search&key=loc&page=1">Theo vị trí </asp:HyperLink></li>
                </ul>
            </div>
            <asp:Panel ID="messagePanel" runat="server" Visible="false" CssClass="alert">
                <asp:Literal ID="liMessage" runat="server"></asp:Literal>
            </asp:Panel>
            <br />
            <br />
            <asp:Table ID="NewsTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="5">
                        <asp:Literal ID="liTableHeader" runat="server"></asp:Literal>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell">Tên công ty / cá nhân</asp:TableCell>
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
            <div class="form_settings">
                <div id="divItemDetail">
                    <div id="divFunction">
                        <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton" OnClick="btnEdit_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnClone" runat="server" Text="Clone" CssClass="formbutton" OnClick="btnClone_Click" />
                        <hr />
                    </div>
                    <div id="divDetails">
                        <div id="divLeft" style="float: left; width: 50%; margin-left: 20px">
                            <br />
                            <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
                            <p>
                                <span>Tên công ty/cá nhân:</span>
                                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqCompany" runat="server" ErrorMessage="Vui lòng nhập tên công ty / cá nhân"
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
                                <span>Trang web công ty/cá nhân:</span>
                                <asp:TextBox ID="txtNavigateUrl" runat="server"></asp:TextBox>
                            </p>
                        </div>
                        <div id="divRight" style="float: left; width: 40%">
                            <br />
                            <p>
                                <span>Số lần click:</span>
                                <asp:TextBox ID="txtClickCount" runat="server" ReadOnly="true"></asp:TextBox>
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
                                <span>Kích thước:</span>
                                <asp:TextBox ID="txtSizeImg" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập kích thước hình ảnh"
                                    ControlToValidate="txtSizeImg" Display="None"></asp:RequiredFieldValidator>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Xin vui lòng nhập đúng định dạng kích thước WidthxHeight (10x10)"
                        ControlToValidate="txtSizeImg" Display="None" ValidationExpression="^\d{4}x\d{3}">
                    </asp:RegularExpressionValidator>--%>
                            </p>
                            <p>
                                <span>Ghi chú:</span>
                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span>Vị trí:</span>
                                <%--<asp:Button ID="btnShowAdsLocation" runat="server" CssClass="formbutton"
                        OnClick="btnShowAdsLocation_Click" Text="Nhấp vào đây để xem vị trí quảng cáo"
                        Width="310px" />--%>
                                <input type="button" onclick="DisplayAdsImage();" class="formbutton" style="width: 310px;"
                                    value="Nhấp vào đây để xem vị trí quảng cáo" />
                                <%--<asp:Image ID="imgLocationImage" runat="server" Visible="false" ImageUrl="~/images/a.jpg" onclick="DisplayFullImage(this);"
                        Height="25px" Width="25px" />--%>
                            </p>
                            <p>
                                <span>Vị trí Đăng ký:</span>
                                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                            </p>
                            <p>
                                <span>Vị trí Quảng cáo chính thức:</span>
                                <asp:DropDownList ID="ddlLocation" runat="server">
                                </asp:DropDownList>
                            </p>
                            <p>
                                <span>Trạng thái:</span>
                                <asp:DropDownList ID="ddlState" runat="server">
                                </asp:DropDownList>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
