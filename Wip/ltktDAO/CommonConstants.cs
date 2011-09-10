using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public static class CommonConstants
    {
        #region Common
        /// <summary>
        /// Number record on one tab
        /// </summary>
        public const int DEFAULT_NUMBER_RECORD_ON_TAB = 8;

        /// <summary>
        /// Number record of relative a article
        /// </summary>
        public const int DEFAULT_NUMBER_RECORD_RELATIVE = 5;

        /// <summary>
        /// number of character string
        /// </summary>
        public const int DEFAULT_NUMBER_OF_CHARACTER_ON_STRING = 15;

        /// <summary>
        /// Blank value
        /// </summary>
        public const string BLANK = "";

        /// <summary>
        /// path of event log
        /// </summary>
        public const string PATH_LOG_FILE = "Log\\EventLog";

        /// <summary>
        /// html for edit icon on admin page
        /// </summary>
        public const string HTML_EDIT_ADMIN = "<span title=\"Sửa\"><img width=\"24px\" height=\"24\" src=\"../../images/edit.png\"/></span>";

        /// <summary>
        /// html for delete icon on admin page
        /// </summary>
        public const string HTML_DELETE_ADMIN = "<span title=\"Xóa\"><img width=\"24px\" height=\"24\" src=\"../../images/delete.png\" onclick=\"return confirm('Do you want to delete?')\"/></span>";
        /// <summary>
        /// Like page
        /// </summary>
        public const string LIKE = "Like";

        /// <summary>
        /// Dislike page
        /// </summary>
        public const string DISLIKE = "Dislike";

        /// <summary>
        /// guest user
        /// </summary>
        public const string USER_GUEST = "Guest";

        /// <summary>
        /// now
        /// </summary>
        public const string NOW = "now";
        /// <summary>
        /// all
        /// </summary>
        public const string ALL = "all";
        /// <summary>
        /// dot dtring (.)
        /// </summary>
        public const string DOT = ".";
        /// <summary>
        /// comma string(,)
        /// </summary>
        public const string COMMA = ",";
        /// <summary>
        /// comma character
        /// </summary>
        public const char COMMA_CHAR = ',';

        /// <summary>
        /// one space string(" ")
        /// </summary>
        public const string SPACE = " ";

        /// <summary>
        /// bar string
        /// </summary>
        public const string BAR = "-";
        /// <summary>
        /// hline string (|)
        /// </summary>
        public const string HLINE = "|";
        /// <summary>
        /// add parameter to address
        /// </summary>
        public const string ADD_PARAMETER = "?";
        /// <summary>
        /// =
        /// </summary>
        public const string EQUAL = "=";
        /// <summary>
        /// &
        /// </summary>
        public const string AND = "&";
        /// <summary>
        /// folder containt images of ads
        /// </summary>
        public const string FOLDER_IMG_ADS = "imagesAd";

        /// <summary>
        /// user system
        /// </summary>
        public const string USER_SYSTEM = "System";
        
        #endregion

        #region Alert (ALERT)
            /// <summary>
            /// alert when delete successful
            /// </summary>
            public const string ALERT_DELETE_SUCCESSFUL = "alert (\"Xóa thành công!\")";

            /// <summary>
            /// alert when delete fail
            /// </summary>
            public const string ALERT_DELETE_FAIL = "alert (\"Đã có lỗi xảy ra, xin vui lòng thử lại\")";

            /// <summary>
            /// alert when update fail
            /// </summary>
            public const string ALERT_UPDATE_FAIL = "alert (\"Đã có lỗi xảy ra, xin vui lòng thử lại\")";

            /// <summary>
            /// alert when update successful
            /// </summary>
            public const string ALERT_UPDATE_SUCCESSFUL = "alert (\"Cập nhật thành công!\")";
            
        #endregion

        #region Text display (TXT)
            /// <summary>
            /// Next page
            /// </summary>
            public const string TXT_NEXT_PAGE = "Trang sau";
            /// <summary>
            /// Previous page
            /// </summary>
            public const string TXT_PREVIOUS_PAGE = "Trang trước";
            /// <summary>
            /// view more
            /// </summary>
            public const string TXT_VIEW_MORE = "Xem tiếp";
            /// <summary>
            /// Article name
            /// </summary>
            public const string TXT_ARTICLE_NAME = "Bài";
            /// <summary>
            /// view all
            /// </summary>
            public const string TXT_VIEW_ALL = "Xem tất cả";
            /// <summary>
            /// login text
            /// </summary>
            public const string TXT_LOGIN = "Đăng nhập";
            /// <summary>
            /// account information text
            /// </summary>
            public const string TXT_ACCOUNT_INFOR = "Thông tin tài khoản"; 
        #endregion

        #region Css (CSS)
            /// <summary>
            /// Css class referlink
            /// </summary>
            public const string CSS_REFERLINK = "referlink"; 
        #endregion

        #region State (STATE)
        /// <summary>
        /// state is unchecked
        /// </summary>
        public const int STATE_UNCHECK = 0;

        /// <summary>
        /// Name of state uncheck
        /// </summary>
        public const string STATE_UNCHECK_NAME = "Chưa duyệt";
        
        /// <summary>
        /// state is checked
        /// </summary>
        public const int STATE_CHECKED = 1;

        /// <summary>
        /// Name of state checked
        /// </summary>
        public const string STATE_CHECKED_NAME = "Đã duyệt";

        /// <summary>
        /// state is bad
        /// </summary>
        public const int STATE_BAD = 2;

        /// <summary>
        /// state is non active
        /// </summary>
        public const int STATE_NON_ACTIVE = 0;

        /// <summary>
        /// Chưa kích hoạt
        /// </summary>
        public const string STATE_NON_ACTIVE_NAME = "Chưa kích hoạt";

        /// <summary>
        /// state is active
        /// </summary>
        public const int STATE_ACTIVE = 1;

        /// <summary>
        /// Đang hoạt động
        /// </summary>
        public const string STATE_ACTIVE_NAME = "Đang hoạt động";
        /// <summary>
        /// state is warning
        /// </summary>
        public const int STATE_WARNING = 2;

        /// <summary>
        /// Cảnh cáo
        /// </summary>
        public const string STATE_WARNING_NAME = "Cảnh cáo";
        /// <summary>
        /// state is kia 3 day
        /// </summary>
        public const int STATE_KIA_3D = 31;

        /// <summary>
        /// KIA 3 ngày
        /// </summary>
        public const string STATE_KIA_3D_NAME = "KIA 3 ngày";
        /// <summary>
        /// state is kia 1 week
        /// </summary>
        public const int STATE_KIA_1W = 32;

        /// <summary>
        /// KIA 1 tuần
        /// </summary>
        public const string STATE_KIA_1W_NAME = "KIA 1 tuần";
        /// <summary>
        /// state is kia 2 week
        /// </summary>
        public const int STATE_KIA_2W = 33;

        /// <summary>
        /// KIA 2 tuần
        /// </summary>
        public const string STATE_KIA_2W_NAME = "KIA 2 tuần";
        /// <summary>
        /// state is kia 3 week
        /// </summary>
        public const int STATE_KIA_3W = 34;

        /// <summary>
        /// KIA 3 tuần
        /// </summary>
        public const string STATE_KIA_3W_NAME = "KIA 3 tuần";
        /// <summary>
        /// state is kia 1 Month
        /// </summary>
        public const int STATE_KIA_1M = 35;

        /// <summary>
        /// KIA 1 tháng
        /// </summary>
        public const string STATE_KIA_1M_NAME = "KIA 1 tháng";
        /// <summary>
        /// state is deleted
        /// </summary>
        public const int STATE_DELETED = 4;

        /// <summary>
        /// state is deleted
        /// </summary>
        public const string STATE_DELETED_NAME = "Đã xóa";
        /// <summary>
        /// state is pending
        /// </summary>
        public const int STATE_PENDING = 10;

        /// <summary>
        /// Name of state pending
        /// </summary>
        public const string STATE_PENDING_NAME = "Sắp hết hạn";
        /// <summary>
        /// state is sticky
        /// </summary>
        public const int STATE_STICKY = 13;

        /// <summary>
        /// Name of state sticky
        /// </summary>
        public const string STATE_STICKY_NAME = "Sticky";

        #endregion

        #region Color State (CS)
        public const string CS_NON_ACTIVE = "yellow";
        public const string CS_ACTIVE = "blue";
        public const string CS_WARNING = "orange";
        public const string CS_KIA = "violet";
        public const string CS_DELETED = "gray";
        public const string CS_ANNOUCEMENT_BGCOLOR = "white";
        public const string CS_ANNOUCEMENT_TEXTCOLOR = "red";
        #endregion

        #region State Tooltip Text(SX)
        public const string SX_NON_ACTIVE = "Non active";
        public const string SX_ACTIVE = "Active";
        public const string SX_WARNING = "Warning";
        public const string SX_KIA = "Lock";
        public const string SX_DELETED = "Deleted";
        #endregion

        #region Article type (AT)
        /// <summary>
        /// Article has type lecture
        /// </summary>
        public const int AT_LECTURE = 0;
        /// <summary>
        /// Article has type a practise
        /// </summary>
        public const int AT_PRACTISE = 1;
        /// <summary>
        /// Article has type Examination
        /// </summary>
        public const int AT_EXAM = 2;
        /// <summary>
        /// Article is not classified
        /// </summary>
        public const int AT_UNCLASSIFIED = 0;

        #region University (AT_UNI)
        /// <summary>
        /// Khối A
        /// </summary>
        public const int AT_UNI_BRANCH_A = 0;
        /// <summary>
        /// Khối B
        /// </summary>
        public const int AT_UNI_BRANCH_B = 1;
        /// <summary>
        /// Khối C
        /// </summary>
        public const int AT_UNI_BRANCH_C = 2;
        /// <summary>
        /// Khối D
        /// </summary>
        public const int AT_UNI_BRANCH_D = 3;
        /// <summary>
        /// Khối A
        /// </summary>
        public const string AT_UNI_BRANCH_A_NAME = "Khối A";
        /// <summary>
        /// Khối B
        /// </summary>
        public const string AT_UNI_BRANCH_B_NAME = "Khối B";
        /// <summary>
        /// Khối C
        /// </summary>
        public const string AT_UNI_BRANCH_C_NAME = "Khối C";
        /// <summary>
        /// Khối D
        /// </summary>
        public const string AT_UNI_BRANCH_D_NAME = "Khối D";
        #endregion

        #region Informatics (AT_IT)
        /// <summary>
        /// Informatics office start
        /// </summary>
        public const int AT_IT_OFFICE_START = 1;
        /// <summary>
        /// informatics office end
        /// </summary>
        public const int AT_IT_OFFICE_END = 9;

        /// <summary>
        /// Article IT with type Excel
        /// </summary>
        public const int AT_IT_OFFICE_EXCEL = 1;
        /// <summary>
        /// Article IT with type Power point
        /// </summary>
        public const int AT_IT_OFFICE_POWERPOINT = 2;
        /// <summary>
        /// Article IT with type power point
        /// </summary>
        public const int AT_IT_OFFICE_ACCESS = 3;
        /// <summary>
        /// Article IT with type word
        /// </summary>
        public const int AT_IT_OFFICE_WORD = 4;
        /// <summary>
        /// Article IT with type simple tip
        /// </summary>
        public const int AT_IT_SIMPLE_TIP = 10;
        /// <summary>
        /// Article IT type with type advance tip
        /// </summary>
        public const int AT_IT_ADVANCE_TIP = 20;
        #endregion

        #region English Type (AT_EL)
        /// <summary>
        /// Class english class
        /// </summary>
        public const int AT_EL_CLASS_START = 1;
        /// <summary>
        /// Class english end
        /// </summary>
        public const int AT_EL_CLASS_END = 19;
        /// <summary>
        /// Major English start
        /// </summary>
        public const int AT_EL_MJ_START = 20;
        /// <summary>
        /// Major English end
        /// </summary>
        public const int AT_EL_MJ_END = 29;
        /// <summary>
        /// Certificate English Start
        /// </summary>
        public const int AT_EL_CERT_START = 30;
        /// <summary>
        /// Certificate English end
        /// </summary>
        public const int AT_EL_CERT_END = 69;
        /// <summary>
        /// Anh văn lớp 1
        /// </summary>
        public const int AT_EL_CLASS_1 = 1;
        /// <summary>
        /// Anh văn lớp 2
        /// </summary>
        public const int AT_EL_CLASS_2 = 2;
        /// <summary>
        /// Anh văn lớp 3
        /// </summary>
        public const int AT_EL_CLASS_3 = 3;
        /// <summary>
        /// Anh văn lớp 4
        /// </summary>
        public const int AT_EL_CLASS_4 = 4;
        /// <summary>
        /// Anh văn lớp 5
        /// </summary>
        public const int AT_EL_CLASS_5 = 5;
        /// <summary>
        /// Anh văn lớp 6
        /// </summary>
        public const int AT_EL_CLASS_6 = 6;
        /// <summary>
        /// Anh văn lớp 7
        /// </summary>
        public const int AT_EL_CLASS_7 = 7;
        /// <summary>
        /// Anh văn lớp 8
        /// </summary>
        public const int AT_EL_CLASS_8 = 8;
        /// <summary>
        /// Anh văn lớp 9
        /// </summary>
        public const int AT_EL_CLASS_9 = 9;
        /// <summary>
        /// Anh văn lớp 10
        /// </summary>
        public const int AT_EL_CLASS_10 = 10;
        /// <summary>
        /// Anh văn lớp 11
        /// </summary>
        public const int AT_EL_CLASS_11 = 11;
        /// <summary>
        /// Anh văn lớp 12
        /// </summary>
        public const int AT_EL_CLASS_12 = 12;
        /// <summary>
        /// CN Toán
        /// </summary>
        public const int AT_EL_MJ_MATH = 20;
        /// <summary>
        /// CN Kinh tế
        /// </summary>
        public const int AT_EL_MJ_ECO = 21;
        /// <summary>
        /// CN Hóa
        /// </summary>
        public const int AT_EL_MJ_CHEM = 22;
        /// <summary>
        /// CN Sinh
        /// </summary>
        public const int AT_EL_MJ_BIO = 23;
        /// <summary>
        /// CN Khoa học vật liệu
        /// </summary>
        public const int AT_EL_MJ_MATERIAL = 24;
        /// <summary>
        /// CN Lý
        /// </summary>
        public const int AT_EL_MJ_PHY = 25;
        /// <summary>
        /// CN viễn thông
        /// </summary>
        public const int AT_EL_MJ_TELE = 26;
        /// <summary>
        /// CN CNTT
        /// </summary>
        public const int AT_EL_MJ_IT = 27;
        /// <summary>
        /// TOEIC 300
        /// </summary>
        public const int AT_EL_TOEIC_300 = 40;
        /// <summary>
        /// TOEIC 400
        /// </summary>
        public const int AT_EL_TOEIC_400 = 41;
        /// <summary>
        /// TOEIC 500
        /// </summary>
        public const int AT_EL_TOEIC_500 = 42;
        /// <summary>
        /// TOEIC 600
        /// </summary>
        public const int AT_EL_TOEIC_600 = 43;
        /// <summary>
        /// TOEIC 700
        /// </summary>
        public const int AT_EL_TOEIC_700 = 44;
        /// <summary>
        /// TOEIC 800
        /// </summary>
        public const int AT_EL_TOEIC_800 = 45;
        /// <summary>
        /// TOEIC 900
        /// </summary>
        public const int AT_EL_TOEIC_900 = 46;
        /// <summary>
        /// Chứng chỉ A
        /// </summary>
        public const int AT_EL_CERT_A = 60;
        /// <summary>
        /// Chứng chỉ B
        /// </summary>
        public const int AT_EL_CERT_B = 61;
        /// <summary>
        /// Chứng chỉ C
        /// </summary>
        public const int AT_EL_CERT_C = 62;
        /// <summary>
        /// TOEFL
        /// </summary>
        public const int AT_EL_TOEFL = 40;
        /// <summary>
        /// IELTS
        /// </summary>
        public const int AT_EL_IELTS = 50;
        #endregion

        #endregion

        #region Messages(MSG)
        /// <summary>
        /// Message back to home
        /// </summary>
        public const string MSG_BACK_TO_HOME = "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
        /// <summary>
        /// Change password successful
        /// </summary>
        public const string MSG_CHANGE_PASSWORD_SUCCESSFUL = "Bạn đã đổi mật khẩu thành công!";
        /// <summary>
        /// Password required wrong
        /// </summary>
        public const string MSG_PASSWORD_REQUIRED_WRONG = "Mật khẩu hiện tại không đúng. Xin vui lòng kiểm tra lại!";
        /// <summary>
        /// update profile successful
        /// </summary>
        public const string MSG_UPDATE_PROFILE_SUCCESSFUL = "Bạn đã cập nhật hồ sơ thành công!";
        /// <summary>
        /// News page error
        /// </summary>
        public const string MSG_NEWS_ERROR = "Đường dẫn trang web không hợp lệ, xin vui lòng kiểm tra lại!";
        /// <summary>
        /// News not found
        /// </summary>
        public const string MSG_NEWS_NOT_FOUND = "Tin tức không tồn tại hoặc đã bị xóa!";
        /// <summary>
        /// do not find out article record on DB
        /// </summary>
        public const string MSG_ARTICLE_EMPTY_RECORD = "Hiện tại chưa có bài viết nào";
        /// <summary>
        /// error text
        /// </summary>
        public const string MSG_COMMON_ERROR_TEXT = "Đã có lỗi xảy ra, xin vui lòng thử lại sau.";
        /// <summary>
        /// Upload successful message 
        /// </summary>
        public const string MSG_UPLOAD_SUCCESSFUL = "Upload thành công";
        /// <summary>
        /// Login failed message
        /// </summary>
        public const string MSG_LOGIN_FAILED = "Tên đăng nhập hoặc mật khẩu không đúng. Xin vui lòng kiểm tra lại!";
        /// <summary>
        /// Username is conflict message
        /// </summary>
        public const string MSG_USERNAME_CONFLICT = "Tên đăng nhập đã được sử dụng.";
        /// <summary>
        /// Email is conflicted message
        /// </summary>
        public const string MSG_EMAIL_CONFLICT = "Email của bạn đã được đăng ký. Nếu bạn đã đăng ký mà không nhớ mật khẩu.<br/>Lấy lại mật khẩu <a href=\"ResetPassword.aspx\">tại đây</a>";
        /// <summary>
        /// Registry is successful message
        /// </summary>
        public const string MSG_REGISTRY_SUCCESSFUL = "Bạn đã đăng ký thành công. Xin vui lòng kiểm tra email để kích hoạt tài khoản!<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
        /// <summary>
        /// Message registry failed
        /// </summary>
        public const string MSG_REGISTRY_FAILED = "Quá trình đăng ký không thành công. Xin vui lòng thử lại!";
        /// <summary>
        /// Message reset password is successful
        /// </summary>
        public const string MSG_RESET_PASSWORD_SUCCESSFUL = "Mật khẩu mới đã được gửi tới email của bạn. Xin vui lòng kiểm tra email.";
        /// <summary>
        /// Message reset password is failed
        /// </summary>
        public const string MSG_RESET_PASSWORD_FAILED = "Lỗi: Không tìm thấy email của bạn!";
        /// <summary>
        /// Message search not found
        /// </summary>
        public const string MSG_SEARCH_NOT_FOUND = "<p><br />Rất tiếc, không có kết quả nào phù hợp với yêu cầu tìm kiếm của bạn.</p>";
        /// <summary>
        /// Message reply is sent successful
        /// </summary>
        public const string MSG_REPLY_SUCCESSFUL = "Phản hồi của bạn đã được gửi thành công đến cho chúng tôi. Chân thành cảm ơn đóng góp của bạn! ";
        /// <summary>
        /// Message reply is sent failed
        /// </summary>
        public const string MSG_REPLY_FAILED = "Phản hồi của bạn gửi không thành công. Xin vui lòng kiểm tra lại địa chỉ email của bạn. \n <br/> <a href=\"Contact.aspx\">Thử lại</a>";
        /// <summary>
        /// Message access is denied
        /// </summary>
        public const string MSG_ACCESS_DENIED = "Bạn không có quyền truy cập khu vực này!";
        /// <summary>
        /// Message resourse not found
        /// </summary>
        public const string MSG_RESOURSE_NOT_FOUND = "Tài nguyên không có hoặc đã bị xóa!";
        /// <summary>
        /// website is under construction.
        /// </summary>
        public const string MSG_UNDERCONSTRUCTION = "Website is under construction!";
        /// <summary>
        /// file zise is too large
        /// </summary>
        public const string MSG_FILE_SIZE_IS_TOO_LARGE = "Kích thước tài liệu quá giới hạn cho phép";

        /// <summary>
        /// Message when error
        /// </summary>
        public const string MSG_ERROR = "Đã có lỗi xảy ra, vui lòng thử lại sau!";

        /// <summary>
        /// Message when link error
        /// </summary>
        public const string MSG_LINK_ERROR = "Đường dẫn không đúng, xin vui lòng kiểm tra lại";

        
        #endregion

        #region Administrator Function (AF)
        /// <summary>
        /// Bật/Tắt thông báo
        /// </summary>
        public const string AF_ANNOUCEMENT = "ANNOUCEMENT";
        /// <summary>
        /// Bật/Tắt chức năng upload
        /// </summary>
        public const string AF_UPLOAD = "UPLOAD";
        /// <summary>
        /// Bật/Tắt chức năng đăng ký
        /// </summary>
        public const string AF_REGISTRY = "REGISTRY";
        /// <summary>
        /// Bật/tắt chức năng login
        /// </summary>
        public const string AF_LOGIN = "LOGIN";
        /// <summary>
        /// Bật/Tắt chức năng download
        /// </summary>
        public const string AF_DOWNLOAD = "DOWNLOAD";
        /// <summary>
        /// Bật/Tắt chức năng Comment
        /// </summary>
        public const string AF_COMMENT = "COMMENT";
        /// <summary>
        /// Bật/Tắt chức năng Comment không cần đăng nhập
        /// </summary>
        public const string AF_COMMENT_EASY = "COMMENT_EASY";
        /// <summary>
        /// Bật/Tắt chức năng đăng ký quảng cáo
        /// </summary>
        public const string AF_ADS = "ADS";
        /// <summary>
        /// Bật/Tắt chức năng upload tại trang LTDH
        /// </summary>
        public const string AF_UPLOAD_UNI = "UPLOAD_UNI";
        /// <summary>
        /// Bật/Tắt chức năng Download tại trang LTDH
        /// </summary>
        public const string AF_DOWNLOAD_UNI = "DOWNLOAD_UNI";
        /// <summary>
        /// Bật/Tắt chức năng Upload tiếng anh
        /// </summary>
        public const string AF_UPLOAD_EL = "UPLOAD_EL";
        /// <summary>
        /// Bật/Tắt chức năng Download Tiếng anh
        /// </summary>
        public const string AF_DOWNLOAD_EL = "DOWNLOAD_EL";
        /// <summary>
        /// Bật/Tắt chức năng Upload IT
        /// </summary>
        public const string AF_UPLOAD_IT = "UPLOAD_IT";
        /// <summary>
        /// Bật/Tắt chức năng Download IT
        /// </summary>
        public const string AF_DOWNLOAD_IT = "DOWNLOAD_IT";
        /// <summary>
        /// Bật/Tắt chức năng Xem tin tức
        /// </summary>
        public const string AF_NEWS_VIEW = "NEWS_VIEW";
        /// <summary>
        /// Bật/Tắt chức năng Post tin tức
        /// </summary>
        public const string AF_NEWS_POST = "NEWS_POST";
        /// <summary>
        /// Bật/Tắt chức năng Search
        /// </summary>
        public const string AF_SEARCH = "SEARCH";
        /// <summary>
        /// Bật/Tắt chức năng Liên hệ
        /// </summary>
        public const string AF_CONTACT = "CONTACT";
        /// <summary>
        /// Bật/Tắt chế độ Underconstruction
        /// </summary>
        public const string AF_UNDERCONTRUCTION = "UNDERCONS";
        /// <summary>
        /// Bật/Tắt chức năng gửi email
        /// </summary>
        public const string AF_EMAIL_SEND = "EMAIL_SEND";
        #endregion

        #region Statistic Function (SF)
        /// <summary>
        /// Thành viên login gần nhất
        /// </summary>
        public const string SF_LATEST_LOGIN = "LATEST_LOGIN";
        /// <summary>
        /// Tổng số bài viết
        /// </summary>
        public const string SF_NUM_ARTICLE = "NUM_ARTICLE";
        /// <summary>
        /// TỔng số bài trong trang English
        /// </summary>
        public const string SF_NUM_ARTICLE_ON_EL = "NUM_ARTICLE_ON_EL";
        /// <summary>
        /// Tổng số bài trong trang IT
        /// </summary>
        public const string SF_NUM_ARTICLE_ON_IT = "NUM_ARTICLE_ON_IT";
        /// <summary>
        /// Tổng số bài trong trang LTDH
        /// </summary>
        public const string SF_NUM_ARTICLE_ON_UNI = "NUM_ARTICLE_ON_UNI";
        /// <summary>
        /// Tổng số bài trong 1 tab tại trang chủ
        /// </summary>
        public const string SF_NUM_ARTICLE_ON_TAB = "NUM_ARTICLE_ON_TAB";
        /// <summary>
        /// Tổng số comment trong ngày
        /// </summary>
        public const string SF_NUM_COMMENT_A_DAY = "NUM_COMMENT_DAY";
        /// <summary>
        /// Tổng số upload trong  ngày
        /// </summary>
        public const string SF_NUM_UPLOAD_A_DAY = "NUM_UPLOAD_DAY";
        /// <summary>
        /// Tổng số download trong 1 ngày
        /// </summary>
        public const string SF_NUM_DOWNLOAD_A_DAY = "NUM_DOWNLOAD_DAY";
        /// <summary>
        /// Tổng số upload
        /// </summary>
        public const string SF_NUM_UPLOAD = "NUM_UPLOAD";
        /// <summary>
        /// Tổng số thành viên hiện tại
        /// </summary>
        public const string SF_NUM_USER = "NUM_USER";
        /// <summary>
        /// Tổng số thành viên đăng ký mới
        /// </summary>
        public const string SF_NUM_USER_REGISTRY = "NUM_USER_REGISTRY";
        /// <summary>
        /// Số email mới
        /// </summary>
        public const string SF_NUM_NEW_EMAIL = "NUM_NEW_EMAIL";
        /// <summary>
        /// Số lượt truy cập
        /// </summary>
        public const string SF_NUM_VIEWER = "NUM_VIEWER";
        /// <summary>
        /// Số lượt truy cập trong ngày
        /// </summary>
        public const string SF_NUM_VIEWER_DAY = "NUM_VIEWER_DAY";
        #endregion

        #region Control Function (CF)
        /// <summary>
        /// Logo trang web
        /// </summary>
        public const string CF_LOGO = "LOGO";
        /// <summary>
        /// Lấy tiêu đề web (hiện ở title bar)
        /// </summary>
        public const string CF_TITLE_ON_HEADER = "TITLE_ON_HEADER";
        /// <summary>
        /// Lấy tiêu đề web (hiện cuối trang web)
        /// </summary>
        public const string CF_TITLE_ON_FOOTER = "TITLE_ON_FOOTER";
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public const string CF_ADDRESS = "ADDRESS";
        /// <summary>
        /// Văn bản chào mừng tại trang chủ
        /// </summary>
        public const string CF_WELCOME_TEXT = "WELCOME_TEXT";
        /// <summary>
        /// Cấu hình email
        /// </summary>
        public const string CF_EMAIL_CONFIG = "EMAIL_CONFIG";
        /// <summary>
        /// Nội dung thông báo
        /// </summary>
        public const string CF_ANNOUCEMENT = "ANNOUCEMENT";
        /// <summary>
        /// TỔng số bài hiển thị trong trang English
        /// </summary>
        public const string CF_NUM_ARTICLE_ON_EL = "NUM_ARTICLE_ON_EL";
        /// <summary>
        /// Tổng số bài hiển thị trong trang IT
        /// </summary>
        public const string CF_NUM_ARTICLE_ON_IT = "NUM_ARTICLE_ON_IT";
        /// <summary>
        /// Tổng số bài hiển thị trong trang LTDH
        /// </summary>
        public const string CF_NUM_ARTICLE_ON_UNI = "NUM_ARTICLE_ON_UNI";
        /// <summary>
        /// Tổng số bài hiển thị trong 1 tab tại trang chủ
        /// </summary>
        public const string CF_NUM_ARTICLE_ON_TAB = "NUM_ARTICLE_ON_TAB";
        /// <summary>
        /// Số tin được phép sticky
        /// </summary>
        public const string CF_NUM_ARTICLE_STICKY = "NUM_ARTICLE_STICKY";
        /// <summary>
        /// max size of file
        /// </summary>
        public const string CF_MAX_FILE_SIZE = "MAX_FILE_SIZE";
        /// <summary>
        /// Number record relative
        /// </summary>
        public const string CF_NUM_RECORD_RELATIVE = "NUM_RECORD_RELATIVE";
        #endregion

        #region Pages Name (PAGE)
        /// <summary>
        /// error Page
        /// </summary>
        public const string PAGE_ERROR = "Error.aspx";
        /// <summary>
        /// Login page
        /// </summary>
        public const string PAGE_LOGIN = "Login.aspx";
        /// <summary>
        /// Home page
        /// </summary>
        public const string PAGE_HOME = "Home.aspx";
        /// <summary>
        /// News page
        /// </summary>
        public const string PAGE_NEWS = "News.aspx";
        /// <summary>
        /// Home page name
        /// </summary>
        public const string PAGE_HOME_NAME = "Trang chủ";

        /// <summary>
        /// Ads contact page name
        /// </summary>
        public const string PAGE_ADS_NAME = "Liên hệ quảng cáo";

        /// <summary>
        /// Contact page name
        /// </summary>
        public const string PAGE_CONTACT_NAME = "Liên hệ/Góp ý";
        /// <summary>
        /// English page
        /// </summary>
        public const string PAGE_ENGLISH = "English.aspx";

        /// <summary>
        /// English page name
        /// </summary>
        public const string PAGE_ENGLISH_NAME = "Anh văn";
        /// <summary>
        /// Informatics page
        /// </summary>
        public const string PAGE_INFORMATICS = "Informatics.aspx";
        /// <summary>
        /// Informatics page name
        /// </summary>
        public const string PAGE_INFORMATICS_NAME = "Tin học";
        /// <summary>
        /// University page
        /// </summary>
        public const string PAGE_UNIVERSITY = "ContestUniversity.aspx";
        /// <summary>
        /// University page name
        /// </summary>
        public const string PAGE_UNIVERSITY_NAME = "Luyện thi đại học";
        /// <summary>
        /// Error page name
        /// </summary>
        public const string PAGE_ERROR_NAME = "Trang lỗi";
        /// <summary>
        /// Article page
        /// </summary>
        public const string PAGE_ARTICLE_DETAILS = "ArticleDetails.aspx";
        /// <summary>
        /// search page name
        /// </summary>
        public const string PAGE_SEARCH_NAME = "Tìm kiếm";
        /// <summary>
        /// reset password page name
        /// </summary>
        public const string PAGE_RESET_PASSWORD_NAME = "Lấy lai mật khẩu";
        /// <summary>
        /// registry page name
        /// </summary>
        public const string PAGE_REGISTRY_NAME = "Đăng ký tài khoản";
        /// <summary>
        /// profile page name
        /// </summary>
        public const string PAGE_PROFILE_NAME = "Hồ sơ cá nhân";
        /// <summary>
        /// news page name
        /// </summary>
        public const string PAGE_NEWS_NAME = "Tin tức";
        /// <summary>
        /// login page name
        /// </summary>
        public const string PAGE_LOGIN_NAME = "Đăng nhập";
        /// <summary>
        /// page under construction
        /// </summary>
        public const string PAGE_UNDERCONSTRUCTION = "UnderConstruction.aspx";
        /// <summary>
        /// under construction name
        /// </summary>
        public const string PAGE_UNDERCONSTRUCTION_NAME = "Đang bảo trì";
        /// <summary>
        /// upload page name
        /// </summary>
        public const string PAGE_UPLOAD_NAME = "Gửi bài viết";
        /// <summary>
        /// Admin general page
        /// </summary>
        public const string PAGE_ADMIN_GENERAL = "./Admin/General.aspx";
        /// <summary>
        /// Admin login page
        /// </summary>
        public const string PAGE_ADMIN_LOGIN = "../Login.aspx";

        /// <summary>
        /// Admin news page
        /// </summary>
        public const string PAGE_ADMIN_NEWS = "News.aspx";
        
        /// <summary>
        /// Name of admin news page
        /// </summary>
        public const string PAGE_ADMIN_NEWS_NAME = "Quản lý tin tức";

        /// <summary>
        /// Admin ads page
        /// </summary>
        public const string PAGE_ADMIN_ADS = "Advertisement.aspx";

        /// <summary>
        /// Name of admin ads page
        /// </summary>
        public const string PAGE_ADMIN_ADS_NAME = "Quản lý quảng cáo";

        /// <summary>
        /// Mailbox page
        /// </summary>
        public const string PAGE_ADMIN_MAIL = "Mailbox.aspx";

        /// <summary>
        /// Mailbox page name
        /// </summary>
        public const string PAGE_ADMIN_MAIL_NAME = "Hộp thư";

        /// <summary>
        /// Users page name
        /// </summary>
        public const string PAGE_ADMIN_USERS_NAME = "Quản lý thành viên";

        /// <summary>
        /// users admin page
        /// </summary>
        public const string PAGE_ADMIN_USERS = "Users.aspx";

        #endregion

        #region Application Constants (APP)
            /// <summary>
            /// Users asre online
            /// </summary>
            public const string APP_USER_ONLINE = "UserOnline";
        #endregion

        #region Session Constants (SES)
        /// <summary>
        /// User on session
        /// </summary>
        public const string SES_USER = "User";
        /// <summary>
        /// Article SCO on session
        /// </summary>
        public const string SES_ARTICLE_SCO = "ArticleSCO";
        /// <summary>
        /// constant of session error text
        /// </summary>
        public const string SES_ERROR = "Error";

        /// <summary>
        /// Session for email
        /// </summary>
        public const string SES_EMAIL = "Email";
        /// <summary>
        /// session edit news
        /// </summary>
        public const string SES_EDIT_NEWS = "editNews";

        /// <summary>
        /// session edit ads
        /// </summary>
        public const string SES_EDIT_ADS = "editAds";

        /// <summary>
        /// session edit user
        /// </summary>
        public const string SES_EDIT_USER = "editUsers";
        #endregion

        #region Request Constants (REQ)
        /// <summary>
        /// section on request
        /// </summary>
        public const string REQ_SECTION = "sec";
        /// <summary>
        /// Id of item on request
        /// </summary>
        public const string REQ_ID = "id";
        /// <summary>
        /// subject on request
        /// </summary>
        public const string REQ_SUBJECT = "sub";
        /// <summary>
        /// time on request
        /// </summary>
        public const string REQ_TIME = "time";
        /// <summary>
        /// library on request
        /// </summary>
        public const string REQ_LIBRARY = "lib";
        /// <summary>
        /// Request Action
        /// </summary>
        public const string REQ_ACTION = "action";
        /// <summary>
        /// Request class
        /// </summary>
        public const string REQ_CLASS = "class";
        /// <summary>
        /// Request Leitmotif
        /// </summary>
        public const string REQ_LEITMOTIF = "leit";
        /// <summary>
        /// request page
        /// </summary>
        public const string REQ_PAGE = "page";

        /// <summary>
        /// request type
        /// </summary>
        public const string REQ_TYPE = "type";
        #endregion

        #region Section Uni,It,EL (SEC)
        /// <summary>
        /// Section university code
        /// </summary>
        public const string SEC_UNIVERSITY_CODE = "uni";
        /// <summary>
        /// Section informatics code
        /// </summary>
        public const string SEC_INFORMATICS_CODE = "it";
        /// <summary>
        /// Section english code
        /// </summary>
        public const string SEC_ENGLISH_CODE = "el";
        /// <summary>
        /// Section university code
        /// </summary>
        public const string SEC_UNIVERSITY_NAME = "Luyện thi Đại học";
        /// <summary>
        /// Section informatics code
        /// </summary>
        public const string SEC_INFORMATICS_NAME = "Tin học";
        /// <summary>
        /// Section english code
        /// </summary>
        public const string SEC_ENGLISH_NAME = "Anh văn";
        #endregion

        #region Parameters (PARAM)
            /// <summary>
            /// THPT
            /// </summary>
            public const string PARAM_EL_COMMON = "com";
            /// <summary>
            /// Chuyên ngành
            /// </summary>
            public const string PARAM_EL_MAJOR = "maj";
            /// <summary>
            /// Chứng chỉ
            /// </summary>
            public const string PARAM_EL_CERT = "cert";
            /// <summary>
            /// THVP
            /// </summary>
            public const string PARAM_IT_OFFICE = "off";
            /// <summary>
            /// Thủ thuật căn bản
            /// </summary>
            public const string PARAM_IT_SIMPLE = "simp";
            /// <summary>
            /// Thủ thuật nâng cao
            /// </summary>
            public const string PARAM_IT_ADVANCE = "adv"; 
        #endregion

        #region Cookie (COOKIE)
            /// <summary>
            /// Cookie username
            /// </summary>
            public const string COOKIE_USERNAME = "Username";
            /// <summary>
            /// Cookie Password
            /// </summary>
            public const string COOKIE_PASSWORD = "Password"; 
        #endregion

        #region Subjects Math,Phy,Chem,Bio,Lit,His,Geo,Eng (SUB)
        /// <summary>
        /// Môn Toán
        /// </summary>
        public const string SUB_MATHEMATICS = "Môn Toán";
        /// <summary>
        /// Môn Lý
        /// </summary>
        public const string SUB_PHYSICAL = "Môn Lý";
        /// <summary>
        /// Môn Hóa
        /// </summary>
        public const string SUB_CHEMICAL = "Môn Hóa";
        /// <summary>
        /// Môn Sinh
        /// </summary>
        public const string SUB_BIOGRAPHY = "Môn Sinh";
        /// <summary>
        /// Môn Văn
        /// </summary>
        public const string SUB_LITERATURE = "Môn Văn";
        /// <summary>
        /// Môn Sử
        /// </summary>
        public const string SUB_HISTORY = "Môn Sử";
        /// <summary>
        /// Môn Địa
        /// </summary>
        public const string SUB_GEOGRAPHY = "Môn Địa";
        /// <summary>
        /// Môn Anh
        /// </summary>
        public const string SUB_ENGLISH = "Môn Anh";
        /// <summary>
        /// Mã Môn Toán
        /// </summary>
        public const string SUB_MATHEMATICS_CODE = "math";
        /// <summary>
        /// Mã môn Lý
        /// </summary>
        public const string SUB_PHYSICAL_CODE = "phy";
        /// <summary>
        /// Mã môn Hóa
        /// </summary>
        public const string SUB_CHEMICAL_CODE = "chem";
        /// <summary>
        /// Mã Môn sinh
        /// </summary>
        public const string SUB_BIOGRAPHY_CODE = "bio";
        /// <summary>
        /// Mã Môn Văn
        /// </summary>
        public const string SUB_LITERATURE_CODE = "lit";
        /// <summary>
        /// Mã môn Sử
        /// </summary>
        public const string SUB_HISTORY_CODE = "his";
        /// <summary>
        /// Mã Môn địa
        /// </summary>
        public const string SUB_GEOGRAPHY_CODE = "geo";
        /// <summary>
        /// Mã Môn Anh
        /// </summary>
        public const string SUB_ENGLISH_CODE = "el";
        #endregion

        #region Templates (TEMP)
        /// <summary>
        /// University link template
        /// </summary>
        public const string TEMP_UNI_LINK = "<a href=\"" + PAGE_UNIVERSITY + "?" + REQ_SUBJECT + "={0}&" + REQ_TIME + "={1}\">{2}</a>";
        /// <summary>
        /// link template for article details
        /// </summary>
        public const string TEMP_ARTICLE_DETAILS_LINK = "<a href='" + PAGE_ARTICLE_DETAILS + "?" + REQ_SECTION + "={0}&" + REQ_ID + "={1}'>{2}</a>";
        /// <summary>
        /// link template for english page
        /// </summary>
        public const string TEMP_ENGLISH_LINK = "<a href='" + PAGE_ENGLISH + "?" + REQ_CLASS + "={0}&" + REQ_TIME + "={1}'>{2}</a>";
        /// <summary>
        /// link template for informatics page
        /// </summary>
        public const string TEMP_INFORMATICS_LINK = "<a href='" + PAGE_INFORMATICS + "?" + REQ_LEITMOTIF + "={0}&" + REQ_TIME + "={1}'>{2}</a>";
        /// <summary>
        /// link template for news page
        /// </summary>
        public const string TEMP_NEWS_LINK = "<a href='" + PAGE_NEWS + "?id={0}'>{1}</a>";
        /// <summary>
        /// image thumbnail for article
        /// </summary>
        public const string TEMP_IMG_THUMBNAIL = "<img width='50px' height='50px' src='{0}' alt='{1}'/>";
        /// <summary>
        /// Self Link template
        /// </summary>
        public const string TEMP_SELF_LINK = "<a href=\"{0}?page={1}\">{2}</a>";


        /// <summary>
        /// Self Link template
        /// </summary>
        public const string TEMP_MINOR_SELF_LINK = "<a href=\"{0}?type={1}&page={2}\">{3}</a>";

        /// <summary>
        /// Display link template
        /// "<a href=\"{0}?action={1}&id={2}\">{3}</a>"
        /// </summary>
        public const string TEMP_DISPLAY_LINK = "<a href=\"{0}?action={1}&id={2}\">{3}</a>";

        /// <summary>
        /// Label tag template
        /// </summary>
        public const string TEMP_LABEL_TAG = "<label>{0}</label>";
        /// <summary>
        /// Template tag
        /// </summary>
        public const string TEMP_LI_TAG = "<li>{0}</li>";
        /// <summary>
        /// Template A tag
        /// </summary>
        public const string TEMP_A_TAG = "<a href=\"{0}\">{1}</a>";
        /// <summary>
        /// Templte b tag
        /// </summary>
        public const string TEMP_I_TAG = "<i>{0}</i>";
        /// <summary>
        /// Template strong tag, 1 param
        /// </summary>
        public const string TEMP_STRONG_TAG = "<strong>{0}</strong>";
        /// <summary>
        /// Template br tag, no param
        /// </summary>
        public const string TEMP_BR_TAG = "<br/>";
        /// <summary>
        /// Template font tag
        /// </summary>
        public const string TEMP_FONT_TAG = "<span style=\"color:{0};\">{1}</span>";
        /// <summary>
        /// Template for span tag
        /// </summary>
        public const string TEMP_SPAN_TAG = "<span style=\"color:{0};\" title=\"{1}\">{2}</span>";
        /// <summary>
        /// Template of annoucement;
        /// </summary>
        public const string TEMP_MARQUEE_TAG = "<div style=\"margin-left:20px;\"><MARQUEE WIDTH=100% BEHAVIOR=SCROLL HEIGHT=20 BGColor={0} onmouseover=\"this.stop();\" onmouseout=\"this.start();\"><span style=\"color:{1}\">{2}</span></MARQUEE></div>";
        /// <summary>
        /// div template with no property, require 1 value for text
        /// </summary>
        public const string TEMP_DIV_TAG = "<div>{0}</div>";
        /// <summary>
        /// div template with 2 param: class and text
        /// </summary>
        public const string TEMP_DIV_TAG_WITH_CLASS= "<div class='{0}'>{1}</div>";
        /// <summary>
        /// div template with 2 param: style and text
        /// </summary>
        public const string TEMP_DIV_TAG_WITH_STYLE = "<div style='{0}'>{1}</div>";
        #endregion

        #region Action request (ACT)
        /// <summary>
        /// Action Click
        /// </summary>
        public const string ACT_CLICK = "click";

        /// <summary>
        /// Action for delete
        /// </summary>
        public const string ACT_DELETE = "delete";

        /// <summary>
        /// Action for edit
        /// </summary>
        public const string ACT_EDIT = "edit";

        /// <summary>
        /// Action for view
        /// </summary>
        public const string ACT_VIEW = "view";

        /// <summary>
        /// Action for inbox
        /// </summary>
        public const string ACT_INBOX = "inbox";

        /// <summary>
        /// action for sent
        /// </summary>
        public const string ACT_SENT = "sent";

        /// <summary>
        /// action for normal user
        /// </summary>
        public const string ACT_NORMAL = "normal";

        /// <summary>
        /// action for KIA user
        /// </summary>
        public const string ACT_KIA = "KIA";

        /// <summary>
        /// action for admin user
        /// </summary>
        public const string ACT_ADMIN = "admin";
        #endregion

        #region Advertisement (ADS)
        /// <summary>
        /// Banner Top
        /// </summary>
        public const string ADS_TOP_BANNER = "top";
        /// <summary>
        /// Banner Top Leader
        /// </summary>
        public const string ADS_TOP_LEADER_BANNER = "topleader";
        /// <summary>
        /// Banner Top Right
        /// </summary>
        public const string ADS_TOP_RIGHT_BANNER = "topright";
        /// <summary>
        /// Banner Middle right
        /// </summary>
        public const string ADS_MIDDLE_RIGHT_BANNER = "middleright";
        /// <summary>
        /// Banner middle right
        /// </summary>
        public const string ADS_BOTTOM_RIGHT_BANNER = "bottomright";
        /// <summary>
        /// Banner Top left
        /// </summary>
        public const string ADS_TOP_LEFT_BANNER = "topleft";
        /// <summary>
        /// Banner middle left
        /// </summary>
        public const string ADS_MIDDLE_LEFT_BANNER = "middleleft";
        /// <summary>
        /// Banner bottom left
        /// </summary>
        public const string ADS_BOTTOM_LEFT_BANNER = "bottomleft";
        /// <summary>
        /// Banner bottom 1
        /// </summary>
        public const string ADS_BOTTOM_1_BANNER = "bot1";
        /// <summary>
        /// Banner bottom 2
        /// </summary>
        public const string ADS_BOTTOM_2_BANNER = "bot2";
        #endregion

        #region SQL query (SQL)
        /// <summary>
        /// insert query template, require 2 argument
        /// </summary>
        public const string SQL_INSERT_SUCCESSFUL_TEMPLATE = " Insert record {0} to Table {1} successful";
        /// <summary>
        /// insert query template, require 2 argument
        /// </summary>
        public const string SQL_INSERT_FAILED_TEMPLATE = " Insert record {0} to Table {1} failed";
        /// <summary>
        /// delete query template, require 2 argument
        /// </summary>
        public const string SQL_DELETE_SUCCESSFUL_TEMPLATE = " Delete record {0} from Table {1} successful";
        /// <summary>
        /// delete query template, require 2 argument
        /// </summary>
        public const string SQL_DELETE_FAILED_TEMPLATE = " Delete record {0} from Table {1} failed";
        /// <summary>
        /// update query template, require 2 argument
        /// </summary>
        public const string SQL_UPDATE_SUCCESSFUL_TEMPLATE = " Update record {0} to Table {1} successful";
        /// <summary>
        /// update query template, require 2 argument
        /// </summary>
        public const string SQL_UPDATE_FAILED_TEMPLATE = " Delete record {0} to Table {1} failed";
        /// <summary>
        /// change state on template, required _adminCode
        /// </summary>
        public const string SQL_CHANGE_STATE_ON = " Change code {0} of " + SQL_TABLE_ADMIN + " is ON";
        /// <summary>
        /// change state off template, require _adminCode
        /// </summary>
        public const string SQL_CHANGE_STATE_OFF = " Change code {0} of " + SQL_TABLE_ADMIN + " is OFF";
        #endregion

        #region SQL table (SQL_TABLE)
        /// <summary>
        /// Table Informatics 
        /// </summary>
        public const string SQL_TABLE_INFORMATICS = "tblInformatics";
        /// <summary>
        /// Table ContestForUniversity
        /// </summary>
        public const string SQL_TABLE_CONTEST_UNIVERSITY = "tblContestForUniversity";
        /// <summary>
        /// Table English
        /// </summary>
        public const string SQL_TABLE_ENGLISH = "tblEnglish";
        /// <summary>
        /// Table News
        /// </summary>
        public const string SQL_TABLE_NEWS = "tblNews";
        /// <summary>
        /// Table User
        /// </summary>
        public const string SQL_TABLE_USER = "tblUser";
        /// <summary>
        /// Table Contact
        /// </summary>
        public const string SQL_TABLE_CONTACT = "tblContact";
        /// <summary>
        /// Table Admin
        /// </summary>
        public const string SQL_TABLE_ADMIN = "tblAdmin";
        /// <summary>
        /// Table Permission
        /// </summary>
        public const string SQL_TABLE_PERMISSION = "tblPermission";
        /// <summary>
        /// Table Statistic
        /// </summary>
        public const string SQL_TABLE_STATISTIC = "tblStatistic";
        /// <summary>
        /// Table Sticky
        /// </summary>
        public const string SQL_TABLE_STICKY = "tblSticky";
        /// <summary>
        /// Table Advertisement
        /// </summary>
        public const string SQL_TABLE_ADVERTISEMENT = "tblAdvertisement";
        /// <summary>
        /// Table control;
        /// </summary>
        public const string SQL_TABLE_CONTROL = "tblControl";

        #endregion

        #region Permission (P)
        public const string P_N_GENERAL = "N_GENERAL";
        public const string P_A_GENERAL = "A_GENERAL";
        public const string P_A_ADS = "A_ADS";
        public const string P_A_USER = "A_USER";
        public const string P_A_NEWS = "A_NEWS";
        public const string P_A_UNIVERSITY = "A_UNIVERSITY";
        public const string P_A_ENGLISH = "A_ENGLISH";
        public const string P_A_INFORMATICS = "A_INFORMATICS";
        public const string P_A_SECURITY = "A_SECURITY";
        public const string P_A_CONTACT = "A_CONTACT";
        public const string P_A_COMMENT = "A_COMMENT";
        public const string P_A_LOG = "A_LOG";
        public const string P_A_CONTROL = "A_CONTROL";
        public const string P_A_EMAIL = "A_EMAIL";
        public const string P_A_AUTHORITY = "A_AUTHORITY";
        public const string P_A_FULL_CONTROL = "A_FULL_CONTROL"; 
        #endregion

    }
}
