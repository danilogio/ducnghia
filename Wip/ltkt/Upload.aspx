<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="ltkt.Upload" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Upload" ContentPlaceHolderID="cphContent" runat="Server">

    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.8.14.custom.min.js"></script>

    <script type="text/javascript">
	    $(document).ready(function() {
	        $('#<%= ddlSubject.ClientID %>').change(function(e) {
	            var selectedIndex = $('#<%= ddlSubject.ClientID%>').get(0).selectedIndex;

	            if (selectedIndex == 0) {
	                $('#divLessonType').hide();
	                $('#divContest').show();
	            }
	            else {
	                $('#divLessonType').show();
	                $('#divContest').hide();
	            }
	        });
	    });

	    function init() {
	        $('#divLessonType').hide();
	    }
    </script>

    <div id="divContact" class="block_text">
        <h2>
            Gửi bài</h2>
        <hr />
        <asp:Panel ID="message" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="upload" runat="server">
        <form method="post">
        <div class="form_settings">
            <p>
                <span>Chủ đề:</span><asp:DropDownList ID="ddlSubject" runat="server">
                    <asp:ListItem Text="Luyện thi đại học" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Tin học" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Anh văn" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <span>Tiêu đề:</span><asp:TextBox ID="txtboxTitle" runat="server" CssClass="contact"></asp:TextBox></p>
            
            <%--Đối với Anh văn, Tin học--%>
            <div id="divLessonType">
                <p id="lessonType">
                    <span>Loại bài viết: </span>
                    <asp:DropDownList ID="ddlType" runat="server">
                        <asp:ListItem Text="Bài giảng" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Đề thi" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Bài tập" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </p>
            </div>
            
            
            <%-- Chung --%>
            <p>
                <span>Tóm tắt:</span><asp:TextBox ID="txtboxSummary" TextMode="MultiLine" Rows="5" runat="server" CssClass="contact"></asp:TextBox>
            </p>
            <p>
                <span>Tập tin nội dung:</span>
                <asp:FileUpload ID="fileContent" runat="server" CssClass="contact"></asp:FileUpload>
            </p>
            
            
            <%--Đối với loại 1: Luyện thi đại học--%>
            <div id="divContest">
                <p id="Contest">
                    <span>Đề thi : </span>
                    <asp:DropDownList ID="ddlTypeContest" runat="server" Width="15%">
                        <asp:ListItem Text="Đại học" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Cao đẳng" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="15%">
                        <asp:ListItem Text="khối A" Value="0"></asp:ListItem>
                        <asp:ListItem Text="khối B" Value="1"></asp:ListItem>
                        <asp:ListItem Text="khối C" Value="2"></asp:ListItem>
                        <asp:ListItem Text="khối D" Value="3"></asp:ListItem>
                        <asp:ListItem Text="khối khác" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                    năm
                    <asp:DropDownList ID="ddlYear" runat="server" Width="15%">
                        <asp:ListItem Text="2002" Value="2002"></asp:ListItem>
                        <asp:ListItem Text="2003" Value="2003"></asp:ListItem>
                        <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                        <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                        <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                        <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                        <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                        <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                        <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                        <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                        <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p id="Solving">
                    <span>Hướng dẫn giải (nếu có):</span><asp:FileUpload ID="fileSolving" runat="server"
                        CssClass="contact"></asp:FileUpload></p>
            </div>
            <%--Chung--%>
            
            <p>
                <span>Tag:</span><asp:TextBox ID="txtboxTag" runat="server" CssClass="contact"></asp:TextBox>
            </p>
            <center>
                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="High" CaptchaLength="5"
                    CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="High" CaptchaMinTimeout="5"
                    CaptchaMaxTimeout="240" CaptchaChars="ABCDEFGHJKLMNPQRSTUVWXYZ123456789abcdefghijklmnpoqrstuvwxyz$%?&#" />
            </center>
            <span>Mã xác nhận:</span><asp:TextBox ID="txtboxConfirmCaptcha" runat="server" CssClass="contact"></asp:TextBox>
            <p style="padding-top: 15px">
                <span>&nbsp;</span><asp:Button ID="btnSubmitUpload" runat="server" Text="Gửi" CssClass="submit"
                    OnClick="btnSubmitUpload_Click" />
            </p>
        </div>
        </form>
        </asp:Panel>
    </div>
</asp:Content>
