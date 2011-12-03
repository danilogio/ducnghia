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
        /// first number page
        /// </summary>
        public const string PAGE_NUMBER_FIRST = "1";
        public const string CONST_ONE = "1";
        public const string CONST_TWO = "2";
        public const string CONST_THREE = "3";
        public const string CONST_FOUR = "4";
        public const string CONST_FIVE = "5";
        public const string CONST_SIX = "6";
        public const string CONST_SEVEN = "7";
        public const string CONST_EIGHT = "8";
        public const string CONST_NINE = "9";
        public const string CONST_TEN = "10";
        public const string CONST_ZERO = "0";
        public const string CONST_ONE_NEGATIVE = "-1";
        /// <summary>
        /// Blank value
        /// </summary>
        public const string BLANK = "";

        /// <summary>
        /// path of event log
        /// </summary>
        public const string PATH_LOG_FILE = "Data\\Log\\EventLog";
        public const string PATH_ADMIN_LOG_FILE = "Log\\EventLog";
        /// <summary>
        /// active icon
        /// </summary>
        public const string PATH_ACTIVE_RATING_ICON = "images/star-y.png";
        /// <summary>
        /// inactive rating icon
        /// </summary>
        public const string PATH_INACTIVE_RATING_ICON = "images/star-g.png";
        /// <summary>
        /// new link icon
        /// </summary>
        public const string PATH_NEW_LINK_ICON = "images/linknew.gif";
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
        /// sharp character
        /// </summary>
        public const string SHARP = "#";
        /// <summary>
        /// one space string(" ")
        /// </summary>
        public const string SPACE = " ";

        /// <summary>
        /// admin
        /// </summary>
        public const string ADMIN = "Admin";

        /// <summary>
        /// splash
        /// </summary>
        public const string SPLASH = "/";

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
        /// :
        /// </summary>
        public const string HYPHEN = ":";
        /// <summary>
        /// folder containt images of ads
        /// </summary>
        public const string FOLDER_IMG_ADS = FOLDER_DATA + "/" + "imagesAd";

        public const string FOLDER_DATA = "Data";

        public const string FOLDER_UNI = "Data/University";

        public const string FOLDER_EL = "Data/English";

        public const string FOLDER_IT = "Data/Informatics";

        public const string FOLDER_MATH = "ToanHoc";

        public const string FOLDER_PHYS = "VatLy";

        public const string FOLDER_CHEM = "HoaHoc";

        public const string FOLDER_BIO = "SinhHoc";

        public const string FOLDER_LIT = "VanHoc";

        public const string FOLDER_HIS = "LichSu";

        public const string FOLDER_GEO = "DiaLy";

        public const string FOLDER_ENG = "AnhVan";

        public const string FOLDER_OTH = "Other";

        public const string FOLDER_DEFAULT_IMG = "DefaultImages";


        /// <summary>
        /// user system
        /// </summary>
        public const string USER_SYSTEM = "System";
        /// <summary>
        /// <![CDATA[>]]>
        /// </summary>
        public const string NEXT_BUTTON = ">";
        /// <summary>
        /// <![CDATA[<]]>
        /// </summary>
        public const string BACK_BUTTON = "<";
        /// <summary>
        /// <![CDATA[<<]]>
        /// </summary>
        public const string FIRST_BUTTON = "<<";
        /// <summary>
        /// <![CDATA[>>]]>
        /// </summary>
        public const string LAST_BUTTON = ">>";
        /// <summary>
        /// newline
        /// </summary>
        public const string NEWLINE = "\n";
        /// <summary>
        /// File type csv
        /// </summary>
        public const string EXT_CSV = ".csv";
        /// <summary>
        /// default size of image
        /// </summary>
        public const string DEFAULT_ADS_IMG_SIZE = "0x0";
        /// <summary>
        /// default size format
        /// </summary>
        public const string DEFAULT_SIZE_FORMAT = "WxH";
        public const string DEFAULT_DATE_FORMAT = "mm/dd/yyyy hh:MM:ss";
        /// <summary>
        /// character X;
        /// </summary>
        public const string X = "x";
        
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
            public const string TXT_ALL = "Tất cả";
            /// <summary>
            /// login text
            /// </summary>
            public const string TXT_LOGIN = "Đăng nhập";
            /// <summary>
            /// account information text
            /// </summary>
            public const string TXT_ACCOUNT_INFOR = "Thông tin tài khoản";
            /// <summary>
            /// University name
            /// </summary>
            public const string TXT_UNIVERSITY = "Đại học";
            /// <summary>
            /// Colleague name
            /// </summary>
            public const string TXT_COLLEAGUE = "Cao đẳng";
            /// <summary>
            /// English name
            /// </summary>
            public const string TXT_ENGLISH = "Anh văn";
            /// <summary>
            /// Informatics name
            /// </summary>
            public const string TXT_INFORMATICS = "Tin học";
            /// <summary>
            /// Back to home
            /// </summary>
            public const string TXT_BACK_TO_HOME = "Quay về trang chủ";
            /// <summary>
            /// Resolved Direction
            /// </summary>
            public const string TXT_RESOLVING = "Hướng dẫn giải";
            /// <summary>
            /// Location
            /// </summary>
            public const string TXT_ADS_LOCATION = "vị trí quảng cáo";
            /// <summary>
            /// Please select of combobox
            /// </summary>
            public const string TXT_PLEASE_SELECT = "---Chọn---";
            /// <summary>
            /// Navigation Url
            /// </summary>
            public const string TXT_ADS_NAVIGATE_URL = "Trang web công ty";
            /// <summary>
            /// Image url
            /// </summary>
            public const string TXT_ADS_IMAGE_URL = "Tập tin quảng cáo";
            /// <summary>
            /// size img
            /// </summary>
            public const string TXT_ADS_IMAGE_SIZE = "Kích thước ảnh quảng cáo";
            /// <summary>
            /// list article
            /// </summary>
            public const string TXT_LIST_ARTICLE = "Danh sách bài viết";
            /// <summary>
            /// sticky
            /// </summary>
            public const string TXT_STICKY = "Sticky";
            /// <summary>
            /// Sticky tolower for Uni admin page - use for this page only
            /// </summary>
            public const string TXT_STICKY_TOLOWER = "sticky";
            public const string TXT_UNSTICKY = "Không Sticky";
            /// <summary>
            /// Chủ đề
            /// </summary>
            public const string TXT_SUBJECT = "Chủ đề";
            /// <summary>
            /// reason
            /// </summary>
            public const string TXT_REASON = "Lý do";
            public const string TXT_INFORM = "BQT Thông báo:";
            /// <summary>
            /// posted date
            /// </summary>
            public const string TXT_POSTED_DATE = "Ngày đăng bài";
            /// <summary>
            /// title
            /// </summary>
            public const string TXT_TITLE = "Tiêu đề";
            public const string TXT_THUMBNAIL = "Hình thumbnail";
            public const string TXT_TAG = "Tag";
            public const string TXT_LOCATION = "Nơi lưu bài";
            public const string TXT_ONE_HALF = "1/2";
            public const string TXT_CLEAR_DATA = "Xóa dữ liệu";
            public const string TXT_FILE_CONTENT = "tập tin nội dung(kích thước > 0 Byte)";
            public const string TXT_RESET_PASSWORD = "Password được reset và gửi tới email của thành viên.";

        #endregion

        #region Css (CSS)
            /// <summary>
            /// Css class referlink
            /// </summary>
            public const string CSS_REFERLINK = "referlink"; 
            public const string CSS_ARTICLE_LIST = "articleList";
            public const string CSS_BLOCK_DETAIL_TEXT = "block_detail_text";
        #endregion

        #region State (STATE)
        /// <summary>
        /// state is unchecked
        /// </summary>
        public const int STATE_UNCHECK = 0;
        /// <summary>
        /// state is block
        /// </summary>
        public const string STATE_BLOCK_NAME = "Khóa";
        /// <summary>
        /// state is blocked
        /// </summary>
        public const int STATE_BLOCK = 56;

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
        /// state bad name
        /// </summary>
        public const string STATE_BAD_NAME = "Bad";
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
        public const string CS_NORMAL = "black";
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
        /// Article lecture name
        /// </summary>
        public const string AT_LECTURE_NAME = "Bài giảng";
        /// <summary>
        /// Article has type a practise
        /// </summary>
        public const int AT_PRACTISE = 1;
        /// <summary>
        /// Article practise name
        /// </summary>
        public const string AT_PRACTISE_NAME = "Bài tập";
        /// <summary>
        /// Article has type Examination
        /// </summary>
        public const int AT_EXAM = 2;
        /// <summary>
        /// Article examination name
        /// </summary>
        public const string AT_EXAM_NAME = "Đề thi";
        /// <summary>
        /// Article is not classified
        /// </summary>
        public const int AT_UNCLASSIFIED = 0;
        public const string AT_UNCLASSIFIED_NAME = "Chưa phân loại";

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
        /// Informatics simple tip start
        /// </summary>
        public const int AT_IT_SIMPLE_TIP_START = AT_IT_SIMPLE_TIP;
        /// <summary>
        /// Informatics simple tip end
        /// </summary>
        public const int AT_IT_SIMPLE_TIP_END = 19;
        /// <summary>
        /// Informatics simple tip start
        /// </summary>
        public const int AT_IT_ADVANCE_TIP_START = AT_IT_ADVANCE_TIP;
        /// <summary>
        /// Informatics simple tip end
        /// </summary>
        public const int AT_IT_ADVANCE_TIP_END = 29;
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
        /// Article IT with type Excel
        /// </summary>
        public const string AT_IT_OFFICE_EXCEL_NAME = "Excel";
        /// <summary>
        /// Article IT with type Power point
        /// </summary>
        public const int AT_IT_OFFICE_POWERPOINT = 2;
        /// <summary>
        /// Article IT with type Power point
        /// </summary>
        public const string AT_IT_OFFICE_POWERPOINT_NAME = "PowerPoint";
        /// <summary>
        /// Article IT with type power point
        /// </summary>
        public const int AT_IT_OFFICE_ACCESS = 3;
        /// <summary>
        /// Article IT with type power point
        /// </summary>
        public const string AT_IT_OFFICE_ACCESS_NAME = "Access";
        /// <summary>
        /// Article IT with type word
        /// </summary>
        public const int AT_IT_OFFICE_WORD = 4;
        /// <summary>
        /// Article IT with type word
        /// </summary>
        public const string AT_IT_OFFICE_WORD_NAME = "Word";
        /// <summary>
        /// Article IT with type simple tip
        /// </summary>
        public const int AT_IT_SIMPLE_TIP = 10;
        /// <summary>
        /// Article IT with type simple tip
        /// </summary>
        public const string AT_IT_SIMPLE_TIP_NAME = "Thủ thuật căn bản";
        /// <summary>
        /// Article IT type with type advance tip
        /// </summary>
        public const int AT_IT_ADVANCE_TIP = 20;
        /// <summary>
        /// Article IT type with type advance tip
        /// </summary>
        public const string AT_IT_ADVANCE_TIP_NAME = "Thủ thuật nâng cao";
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
        public const int AT_EL_CERT_TOEIC_START = 40;
        public const int AT_EL_CERT_TOEIC_END = 49;
        public const int AT_EL_CERT_TOEFL_START = 30;
        public const int AT_EL_CERT_TOEFL_END = 39;
        public const int AT_EL_CERT_IELTS_START = 50;
        public const int AT_EL_CERT_IELTS_END = 59;
        public const int AT_EL_CERT_ABC_START = 60;
        public const int AT_EL_CERT_ABC_END = 69;
        public const string AT_EL_CLASS_1_TO_9 = "19";
        public const string AT_EL_CLASS_1_TO_9_NAME = "Lớp 1->9";
        public const string AT_EL_CERT_TOEIC = "4049";
        public const string AT_EL_CERT_TOEFL = "3039";
        public const string AT_EL_CERT_IELTS = "5059";
        public const string AT_EL_ABC = "abc";
        public const string AT_EL_ABC_NAME = "Chứng Chỉ ABC";
        /// <summary>
        /// Anh văn lớp 1
        /// </summary>
        public const int AT_EL_CLASS_1 = 1;
        /// <summary>
        /// Anh văn lớp 1
        /// </summary>
        public const string AT_EL_CLASS_1_CODE = "1";
        public const string AT_EL_CLASS_1_NAME = "Lớp 1";
        /// <summary>
        /// Anh văn lớp 2
        /// </summary>
        public const int AT_EL_CLASS_2 = 2;
        /// <summary>
        /// Anh văn lớp 2
        /// </summary>
        public const string AT_EL_CLASS_2_CODE = "2";
        public const string AT_EL_CLASS_2_NAME = "Lớp 2";
        /// <summary>
        /// Anh văn lớp 3
        /// </summary>
        public const int AT_EL_CLASS_3 = 3;
        /// <summary>
        /// Anh văn lớp 3
        /// </summary>
        public const string AT_EL_CLASS_3_CODE = "3";
        public const string AT_EL_CLASS_3_NAME = "Lớp 3";
        /// <summary>
        /// Anh văn lớp 4
        /// </summary>
        public const int AT_EL_CLASS_4 = 4;
        /// <summary>
        /// Anh văn lớp 4
        /// </summary>
        public const string AT_EL_CLASS_4_CODE = "4";
        public const string AT_EL_CLASS_4_NAME = "Lớp 4";
        /// <summary>
        /// Anh văn lớp 5
        /// </summary>
        public const int AT_EL_CLASS_5 = 5;
        /// <summary>
        /// Anh văn lớp 5
        /// </summary>
        public const string AT_EL_CLASS_5_CODE = "5";
        public const string AT_EL_CLASS_5_NAME = "Lớp 5";
        /// <summary>
        /// Anh văn lớp 6
        /// </summary>
        public const int AT_EL_CLASS_6 = 6;
        /// <summary>
        /// Anh văn lớp 6
        /// </summary>
        public const string AT_EL_CLASS_6_CODE = "6";
        public const string AT_EL_CLASS_6_NAME = "Lớp 6";
        /// <summary>
        /// Anh văn lớp 7
        /// </summary>
        public const int AT_EL_CLASS_7 = 7;
        /// <summary>
        /// Anh văn lớp 7
        /// </summary>
        public const string AT_EL_CLASS_7_CODE = "7";
        public const string AT_EL_CLASS_7_NAME = "Lớp 7";
        /// <summary>
        /// Anh văn lớp 8
        /// </summary>
        public const int AT_EL_CLASS_8 = 8;
        /// <summary>
        /// anh văn lớp 8
        /// </summary>
        public const string AT_EL_CLASS_8_CODE = "8";
        public const string AT_EL_CLASS_8_NAME = "Lớp 8";
        /// <summary>
        /// Anh văn lớp 9
        /// </summary>
        public const int AT_EL_CLASS_9 = 9;
        /// <summary>
        /// Anh văn lớp 9
        /// </summary>
        public const string AT_EL_CLASS_9_CODE = "9";
        public const string AT_EL_CLASS_9_NAME = "Lớp 9";
        /// <summary>
        /// Anh văn lớp 10
        /// </summary>
        public const int AT_EL_CLASS_10 = 10;
        /// <summary>
        /// Anh văn lớp 10
        /// </summary>
        public const string AT_EL_CLASS_10_CODE = "10";
        public const string AT_EL_CLASS_10_NAME = "Lớp 10";
        /// <summary>
        /// Anh văn lớp 11
        /// </summary>
        public const int AT_EL_CLASS_11 = 11;
        /// <summary>
        /// Anh văn 11
        /// </summary>
        public const string AT_EL_CLASS_11_CODE = "11";
        public const string AT_EL_CLASS_11_NAME = "Lớp 11";
        /// <summary>
        /// Anh văn lớp 12
        /// </summary>
        public const int AT_EL_CLASS_12 = 12;
        /// <summary>
        /// Anh văn 12
        /// </summary>
        public const string AT_EL_CLASS_12_CODE = "12";
        public const string AT_EL_CLASS_12_NAME = "Lớp 12";
        /// <summary>
        /// CN Toán
        /// </summary>
        public const int AT_EL_MJ_MATH = 20;
        public const string AT_EL_MJ_MATH_NAME = "CN Toán";
        /// <summary>
        /// CN Kinh tế
        /// </summary>
        public const int AT_EL_MJ_ECO = 21;
        public const string AT_EL_MJ_ECO_NAME = "CN Kinh tế";
        /// <summary>
        /// CN Hóa
        /// </summary>
        public const int AT_EL_MJ_CHEM = 22;
        public const string AT_EL_MJ_CHEM_NAME = "CN Hóa";
        /// <summary>
        /// CN Sinh
        /// </summary>
        public const int AT_EL_MJ_BIO = 23;
        public const string AT_EL_MJ_BIO_NAME = "CN Sinh";
        /// <summary>
        /// CN Khoa học vật liệu
        /// </summary>
        public const int AT_EL_MJ_MATERIAL = 24;
        public const string AT_EL_MJ_MATERIAL_NAME = "CN KHVL";
        /// <summary>
        /// CN Lý
        /// </summary>
        public const int AT_EL_MJ_PHY = 25;
        public const string AT_EL_MJ_PHY_NAME = "CN Vật lý";
        /// <summary>
        /// CN viễn thông
        /// </summary>
        public const int AT_EL_MJ_TELE = 26;
        public const string AT_EL_MJ_TELE_NAME = "CN Viễn thông";
        /// <summary>
        /// CN CNTT
        /// </summary>
        public const int AT_EL_MJ_IT = 27;
        public const string AT_EL_MJ_IT_NAME = "CN CNTT";
        /// <summary>
        /// TOEIC name
        /// </summary>
        public const string AT_EL_TOEIC_NAME = "TOEIC";
        /// <summary>
        /// TOEIC 300
        /// </summary>
        public const int AT_EL_TOEIC_300 = 40;
        public const string AT_EL_TOEIC_300_NAME = "TOEIC 300";
        /// <summary>
        /// TOEIC 400
        /// </summary>
        public const int AT_EL_TOEIC_400 = 41;
        public const string AT_EL_TOEIC_400_NAME = "TOEIC 400";
        /// <summary>
        /// TOEIC 500
        /// </summary>
        public const int AT_EL_TOEIC_500 = 42;
        public const string AT_EL_TOEIC_500_NAME = "TOEIC 500";
        /// <summary>
        /// TOEIC 600
        /// </summary>
        public const int AT_EL_TOEIC_600 = 43;
        public const string AT_EL_TOEIC_600_NAME = "TOEIC 600";
        /// <summary>
        /// TOEIC 700
        /// </summary>
        public const int AT_EL_TOEIC_700 = 44;
        public const string AT_EL_TOEIC_700_NAME = "TOEIC 700";
        /// <summary>
        /// TOEIC 800
        /// </summary>
        public const int AT_EL_TOEIC_800 = 45;
        public const string AT_EL_TOEIC_800_NAME = "TOEIC 800";
        /// <summary>
        /// TOEIC 900
        /// </summary>
        public const int AT_EL_TOEIC_900 = 46;
        public const string AT_EL_TOEIC_900_NAME = "TOEIC 900";
        /// <summary>
        /// Chứng chỉ A
        /// </summary>
        public const int AT_EL_CERT_A = 60;
        public const string AT_EL_CERT_A_NAME = "Chứng chỉ A";
        /// <summary>
        /// Chứng chỉ B
        /// </summary>
        public const int AT_EL_CERT_B = 61;
        public const string AT_EL_CERT_B_NAME = "Chứng chỉ B";
        /// <summary>
        /// Chứng chỉ C
        /// </summary>
        public const int AT_EL_CERT_C = 62;
        public const string AT_EL_CERT_C_NAME = "Chứng chỉ C";
        /// <summary>
        /// TOEFL
        /// </summary>
        public const int AT_EL_TOEFL = 30;
        public const string AT_EL_TOEFL_NAME = "TOEFL";
        /// <summary>
        /// IELTS
        /// </summary>
        public const int AT_EL_IELTS = 50;
        public const string AT_EL_IELTS_NAME = "IELTS";
        #endregion

        #endregion

        #region Messages(MSG)
        /// <summary>
        /// Message back to home
        /// </summary>
        public const string MSG_I_BACK_TO_HOME = "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
        /// <summary>
        /// Change password successful
        /// </summary>
        public const string MSG_I_CHANGE_PASSWORD_SUCCESSFUL = "Bạn đã đổi mật khẩu thành công!";
        /// <summary>
        /// Password required wrong
        /// </summary>
        public const string MSG_E_PASSWORD_REQUIRED_WRONG = "Mật khẩu hiện tại không đúng. Xin vui lòng kiểm tra lại!";
        /// <summary>
        /// update profile successful
        /// </summary>
        public const string MSG_I_UPDATE_PROFILE_SUCCESSFUL = "Bạn đã cập nhật hồ sơ thành công!";
        /// <summary>
        /// News page error
        /// </summary>
        public const string MSG_E_NEWS_ERROR = "Đường dẫn trang web không hợp lệ, xin vui lòng kiểm tra lại!";
        /// <summary>
        /// News not found
        /// </summary>
        public const string MSG_E_NEWS_NOT_FOUND = "Tin tức không tồn tại hoặc đã bị xóa!";
        /// <summary>
        /// do not find out article record on DB
        /// </summary>
        public const string MSG_I_ARTICLE_EMPTY_RECORD = "Hiện tại chưa có bài viết nào";
        /// <summary>
        /// error text
        /// </summary>
        public const string MSG_E_COMMON_ERROR_TEXT = "Đã có lỗi xảy ra, xin vui lòng thử lại sau.";
        /// <summary>
        /// Upload successful message 
        /// </summary>
        public const string MSG_I_UPLOAD_SUCCESSFUL = "Upload thành công";
        /// <summary>
        /// Login failed message
        /// </summary>
        public const string MSG_E_LOGIN_FAILED = "Tên đăng nhập hoặc mật khẩu không đúng. Xin vui lòng kiểm tra lại!";
        /// <summary>
        /// Username is conflict message
        /// </summary>
        public const string MSG_W_USERNAME_CONFLICT = "Tên đăng nhập đã được sử dụng.";
        /// <summary>
        /// Email is conflicted message
        /// </summary>
        public const string MSG_W_EMAIL_CONFLICT = "Email của bạn đã được đăng ký. Nếu bạn đã đăng ký mà không nhớ mật khẩu.<br/>Lấy lại mật khẩu <a href=\"ResetPassword.aspx\">tại đây</a>";
        /// <summary>
        /// Registry is successful message
        /// </summary>
        public const string MSG_I_REGISTRY_SUCCESSFUL = "Bạn đã đăng ký thành công. Xin vui lòng kiểm tra email để kích hoạt tài khoản!<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a>";
        /// <summary>
        /// Message registry failed
        /// </summary>
        public const string MSG_E_REGISTRY_FAILED = "Quá trình đăng ký không thành công. Xin vui lòng thử lại!";
        /// <summary>
        /// Message reset password is successful
        /// </summary>
        public const string MSG_I_RESET_PASSWORD_SUCCESSFUL = "Mật khẩu mới đã được gửi tới email của bạn. Xin vui lòng kiểm tra email.";
        /// <summary>
        /// Message reset password is failed
        /// </summary>
        public const string MSG_E_RESET_PASSWORD_FAILED = "Lỗi: Không tìm thấy email của bạn!";
        /// <summary>
        /// Message search not found
        /// </summary>
        public const string MSG_I_SEARCH_NOT_FOUND = "<p><br />Rất tiếc, không có kết quả nào phù hợp với yêu cầu tìm kiếm của bạn.</p>";
        /// <summary>
        /// Message reply is sent successful
        /// </summary>
        public const string MSG_I_REPLY_SUCCESSFUL = "Phản hồi của bạn đã được gửi thành công đến cho chúng tôi. Chân thành cảm ơn đóng góp của bạn! ";
        /// <summary>
        /// Message reply is sent failed
        /// </summary>
        public const string MSG_E_REPLY_FAILED = "Phản hồi của bạn gửi không thành công. Xin vui lòng kiểm tra lại địa chỉ email của bạn. \n <br/> <a href=\"Contact.aspx\">Thử lại</a>";
        /// <summary>
        /// Message access is denied
        /// </summary>
        public const string MSG_E_ACCESS_DENIED = "Bạn không có quyền truy cập khu vực này!";
        /// <summary>
        /// Message resourse not found
        /// </summary>
        public const string MSG_E_RESOURCE_NOT_FOUND = "Tài nguyên không có hoặc đã bị xóa!";
        /// <summary>
        /// website is under construction.
        /// </summary>
        public const string MSG_I_UNDERCONSTRUCTION = "Trang web hiện đang được bảo trì";
        /// <summary>
        /// file zise is too large
        /// </summary>
        public const string MSG_E_FILE_SIZE_IS_TOO_LARGE = "Kích thước tài liệu quá giới hạn cho phép";
        /// <summary>
        /// file zise is not allow
        /// </summary>
        public const string MSG_E_FILE_SIZE_IS_NOT_ALLOW = "Định dạng tài liệu không cho phép tải lên";
        /// <summary>
        /// gửi quảng cáo thành công
        /// </summary>
        public const string MSG_I_ADVERTISEMENT_CONTACT_IS_SENT_SUCCESSFUL = "Quý vị đặt quảng cáo thành công! <br />Chúng tôi sẽ liên lạc với quý vị để thêm chi tiết<br />";
        /// <summary>
        /// Invalid from date
        /// </summary>
        public const string MSG_E_INVALID_FROM_DATE = "Ngày bắt đầu phải lớn hơn hoặc bằng ngày hiện tại";

        public const string MSG_E_INVALID_TO_DATE = "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu";
        /// <summary>
        /// select one item
        /// </summary>
        public const string MSG_E_PLEASE_SELECT_ONE_ITEM = "Vui lòng chọn 1 {0}";
        /// <summary>
        /// Invalid file type
        /// </summary>
        public const string MSG_E_UPLOAD = "Định dạng tập tin không cho phép hoặc tập tin có kích thước quá lớn";

        public const string MSG_I_THANKS_FOR_UPLOADING = "<br /><br />Cám ơn bạn đã đóng góp cho trung tâm!";

        public const string MSG_I_WAITING_FOR_CHECKED = "<br />Bài viết của bạn sẽ được kiểm duyệt trong vòng 24h";

        public const string MSG_I_UPLOAD_AGAIN = "<br /><br /><a href=\"Upload.aspx\">Thử lại</a>";

        public const string MSG_E_PLEASE_INPUT_DATA = "Vui lòng nhập {0}";
        public const string MSG_E_PLEASE_INPUT_RIGHT_FORMAT = "Vui lòng nhập {0} theo định dạng {1}";
        public const string MSG_W_ADS_FROM_DATE = "Warning: Quảng cáo này có Ngày bắt đầu nhỏ hơn ngày hiện tại.";
        public const string MSG_E_ACTION_FAILED = "Thao tác {0} thất bại. Vui lòng thử lại sau";
        public const string MSG_I_ACTION_SUCCESSFUL = "Thao tác {0} đã thành công";
        public const string MSG_E_MAX_LENGTH = "Chiều dài của {0} tối đa là {1}";
        public const string MSG_E_OVER_NUMBER = "Tổng số {0} là {1} đã vượt quá {2} là {3}";
        public const string MSG_I_ACTION_DETAIL = "Đã {0} được {1} {2}";
        /// <summary>
        /// Message when error
        /// </summary>
        //public const string MSG_ERROR = "Đã có lỗi xảy ra, vui lòng thử lại sau!";

        /// <summary>
        /// Message when link error
        /// </summary>
        public const string MSG_E_LINK_INVALID = "Đường dẫn không đúng, xin vui lòng kiểm tra lại";
        public const string MSG_I_NUM_SEARCHED_RECORD = "Có tổng cộng {0} bài viết được tìm thấy";
        public const string MSG_I_NUM_SEARCHED_USER = "Có tổng cộng {0} User được tìm thấy";
        #endregion

        #region Administrator Function (AF)
        /// <summary>
        /// Bật/Tắt thông báo
        /// </summary>
        public const string AF_ANNOUCEMENT = "ANNOUCEMENT";

        public const string AF_ANNOUCEMENT_NAME = "Thông báo";
        /// <summary>
        /// Bật/Tắt chức năng upload
        /// </summary>
        public const string AF_UPLOAD = "UPLOAD";
        public const string AF_UPLOAD_NAME = "Upload";
        /// <summary>
        /// Bật/Tắt chức năng đăng ký
        /// </summary>
        public const string AF_REGISTRY = "REGISTRY";
        public const string AF_REGISTRY_NAME = "Đăng ký thành viên";
        /// <summary>
        /// Bật/tắt chức năng login
        /// </summary>
        public const string AF_LOGIN = "LOGIN";
        public const string AF_LOGIN_NAME = "Đăng nhập thành viên";
        /// <summary>
        /// Bật/Tắt chức năng download
        /// </summary>
        public const string AF_DOWNLOAD = "DOWNLOAD";
        public const string AF_DOWNLOAD_NAME = "Download";
        /// <summary>
        /// Bật/Tắt chức năng Comment
        /// </summary>
        public const string AF_COMMENT = "COMMENT";
        public const string AF_COMMENT_NAME = "Comment";
        /// <summary>
        /// Bật/Tắt chức năng Comment không cần đăng nhập
        /// </summary>
        public const string AF_COMMENT_EASY = "COMMENT_EASY";
        public const string AF_COMMENT_EASY_NAME = "Comment không cần duyệt";
        /// <summary>
        /// Bật/Tắt chức năng đăng ký quảng cáo
        /// </summary>
        public const string AF_ADS = "ADS";
        public const string AF_ADS_NAME = " Đăng ký Quảng cáo";
        /// <summary>
        /// Bật/Tắt chức năng upload tại trang LTDH
        /// </summary>
        public const string AF_UPLOAD_UNI = "UPLOAD_UNI";
        public const string AF_UPLOAD_UNI_NAME = "Upload trang LTĐH";
        /// <summary>
        /// Bật/Tắt chức năng Download tại trang LTDH
        /// </summary>
        public const string AF_DOWNLOAD_UNI = "DOWNLOAD_UNI";
        public const string AF_DOWNLOAD_UNI_NAME = "Download trang LTĐH";
        /// <summary>
        /// Bật/Tắt chức năng Upload tiếng anh
        /// </summary>
        public const string AF_UPLOAD_EL = "UPLOAD_EL";
        public const string AF_UPLOAD_EL_NAME = "Upload trang Anh văn";
        /// <summary>
        /// Bật/Tắt chức năng Download Tiếng anh
        /// </summary>
        public const string AF_DOWNLOAD_EL = "DOWNLOAD_EL";
        public const string AF_DOWNLOAD_EL_NAME = "Download trang Anh văn";
        /// <summary>
        /// Bật/Tắt chức năng Upload IT
        /// </summary>
        public const string AF_UPLOAD_IT = "UPLOAD_IT";
        public const string AF_UPLOAD_IT_NAME = "Upload trang Tin học";
        /// <summary>
        /// Bật/Tắt chức năng Download IT
        /// </summary>
        public const string AF_DOWNLOAD_IT = "DOWNLOAD_IT";
        public const string AF_DOWNLOAD_IT_NAME = "Download trang Tin học";
        /// <summary>
        /// Bật/Tắt chức năng Xem tin tức
        /// </summary>
        public const string AF_NEWS_VIEW = "NEWS_VIEW";
        public const string AF_NEWS_VIEW_NAME = "Xem tin tức";
        /// <summary>
        /// Bật/Tắt chức năng Post tin tức
        /// </summary>
        public const string AF_NEWS_POST = "NEWS_POST";
        public const string AF_NEWS_POST_NAME = "Gửi tin tức";
        /// <summary>
        /// Bật/Tắt chức năng Search
        /// </summary>
        public const string AF_SEARCH = "SEARCH";
        public const string AF_SEARCH_NAME = "Tìm kiếm";
        /// <summary>
        /// Bật/Tắt chức năng Liên hệ
        /// </summary>
        public const string AF_CONTACT = "CONTACT";
        public const string AF_CONTACT_NAME = "Liên hệ";
        /// <summary>
        /// Bật/Tắt chế độ Underconstruction
        /// </summary>
        public const string AF_UNDERCONTRUCTION = "UNDERCONS";
        public const string AF_UNDERCONTRUCTION_NAME = "Bật/tắt website";
        /// <summary>
        /// Bật/Tắt chức năng gửi email
        /// </summary>
        public const string AF_EMAIL_SEND = "EMAIL_SEND";
        public const string AF_EMAIL_SEND_NAME = "Gửi email";

        /// <summary>
        /// Bật/tắt xem trước
        /// </summary>
        public const string AF_PREVIEW_ARTICLE = "PREVIEW_ARTICLE";
        public const string AF_PREVIEW_ARTICLE_NAME = "Xem trước";
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
        /// <summary>
        /// Số đăng ký quảng cáo mới
        /// </summary>
        public const string SF_NUM_NEW_ADV_CONTACT = "NUM_NEW_ADV_CONTACT";
        /// <summary>
        /// Số bài Anh văn đã được sticky
        /// </summary>
        public const string SF_NUM_STICKED_ON_EL = "NUM_STICKED_ON_EL";
        /// <summary>
        /// Số bài LTDH đã được sticky
        /// </summary>
        public const string SF_NUM_STICKED_ON_UNI = "NUM_STICKED_ON_UNI";
        /// <summary>
        /// Số bài IT đã được sticky
        /// </summary>
        public const string SF_NUM_STICKED_ON_IT = "NUM_STICKED_ON_IT";
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
        public const string CF_NUM_ARTICLE_ON_EL_NAME = "số bài hiển thị trong trang English";
        /// <summary>
        /// Tổng số bài hiển thị trong trang IT
        /// </summary>
        public const string CF_NUM_ARTICLE_ON_IT = "NUM_ARTICLE_ON_IT";
        public const string CF_NUM_ARTICLE_ON_IT_NAME = "số bài hiển thị trong trang Tin học";
        /// <summary>
        /// Tổng số bài hiển thị trong trang LTDH
        /// </summary>
        public const string CF_NUM_ARTICLE_ON_UNI = "NUM_ARTICLE_ON_UNI";
        public const string CF_NUM_ARTICLE_ON_UNI_NAME = "số bài hiển thị trong trang LTĐH";
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

        /// <summary>
        /// File type allow to upload
        /// </summary>
        public const string CF_FILE_TYPE_ALLOW = "FILE_TYPE_ALLOW";

        
        /// <summary>
        /// Filesize max of image
        /// </summary>
        public const string CF_IMG_FILE_SIZE_MAX = "IMG_FILE_SIZE_MAX";
        /// <summary>
        /// File type allowed of image
        /// </summary>
        public const string CF_IMG_FILE_TYPE_ALLOW = "IMG_FILE_TYPE_ALLOW";
        /// <summary>
        /// Key code of English page
        /// </summary>
        public const string CF_KEY_CODE_EL = "KEY_CODE_EL";
        /// <summary>
        /// keycode of IT page
        /// </summary>
        public const string CF_KEY_CODE_IT = "KEY_CODE_IT";
        /// <summary>
        /// keycode of Uni page
        /// </summary>
        public const string CF_KEY_CODE_UNI = "KEY_CODE_UNI";
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
        /// Ads page
        /// </summary>
        public const string PAGE_ADS = "Ads.aspx";
        /// <summary>
        /// Advertisement Contact page
        /// </summary>
        public const string PAGE_ADCONTACT = "AdContact.aspx";
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
        public const string PAGE_UPLOAD = "Upload.aspx";
        /// <summary>
        /// Admin login page
        /// </summary>
        public const string PAGE_ADMIN_LOGIN = "../Login.aspx";

        /// <summary>
        /// Admin general page
        /// </summary>
        //public const string PAGE_ADMIN_GENERAL = "./Admin/General.aspx";
        public const string PAGE_ADMIN_GENERAL = "General.aspx";

        /// <summary>
        /// Users page name
        /// </summary>
        public const string PAGE_ADMIN_USERS_NAME = "Quản lý thành viên";

        /// <summary>
        /// users admin page
        /// </summary>
        public const string PAGE_ADMIN_USERS = "Users.aspx";

        /// <summary>
        /// Name of admin news page
        /// </summary>
        public const string PAGE_ADMIN_NEWS_NAME = "Quản lý tin tức";

        /// <summary>
        /// Admin news page
        /// </summary>
        public const string PAGE_ADMIN_NEWS = "News.aspx";

        /// <summary>
        /// permission admin page name
        /// </summary>
        public const string PAGE_ADMIN_PERMISSION_NAME = "Quản lý phân quyền";

        /// <summary>
        /// permission admin page
        /// </summary>
        public const string PAGE_ADMIN_PERMISSION = "Permission.aspx";

        /// <summary>
        /// security admin page name
        /// </summary>
        public const string PAGE_ADMIN_SECURITY_NAME = "Bảo mật";

        /// <summary>
        /// security admin page
        /// </summary>
        public const string PAGE_ADMIN_SECURITY = "Security.aspx";

        /// <summary>
        /// control admin page name
        /// </summary>
        public const string PAGE_ADMIN_CONTROL_NAME = "Điều kiển";

        /// <summary>
        /// control admin page 
        /// </summary>
        public const string PAGE_ADMIN_CONTROL = "Control.aspx";

        /// <summary>
        /// Comment admin page name
        /// </summary>
        public const string PAGE_ADMIN_COMMENT_NAME = "Quản lý bình luận (comment)";

        /// <summary>
        /// Comment admin page
        /// </summary>
        public const string PAGE_ADMIN_COMMENT = "Comment.aspx";
        
        /// <summary>
        /// contest for university page name
        /// </summary>
        public const string PAGE_ADMIN_UNIVERSITY_NAME = "Quản lý chủ đề luyện thi đại học";

        /// <summary>
        /// contest for university page
        /// </summary>
        public const string PAGE_ADMIN_UNIVERSITY = "ContestUniversity.aspx";
        
        /// <summary>
        /// contest for english page name
        /// </summary>
        public const string PAGE_ADMIN_ENGLISH_NAME = "Quản lý chủ đề Tiếng Anh";

        /// <summary>
        /// contest for university page
        /// </summary>
        public const string PAGE_ADMIN_ENGLISH = "English.aspx";
        
        /// <summary>
        /// contest for english page name
        /// </summary>
        public const string PAGE_ADMIN_INFORMATICS_NAME = "Quản lý chủ đề Tin học";

        /// <summary>
        /// contest for university page
        /// </summary>
        public const string PAGE_ADMIN_INFORMATICS = "Informatics.aspx";

        /// <summary>
        /// Name of admin ads page
        /// </summary>
        public const string PAGE_ADMIN_ADS_NAME = "Quản lý quảng cáo";

        /// <summary>
        /// Admin ads page
        /// </summary>
        public const string PAGE_ADMIN_ADS = "Advertisement.aspx";

        /// <summary>
        /// Mailbox page name
        /// </summary>
        public const string PAGE_ADMIN_MAIL_NAME = "Hộp thư";

        /// <summary>
        /// Mailbox page
        /// </summary>
        public const string PAGE_ADMIN_MAIL = "Mailbox.aspx";

        /// <summary>
        /// contact admin page name
        /// </summary>
        public const string PAGE_ADMIN_CONTACT_NAME = "Liên hệ/Góp ý";

        /// <summary>
        /// contact admin page
        /// </summary>
        public const string PAGE_ADMIN_CONTACT = "Contact.aspx";

        /// <summary>
        /// log admin page name
        /// </summary>
        public const string PAGE_ADMIN_LOG_NAME = "Nhật ký hệ thống";

        /// <summary>
        /// log admin page
        /// </summary>
        public const string PAGE_ADMIN_LOG = "Log.aspx";

        /// <summary>
        /// import admin page name
        /// </summary>
        public const string PAGE_ADMIN_IMPORT_NAME = "Nhập liệu";

        /// <summary>
        /// import admin page
        /// </summary>
        public const string PAGE_ADMIN_IMPORT = "Import.aspx";



        

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


        /// <summary>
        /// session for permission search
        /// </summary>
        public const string SES_PERMISSION_SEARCH = "permission_Search";

        /// <summary>
        /// session for permission step edit
        /// </summary>
        public const string SES_PERMISSION_EDIT = "permission_Edit";

        /// <summary>
        /// Session for edit contest
        /// </summary>
        public const string SES_EDIT_CONTEST = "editContest";
        /// <summary>
        /// session for security admin vo / security admin vo list
        /// </summary>
        public const string SES_SECURITY_ADMIN_VO = "saVO";

        public const string SES_FIRST_LOAD = "first_load";
        /// <summary>
        /// save id
        /// </summary>
        public const string SES_ID = "ID";
        /// <summary>
        /// message inform
        /// </summary>
        public const string SES_INFORM = "INFORM";
        /// <summary>
        /// url of old page
        /// </summary>
        public const string SES_OLD_PAGE = "OLD_PAGE";

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
        /// key on searching request
        /// </summary>
        public const string REQ_KEY = "key";
        /// <summary>
        /// subject on request
        /// </summary>
        public const string REQ_SUBJECT = "sub";
        /// <summary>
        /// subject on request
        /// </summary>
        public const string REQ_STATE = "state";
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

        /// <summary>
        /// request redirect 
        /// </summary>
        public const string REQ_REDIRECT = "red";

        
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
            /// THPT
            /// </summary>
            public const string PARAM_EL_COMMON_NAME = "THPT";
            /// <summary>
            /// Chuyên ngành
            /// </summary>
            public const string PARAM_EL_MAJOR = "maj";
            /// <summary>
            /// CN
            /// </summary>
            public const string PARAM_EL_MAJOR_NAME = "Chuyên Ngành";
            /// <summary>
            /// Chứng chỉ
            /// </summary>
            public const string PARAM_EL_CERT = "cert";
            /// <summary>
            /// cert name
            /// </summary>
            public const string PARAM_EL_CERT_NAME = "Chứng chỉ";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_1_TO_9 = "1-9";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_1_TO_9_NAME = "Lớp 1";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_1 = "1";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_1_NAME = "Lớp 1";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_2 = "2";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_2_NAME = "Lớp 2";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_3 = "3";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_3_NAME = "Lớp 3";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_4 = "4";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_4_NAME = "Lớp 4";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_5 = "5";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_5_NAME = "Lớp 5";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_6 = "6";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_6_NAME = "Lớp 6";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_7 = "7";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_7_NAME = "Lớp 7";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_8 = "8";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_8_NAME = "Lớp 8";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_9 = "9";
            /// <summary>
            /// Class 1
            /// </summary>
            public const string PARAM_EL_CLASS_9_NAME = "Lớp 9";
            /// <summary>
            /// Class 1 to 9
            /// </summary>
            public const string PARAM_EL_CLASS_10 = "10";
            /// <summary>
            /// Class 1 to 9
            /// </summary>
            public const string PARAM_EL_CLASS_10_NAME = "Lớp 10";
            /// <summary>
            /// Class 1 to 9
            /// </summary>
            public const string PARAM_EL_CLASS_11 = "11";
            /// <summary>
            /// Class 1 to 9
            /// </summary>
            public const string PARAM_EL_CLASS_11_NAME = "Lớp 11";
            /// <summary>
            /// Class 1 to 9
            /// </summary>
            public const string PARAM_EL_CLASS_12 = "12";
            /// <summary>
            /// Class 1 to 9
            /// </summary>
            public const string PARAM_EL_CLASS_12_NAME = "Lớp 12";

            public const string PARAM_EL_MATH_ECO = "math-eco";

            public const string PARAM_EL_CHEM_BIO_MAT = "chem-bio-mat";

            public const string PARAM_EL_PHY_TELE_IT = "phy-tele-it";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_MATH = "math";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_MATH_NAME = "Toán";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_ECO = "eco";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_ECO_NAME = "Kinh tế";
            /// <summary>
            /// Chemical - Biography - Material
            /// </summary>
            public const string PARAM_EL_CHEM = "chem";
            /// <summary>
            /// Chemical - Biography - Material
            /// </summary>
            public const string PARAM_EL_CHEM_NAME = "Hóa";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_BIO = "bio";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_BIO_NAME = "Sinh học";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_MAT = "mat";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_MAT_NAME = "Khoa học vật liệu";
            /// <summary>
            /// Physical - Telecom - IT
            /// </summary>
            public const string PARAM_EL_PHY = "phy";
            /// <summary>
            /// Physical - Telecom - IT
            /// </summary>
            public const string PARAM_EL_PHY_NAME = "Vật lý";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_TELE = "tele";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_TELE_NAME = "Viễn thông";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_IT = "it";
            /// <summary>
            /// Mathematics and Economic
            /// </summary>
            public const string PARAM_EL_IT_NAME = "Công nghệ thông tin";
            /// <summary>
            /// other major
            /// </summary>
            public const string PARAM_EL_OTHER_MJ = "other-mj";
            /// <summary>
            /// other major
            /// </summary>
            public const string PARAM_EL_OTHER_MJ_NAME = "Khác";
            /// <summary>
            /// TOEFL
            /// </summary>
            public const string PARAM_EL_TOEFL = "toefl";
            /// <summary>
            /// TOEFL
            /// </summary>
            public const string PARAM_EL_TOEFL_NAME = "TOEFL";
            /// <summary>
            /// TOEIC
            /// </summary>
            public const string PARAM_EL_TOEIC = "toeic";
            /// <summary>
            /// TOEIC
            /// </summary>
            public const string PARAM_EL_TOEIC_NAME = "TOEIC";
            /// <summary>
            /// IELTS
            /// </summary>
            public const string PARAM_EL_IELTS = "ielts";
            /// <summary>
            /// IELTS
            /// </summary>
            public const string PARAM_EL_IELTS_NAME = "IELTS";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_ABC = "abc";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_ABC_NAME = "A-B-C";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_A = "a";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_A_NAME = "Chứng chỉ A";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_B = "b";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_B_NAME = "Chứng chỉ B";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_C = "c";
            /// <summary>
            /// A-B-C
            /// </summary>
            public const string PARAM_EL_C_NAME = "Chứng chỉ C";
            
        
            /// <summary>
            /// THVP
            /// </summary>
            public const string PARAM_IT_OFFICE = "off";

            /// <summary>
            /// THVP
            /// </summary>
            public const string PARAM_IT_OFFICE_NAME = "Văn phòng";

            /// <summary>
            /// THVP
            /// </summary>
            public const string PARAM_IT_TIP = "tip";

            /// <summary>
            /// THVP
            /// </summary>
            public const string PARAM_IT_TIP_NAME = "Thủ thuật";
            
            /// <summary>
            /// Thủ thuật căn bản
            /// </summary>
            public const string PARAM_IT_TIP_SIMPLE = "simp";

            /// <summary>
            /// Thủ thuật căn bản
            /// </summary>
            public const string PARAM_IT_TIP_SIMPLE_NAME = "Cơ bản";
            /// <summary>
            /// Thủ thuật nâng cao
            /// </summary>
            public const string PARAM_IT_TIP_ADVANCE = "adv";
            /// <summary>
            /// Thủ thuật nâng cao
            /// </summary>
            public const string PARAM_IT_TIP_ADVANCE_NAME = "Nâng cao";
            
            /// <summary>
            /// office word
            /// </summary>
            public const string PARAM_IT_OFFICE_WORD = "word";
            /// <summary>
            /// office word
            /// </summary>
            public const string PARAM_IT_OFFICE_WORD_NAME = "Word";
            /// <summary>
            /// office excel
            /// </summary>
            public const string PARAM_IT_OFFICE_EXCEL = "excel";
            /// <summary>
            /// office excel
            /// </summary>
            public const string PARAM_IT_OFFICE_EXCEL_NAME = "Excel";
            /// <summary>
            /// office powerpoint
            /// </summary>
            public const string PARAM_IT_OFFICE_PP = "pp";
            /// <summary>
            /// office powerpoint
            /// </summary>
            public const string PARAM_IT_OFFICE_PP_NAME = "PowerPoint";
            /// <summary>
            /// power point access
            /// </summary>
            public const string PARAM_IT_OFFICE_ACCESS = "acc";
            /// <summary>
            /// power point access
            /// </summary>
            public const string PARAM_IT_OFFICE_ACCESS_NAME = "Access";
            /// <summary>
            /// param is location
            /// </summary>
            public const string PARAM_LOCATION = "loc";
            public const string PARAM_NEW = "new";
            public const string PARAM_RESET = "reset";
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
        public const string TEMP_UNI_LINK = "<a href=\"" + TEMP_UNI_URL + "&" + REQ_PAGE + "={2}\">{3}</a>";
        /// <summary>
        /// University url template
        /// </summary>
        public const string TEMP_UNI_URL = PAGE_UNIVERSITY + "?" + REQ_SUBJECT + "={0}&" + REQ_TIME + "={1}";
        /// <summary>
        /// link template for article details
        /// </summary>
        public const string TEMP_ARTICLE_DETAILS_LINK = "<a href='" + PAGE_ARTICLE_DETAILS + "?" + REQ_SECTION + "={0}&" + REQ_ID + "={1}'>{2}</a>";
        /// <summary>
        /// link template for english page
        /// </summary>
        public const string TEMP_ENGLISH_LINK = "<a href='" + TEMP_ENGLISH_URL + "&" + REQ_PAGE + "={2}'>{3}</a>";
        /// <summary>
        /// url template of english page
        /// </summary>
        public const string TEMP_ENGLISH_URL = PAGE_ENGLISH + "?" + REQ_CLASS + "={0}&" + REQ_TIME + "={1}";
        /// <summary>
        /// link template for informatics page
        /// </summary>
        public const string TEMP_INFORMATICS_LINK = "<a href='" + TEMP_INFORMATICS_URL + "&" + REQ_PAGE + "={2}'>{3}</a>";
        /// <summary>
        /// url template of informatics page
        /// </summary>
        public const string TEMP_INFORMATICS_URL = PAGE_INFORMATICS + "?" + REQ_LEITMOTIF + "={0}&" + REQ_TIME + "={1}";
        /// <summary>
        /// link template for news page
        /// </summary>
        public const string TEMP_NEWS_LINK = "<a href='" + PAGE_NEWS + "?id={0}'>{1}</a>";
        /// <summary>
        /// link template for ads page
        /// </summary>
        public const string TEMP_ADS_URL = PAGE_ADS + "?" + REQ_ACTION + "=" + ACT_CLICK + "&" + REQ_ID + "={0}&" + REQ_REDIRECT + "={1}";
        /// <summary>
        /// url template for admin contest
        /// </summary>
        public const string TEMP_ADMIN_CONTEST_URL = "~/_lh/Admin/" + PAGE_ADMIN_UNIVERSITY +"?" + REQ_ACTION + "={0}&" + REQ_KEY +"={1}&"+ REQ_STATE +"={2}&" + REQ_PAGE +"={3}";
        /// <summary>
        /// url template for admin it
        /// </summary>
        public const string TEMP_ADMIN_IT_URL = "~/_lh/Admin/" + PAGE_ADMIN_INFORMATICS + "?" + REQ_ACTION + "={0}&" + REQ_KEY + "={1}&" + REQ_STATE + "={2}&" + REQ_PAGE + "={3}";
        /// <summary>
        /// url template for admin english
        /// </summary>
        public const string TEMP_ADMIN_EL_URL = "~/_lh/Admin/" + PAGE_ADMIN_ENGLISH + "?" + REQ_ACTION + "={0}&" + REQ_KEY + "={1}&" + REQ_STATE + "={2}&" + REQ_PAGE + "={3}";
        /// <summary>
        /// image thumbnail for article
        /// </summary>
        public const string TEMP_IMG_THUMBNAIL = "<img width='50px' height='50px' src='{0}' alt='{1}'/>";
        /// <summary>
        /// thumbnail image for article details
        /// </summary>
        public const string TEMP_IMG_ARTICLE_DETAIL_THUMBNAIL = "<img src=\"{0}\" alt='' width='130px' height='120px' style='margin-top:10px;' />";
        /// <summary>
        /// image rating
        /// </summary>
        public const string TEMP_IMG_RATING = "<img src='{0}' alt='' width='15px' height='15px'/>";
        /// <summary>
        /// image for new links
        /// </summary>
        public const string TEMP_IMG_NEW_LINK = "<img src='{0}' alt=''/>";
        /// <summary>
        /// Self Link template
        /// </summary>
        public const string TEMP_SELF_LINK = "<a href=\"{0}?page={1}\">{2}</a>";
        /// <summary>
        /// paging link
        /// </summary>
        public const string TEMP_PAGING_LINK = "<a href=\"{0}?{1}\">{2}</a>";
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
        /// Templte i tag
        /// </summary>
        public const string TEMP_I_TAG = "<i>{0}</i>";

        /// <summary>
        /// Templte b tag
        /// </summary>
        public const string TEMP_B_TAG = "<b>{0}</b>";
        public const string TEMP_BAR = "-{0}-";
        /// <summary>
        /// Template strong tag, 1 param
        /// </summary>
        public const string TEMP_STRONG_TAG = "<strong>{0}</strong>";
        /// <summary>
        /// Template br tag, no param
        /// </summary>
        public const string TEMP_BR_TAG = "<br />";
        /// <summary>
        /// Template spane tag
        /// </summary>
        public const string TEMP_SPAN_TAG = "<span>{0}</span>";
        /// <summary>
        /// Template font tag
        /// </summary>
        public const string TEMP_FONT_TAG = "<span style=\"color:{0};\">{1}</span>";
        /// <summary>
        /// Template for span tag
        /// </summary>
        public const string TEMP_SPAN_TAG_WITH_COLOR = "<span style=\"color:{0};\" title=\"{1}\">{2}</span>";
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
        /// <summary>
        /// div template for article details
        /// </summary>
        public const string TEMP_DIV_TAG_ARTICLE_DETAIL = "<div id='{0}' onmouseover='hover({0})' class='temp'>{1}</div>";
        /// <summary>
        /// tag center, 1 argument required
        /// </summary>
        public const string TEMP_CENTER_TAG = "<center>{0}</center>";
        /// <summary>
        /// tag ul with class, 2 arg required
        /// </summary>
        public const string TEMP_UL_TAG_WITH_CLASS = "<ul class='{0}'>{1}</ul>";
        /// <summary>
        /// hr tag <![CDATA[]]>
        /// </summary>
        public const string TEMP_HR_TAG = "<hr />";
        /// <summary>
        /// CDATA[]
        /// </summary>
        public const string TEMP_CDATA = "<![CDATA[{0}]]>";
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
        /// Action for search
        /// </summary>
        public const string ACT_SEARCH = "search";
        /// <summary>
        /// search with any keyword
        /// </summary>
        public const string ACT_SEARCH_FREE = "search_free";

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

        /// <summary>
        /// action clone
        /// </summary>
        public const string ACT_CLONE = "Clone";
        #endregion

        #region Advertisement (ADS)
        /// <summary>
        /// Ads is inactived
        /// </summary>
        public const string ADS_INACTIVE = "inactive";
        /// <summary>
        /// Banner Top
        /// </summary>
        public const string ADS_TOP_BANNER = "top";
        /// <summary>
        /// Banner Top name
        /// </summary>
        public const string ADS_TOP_BANNER_NAME = "Top";
        /// <summary>
        /// Banner Top Leader
        /// </summary>
        public const string ADS_TOP_LEADER_BANNER = "topleader";
        /// <summary>
        /// Banner Top Leader Name
        /// </summary>
        public const string ADS_TOP_LEADER_BANNER_NAME = "Top Leader";
        /// <summary>
        /// Banner Top Right
        /// </summary>
        public const string ADS_TOP_RIGHT_BANNER = "topright";
        /// <summary>
        /// Banner Top Right Name
        /// </summary>
        public const string ADS_TOP_RIGHT_BANNER_NAME = "Top Right";
        /// <summary>
        /// Banner Middle right
        /// </summary>
        public const string ADS_MIDDLE_RIGHT_BANNER = "middleright";
        /// <summary>
        /// Banner Middle right Name
        /// </summary>
        public const string ADS_MIDDLE_RIGHT_BANNER_NAME = "Middle Right";
        /// <summary>
        /// Banner middle right
        /// </summary>
        public const string ADS_BOTTOM_RIGHT_BANNER = "bottomright";
        /// <summary>
        /// Banner middle right Name
        /// </summary>
        public const string ADS_BOTTOM_RIGHT_BANNER_NAME = "Bottom Right";
        /// <summary>
        /// Banner Top left
        /// </summary>
        public const string ADS_TOP_LEFT_BANNER = "topleft";
        /// <summary>
        /// Banner Top left Name
        /// </summary>
        public const string ADS_TOP_LEFT_BANNER_NAME = "Top Left";
        /// <summary>
        /// Banner middle left
        /// </summary>
        public const string ADS_MIDDLE_LEFT_BANNER = "middleleft";
        /// <summary>
        /// Banner middle left Name
        /// </summary>
        public const string ADS_MIDDLE_LEFT_BANNER_NAME = "Middle Left";
        /// <summary>
        /// Banner bottom left
        /// </summary>
        public const string ADS_BOTTOM_LEFT_BANNER = "bottomleft";
        /// <summary>
        /// Banner bottom left Name
        /// </summary>
        public const string ADS_BOTTOM_LEFT_BANNER_NAME = "Bottom Left";
        /// <summary>
        /// Banner bottom 1
        /// </summary>
        public const string ADS_BOTTOM_1_BANNER = "bot1";
        /// <summary>
        /// Banner bottom 1 name
        /// </summary>
        public const string ADS_BOTTOM_1_BANNER_NAME = "Bottom 1";
        /// <summary>
        /// Banner bottom 2
        /// </summary>
        public const string ADS_BOTTOM_2_BANNER = "bot2";
        /// <summary>
        /// Banner bottom 2 name
        /// </summary>
        public const string ADS_BOTTOM_2_BANNER_NAME = "Bottom 2";
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

