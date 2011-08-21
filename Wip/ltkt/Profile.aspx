<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Profile.aspx.cs" Inherits="ltkt.Profiles" Title="Hồ sơ cá nhân" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="ProfileHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <title>Hồ sơ cá nhân | Website luyện thi kinh tế</title>
</asp:Content>

<asp:Content ID="Profile" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="loginForm" class="block_text">
        <h2>
            <asp:Literal ID="lTitle" runat="server" Text="Hồ sơ cá nhân"></asp:Literal>
        </h2>
        <hr />
        <p>
            <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
        </p>
        <asp:Panel ID="messagePanel" runat="server" Visible="false">
            <asp:Literal ID="lMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server" Visible="true">
            <div class="form_settings">
                <span>Tên đăng nhập:</span><asp:Literal ID="lLogonUser" runat="server" Text="Tên đăng nhập"></asp:Literal>
                <br />
                <br />
                <span>Tên hiển thị:</span><asp:Literal ID="lDisplayName" runat="server" Text="Tên hiển thị"></asp:Literal>
                <br />
                <br />
                <span>Giới tính:</span><asp:Literal ID="lSex" runat="server" Text="Giới tính"></asp:Literal>
                <br />
                <br />
                <span>Email:</span><asp:Literal ID="lEmail" runat="server" Text="Email"></asp:Literal>
                <br />
                <br />
                <span>Số bài viết:</span><asp:Literal ID="lNumberOfArticles" runat="server" Text="Số bài viết"></asp:Literal>
            </div>
            <div style="padding-top: 30px;">
                <div style="float: left; width: 30%;">
                    <p style="padding-top: 15px">
                        <span>&nbsp;</span><asp:Button ID="btnChangePassword" runat="server" Text="Đổi mật khẩu"
                            CssClass="searchsubmit formbutton" OnClick="btnChangePassword_Click" />
                    </p>
                </div>
                <div>
                    <p style="padding-top: 15px">
                        <span>&nbsp;</span><asp:Button ID="btnUpdateProfile" runat="server" Text="Cập nhật hồ sơ"
                            CssClass="searchsubmit formbutton" OnClick="btnUpdateProfile_Click" />
                    </p>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="editPanel" runat="server" Visible="false">
            <div class="form_settings">
                <p>
                    <span>Tên hiển thị:</span><asp:TextBox ID="txtboxDisplayName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqDisplayName" runat="server" ErrorMessage="Vui lòng nhập tên hiển thị"
                        ControlToValidate="txtboxDisplayName" Display="none">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Email:</span><asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="Vui lòng nhập email liên lạc"
                        ControlToValidate="txtboxEmail" Display="none">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valEmail" runat="server" ControlToValidate="txtboxEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email không đúng định dạng"
                        Display="None" />
                </p>
                <center>
                    <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5"
                        CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5"
                        CaptchaMaxTimeout="240" BorderColor="#333300" BorderWidth="2px" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#"
                        CaptchaFontWarping="Low" />
                </center>
                <span>Mã xác nhận:</span><asp:TextBox ID="txtboxCaptcha" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqCaptcha" runat="server" ErrorMessage="Vui lòng nhập mã xác nhận"
                    ControlToValidate="txtboxCaptcha" Display="none">
                </asp:RequiredFieldValidator>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmitUpdateProfile" runat="server" Text="Cập nhật"
                        CssClass="submit" OnClick="btnSubmitUpdateProfile_Click" /></p>
            </div>
        </asp:Panel>
        <asp:Panel ID="changePasswordPanel" runat="server" Visible="false">
            <div class="form_settings">
                <p>
                    <span>Mật khẩu hiện tại:</span><asp:TextBox ID="txtboxPassword" runat="server" TextMode="Password"
                        MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ErrorMessage="Vui lòng nhập mật khẩu"
                        ControlToValidate="txtboxPassword" Display="none">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExpPassword" runat="server" ErrorMessage="Mật khẩu phải có từ 6 ký tự trở lên"
                        ControlToValidate="txtboxPassword" Display="None" ValidationExpression="^.{6,30}$">
                    </asp:RegularExpressionValidator>
                </p>
                <p>
                    <span>Mật khẩu mới:</span><asp:TextBox ID="txtboxNewPassword" runat="server" TextMode="Password"
                        MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqNewPassword" runat="server" ErrorMessage="Vui lòng nhập mật khẩu"
                        ControlToValidate="txtboxNewPassword" Display="none">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExpNewPassword" runat="server" ErrorMessage="Mật khẩu phải có từ 6 ký tự trở lên"
                        ControlToValidate="txtboxNewPassword" Display="None" ValidationExpression="^.{6,30}$">
                    </asp:RegularExpressionValidator>
                </p>
                <p>
                    <span>Nhập lại mật khẩu mới:</span><asp:TextBox ID="txtboxConfirmPassword" runat="server"
                        TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="compPass" runat="server" ControlToValidate="txtboxConfirmPassword"
                        Operator="Equal" ControlToCompare="txtboxNewPassword" ErrorMessage="Mật khẩu được nhập lại không giống nhau."
                        Display="None" />
                    <asp:RequiredFieldValidator ID="reqConfirmPassword" runat="server" ErrorMessage="Vui lòng nhập xác nhận mật khẩu"
                        ControlToValidate="txtboxConfirmPassword" Display="none"></asp:RequiredFieldValidator>
                </p>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmitChangePassword" runat="server" Text="Đổi mật khẩu"
                        CssClass="submit" OnClick="btnSubmitChangePassword_Click" />
                </p>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
