<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="newsContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="news" class="block_text">
        <h2>Cơ chế gửi bài tại thư viện trực tuyến Đức Nghĩa</h2>
        <h5>Post ngày 9/7/1011 bởi <b>Thầy Đức Nghĩa</b></h5>
        Để đảm bảo sự trong sạch và nâng cao chất lượng nội dung Thư viện trực tuyến Đức Nghĩa, BQT xin thông báo rõ một số quy chế mới sau:
            <ul>
                <li>Không được đăng các tài liệu phản động hoặc mang nội dung chính trị nhạy cảm, các tác phẩm văn học bị cấm phát hành, phim ảnh khiêu dâm.</li>
                <li>Không được đăng các tài liệu hoặc gửi ý kiến mang thông tin lừa đảo, ví dụ như lừa người dùng chuyển tiền vào tài khoản điện thoại.</li>
                <li>Không được gửi các tài liệu mang thông tin nói xấu, bôi nhọ danh dự người khác hoặc tổ chức nào đó.</li>
            </ul>
            <p>
            Các hoạt động trên là những hành vi vi phạm pháp luật nước CHXHCN Việt Nam, vì vậy nếu có thành viên nào còn tái phạm, BQT sẽ chuyển hồ sơ sang bên cơ quan công an để xử lý theo pháp luật. Các thành viên đã nhỡ đăng bài hoặc gửi ý kiến vi phạm thì cũng phải xóa ngay lập tức.
            </p>

            Đối với cơ quan công an, bằng các biện pháp nghiệp vụ chuyên nghiệp thì việc tìm ra thủ phạm đăng tài liệu hoàn toàn không phải là khó. Trên thực tế, các cơ quan công an và BQT Violet đã từng phối hợp để xử lý rất nhiều vụ việc nghiêm trọng từ trước đến nay.
            <p>
            Ngoài ra, cũng xin nhắc lại một số quy chế khác về việc đăng bài giảng
            </p>
            <ul>
                <li>Không được đăng nhiều lần cùng một nội dung trên một trang thư viện. Nếu cùng một tài liệu mà muốn đăng ở nhiều trang thư viện khác nhau thì từ trang thứ 2 trở đi sẽ không “Đưa lên từ máy tính” mà phải chọn mục “Chọn từ bài giảng của tôi”. Riêng những tài liệu nào mà thành viên muốn luôn xuất hiện để phổ biến kinh nghiệm cần thiết cho người khác thì có thể liên hệ với BQT để đặt dưới hình thức banner.</li>
                <li>Các nội dung được đưa vào các thư mục môn học (Toán, Ngữ Văn, Vật lý,…) thì phải đúng là nội dung chuyên môn tương ứng. Các thông tin tham khảo không mang tính chuyên môn phải được đưa vào thư mục “Bài giảng khác” hoặc “Tư liệu khác”.</li>
                <li>Các thành viên đưa bài giảng của người khác phải đề rõ thông tin tác giả (mục Nguồn gốc), đồng thời trước khi đăng bài thì cần tìm kiếm xem bài đó đã đăng chưa. Tuyệt đối không được download bài của người khác rồi upload lại để lấy điểm, trừ khi đã được sửa đổi, đóng góp ý tưởng của riêng mình khoảng 30%.</li>
                <li>Trước đây, điểm của các thành viên được cộng 10 điểm mỗi tuần (nếu dùng hết). Từ nay, hệ thống sẽ cộng thêm 30 điểm mỗi tuần (nếu dùng hết). Như vậy, mỗi thành viên có thể download từ 1 đến 30 bài giảng mỗi tuần mà không mất điểm nào.</li>
                <li>Thành viên nào vi phạm quy định trên thì các tài liệu sẽ được xóa mà không cần thông báo, đồng thời nếu vi phạm nhiều lần thì sẽ bị khóa tài khoản.</li>
            </ul>
            <p>
            Rất mong được sự hỗ trợ của các thành viên
            </p>
            <p><b>BQT Thư viện trực tuyến Đức Nghĩa.</b></p>
    </div>
    
    <br />
    <h4><span><span><b>Các tin tức khác:</b></span></span></h4>    
    <div id="other_news">
        <%--<div class="block_text">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/News.aspx?action=news&id=2"><h3>Đức Nghĩa chào mừng ngày Nhà giáo Việt Nam</h3></asp:HyperLink>
            <h4><span><span>Hòa chung không khí tưng bừng chào mừng ngày Nhà giáo Việt Nam 20-11, công ty Cổ phần Tin học Bạch Kim xin gửi tới quý thầy, cô lời chúc sức khỏe, niềm vui và hạnh phúc!</span></span></h4>
            <h5>Post ngày 9/7/1011 bởi <b>Thầy Đức Nghĩa</b></h5>
        </div>
        
        <div class="block_text">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/News.aspx?action=news&id=3"><h3>Đức Nghĩa chào mừng năm học mới</h3></asp:HyperLink>
            <h4><span><span>Sau khi ra mắt vào 10/05/2010, phần mềm Violet 1.7 với nhiều tính năng mới so với các phiên bản trước đã nhận được sự quan tâm rất lớn của các thầy, cô giáo trên toàn quốc. Bộ GD&ĐT cũng đã trang bị phần mềm Violet 1.7 cho một số trường khó khăn thông qua các Dự án Phát triển THCS và THPT.</span></span></h4>
            <h5>Post ngày 8/7/1011 bởi <b>Thầy Đức Nghĩa</b></h5>
        </div>--%>
        <hr />
        <div id="linhk_news">
            <ul>
                <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/News.aspx?action=news&id=4">Thông báo địa điểm họp mặt thành viên</asp:HyperLink><div class="date"> (19-11-2011)</div></li>
                <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/News.aspx?action=news&id=5">Thông báo bảo trì server</asp:HyperLink><div class="date"> (19-11-2011)</div></li>
            </ul>
        </div>
        <hr />
        <div id="older_news">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/News.aspx?action=oldernews&id=5">Các tin cũ hơn>></asp:HyperLink>
        </div>
    </div>
</asp:Content>

