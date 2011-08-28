using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public static class CommonConstants
    {
        /// <summary>
        /// Article has type lecture
        /// </summary>
        public const int ARTICLE_TYPE_LECTURE = 0;
        /// <summary>
        /// Article has type a practise
        /// </summary>
        public const int ARTICLE_TYPE_PRACTISE = 1;
        /// <summary>
        /// Article has type Examination
        /// </summary>
        public const int ARTICLE_TYPE_EXAM = 2;
        /// <summary>
        /// Number record on one tab
        /// </summary>
        public const int NUMBER_RECORD_ON_TAB = 8;
        
        /// <summary>
        /// Number record of relative a article
        /// </summary>
        public const int NUMBER_RECORD_RELATIVE = 5;

        /// <summary>
        /// Blank value
        /// </summary>
        public const string BLANK = "";
        
        /// <summary>
        /// do not find out article record on DB
        /// </summary>
        public const string ARTICLE_EMPTY_RECORD = "Hiện tại chưa có bài viết nào";
        /// <summary>
        /// path of event log
        /// </summary>
        public const string LOG_FILE_PATH = "Log\\EventLog";
        /// <summary>
        /// number of character string
        /// </summary>
        public const int NUMBER_OF_CHARACTER_ON_STRING = 15;
        /// <summary>
        /// error text
        /// </summary>
        public const string COMMON_ERROR_TEXT = "Đã có lỗi xảy ra, xin vui lòng thử lại sau.";
        /// <summary>
        /// constant of session error text
        /// </summary>
        public const string CONST_SES_ERROR = "Error";
        /// <summary>
        /// error Page
        /// </summary>
        public const string PAGE_ERROR = "Error.aspx";
        /// <summary>
        /// Login page
        /// </summary>
        public const string PAGE_LOGIN = "Login.aspx";
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
        /// User on session
        /// </summary>
        public const string SES_USER = "User";
        /// <summary>
        /// Upload successful
        /// </summary>
        public const string UPLOAD_SUCCESSFUL = "Upload thành công";
        /// <summary>
        /// Article SCO on session
        /// </summary>
        public const string SES_ARTICLE_SCO = "ArticleSCO";
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
        /// library on session
        /// </summary>
        public const string REQ_LIBRARY = "lib";
        /// <summary>
        /// now
        /// </summary>
        public const string NOW = "now";
        /// <summary>
        /// comma character(,)
        /// </summary>
        public const string COMMA = ",";
        /// <summary>
        /// one space character(" ")
        /// </summary>
        public const string SPACE = " ";
        /// <summary>
        /// bar character
        /// </summary>
        public const string BAR = "-";
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

        public const string UNI_LINK_TEMPLATE = "<a href=\"ContestUniversity.aspx?sub={0}&time={1}\">{2}</a>";

        public const string UNI_LABEL_TEMPLATE = "<label>{0}</label>";

        public const string REQ_ACTION = "action";

        public const string ACT_CLICK = "click";

        public const string ADS_TOP_BANNER = "top";

        public const string ADS_TOP_LEADER_BANNER = "topleader";

        public const string ADS_TOP_RIGHT_BANNER = "topright";

        public const string ADS_MIDDLE_RIGHT_BANNER = "middleright";

        public const string ADS_BOTTOM_RIGHT_BANNER = "bottomright";

        public const string ADS_TOP_LEFT_BANNER = "topleft";

        public const string ADS_MIDDLE_LEFT_BANNER = "middleleft";

        public const string ADS_BOTTOM_LEFT_BANNER = "bottomleft";

        public const string ADS_BOTTOM_1_BANNER = "bot1";

        public const string ADS_BOTTOM_2_BANNER = "bot2";
    }
}
