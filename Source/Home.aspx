<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Home" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script type="text/javascript">
			        $(function(){
				        // Tabs
			        $('#ExamLesson').tabs();
			        $('#ItLesson').tabs();
			        $('#EnglishLesson').tabs();
				        });
				</script>
				
				<!-- 
				
                <div id="block_text" class="block_text">
                    <h2>Chào mừng quý vị đến với Website Luyện thi Kinh tế</h2>
                    <hr /> 
                    <p>Tại đây các bạn sẽ được cung cấp kho tư liệu về đề thi cũng như các giải đáp thắc mắc về đề thi các năm.<br /> 
                    Chúng tôi tập trung vào 3 mảng chính: Luyện thi, Tin học và Anh văn</p>

                    <h3>Hướng dẫn</h3>
                    <p>Trang web này chạy tốt với các trình duyệt:</p>
                    <ul>
                        <li>Firefox 3.5</li>
                        <li>Opera 10.00</li>
                        <li>IE 7 and 8</li>
                        <li>Chrome</li>
                    </ul>
                    <p>Mọi thắc mắc xin liện hệ email: <a href="mailto:trungtamducnghia@gmail.com">trungtamducnghia@gmail.com</a></p>
                    <p>Hoặc gửi mail cho chúng tôi tại phần Liên hệ</p>  
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
                
                -->
                
                <div id="ExamLesson" class="block_text">
                    <h2>Thư viện đề thi đại học, cao đẳng</h2>
			        <ul>
				        <li><a href="#ExamLesson-1">Đề thi</a></li>
				        <li><a href="#ExamLesson-2">Gợi ý giải</a></li>
			        </ul>
			        <div id="ExamLesson-1">
			            <div class="block_details">
                            <div class="block_details_img"> 
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/acroread.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/zip.png" alt="Eden"/>
                            </div>
                            <div class="block_details_title">
                                 <a href="#">Đề thi đại học năm 2009</a>
                            </div>
                            <div class="block_details_text">
                                Môn Hóa<br />
                                Khối B
                            </div>
                        </div>             
                        <div><a href="~/">Xem thêm</a></div>
			        </div>
			        <div id="ExamLesson-2">Hiện chưa có bài viết nào
			        </div>
			        
		        </div>
		        
		        
                 <div id="ItLesson" class="block_text">
                    <h2>Thư viện Tin học</h2>
		            <ul>
			            <li><a href="#ItLesson-1">Bài giảng</a></li>
			            <li><a href="#ItLesson-2">Bài tập</a></li>
			            <li><a href="#ItLesson-3">Đề thi</a></li>
		            </ul>
		         <!-- start ItLesson-1-->
		            <div id="ItLesson-1">
		                <div class="block_details">
                            <div class="block_details_img"> 
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/acroread.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/zip.png" alt="Eden"/>
                            </div>
                            <div class="block_details_title">
                                 <a href="#">Đề thi đại học năm 2009</a>
                            </div>
                            <div class="block_details_text">
                                Môn Hóa<br />
                                Khối B
                            </div>
                        </div>
                        
                        <br /><a href="#">Xem thêm</a>
		            </div>
		         <!-- start ItLesson-2-->
		            <div id="ItLesson-2">
		                <div class="block_details">
                            <div class="block_details_img"> 
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/acroread.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/zip.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
                            </div>
                            <div class="block_details_title">
                                 <a href="#">Đề thi đại học năm 2010</a>
                            </div>
                            <div class="block_details_text">
                                Môn Lý<br />
                                Khối A
                            </div>
                        </div>
                        
                        <br /><a href="#">Xem thêm</a>
		                </div>
		         <!-- start ItLesson-3-->
	                <div id="ItLesson-3">Hiện chưa có bài viết nào
	                </div>
                 </div>
                
                
                 
                 <div id="EnglishLesson" class="block_text">
                    <h2>Thư viện Anh Văn</h2> 
                     <ul>
			            <li><a href="#EnglishLesson-1">Bài giảng</a></li>
			            <li><a href="#EnglishLesson-2">Bài tập</a></li>
			            <li><a href="#EnglishLesson-3">Đề thi</a></li>
		            </ul>
		        <!-- start EglishLesson-1-->
		            <div id="EnglishLesson-1">
                        <div class="block_details">
                            <div class="block_details_img"> 
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/acroread.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/pp.png" alt="Eden"/>
                            </div>
                            <div class="block_details_title">
                                 <a href="#">Đề thi đại học năm 2009</a>
                            </div>
                            <div class="block_details_text">
                                Môn Hóa<br />
                                Khối B
                            </div>
                        </div>
                        
                        <br /><a href="#">Xem thêm</a>
                    </div>
                <!-- start EglishLesson-2-->
                    <div id="EnglishLesson-2">
		                <div class="block_details">
                            <div class="block_details_img"> 
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/acroread.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/zip.png" alt="Eden"/>
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
                                <img width="50px" height="50px" src="images/Word.png" alt="Eden"/>
                            </div>
                            <div class="block_details_title">
                                 <a href="#">Đề thi đại học năm 2010</a>
                            </div>
                            <div class="block_details_text">
                                Môn Lý<br />
                                Khối A
                            </div>
                        </div>
                        
                        <br /><a href="#">Xem thêm</a>
		           </div>
		        <!-- start EglishLesson-3-->
		            <div id="EnglishLesson-3">Hiện chưa có bài viết nào
	                </div>
                </div>
                
                
 
</asp:Content>
