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
        EventLog log = new EventLog();

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
        #endregion

        #region Method

        /// <summary>
        /// Get amount of latest article by posted date with range type
        /// </summary>
        /// <param name="numRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblInformatic> getLatestArticleByPostedDate(int _mintype, int _maxtype, int _numRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (_numRecord <= 0)
                _numRecord = 1;

            IEnumerable<tblInformatic> lst = (from p in DB.tblInformatics
                                              where p.Leitmotif >= _mintype && p.Leitmotif <= _maxtype && p.State != CommonConstants.STATE_UNCHECK
                                              orderby p.Posted descending
                                              select p).Take(_numRecord);
            return lst;
        }
        /// <summary>
        /// Get amount of latest article by posted date with match type
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_numRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblInformatic> getLatestArticleByPostedDate(int _type, int _numRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (_numRecord <= 0)
                _numRecord = 1;

            IEnumerable<tblInformatic> lst = (from p in DB.tblInformatics
                                              where p.Leitmotif == _type && p.State != CommonConstants.STATE_UNCHECK
                                              orderby p.Posted descending
                                              select p).Take(_numRecord);
            return lst;
        }
        /// <summary>
        /// Thêm bài mới
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Boolean insertInformatic(tblInformatic record)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DB.tblInformatics.InsertOnSubmit(record);

                    DB.SubmitChanges();

                    ts.Complete();
                    log.writeLog(DBHelper.strPathLogFile, record.Author, 
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE, 
                                                                    record.ID.ToString(), 
                                                                    CommonConstants.SQL_TABLE_INFORMATICS));
                }
                
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, record.Author, e.Message);
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
        public Boolean insertInformatic(string _title, int _type, string _content,
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
                    record.State = CommonConstants.STATE_UNCHECK;
                    record.Location = _location;
                    record.Tag = _tag;
                    record.StickyFlg = false;
                    record.Score = 0;

                    DB.tblInformatics.InsertOnSubmit(record);
                    DB.SubmitChanges();
                    ts.Complete();
                    log.writeLog(DBHelper.strPathLogFile, record.Author,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                    _title,
                                                                    CommonConstants.SQL_TABLE_INFORMATICS));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _author, e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật bài viết
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public Boolean updateInformatic(int _id, tblInformatic update, string currentUsername)
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
                    informatic.HtmlEmbedLink = update.HtmlEmbedLink;
                    informatic.HtmlPreview = update.HtmlPreview;

                    DB.SubmitChanges();
                    ts.Complete();
                    
                    //write log
                    log.writeLog(DBHelper.strPathLogFile, currentUsername, 
                                    BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE, 
                                                                    _id.ToString(), 
                                                                    CommonConstants.SQL_TABLE_INFORMATICS));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, currentUsername, e.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// Tổng số các bài viết về chủ đề tin học
        /// </summary>
        /// <returns></returns>
        public  int sumInformatics()
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
        public Boolean insertComment(int _id, string _newComment, string currentUsername)
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
                log.writeLog(DBHelper.strPathLogFile, currentUsername, e.Message);
                return false;
            }

            return true;
        }

        public  Boolean Like(int _id)
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
                log.writeLog(DBHelper.strPathLogFile, e.Message);
                return false;
            }
            return true;
        }

        public  Boolean Dislike(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var informatic = DB.tblInformatics.Single(info => info.ID == _id);
                    informatic.Point -= 1;
                    informatic.State = CommonConstants.STATE_BAD; // Bad

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lấy bài viết liên quan theo loại
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public  IList<tblInformatic> getRelativeByType(int _type, int _numberRecords)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (_numberRecords < 1)
                _numberRecords = 1;
            IEnumerable<tblInformatic> lst = (from record in DB.tblInformatics
                                              where record.Type == _type
                                              select record).Take(_numberRecords);

            return lst.ToList();
        }

        public  IList<tblInformatic> listInformatics(string _keyword)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.Title.Contains(_keyword) ||
                                                         record.Tag.Contains(_keyword) ||
                                                         record.Contents.Contains(_keyword)
                                             select record;

            return lst.ToList();
        }

        #endregion
    }
}
