<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registry.aspx.cs" Inherits="Registry" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="signupForm" class="block_text" runat="server">
        <h2>Đăng ký tài khoản</h2>
        <hr />
        <form action="Registry.aspx" method="post">
          <div class="form_settings">
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" 
                                        runat="server" 
                                        ShowSummary="true" 
                                        HeaderText="Lỗi"/>
            </p>
            <p><span>Tên đăng nhập:</span><asp:TextBox ID="txtboxLoginName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập tên đăng nhập" 
                                            ControlToValidate="txtboxLoginName" 
                                            Display="None">
                             </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                runat="server" 
                                                ErrorMessage="Tên đăng nhập từ 6 tới 20 kí tự và không được chứa khoảng trắng"
                                                ControlToValidate="txtboxLoginName"
                                                Display="None"
                                                ValidationExpression="^[a-zA-Z'.\S]{6,20}$">
                </asp:RegularExpressionValidator>
            </p>
            <p><span>Tên hiển thị:</span><asp:TextBox ID="txtboxDisplayName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập tên hiển thị"
                                            ControlToValidate="txtboxDisplayName"
                                            Display="none">
                                            </asp:RequiredFieldValidator>
            </p>
            <p><span>Mật khẩu:</span><asp:TextBox ID="txtboxPassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập mật khẩu"
                                            ControlToValidate="txtboxPassword"
                                            Display="none">
                                            </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                                runat="server" 
                                                ErrorMessage="Mật khẩu phải có từ 6 ký tự trở lên"
                                                ControlToValidate="txtboxPassword"
                                                Display="None"
                                                ValidationExpression="^.{6,30}$">
                </asp:RegularExpressionValidator>
            </p>
            <p><span>Nhập lại mật khẩu:</span><asp:TextBox ID="txtboxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="compPass" runat="server"
                                      ControlToValidate="txtboxConfirmPassword"
                                      Operator="Equal"
                                      ControlToCompare="txtboxPassword"
                                      ErrorMessage="Mật khẩu được nhập lại không giống nhau."
                                      Display="None" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập xác nhận mật khẩu"
                                            ControlToValidate="txtboxConfirmPassword"
                                            Display="none"></asp:RequiredFieldValidator>
                 </p>                           
                <p><span>Email:</span><asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập email liên lạc"
                                            ControlToValidate="txtboxEmail"
                                            Display="none">
                                            </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valEmail" runat="server"
                                                ControlToValidate="txtboxEmail"
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
                                            BorderColor="#333300" 
                                            BorderWidth="2px" 
                                            CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#"
                                            CaptchaFontWarping="Low" /></center>
                <span>Mã xác nhận:</span><asp:TextBox ID="txtboxCaptcha"
                                                      runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                                            runat="server" 
                                            ErrorMessage="Vui lòng nhập mã xác nhận"
                                            ControlToValidate="txtboxCaptcha"
                                            Display="none">
                                            </asp:RequiredFieldValidator> 
                
                
            </p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button ID="btnSubmitSignup" runat="server" Text="Đăng ký" CssClass="submit" OnClick="btnRegistry_Click" /></p>
            
          </div>
        </form>
        <p><br /><br />Lưu ý: Các bạn vui lòng để lại email của mình để chúng tôi tiện liên lạc.</p>
    </div>
</asp:Content>

