using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ltktDAO
{
    public class Informatics
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;

        #region Property
        #region Get Property
        /// <summary>
        /// lấy tiêu đề
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getTitle(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Title;
            }

            return null;
        }


        /// <summary>
        /// Lấy chapeau
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getChapeau(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Chapeau;
            }

            return null;
        }

        /// <summary>
        /// lấy loại bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getType(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
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
        /// Lấy nội dung bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getContent(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Contents;
            }

            return null;
        }

        /// <summary>
        /// lấy tên tác giả
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getAuthor(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblUser> lst = from author in DB.tblUsers
                                       join record in DB.tblInformatics on author.Username equals record.Author
                                       where record.ID == ID
                                       select author;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).DisplayName;
            }

            return null;
        }


        /// <summary>
        /// Lấy ngày đăng
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static DateTime getPosted(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Posted;
            }

            return new DateTime(1970, 1, 1);
        }

        /// <summary>
        /// Lấy trang thái bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getState(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
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
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return (int)lst.ElementAt(0).Point;
            }

            return -1;
        }

        /// <summary>
        /// lấy tag
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getTag(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Tag;
            }

            return null;
        }

        /// <summary>
        /// Lay comment
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static string getComment(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == _id
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Comment;
            }

            return null;
        }

        /// <summary>
        /// Lấy bài viết theo id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static tblInformatic getInformatic(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == _id
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }

            return null;
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
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.Title = _title;
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
        /// Xét chapeau
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_chapeau"></param>
        /// <returns></returns>
        public static Boolean setChapeau(int ID, string _chapeau)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.Chapeau = _chapeau;
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
        /// Xét loại
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
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.Type = _type;
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
        /// Xét tác giả
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_author"></param>
        /// <returns></returns>
        public static Boolean setAuthor(int ID, string _author)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.Author = _author;
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
                var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                record.Contents = _content;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét trạng thái
        /// 0 - unchecked
        /// 1 - checked
        /// 2 - bad
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_state"></param>
        /// <returns></returns>
        public static Boolean setState(int ID, int _state)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.State = _state;
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
        /// Ngày đăng tin
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_posted"></param>
        /// <returns></returns>
        public static Boolean setPosted(int ID, DateTime _posted)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.Posted = _posted;
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
        /// Xét điểm bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_point"></param>
        /// <returns></returns>
        public static Boolean setPoint(int ID, int _point)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.Point = _point;
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
        /// Xét tag
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_tag"></param>
        /// <returns></returns>
        public static Boolean setTag(int ID, string _tag)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == ID);
                    record.Tag = _tag;
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

        public static Boolean setComment(int _id, string _comment)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblInformatics.Single(TB => TB.ID == _id);
                    record.Tag = _comment;
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
        #endregion

        #region Method
        /// <summary>
        /// Thêm bài mới
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static Boolean insertInformatic(tblInformatic record)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DB.tblInformatics.InsertOnSubmit(record);

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
        /// Thêm một bài giảng/bài tập/đề thi tin học
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_type"></param>
        /// <param name="_content"></param>
        /// <param name="_author"></param>
        /// <param name="_posted"></param>
        /// <param name="_location"></param>
        /// <returns></returns>
        public static Boolean insertInformatic(string _title, int _type, string _content,
            string _author, DateTime _posted, string _location, string _tag)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblInformatic record = new tblInformatic();
                    record.Title = _title;
                    record.Type = _type;
                    record.Contents = _content;
                    record.Author = _author;
                    record.Posted = _posted;
                    record.Point = 0;
                    record.State = 0;
                    record.Location = _location;
                    record.Tag = _tag;

                    DB.tblInformatics.InsertOnSubmit(record);
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
        /// <param name="update"></param>
        /// <returns></returns>
        public static Boolean updateInformatic(int _id, tblInformatic update)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var informatic = DB.tblInformatics.Single(info => info.ID == _id);
                    informatic.Title = update.Title;
                    informatic.Type = update.Type;
                    informatic.Chapeau = update.Chapeau;
                    informatic.Contents = update.Contents;
                    informatic.Author = update.Author;
                    informatic.Posted = update.Posted;
                    informatic.State = update.State;
                    informatic.Point = update.Point;
                    informatic.Tag = update.Tag;

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
        /// Tổng số các bài viết về chủ đề tin học
        /// </summary>
        /// <returns></returns>
        public static int sumInformatics()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            return (from informatics in DB.tblInformatics
                    select informatics).Count();
        }

        /// <summary>
        /// Them 1 comment vao bai viet
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_newComment"></param>
        /// <returns></returns>
        public static Boolean insertComment(int _id, string _newComment)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var informatic = DB.tblInformatics.Single(info => info.ID == _id);
                    informatic.Comment += _newComment;
                    informatic.Comment += "<br /><br />";

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

        public static Boolean Like(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var informatic = DB.tblInformatics.Single(info => info.ID == _id);
                    informatic.Point += 1;

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

        public static Boolean Dislike(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var informatic = DB.tblInformatics.Single(info => info.ID == _id);
                    informatic.Point -= 1;
                    informatic.State = 2; // Bad

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
