using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ltktDAO
{
    public class English
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;

        #region Property
        #region Get Property
        /// <summary>
        /// Lấy tiêu đề
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getTitle(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblEnglishes
                      where record.ID == ID
                      select record;

            return lst.ElementAt(0).Title;
        }

        /// <summary>
        /// Lấy ra loại bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getType(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblEnglishes
                      where record.ID == ID
                      select record;

            int type = lst.ElementAt(0).Type;
            string strType = "";
            switch (type)
            {
                case 0:
                    {
                        strType = "Bài giảng";
                        break;
                    }
                case 1:
                    {
                        strType = "Đề thi";
                        break;
                    }
                case 2:
                    {
                        strType = "Bài tập";
                        break;
                    }
                default:
                    break;
            }

            return strType;
        }

        /// <summary>
        /// Lấy nội dung
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getContent(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblEnglishes
                      where record.ID == ID
                      select record;

            return lst.ElementAt(0).Contents;
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
                      join record in DB.tblEnglishes on author.Username equals record.Author
                      where record.ID == ID
                      select author;

            return lst.ElementAt(0).DisplayName;
        }

        /// <summary>
        /// Lấy ngày đăng
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static DateTime getPosted(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblEnglishes
                      where record.ID == ID
                      select record;

            return lst.ElementAt(0).Posted;
        }

        /// <summary>
        /// Lấy trạng thái bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getState(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblEnglishes
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
        /// Lấy điểm bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static int getPoint(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblEnglishes
                      where record.ID == ID
                      select record;

            return (int)lst.ElementAt(0).Point;
        }

        /// <summary>
        /// Lấy tag
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getTag(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblEnglishes
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
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
                record.Title = _title;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét loại bài viết
        /// 0 - Bài giảng
        /// 1 - Đề thi
        /// 2 - Bài tập
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static Boolean setType(int ID, int _type)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
                record.Type = _type;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét tác giả bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_author"></param>
        /// <returns></returns>
        public static Boolean setAuthor(int ID, string _author)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
                record.Author = _author;
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
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
                record.Contents = _content;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét trạng thái bài viết
        /// 0 - uncheck
        /// 1 - checked
        /// 2 - bad
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_state"></param>
        /// <returns></returns>
        public static Boolean setState(int ID, int _state)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
                record.State = _state;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét ngày đăng tin
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_posted"></param>
        /// <returns></returns>
        public static Boolean setPosted(int ID, DateTime _posted)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
                record.Posted = _posted;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét điểm bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_point"></param>
        /// <returns></returns>
        public static Boolean setPoint(int ID, int _point)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
                record.Point = _point;
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
                var record = DB.tblEnglishes.Single(TB => TB.ID == ID);
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
        /// Thêm một bài viết mới
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static Boolean insertEnglish(tblEnglish record)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DB.tblEnglishes.InsertOnSubmit(record);

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
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public static Boolean updateEnglish(int _id, tblEnglish update)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var english = DB.tblEnglishes.Single(e => e.ID == _id);

                    english.Title = update.Title;
                    english.Type = update.Type;
                    english.Contents = update.Contents;
                    english.Author = update.Author;
                    english.Posted = update.Posted;
                    english.State = update.State;
                    english.Point = update.Point;
                    english.Tag = update.Tag;

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
        /// Tổng các bài viết về chủ đề Anh văn (bài giảng, đề thi, bài tập).
        /// </summary>
        /// <returns></returns>
        public static int sumEnglish()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            return (from english in DB.tblEnglishes
                    select english).Count();

        }


        #endregion
    }
}
