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
        /// Upload successful
        /// </summary>
        public const string UPLOAD_SUCCESSFUL = "Upload thành công";
    }
}
