using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class Admin
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;

        /// <summary>
        /// Tống tất cả các bài viết (ltđh, anh văn, tin học)
        /// </summary>
        /// <returns></returns>
        public static int sumArticle()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            int sumContest = (from contest in DB.tblContestForUniversities
                              select contest).Count();
            int sumEnglish = (from english in DB.tblEnglishes
                              select english).Count();
            int sumInformatics = (from informatics in DB.tblInformatics
                                  select informatics).Count();

            return (sumContest + sumEnglish + sumInformatics);
        }

        /// <summary>
        /// Năm (5) thành viên login gần nhất
        /// </summary>
        /// <returns></returns>
        public static string latestLogin()
        {
            return "test";
        }
    }

    
}
