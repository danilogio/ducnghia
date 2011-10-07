<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ContestUniversity.aspx.cs" Inherits="ltkt.Admin.ContestUniversity" %>

<asp:Content ID="ContestForUniversityAdminHeader" ContentPlaceHolderID="cphAdminHeader"
    runat="Server">
    <%--<title>Quản lý đề thi đại học | Website luyện thi kinh tế</title>--%>
    <title>
        <asp:Literal ID="liTitle" runat="server"></asp:Literal>
    </title>
    <link type="text/css" href="styles.css" rel="stylesheet" />
    
    <script type="text/javascript" src="../../js/jquery-1.5.1.min.js"></script>

    <script type="text/javascript" src="../../js/jquery-ui-1.8.14.custom.min.js"></script>

    
    <script type="text/javascript">
	    function init() {
	        $('#uploadContent').hide();
	        $('#uploadSolving').hide();
	        $('#uploadThumbnail').hide();
	    }
	    
	    function uploadContent()
	    {
	        $('#uploadContent').show();
	    }
	    
	    function uploadSolving()
	    {
	        $('#uploadSolving').show();
	    }
	    
	    function uploadThumbnail()
	    {
	        $('#uploadThumbnail').show();
	    }
	    
    </script>
    
    <script type="text/javascript">
        function DisplayFullImage(srcImg) 
        { 
            txtCode = "<HTML><HEAD>" 
            +  "</HEAD><BODY TOPMARGIN=0 LEFTMARGIN=0 MARGINHEIGHT=0 MARGINWIDTH=0><CENTER>"   
            + "<IMG src='" + srcImg + "' BORDER=0 NAME=FullImage " 
            + "onload='window.resizeTo(document.FullImage.width+50,document.FullImage.height+75)'>"  
            + "</CENTER>"   
            + "</BODY></HTML>"; 
            mywindow= window.open  ('','image',  'toolbar=0,location=0,menuBar=0,scrollbars=1,resizable=0,width=1,height=1'); 
            mywindow.document.open(); 
            mywindow.document.write(txtCode); 
            mywindow.document.close();
        }
        
        function openFile(file)
        {
            //startoff()
	        window.open(file)
        }
    </script>
    
</asp:Content>
<asp:Content ID="ContestForUniversityAdmin" ContentPlaceHolderID="cphAdminContent"
    runat="Server">
    <div id="div_content" class="block_text">
        <asp:Panel ID="ErrorMessagePanel" runat="server" Visible="false" CssClass="alert">
            <asp:Literal ID="liErrorMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <asp:Panel ID="viewPanel" runat="server">
            <div style="float: left; width: 100%">
                <div align="left" style="float: left; width: 20%">
                    <h3>
                        Môn</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowAll" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&page=1">Tất cả </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowMath" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=math&page=1">Môn Toán </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowPhy" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=phy&page=1">Môn Lý </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowChem" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=chem&page=1">Môn Hóa </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowBio" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=bio&page=1">Môn Sinh </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 50%">
                    <h3>
                        &nbsp&nbsp&nbsp&nbsp</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowLit" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=lit&page=1">Môn văn </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowHis" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=his&page=1">Môn Sử </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowGeo" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=geo&page=1">Môn Địa </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowEng" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=el&page=1">Môn Anh </asp:HyperLink></li>
                    </ul>
                </div>
                <div align="left" style="float: left; width: 30%">
                    <h3>
                        Trạng thái</h3>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hpkShowAllState" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=all&page=1">Tất cả </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowUncheck" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=0&page=1">Chưa duyệt </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowChecked" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=1&page=1">Đã duyệt </asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hpkShowBad" runat="server" NavigateUrl="~/_lh/Admin/ContestUniversity.aspx?action=search&key=all&state=2&page=1">Báo xấu </asp:HyperLink></li>
                    </ul>
                </div>
            </div>
            <asp:Panel ID="messagePanel" runat="server" Visible="false" CssClass="alert">
                <asp:Literal ID="liMessage" runat="server"></asp:Literal>
            </asp:Panel>
            <br />
            <asp:Table ID="ContestTable" CssClass="table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="table-header" ColumnSpan="7">
                        <asp:Literal ID="liTableHeader" runat="server"></asp:Literal>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="table-header-cell">#</asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Tiêu đề</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Ngày đăng</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Môn</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Người gửi</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Trạng thái</center></asp:TableCell>
                    <asp:TableCell CssClass="table-header-cell"><center>Thao tác</center></asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell CssClass="table-footer" ColumnSpan="7">
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
        <asp:Panel ID="detailPanel" runat="server" Visible="false">
            <div id="function">
                <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="formbutton"/>
                <hr />
            </div>
            <div class="form_settings">
                <p>
                    <span>Tiêu đề</span>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Tác giả</span>
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Ngày gửi</span>
                    <asp:TextBox ID="txtPosted" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Trạng thái</span>
                    <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>
                </p>
                <p>
                    <span>Đánh dấu sticky</span>
                    <asp:DropDownList ID="ddlSticky" runat="server"></asp:DropDownList>
                </p>
                <p>
                    <span>Đề thi</span>
                    <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                </p>
                <p>
                    <span>Khối thi</span>
                    <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                </p>
                <p>
                    <span>Môn thi</span>
                    <asp:DropDownList ID="ddlSubject" runat="server"></asp:DropDownList>
                </p>
                <p>
                    <span>Đề thi năm</span>
                    <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                </p>
                <p>
                    <span>Tóm tắt</span>
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </p>
                <p>
                    <span>Tag</span>   
                    <asp:TextBox ID="txtTag" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Điểm bài viết</span>
                    <asp:TextBox ID="txtPoint" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Đánh giá mức độ</span>
                    <asp:TextBox ID="txtScore" runat="server"></asp:TextBox>
                </p>
                <p>
                    <span>Tập tin nội dung:</span>
                    <asp:Literal ID="liContent" runat="server" Text="ad"></asp:Literal>
                </p>
                <p id="uploadContent">
                    <span>Tải tập tin nội dung</span>
                    <asp:FileUpload ID="fileContent" runat="server" />
                </p>
                <p>
                    <span>Tập tin hướng dẫn giải:</span>
                    <asp:Literal ID="liSolving" runat="server" Text="ad"></asp:Literal>
                </p>
                <p id="uploadSolving">
                    <span>Tải tập tin hướng dẫn</span>
                    <asp:FileUpload ID="fileSolving" runat="server" />
                </p>
                <p>
                    <span>Hình thu nhỏ</span>
                    <asp:Literal ID="liThumbnail" runat="server" Text="a"></asp:Literal>
                </p>
                <p id="uploadThumbnail">
                    <span>Tải tập tin hình thu nhỏ</span>
                    <asp:FileUpload ID="fileThumbnail" runat="server" />
                </p>
                <p>
                    <span>Mã html preview</span>
                    <asp:TextBox ID="txtHtmlPreview" runat="server" TextMode="MultiLine"></asp:TextBox>
                </p>
                <p>
                    <span>Mã html embed</span>
                    <asp:TextBox ID="txtHtmlEmbed" runat="server" TextMode="MultiLine"></asp:TextBox>
                </p>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
