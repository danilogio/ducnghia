<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="contact" class="block_text">
        <h2>Lấy lại mật khẩu</h2>
        <hr />
        <p>Vui lòng nhập email đăng ký. Chúng tôi sẽ gửi lại mật khẩu vào email sau ít phút:</p>
        <p>
                <asp:ValidationSummary ID="ValidationSummary1" 
                                        runat="server" 
                                        ShowSummary="true" 
                                        HeaderText="Lỗi"/>
        </p>
        <form action="Contact.aspx" method="post">
          <div class="form_settings">
            <p><span>Email:</span><asp:TextBox ID="txtboxRegistryEmail" runat="server" CssClass="contact"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập email liên lạc"
                                            ControlToValidate="txtboxRegistryEmail"
                                            Display="none">
                                            </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valEmail" runat="server"
                                                ControlToValidate="txtboxRegistryEmail"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ErrorMessage="Email không đúng định dạng"
                                                Display="None"/>
            </p>
            <p><center><cc1:CaptchaControl ID="ccJoin" 
                                           runat="server"
                                           CaptchaBackgroundNoise="High" 
                                           CaptchaLength="5" 
                                           CaptchaHeight="60" 
                                           CaptchaWidth="200" 
                                           CaptchaLineNoise="High" 
                                           CaptchaMinTimeout="5" 
                                           CaptchaMaxTimeout="240" 
                                           CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#"/></center>
                <span>Mã xác nhận:</span><asp:TextBox ID="txtboxCaptcha" 
                                                      runat="server">
                                                      </asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập mã xác nhận"
                                            ControlToValidate="txtboxCaptcha"
                                            Display="none">
                                            </asp:RequiredFieldValidator> 
            
            </p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" CssClass="submit" /></p>
          </div>
        </form>
    </div>
</asp:Content>

