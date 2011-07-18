<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>
	<script type="text/javascript" src="js/jquery-ui-1.8.14.custom.min.js"></script>
	<script type="text/javascript">
	    $(function() {

	        $('#<%= ddlSubject.ClientID %>').change(function(e) {

	            var selectedIndex = $('#<%= ddlSubject.ClientID%>').get(0).selectedIndex;
	            $("#div_content").html("");
	            $.post("Upload.aspx", { selIndex: selectedIndex }, function(result) {
	                //alert(result);
	                if (result != "") {
	                    $("#div_content").html(result);
	                }

	            });

	        });
	    }); 
    </script>
        
    <div id="contact" class="block_text">
        <h2>Gửi bài</h2>
        <hr />
        <p>Mọi thắc mắc/góp ý các bạn vui lòng gửi lại cho chúng tôi để có thể phục vụ các bạn tốt hơn:</p>
        <form action="Contact.aspx" method="post">
          <div class="form_settings">
            <p><span>Chủ đề:</span><asp:DropDownList ID="ddlSubject" runat="server">
                                        <asp:ListItem Text="Vui lòng chọn chủ đề" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Luyện thi đại học" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Tin học" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Anh văn" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
            </p>
            <p><span>Tiêu đề:</span><asp:TextBox ID="txtboxContactName" runat="server" CssClass="contact"></asp:TextBox></p>
            
            <p id="div_content">
                   
            </p>

            <p><span>Lời gửi:</span><asp:TextBox ID="txtboxContactMessage" runat="server" Columns="50" Rows="8" CssClass="contact textarea" TextMode="MultiLine"></asp:TextBox></p>
            <p><center><cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5" CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#"/></center><span>Mã xác nhận:</span><asp:TextBox ID="TextBox1" runat="server" CssClass="contact"></asp:TextBox></p>
            <p style="padding-top: 15px"><span>&nbsp;</span><asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" CssClass="submit" /></p>
          </div>
        </form>
        <p><br /><br />Lưu ý: Các bạn vui lòng để lại email của mình để chúng tôi tiện liên lạc.</p>
    </div>
</asp:Content>

