<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="ltkt.Admin.Login" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login to configuration website</title>
    <link type="text/css" href="../css/redmond/jquery-ui-1.8.14.custom.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../js/plugins/buttonCaptcha/jquery.buttonCaptcha.styles.css" />
    <script type="text/javascript" src="../js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.10.custom.min.js"></script>
    <script type="text/javascript" language="javascript" src="../js/plugins/buttonCaptcha/jquery.buttonCaptcha.js"></script>
    <script type="text/javascript">
        $(function() {
        $("#btnSubmitLogin").buttonCaptcha({
                codeWord: 5,
                codeZone: false,
                verifyMustBe: true,
                verifyMustName: 'codeWordReal'
            });
        });

    </script>

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
        .block_text
        {
            border: 1px solid #b5b5b5;
            padding: 5px 5px 1px 5px;
            margin-bottom: 13px;
            margin-left: 5px;
            border-color: #a6c9e2;
        }
        .style1
        {
            width: 100%;
        }
        
    </style>
</head>
<body>
    <div id="loginForm" class="block_text">
        <h2>
            Đăng nhập tài khoản</h2>
        <hr />
        <asp:Panel ID="messagePanel" runat="server">
            <center>
                <asp:Literal ID="lMessage" runat="server"></asp:Literal>
            </center>
        </asp:Panel>
        <asp:Panel ID="loginPanel" runat="server">
            <form action="Login.aspx" method="post" runat="server">
            <center>
                <table class="style1">
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true"
                                HeaderText="<strong>Lỗi:</strong>" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">
                            <span>Tên đăng nhập:</span>
                        </td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txtboxLoginName" runat="server" Width="200px">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vui lòng nhập tên đăng nhập"
                                ControlToValidate="txtboxLoginName" Display="None">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Tên đăng nhập từ 6 tới 20 kí tự và không được chứa khoảng trắng"
                                ControlToValidate="txtboxLoginName" Display="None" ValidationExpression="^[a-zA-Z'.\S]{6,20}$">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>Mật khẩu:</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtboxPassword" TextMode="Password" runat="server" Width="200px">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vui lòng nhập mật khẩu"
                                ControlToValidate="txtboxPassword" Display="none">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                        

                        </td>
                        <td>
                            <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5"
                                CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5"
                                CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>Mã xác nhận:</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtboxCaptcha" runat="server" Width="200px">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Vui lòng nhập mã xác nhận"
                                ControlToValidate="txtboxCaptcha" Display="none">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmitLogin" runat="server" Text="Đăng nhập" CssClass="submit"
                                OnClick="BtnLogin_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lbErrorCaptcha" runat="server" Text=""></asp:Label>
            </center>
            </form>
        </asp:Panel>
    </div>
</body>
</html>
