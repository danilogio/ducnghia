﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
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
            <%=loadDataForITLectures() %>
        </div>
        <!-- start ItLesson-2-->
        <div id="ItLesson02">
            <%=loadDataForITPractise() %>
        </div>
        <!-- start ItLesson-3-->
        <div id="ItLesson03">
            <%=loadDataForITExamination() %>
        </div>
    </div>
    <div id="EnglishLesson" class="block_text">
        <h2>
            Thư viện Anh Văn</h2>
        <div>
            <ul>
                <li><a href="#EnglishLesson01">Bài giảng</a></li>
                <li><a href="#EnglishLesson02">Bài tập</a></li>
                <li><a href="#EnglishLesson03">Đề thi</a></li>
            </ul>
            <!-- start EglishLesson-1-->
            <div id="EnglishLesson01">
                <%=loadDataForELLectures() %>
            </div>
            <!-- start EglishLesson-2-->
            <div id="EnglishLesson02">
                <%=loadDataForELPractise() %>
            </div>
            <!-- start EglishLesson-3-->
            <div id="EnglishLesson03">
                <%=loadDataForELExamination() %>
            </div>
        </div>
    </div>
    <div id="news" class="block_text">
        <h2>
            Tin tức thư viện</h2>
        <hr />
        <div>
            <%--<h3>
                Cơ chế gửi bài tại thư viện trực tuyến Đức Nghĩa</h3>
            <h5>
                Post ngày 9/7/1011 bởi <b>Thầy Đức Nghĩa</b></h5>
            <p>
                Để đảm bảo sự trong sạch và nâng cao chất lượng nội dung Thư viện trực tuyến Violet,
                BQT xin thông báo rõ một số quy chế mới sau: *Không được đăng các tài liệu phản
                động hoặc mang nội dung chính trị nhạy cảm, các tác phẩm văn học bị cấm phát hành,
                phim ảnh khiêu dâm. *Không được đăng các tài liệu hoặc gửi ý kiến mang thông tin
                lừa đảo, ví dụ như lừa người dùng chuyển tiền vào tài khoản điện thoại. *Không được
                gửi các tài liệu mang thông tin nói xấu, bôi... <a href="News.aspx">Xem tiếp >></a>
            </p>
            <ul>
                <li>
                    <asp:HyperLink ID="HpkNews1" runat="server" NavigateUrl="~/News.aspx">Trung Tâm Đức Nghĩa chào mừng ngày Nhà giáo Việt Nam</asp:HyperLink><div
                        class="date">
                        (20-11-2011)</div>
                </li>
                <li>
                    <asp:HyperLink ID="HpkNews2" runat="server" NavigateUrl="~/News.aspx">Trung tâm Đức Nghĩa chào mừng năm học mới</asp:HyperLink><div
                        class="date">
                        (20-11-2011)</div>
                </li>
                <li>
                    <asp:HyperLink ID="HpkNews3" runat="server" NavigateUrl="~/News.aspx">Thông báo địa điểm họp mặt thành viên</asp:HyperLink><div
                        class="date">
                        (19-11-2011)</div>
                </li>
            </ul>--%>
            <%=loadLatestNews()%>
        </div>
        
        <div class="referlink">
            <asp:HyperLink ID="HpkViewAllNsew" runat="server" NavigateUrl="~/News.aspx">Xem tất cả >></asp:HyperLink>
        </div>
    </div>
</asp:Content>