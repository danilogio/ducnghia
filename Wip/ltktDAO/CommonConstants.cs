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
        /// do not find out article record on DB
        /// </summary>
        public const string ARTICLE_EMPTY_RECORD = "Hiện tại chưa có bài viết nào";
    }
}
