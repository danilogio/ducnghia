<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="ltkt.Upload" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="UploadHeader" ContentPlaceHolderID="cphMasterHearder" runat="Server">
    <%--<title>Gửi bài viết | Website luyện thi kinh tế</title>--%>
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>

    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.8.14.custom.min.js"></script>

    <script type="text/javascript">
//	    $(document).ready(function() {
//	        $('#<%= ddlSubject.ClientID %>').change(function(e) {
//	            var selectedIndex = $('#<%= ddlSubject.ClientID%>').get(0).selectedIndex;

//	            if (selectedIndex == 0) {
//	                $('#divLessonType').hide();
//	                $('#divContest').show();
//	            }
//	            else {
//	                $('#divLessonType').show();
//	                $('#divContest').hide();
//	            }
//	        });
//	    });

	    function init() {
	        $('#<%= ddlSubject.ClientID%>').val(0);
	        $('#divLessonType').hide();
	    }
	    
//	    function checkFileExtension(elem) {
//            var filePath = elem.value;

//            if(filePath.indexOf('.') == -1)
//                return false;
//            
//            var validExtensions = new Array();
//            var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
//            //Add valid extentions in this array
//            validExtensions[0] = 'doc';
//            //validExtensions[1] = 'pdf';
//        
//            for(var i = 0; i < validExtensions.length; i++) {
//                if(ext == validExtensions[i])
//                    return true;
//            }

//            alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');
//            return false;
//        }
    </script>

</asp:Content>
<asp:Content ID="Upload" ContentPlaceHolderID="cphContent" runat="Server">
    <%--<script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>

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
	        $('#<%= ddlSubject.ClientID%>').val(0);
	        $('#divLessonType').hide();
	    }
    </script>--%>
    <div id="divContact" class="block_text">
        <h2>
            Gửi bài</h2>
        <hr />
        <asp:Panel ID="message" runat="server" Visible="false">
            <asp:Literal ID="liMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="upload" runat="server">
            <div class="form_settings">
                <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="true" HeaderText="Lỗi" />
                <p>
                    <span>Chủ đề:</span><asp:DropDownList ID="ddlSubject" runat="server">
                        <asp:ListItem Text="Luyện thi đại học" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Tin học" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Anh văn" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <span>Tiêu đề:</span><asp:TextBox ID="txtboxTitle" runat="server" CssClass="contact"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqTitle" runat="server" ErrorMessage="Vui lòng nhập tiêu đề"
                        ControlToValidate="txtboxTitle" Display="None">
                    </asp:RequiredFieldValidator>
                </p>
                <%--Đối với Anh văn, Tin học--%>
                <%--<div id="divLessonType">
                    <p id="lessonType">
                        <span>Loại bài viết: </span>
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Text="Bài giảng" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Đề thi" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Bài tập" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </div>--%>
                <%-- Chung --%>
                <p>
                    <span>Tóm tắt:</span><asp:TextBox ID="txtboxSummary" TextMode="MultiLine" Rows="5"
                        runat="server" CssClass="contact"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqSummary" runat="server" ErrorMessage="Xin vui lòng tóm tắt ngắn ngọn nội dung"
                        ControlToValidate="txtboxSummary" Display="None"></asp:RequiredFieldValidator>
                </p>
                <p>
                    <span>Tập tin nội dung<asp:Literal ID="liFileSize" runat="server"></asp:Literal></span>
                    <asp:FileUpload ID="fileContent" runat="server" CssClass="contact"></asp:FileUpload>
                    <asp:RequiredFieldValidator ID="reqFileContent" runat="server" ErrorMessage="Xin vui lòng chọn tập tin nội dung"
                        ControlToValidate="fileContent" Display="None"></asp:RequiredFieldValidator>
                </p>
                <%--Đối với loại 1: Luyện thi đại học--%>
                <div id="divContest">
                    <p id="Contest">
                        <span>Đề thi : </span>
                        <asp:DropDownList ID="ddlTypeContest" runat="server" Width="15%">
                            <asp:ListItem Text="Đại học" Value="false"></asp:ListItem>
                            <asp:ListItem Text="Cao đẳng" Value="true"></asp:ListItem>
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
                <p>
                    <div align="center" style="margin-top: 10px; margin-left: 100px">
                        <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6Le4WccSAAAAAPNrmUGzjeAUMyH_iXso4kipQqrQ "
                            PrivateKey="6Le4WccSAAAAAPovqPf4ymPe2E4dI9k7JD3qhnan" />
                    </div>
                </p>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><asp:Button ID="btnSubmitUpload" runat="server" Text="Gửi" CssClass="submit"
                        OnClick="btnSubmitUpload_Click" />
                </p>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
