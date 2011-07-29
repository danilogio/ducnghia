using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DucNghia.DAO
{
    class ContestForUniversityDAO
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        
        #region Property
        #region Get Property
        /// <summary>
        /// Lấy tiêu đề bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getTitle(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                      where record.ID == ID
                                      select record;
                                      
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Title;
            }
            return "Not Exists";
        }

        /// <summary>
        /// Lấy nội dung bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getContent(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Contents;
            }
            return "Not Exists";
        }

        /// <summary>
        /// Lời giải của đề thi
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getSolving(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            return lst.ElementAt(0).Solving;
        }

        /// <summary>
        /// Lấy tên tác giả
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getAuthor(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from author in DB.tblUsers
                      join record in DB.tblContestForUniversities on author.Username equals record.Author
                      where record.ID == ID
                      select author;

            return lst.ElementAt(0).DisplayName;
        }

        /// <summary>
        /// Lấy ngày đăng tin
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static DateTime getPosted(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            return lst.ElementAt(0).Posted;
        }

        /// <summary>
        /// Lấy trạng thái của bài viêt
        /// 0 - uncheck
        /// 1 - checked
        /// 2 - bad
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getState(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            int state = lst.ElementAt(0).State;
            string strState = "";
            switch (state)
            {
                case 0:
                    {
                        strState = "Uncheck";
                        break;
                    }
                case 1:
                    {
                        strState = "Checked";
                        break;
                    }
                case 2:
                    {
                        strState = "Bad";
                        break;
                    }
                default:
                    break;
            }

            return strState;
        }

        /// <summary>
        /// Lấy ra loại đề thi, cao đẳng hay đại học?
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getContestType(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            if (lst.ElementAt(0).isUniversity == false)
            {
                return "Đại học";
            }

            return "Cao đẳng";
        }

        /// <summary>
        /// Đề thi này của khối nào?
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getBranch(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            int branch = lst.ElementAt(0).Branch;
            string strBranch = "";
            switch (branch)
            {
                case 0:
                    {
                        strBranch = "Khối A";
                        break;
                    }
                case 1:
                    {
                        strBranch = "Khối B";
                        break;
                    }
                case 2:
                    {
                        strBranch = "Khối C";
                        break;
                    }
                case 3:
                    {
                        strBranch = "Khối D";
                        break;
                    }
                case 4:
                    {
                        strBranch = "Các khối khác";
                        break;
                    }
                default :
                    break;
            }

            return strBranch;
        }

        /// <summary>
        /// Đề thi năm nào?
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static int getYear(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            return lst.ElementAt(0).Year;
        }
        /// <summary>
        /// Lấy điểm bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static int getPoint(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            return (int)lst.ElementAt(0).Point;
        }

        /// <summary>
        /// Lấy tag của bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getTag(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblContestForUniversities
                      where record.ID == ID
                      select record;

            return lst.ElementAt(0).Tag;
        }


        #endregion

        #region Set Property
        /// <summary>
        /// Xét tiêu đề
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_title"></param>
        /// <returns></returns>
        public static Boolean setTitle(int ID, string _title)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Title = _title;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét nội dung
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_content"></param>
        /// <returns></returns>
        public static Boolean setContent(int ID, string _content)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Contents = _content;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét tác giả
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_author"></param>
        /// <returns></returns>
        public static Boolean setAuthor(int ID, string _author)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Author = _author;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét ngày đăng
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_posted"></param>
        /// <returns></returns>
        public static Boolean setPosted(int ID, DateTime _posted)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Posted = _posted;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét trạng thái
        /// 0: uncheck
        /// 1: checked
        /// 2: bad
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_state"></param>
        /// <returns></returns>
        public static Boolean setState(int ID, int _state)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.State = _state;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét loại đê thi
        /// false - đại học
        /// true - cao đẳng
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_isUniversity"></param>
        /// <returns></returns>
        public static Boolean setContestType(int ID, bool _isUniversity)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.isUniversity = _isUniversity;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét khối thi của đề
        /// 0 - khối A
        /// 1 - Khối B
        /// 2 - Khối C
        /// 3 - Khối D
        /// 4 - Các khối khác
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_branch"></param>
        /// <returns></returns>
        public static Boolean setBranch(int ID, int _branch)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Branch = _branch;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét năm thi của đề
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_year"></param>
        /// <returns></returns>
        public static Boolean setYear (int ID, int _year)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Year = _year;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét lời giải cho đề thi
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_solving"></param>
        /// <returns></returns>
        public static Boolean setSolving (int ID, string _solving)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Solving = _solving;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét diểm bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_point"></param>
        /// <returns></returns>
        public static Boolean setPoint(int ID, int _point)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Point = _point ;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét tag
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_tag"></param>
        /// <returns></returns>
        public static Boolean setTag(int ID, string _tag)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                record.Tag = _tag;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }


        #endregion
        #endregion

        #region Method
        /// <summary>
        /// Thêm một đề thi
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static Boolean insertContest(tblContestForUniversity record)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DB.tblContestForUniversities.InsertOnSubmit(record);

                    DB.SubmitChanges();

                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật đề thi
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public static Boolean updateContest(int _id, tblContestForUniversity update)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var contest = DB.tblContestForUniversities.Single(cont => cont.ID == _id);
                    contest.Title = update.Title;
                    contest.Contents = update.Contents;
                    contest.Author = update.Author;
                    contest.Posted = update.Posted;
                    contest.State = update.State;
                    contest.isUniversity = update.isUniversity;
                    contest.Branch = update.Branch;
                    contest.Year = update.Year;
                    contest.Solving = update.Solving;
                    contest.Point = update.Point;
                    contest.Tag = update.Tag;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
