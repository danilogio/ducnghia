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
            <div id="EnglishLesson01"></a>
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
            <%=loadLatestNews()%>
        </div>
        <div class="referlink">
            <asp:HyperLink ID="HpkViewAllNsew" runat="server" NavigateUrl="~/News.aspx">Xem tất cả >></asp:HyperLink>
        </div>
    </div>
</asp:Content>
