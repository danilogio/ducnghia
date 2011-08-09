<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Home" ContentPlaceHolderID="cphContent" runat="Server">

    <script type="text/javascript">
        $(function() {
            // Tabs
            $('#ExamLesson').tabs();
            $('#ItLesson').tabs();
            $('#EnglishLesson').tabs();
        });
    </script>

    <div id="block_text" class="block_text">
        <h2>
            <asp:Label ID="lblWelcomeTitle" runat="server"></asp:Label></h2>
        <hr />
        <p>
            <asp:Label ID="lblWelcomeText" runat="server"></asp:Label></p>
    </div>
    
    <div id="ExamLesson" class="block_text">
        <h2>
            Thư viện đề thi đại học, cao đẳng</h2>
        <ul>
            <li><a href="#ExamLesson01">Đề thi</a></li>
        </ul>
        <div id="ExamLesson01">
            <%=loadDataForUniversityArticles() %>
        </div>
      
    </div>
    
    <div id="ItLesson" class="block_text">
        <h2>
            Thư viện Tin học</h2>
        <ul>
            <li><a href="#ItLesson01">Bài giảng</a></li>
            <li><a href="#ItLesson02">Bài tập</a></li>
            <li><a href="#ItLesson03">Đề thi</a></li>
        </ul>
        <!-- start ItLesson-1-->
        <div id="ItLesson01">
            <%=loadDataForELLectures() %>
        </div>
        <!-- start ItLesson-2-->
        <div id="ItLesson02">
            <%=loadDataForELPractise() %>
        </div>
        <!-- start ItLesson-3-->
        <div id="ItLesson03">
            <%=loadDataForELExamination() %>
        </div>
    </div>
    <div id="EnglishLesson" class="block_text">
        <h2>
            Thư viện Anh Văn</h2>
        <ul>
            <li><a href="#EnglishLesson01">Bài giảng</a></li>
            <li><a href="#EnglishLesson02">Bài tập</a></li>
            <li><a href="#EnglishLesson03">Đề thi</a></li>
        </ul>
        <!-- start EglishLesson-1-->
        <div id="EnglishLesson01">
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/Word.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2011</a>
                </div>
                <div class="block_details_text">
                    Môn Toán<br />
                    Khối A
                </div>
            </div>
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/Word.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2010</a>
                </div>
                <div class="block_details_text">
                    Môn Lý<br />
                    Khối A
                </div>
            </div>
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/acroread.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2009</a>
                </div>
                <div class="block_details_text">
                    Môn Hóa<br />
                    Khối B
                </div>
            </div>
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/pp.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2009</a>
                </div>
                <div class="block_details_text">
                    Môn Hóa<br />
                    Khối B
                </div>
            </div>
            <br />
            
            <div class="referlink">
                <a href="#">Xem thêm</a>
            </div>
        </div>
        <!-- start EglishLesson-2-->
        <div id="EnglishLesson02">
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/Word.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2011</a>
                </div>
                <div class="block_details_text">
                    Môn Toán<br />
                    Khối A
                </div>
            </div>
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/acroread.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2009</a>
                </div>
                <div class="block_details_text">
                    Môn Hóa<br />
                    Khối B
                </div>
            </div>
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/zip.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2009</a>
                </div>
                <div class="block_details_text">
                    Môn Hóa<br />
                    Khối B
                </div>
            </div>
            <div class="block_details">
                <div class="block_details_img">
                    <img width="50px" height="50px" src="images/Word.png" alt="Eden" />
                </div>
                <div class="block_details_title">
                    <a href="#">Đề thi đại học năm 2010</a>
                </div>
                <div class="block_details_text">
                    Môn Lý<br />
                    Khối A
                </div>
            </div>
            <br />
            <div class="referlink">
                <a href="#">Xem thêm</a>
            </div>
        </div>
        <!-- start EglishLesson-3-->
        <div id="EnglishLesson03">
            Hiện chưa có bài viết nào
        </div>
        
        
    </div>

                
    <div id="news" class="block_text">
        <h2>Tin tức thư viện</h2>
        <hr /> 
        <h3>Cơ chế gửi bài tại thư viện trực tuyến Đức Nghĩa</h3>
        <h5>Post ngày 9/7/1011 bởi <b>Thầy Đức Nghĩa</b></h5>
        <p>Để đảm bảo sự trong sạch và nâng cao chất lượng nội dung Thư viện trực tuyến Violet, BQT xin thông báo rõ một số quy chế mới sau: *Không được đăng các tài liệu phản động hoặc mang nội dung chính trị nhạy cảm, các tác phẩm văn học bị cấm phát hành, phim ảnh khiêu dâm. *Không được đăng các tài liệu hoặc gửi ý kiến mang thông tin lừa đảo, ví dụ như lừa người dùng chuyển tiền vào tài khoản điện thoại. *Không được gửi các tài liệu mang thông tin nói xấu, bôi...
        <a href="News.aspx">Xem tiếp>></a></p>
        <ul>
            <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/News.aspx">Trung Tâm Đức Nghĩa chào mừng ngày Nhà giáo Việt Nam</asp:HyperLink><div class="date"> (20-11-2011)</div></li>
            <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/News.aspx">Trung tâm Đức Nghĩa chào mừng năm học mới</asp:HyperLink><div class="date"> (20-11-2011)</div></li>
            <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/News.aspx">Thông báo địa điểm họp mặt thành viên</asp:HyperLink><div class="date"> (19-11-2011)</div></li>
        </ul>
        <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#">Xem tất cả>></asp:HyperLink>
    </div>
  
</asp:Content>
