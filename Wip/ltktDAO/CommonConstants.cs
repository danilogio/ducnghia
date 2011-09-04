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
        public const int NUMBER_RECORD_ON_TAB = 8;

        /// <summary>
        /// Number record of relative a article
        /// </summary>
        public const int NUMBER_RECORD_RELATIVE = 5;

        /// <summary>
        /// number of character string
        /// </summary>
        public const int NUMBER_OF_CHARACTER_ON_STRING = 15;

        /// <summary>
        /// Blank value
        /// </summary>
        public const string BLANK = "";

        /// <summary>
        /// path of event log
        /// </summary>
        public const string LOG_FILE_PATH = "Log\\EventLog";

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
        #endregion

        #region State (STATE)
        /// <summary>
        /// state is unchec
        /// </summary>
        public const int STATE_UNCHECK = 0;
        /// <summary>
        /// state is checked
        /// </summary>
        public const int STATE_CHECKED = 1;
        /// <summary>
        /// state is bad
        /// </summary>
        public const int STATE_BAD = 2;

        /// <summary>
        /// state is non active
        /// </summary>
        public const int STATE_NON_ACTIVE = 0;

        /// <summary>
        /// state is active
        /// </summary>
        public const int STATE_ACTIVE = 1;
        /// <summary>
        /// state is warning
        /// </summary>
        public const int STATE_WARNING = 2;
        /// <summary>
        /// state is kia 3 day
        /// </summary>
        public const int STATE_KIA_3D = 31;
        /// <summary>
        /// state is kia 1 week
        /// </summary>
        public const int STATE_KIA_1W = 32;
        /// <summary>
        /// state is kia 2 week
        /// </summary>
        public const int STATE_KIA_2W = 33;
        /// <summary>
        /// state is kia 3 week
        /// </summary>
        public const int STATE_KIA_3W = 34;
        /// <summary>
        /// state is kia 1 Month
        /// </summary>
        public const int STATE_KIA_1M = 35;
        /// <summary>
        /// state is deleted
        /// </summary>
        public const int STATE_DELETED = 4;
        /// <summary>
        /// state is pending
        /// </summary>
        public const int STATE_PENDING = 10;
        /// <summary>
        /// state is sticky
        /// </summary>
        public const int STATE_STICKY = 13;

        #endregion

        #region Color State (CS)
        public const string CS_NON_ACTIVE = "yellow";
        public const string CS_ACTIVE = "blue";
        public const string CS_WARNING = "orange";
        public const string CS_KIA = "violet";
        public const string CS_DELETED = "gray";
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
        /// Article IT with type word
        /// </summary>
        public const int AT_IT_OFFICE_WORD = 0;
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
        /// Article IT with type simple tip
        /// </summary>
        public const int AT_IT_OFFICE_SIMPLE_TIP = 4;
        /// <summary>
        /// Article IT type with type advance tip
        /// </summary>
        public const int AT_IT_OFFICE_ADVANCE_TIP = 5;
        #endregion

        #region English Type (AT_EL)
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

        #region Sticky Type (ST)
        /// <summary>
        /// Sticky University
        /// </summary>
        public const int ST_UNI = 0;
        /// <summary>
        /// Sticky English
        /// </summary>
        public const int ST_EL = 1;
        /// <summary>
        /// Sticky Informatics
        /// </summary>
        public const int ST_IT = 2;
        #endregion

        #region Messages(MSG)
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
        /// Home page name
        /// </summary>
        public const string PAGE_HOME_NAME = "Trang chủ";
        /// <summary>
        /// English page
        /// </summary>
        public const string PAGE_ENGLISH = "English.aspx";
        /// <summary>
        /// Informatics page
        /// </summary>
        public const string PAGE_INFORMATICS = "Informatics.aspx";
        /// <summary>
        /// University page
        /// </summary>
        public const string PAGE_UNIVERSITY = "ContestUniversity.aspx";
        /// <summary>
        /// Article page
        /// </summary>
        public const string PAGE_ARTICLE_DETAILS = "ArticleDetails.aspx";
        /// <summary>
        /// Admin general page
        /// </summary>
        public const string PAGE_ADMIN_GENERAL = "./Admin/General.aspx";
        /// <summary>
        /// Admin login page
        /// </summary>
        public const string PAGE_ADMIN_LOGIN = "./Login.aspx";

        /// <summary>
        /// Admin news page
        /// </summary>
        public const string PAGE_ADMIN_NEWS = "./Admin/News.aspx";

        /// <summary>
        /// Admin ads page
        /// </summary>
        public const string PAGE_ADMIN_ADS = "./Admin/Advertisement.aspx";
        #endregion

        #region Application Constants (APP)
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
        public const string SEC_UNIVERSITY = "Luyện thi Đại học";
        /// <summary>
        /// Section informatics code
        /// </summary>
        public const string SEC_INFORMATICS = "Tin học";
        /// <summary>
        /// Section english code
        /// </summary>
        public const string SEC_ENGLISH = "Anh văn";
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

        public const string TEMP_ARTICLE_DETAILS_LINK = "<a href='" + PAGE_ARTICLE_DETAILS + "?" + REQ_SECTION + "={0}&" + REQ_ID + "={1}'>{2}</a>";

        /// <summary>
        /// Self Link template
        /// </summary>
        public const string TEMP_SELF_LINK = "<a href=\"{0}?page={1}\">{2}</a>";

        /// <summary>
        /// Display link template
        /// </summary>
        public const string TEMP_DISPLAY_LINK = "<a href=\"{0}?action={1}&id={2}\" target=\"_blank\">{3}</a>";

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
        /// Template font tag
        /// </summary>
        public const string TEMP_FONT_TAG = "<span style=\"color:{0};\">{1}</span>";
        /// <summary>
        /// Template foe span tag
        /// </summary>
        public const string TEMP_SPAN_TAG = "<span style=\"color:{0};\" title=\"{1}\">{2}</span>";
        #endregion

        #region Action request (ACT)
        /// <summary>
        /// Action Click
        /// </summary>
        public const string ACT_CLICK = "click";
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
    }
}
