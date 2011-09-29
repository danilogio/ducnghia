<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AdContact.aspx.cs" Inherits="ltkt.AdContact" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="AdContactHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title><asp:Literal ID="liTitle" runat="server"></asp:Literal></title>

    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.8.14.custom.min.js"></script>

    <link rel="stylesheet" type="text/css" media="all" href="css/calendar-blue.css" />
    

    <script type="text/javascript">
        $(document).ready(function() {
            $(".calendar").datepicker({
                dateFormat : 'mm/dd/yy'
            });
        }); 
    </script>

    <script type="text/javascript">
    function DisplayAdsImage() 
    { 
        txtCode = "<HTML><HEAD>" 
        +  "</HEAD><BODY TOPMARGIN=0 LEFTMARGIN=0 MARGINHEIGHT=0 MARGINWIDTH=0><CENTER>"   
        + "<IMG src='" + "images/Ads.jpg" + "' BORDER=0 NAME=FullImage " 
        + "onload='window.resizeTo(document.FullImage.width+50,700)'>"  
        + "</CENTER>"   
        + "</BODY></HTML>"; 
        mywindow= window.open  ('','image',  'toolbar=0,location=0,menuBar=0,scrollbars=1,resizable=0,width=1,height=1'); 
        mywindow.document.open(); 
        mywindow.document.write(txtCode); 
        mywindow.document.close();
    }
    </script>

</asp:Content>
<asp:Content ID="AdContact" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="Advertisement" class="block_text">
        <h2>
            Liên hệ quảng cáo</h2>
        <hr />
        <asp:Panel ID="messagePanel" Visible="false" runat="server" CssClass="alert">
            <div id="divMessage" class="form_settings">
                <asp:Literal ID="liMessage" runat="server" Text=""></asp:Literal>
            </div>
        </asp:Panel>
        <asp:Panel ID="contactPanel" runat="server">
            <div class="form_settings">
                <p>
                    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
                </p>
                <p>
                    <span>Tên Công ty(*):</span>
                    <asp:TextBox ID="txtboxCompanyName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqComName" runat="server" ControlToValidate="txtboxCompanyName"
                        Display="None" ErrorMessage="Vui lòng nhập tên công ty">
                    </asp:RequiredFieldValidator>
                </p>
                <%-- Address--%>
                <p>
                    <span>Địa chỉ(*):</span>
                    <asp:TextBox ID="txtAddress" runat="server" Rows="2" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAddress" runat="server" ControlToValidate="txtAddress"
                        Display="None" ErrorMessage="Vui lòng nhập địa chỉ công ty">
                    </asp:RequiredFieldValidator>
                </p>
                <%--Email--%>
                <p>
                    <span>Email(*):</span>
                    <asp:TextBox ID="txtboxContactEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqContactEmail" runat="server" ControlToValidate="txtboxContactEmail"
                        Display="none" ErrorMessage="Vui lòng nhập email liên lạc">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtboxContactEmail"
                        Display="None" ErrorMessage="Email không đúng định dạng" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </p>
                <%--Phone--%>
                <p>
                    <span>Số điện thoại(*):</span>
                    <asp:TextBox ID="txtboxFone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPhone" runat="server" ControlToValidate="txtboxFone"
                        Display="None" ErrorMessage="Vui lòng nhập số điện thoại">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valPhone" runat="server" ErrorMessage="Xin vui lòng kiểm tra lại số điện thoại"
                        ControlToValidate="txtboxFone" Display="None" ValidationExpression="^['0-9'.\S]{10,11}$">
                    </asp:RegularExpressionValidator>
                </p>
                <%--From date - To Date--%>
                <p>
                    <span>Từ ngày(*):</span>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="calendar"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFromDate" runat="server" ControlToValidate="txtFromDate"
                        Display="None" ErrorMessage="Vui lòng nhập ngày bắt đầu">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Đến ngày(*):</span>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="calendar"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqToDate" runat="server" ControlToValidate="txtToDate"
                        Display="None" ErrorMessage="Vui lòng nhập ngày kêt thúc">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Vị trí:</span>
                    <%--<asp:Button ID="btnShowAdsLocation" runat="server" CssClass="formbutton"
                        OnClick="btnShowAdsLocation_Click" Text="Nhấp vào đây để xem vị trí quảng cáo"
                        Width="310px" />--%>
                    <input type="button" onclick="DisplayAdsImage();" class="formbutton" style="width: 310px;" value="Nhấp vào đây để xem vị trí quảng cáo" />
                    <%--<asp:Image ID="imgLocationImage" runat="server" Visible="false" ImageUrl="~/images/a.jpg" onclick="DisplayFullImage(this);"
                        Height="25px" Width="25px" />--%>
                </p>
                <div id="checkbox">
                    <asp:CheckBoxList ID="chxLocation" runat="server" CssClass="checkboxlist">
                        <asp:ListItem Text="Top Banner" Value="top"></asp:ListItem>
                        <asp:ListItem Text="Leader Banner" Value="topleader"></asp:ListItem>
                        <asp:ListItem Text="Top-Left Banner" Value="topleft"></asp:ListItem>
                        <asp:ListItem Text="Middle-Left Banner" Value="middleleft"></asp:ListItem>
                        <asp:ListItem Text="Bottom-Left Banner" Value="bottomleft"></asp:ListItem>
                        <asp:ListItem Text="Top-Right Banner" Value="topright"></asp:ListItem>
                        <asp:ListItem Text="Middle-Right Banner" Value="middleright"></asp:ListItem>
                        <asp:ListItem Text="Bottom-Right Banner" Value="bottomright"></asp:ListItem>
                        <asp:ListItem Text="Bottom 1 Banner" Value="bót1"></asp:ListItem>
                        <asp:ListItem Text="Bottom 2 Banner" Value="bot2"></asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <%--<p>
                    <span>Vị trí:</span> <span id="location" class="checkboxlist">
                        <input runat="server" type="checkbox" id="chkTop" value="0" class="checkbox" checked="checked" />
                        Top Banner<br />
                        <input runat="server" type="checkbox" id="chkRight" value="1" class="checkbox" />
                        Right Banner<br />
                        <input runat="server" type="checkbox" id="chkLeft" value="2" class="checkbox" />
                        Left Banner<br />
                        <input runat="server" type="checkbox" id="chkBot" value="3" class="checkbox" />
                        Bottom Banner<br />
                    </span>
                </p>--%>
                <div align="center" style="margin-top: 10px; margin-left: 100px">
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PrivateKey="6Le4WccSAAAAAPovqPf4ymPe2E4dI9k7JD3qhnan"
                        PublicKey="6Le4WccSAAAAAPNrmUGzjeAUMyH_iXso4kipQqrQ " />
                </div>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" CssClass="submit"
                        OnClick="btnSubmitContact_Click" Text="Gửi" />
                </p>
            </div>
        </asp:Panel>
        
    </div>
</asp:Content>
