<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AdContact.aspx.cs" Inherits="ltkt.AdContact" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="AdContactHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title>Liên hệ quảng cáo | Website luyện thi kinh tế</title>

    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.8.14.custom.min.js"></script>

    <link rel="stylesheet" type="text/css" media="all" href="css/calendar-blue.css" />

    <script type="text/javascript">
        $(document).ready(function() {
            $(".calendar").datepicker({
                dateFormat : 'dd-mm-yy'
            });
        }); 
    </script>

</asp:Content>
<asp:Content ID="AdContact" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="Advertisement" class="block_text">
        <h2>
            Liên hệ quảng cáo</h2>
        <hr />
        <asp:Panel ID="messagePanel" Visible="false" runat="server">
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
                    <asp:RequiredFieldValidator ID="reqComName" runat="server" ErrorMessage="Vui lòng nhập tên công ty"
                        ControlToValidate="txtboxCompanyName" Display="None">
                    </asp:RequiredFieldValidator>
                </p>
                <%-- Address--%>
                <p>
                    <span>Địa chỉ(*):</span>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAddress" runat="server" ErrorMessage="Vui lòng nhập địa chỉ công ty"
                        ControlToValidate="txtAddress" Display="None">
                    </asp:RequiredFieldValidator>
                </p>
                <%--Email--%>
                <p>
                    <span>Email(*):</span>
                    <asp:TextBox ID="txtboxContactEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqContactEmail" runat="server" ErrorMessage="Vui lòng nhập email liên lạc"
                        ControlToValidate="txtboxContactEmail" Display="none">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtboxContactEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không đúng định dạng"
                        Display="None" />
                </p>
                <%--Phone--%>
                <p>
                    <span>Số điện thoại(*):</span>
                    <asp:TextBox ID="txtboxFone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPhone" runat="server" ErrorMessage="Vui lòng nhập số điện thoại"
                        ControlToValidate="txtboxFone" Display="None">
                    </asp:RequiredFieldValidator>
                </p>
                <%--From date - To Date--%>
                <p>
                    <span>Từ ngày(*):</span>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="calendar"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFromDate" runat="server" ErrorMessage="Vui lòng nhập ngày bắt đầu"
                        ControlToValidate="txtFromDate" Display="None">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Đến ngày(*):</span>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="calendar"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqToDate" runat="server" ErrorMessage="Vui lòng nhập ngày kêt thúc"
                        ControlToValidate="txtToDate" Display="None">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Vị trí:</span>
                    <asp:CheckBoxList ID="chxLocation" runat="server" CssClass="checkboxlist">
                        <asp:ListItem Text="Top Banner" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Right Banner" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Left Banner" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Bottom Banner" Value="3"></asp:ListItem>
                    </asp:CheckBoxList>
                </p>
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
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6Le4WccSAAAAAPNrmUGzjeAUMyH_iXso4kipQqrQ "
                        PrivateKey="6Le4WccSAAAAAPovqPf4ymPe2E4dI9k7JD3qhnan" />
                </div>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" CssClass="submit"
                        OnClick="btnSubmitContact_Click" /></p>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
