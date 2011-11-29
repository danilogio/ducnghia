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
        EventLog log = new EventLog();
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);

        #region Property
        #region Get Property
        /// <summary>
        /// Lấy tiêu đề
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getTitle(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Title.Trim();
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lấy ra loại bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getType(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            int type = lst.ElementAt(0).Type;
            string strType = CommonConstants.BLANK;
            switch (type)
            {
                case CommonConstants.AT_LECTURE:
                    {
                        strType = CommonConstants.AT_LECTURE_NAME;
                        break;
                    }
                case CommonConstants.AT_EXAM:
                    {
                        strType = CommonConstants.AT_EXAM_NAME;
                        break;
                    }
                case CommonConstants.AT_PRACTISE:
                    {
                        strType = CommonConstants.AT_PRACTISE_NAME;
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
        public string getContent(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Contents;
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lấy tên tác giả
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getAuthor(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblUser> lst = from author in DB.tblUsers
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
        public DateTime getPosted(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Posted;
            }

            return new DateTime(1970, 1, 1);
        }

        /// <summary>
        /// Lấy trạng thái bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getState(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            int state = lst.ElementAt(0).State;
            string strState = CommonConstants.BLANK;
            switch (state)
            {
                case CommonConstants.STATE_UNCHECK:
                    {
                        strState = CommonConstants.STATE_UNCHECK_NAME;
                        break;
                    }
                case CommonConstants.STATE_CHECKED:
                    {
                        strState = CommonConstants.STATE_CHECKED_NAME;
                        break;
                    }
                case CommonConstants.STATE_BAD:
                    {
                        strState = CommonConstants.STATE_BAD_NAME;
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
        public int getPoint(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            if (lst.Count() > 0)
            {
                return (int)lst.ElementAt(0).Point;
            }

            return 0;
        }
        /// <summary>
        /// Lấy điểm checker
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int getScore(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            if (lst.Count() > 0)
            {
                return (int)lst.ElementAt(0).Score;
            }

            return 0;
        }

        /// <summary>
        /// Lấy tag
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getTag(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == ID
                                          select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Tag.Trim();
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lay comment
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public string getComments(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == _id
                                          select record;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Comment.Trim();
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lấy bài dựa theo id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static tblEnglish getEnglish(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.ID == _id
                                          select record;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }

            return null;
        }

        #endregion

        /*#region Set Property
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

        /// <summary>
        /// Xet comment
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_comment"></param>
        /// <returns></returns>
        public static Boolean setComment(int _id, string _comment)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblEnglishes.Single(TB => TB.ID == _id);
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

        #endregion*/
        #endregion

        #region Method
        /// <summary>
        /// count stickied article
        /// </summary>
        /// <returns></returns>
        public int countStickyArticle()
        {
            int num = 0;
            num = (from p in DB.tblEnglishes
                   where p.StickyFlg == true && p.DeleteFlg == false
                   select p).Count();
            return num;
        }
        public int countTotalArticles(ArticleSCO articleSCO)
        {
            int num = 0;
            if (articleSCO != null)
            {
                LTDHDataContext DB = new LTDHDataContext(@strPathDB);
                int start = 0;
                int end = 0;
                int year = BaseServices.getYearFromString(articleSCO.Time);

                locateArticleIndex(articleSCO, out start, out end);
                if (articleSCO.Classes == CommonConstants.ALL)
                {
                    num = (from p in DB.tblEnglishes
                           where p.State != CommonConstants.STATE_UNCHECK
                                 && p.Posted.Year < year && p.DeleteFlg == false
                           select p).Count();
                }
                if (start > 0 && end > 0 && end >= start)
                {
                    return (from p in DB.tblEnglishes
                            where p.State != CommonConstants.STATE_UNCHECK
                                    && p.Posted.Year <= year
                                    && p.Class >= start && p.Class <= end && p.DeleteFlg == false
                            select p).Count();
                }
                
            }
            return num;
        }
        /// <summary>
        /// count all article is deleted
        /// </summary>
        /// <returns></returns>
        public int countDeletedArticles()
        {
            int num = (from p in DB.tblEnglishes
                       where p.DeleteFlg == true
                       select p).Count();
            return num;
        }
        /// <summary>
        /// get all deleted article
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblEnglish> getDeletedArticleList()
        {
            IEnumerable<tblEnglish> lst = from p in DB.tblEnglishes
                                          where p.DeleteFlg == true
                                          select p;
            return lst;
        }
        private void locateArticleIndex(ArticleSCO articleSCO,out int start, out int end)
        {
            start = 0;
            end = 0;
            if (articleSCO != null)
            {
                if (articleSCO.Classes == CommonConstants.PARAM_EL_COMMON)
                {
                    start = CommonConstants.AT_EL_CLASS_START;
                    end = CommonConstants.AT_EL_CLASS_END;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_MAJOR)
                {
                    start = CommonConstants.AT_EL_MJ_START;
                    end = CommonConstants.AT_EL_MJ_END;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_CLASS_1_TO_9)
                {
                    start = CommonConstants.AT_EL_CLASS_1;
                    end = CommonConstants.AT_EL_CLASS_9;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_CERT)
                {
                    start = CommonConstants.AT_EL_CERT_TOEFL_START;
                    end = CommonConstants.AT_EL_CERT_ABC_END;
                }
                else if (articleSCO.Classes == CommonConstants.AT_EL_CLASS_12_CODE)
                {
                    start = CommonConstants.AT_EL_CLASS_2;
                    end = start;
                }
                else if (articleSCO.Classes == CommonConstants.AT_EL_CLASS_11_CODE)
                {
                    start = CommonConstants.AT_EL_CLASS_11;
                    end = start;
                }
                else if (articleSCO.Classes == CommonConstants.AT_EL_CLASS_10_CODE)
                {
                    start = CommonConstants.AT_EL_CLASS_10;
                    end = start;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_MATH_ECO)
                {
                    start = CommonConstants.AT_EL_MJ_MATH;
                    end = CommonConstants.AT_EL_MJ_ECO;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_CHEM_BIO_MAT)
                {
                    start = CommonConstants.AT_EL_MJ_CHEM;
                    end = CommonConstants.AT_EL_MJ_MATERIAL;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_PHY_TELE_IT)
                {
                    start = CommonConstants.AT_EL_MJ_PHY;
                    end = CommonConstants.AT_EL_MJ_IT;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_OTHER_MJ)
                {
                    start = CommonConstants.AT_EL_MJ_IT + 1;
                    end = CommonConstants.AT_EL_MJ_END;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_TOEIC)
                {
                    start = CommonConstants.AT_EL_CERT_TOEIC_START;
                    end = CommonConstants.AT_EL_CERT_TOEIC_END;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_TOEFL)
                {
                    start = CommonConstants.AT_EL_CERT_TOEFL_START;
                    end = CommonConstants.AT_EL_CERT_TOEFL_END;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_IELTS)
                {
                    start = CommonConstants.AT_EL_CERT_IELTS_START;
                    end = CommonConstants.AT_EL_CERT_IELTS_END;
                }
                else if (articleSCO.Classes == CommonConstants.PARAM_EL_ABC)
                {
                    start = CommonConstants.AT_EL_CERT_ABC_START;
                    end = CommonConstants.AT_EL_CERT_ABC_END;
                }
            }

        }
        /// <summary>
        /// get max point article
        /// </summary>
        /// <returns></returns>
        public tblEnglish getMaxPoint()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from p in DB.tblEnglishes
                                          where p.Point == DB.tblEnglishes.Max(p2 => p2.Point) 
                                          && p.DeleteFlg == false
                             orderby p.Posted descending
                             select p;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(BaseServices.random(0, lst.Count() - 1));
            }
            return null;
        }
        /// <summary>
        /// Thêm một bài viết mới
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Boolean insertEnglish(tblEnglish record)
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
                ltktDAO.Control controlDao = new ltktDAO.Control();
                long keyCode = controlDao.getValueByLong(CommonConstants.CF_KEY_CODE_EL);
                controlDao.setValue(CommonConstants.CF_KEY_CODE_EL, (keyCode + 1).ToString());

            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, record.Author, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm một bài giảng/bài tập/đề thi anh văn
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_type"></param>
        /// <param name="_content"></param>
        /// <param name="_author"></param>
        /// <param name="_posted"></param>
        /// <param name="_location"></param>
        /// <param name="_tag"></param>
        /// <returns></returns>
        public Boolean insertEnglish(string _title, int _type, string _content,
            string _author, DateTime _posted, int _class, string _location, string _tag, string folderId)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblEnglish record = new tblEnglish();
                    record.Title = _title;
                    record.Type = _type;
                    record.Contents = _content;
                    record.Author = _author;
                    record.Posted = _posted;
                    record.Class = _class;
                    record.Location = _location;
                    record.State = 0;
                    record.Point = 0;
                    record.Score = 0;
                    record.Tag = _tag;
                    record.StickyFlg = false;
                    record.Class = _class;
                    record.FolderID = folderId;
                    record.DeleteFlg = false;

                    DB.tblEnglishes.InsertOnSubmit(record);
                    DB.SubmitChanges();
                    ts.Complete();
                }

                ltktDAO.Statistics statisticDAO = new ltktDAO.Statistics();
                statisticDAO.add(CommonConstants.SF_NUM_UPLOAD, CommonConstants.CONST_ONE);
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _author, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
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
        public Boolean updateEnglish(int _id, tblEnglish update)
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
                    english.HtmlEmbedLink = update.HtmlEmbedLink;
                    english.HtmlPreview = update.HtmlPreview;
                    english.StickyFlg = update.StickyFlg;
                    english.Checker = update.Checker;
                    english.Score = update.Score;
                    english.Thumbnail = update.Thumbnail;
                    english.Class = update.Class;
                    english.Location = update.Location;
                    english.Comment = update.Comment;
                    english.FolderID = update.FolderID;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, update.Author, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tổng các bài viết về chủ đề Anh văn (bài giảng, đề thi, bài tập).
        /// </summary>
        /// <returns></returns>
        public int sumEnglish()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            return (from english in DB.tblEnglishes 
                    where english.DeleteFlg == false
                    select english).Count();

        }
        public bool setDeleteFlagArticle(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var english = DB.tblEnglishes.Single(e => e.ID == _id);
                    english.DeleteFlg = true;
                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                writeException(ex);
                return false;
            }
            return true;
        }
        /// <summary>
        /// delete article
        /// </summary>
        /// <param name="deletedList"></param>
        /// <returns></returns>
        public bool deleteArticles()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    IEnumerable<tblEnglish> deletedList = from p in DB.tblEnglishes
                                                  where p.DeleteFlg == true
                                                  select p;
                    DB.tblEnglishes.DeleteAllOnSubmit(deletedList);
                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                writeException(ex);
                return false;
            }
            return true;
        }
        public Boolean insertComment(int _id, string _newComment)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var english = DB.tblEnglishes.Single(e => e.ID == _id);
                    english.Comment += _newComment;
                    english.Comment += "<br /><br />;";

                    DB.SubmitChanges();
                    ts.Complete();
                    
                    //Cho cái này vào bị lỗi liên tục
                    //2011-09-27 16:09 tktung bỏ
                    //ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                    //statDAO.add(CommonConstants.SF_NUM_COMMENT_A_DAY, "1");
                }
            }
            catch (Exception e) {
                writeException(e);
                return false; 
            }

            return true;
        }
        private void writeException(Exception e)
        {
            log.writeLog(DBHelper.strPathLogFile, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
        }
        public Boolean Like(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var english = DB.tblEnglishes.Single(e => e.ID == _id);
                    english.Point += 1;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }
            return true;
        }
        /// <summary>
        /// get latest article by posted date
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="numberRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblEnglish> getLatestArticlesByPostedDate(int _class, int numberRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (numberRecord <= 0)
                numberRecord = 1;
            IEnumerable<tblEnglish> lst = (from p in DB.tblEnglishes
                                           where p.Class == _class && p.StickyFlg == false 
                                           && p.DeleteFlg == false
                                           orderby p.Posted descending
                                           select p).Take(numberRecord);
            return lst;
        }

        public IEnumerable<tblEnglish>  fetchEnglishList(int start, int count)
        {
            IEnumerable<tblEnglish> lst = (from r in DB.tblEnglishes
                                              where r.DeleteFlg == false
                                              orderby r.Posted descending 
                                              select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblEnglish> fetchEnglishList(int state, int start, int count)
        {
            IEnumerable<tblEnglish> lst = (from r in DB.tblEnglishes
                                              where r.State == state && r.DeleteFlg == false
                                              orderby r.Posted descending
                                              select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblEnglish> fetchEnglishListWithClass(string _class, int start, int count)
        {
            int startIdx = 0;
            int endIdx = 0;
            findIndex(_class, out startIdx, out endIdx);
            if (startIdx == -1)
                return null;
            IEnumerable<tblEnglish> lst = (from r in DB.tblEnglishes
                                           where r.Class >= startIdx && r.Class <= endIdx 
                                           && r.DeleteFlg == false
                                              orderby r.Posted descending
                                              select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblEnglish> fetchStickyEnglishList(int start, int count)
        {
            IEnumerable<tblEnglish> lst = (from r in DB.tblEnglishes
                                           where r.StickyFlg == true 
                                           && r.DeleteFlg == false
                                           orderby r.Posted descending
                                           select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblEnglish> fetchStickyEnglishList(int state, int start, int count)
        {
            IEnumerable<tblEnglish> lst = (from r in DB.tblEnglishes
                                           where r.StickyFlg == true 
                                           && r.State == state 
                                           && r.DeleteFlg == false
                                           orderby r.Posted descending
                                           select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblEnglish> searchArticles(string keyword, int start, int count)
        {
            IEnumerable<tblEnglish> lst = (from r in DB.tblEnglishes
                                           where (r.Title.Contains(keyword) || r.Tag.Contains(keyword)) 
                                           && r.DeleteFlg == false
                                           orderby r.Posted descending
                                           select r).Skip(start).Take(count);

            return lst;
        }
        public int countArticles(string keyword)
        {
            int num = (from r in DB.tblEnglishes
                       where (r.Title.Contains(keyword) || r.Tag.Contains(keyword)) 
                       && r.DeleteFlg == false
                       orderby r.Posted descending
                       select r).Count();

            return num;
        }
        public int countStickyEnglishList(int state)
        {
            int num = (from r in DB.tblEnglishes
                       where r.StickyFlg == true 
                       && r.State == state 
                       && r.DeleteFlg == false
                       select r).Count();

            return num;
        }
        /// <summary>
        /// count english article with class
        /// </summary>
        /// <param name="_class"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int countEnglishListWithClass(string _class)
        {
            int startIdx = 0;
            int endIdx = 0;
            findIndex(_class, out startIdx, out endIdx);
            if (startIdx == -1)
                return 0;
            int num = (from r in DB.tblEnglishes
                       where r.Class >= startIdx 
                       && r.Class <= endIdx 
                       && r.DeleteFlg == false
                       select r).Count();

            return num;
        }
        /// <summary>
        /// count all article
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public int countEnglishList(int state)
        {
            int num = (from r in DB.tblEnglishes
                       where r.State == state 
                       && r.DeleteFlg == false
                       select r).Count();

            return num;
        }
        /// <summary>
        /// count article with class and state
        /// </summary>
        /// <param name="_class"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int countEnglishList(string _class, int state)
        {
            int startIdx = 0;
            int endIdx = 0;
            findIndex(_class, out startIdx, out endIdx);
            if (startIdx == -1)
                return 0;
            int num = (from r in DB.tblEnglishes
                                           where r.Class >= startIdx 
                                           && r.Class <= endIdx
                                           && r.State == state 
                                           && r.DeleteFlg == false
                                           select r).Count();

            return num;
        }
        public IEnumerable<tblEnglish> fetchEnglishList(string _class, int state, int start, int count)
        {
            int startIdx = 0;
            int endIdx = 0;
            findIndex(_class, out startIdx, out endIdx);
            if (startIdx == -1)
                return null;
            IEnumerable<tblEnglish> lst = (from r in DB.tblEnglishes
                                           where r.Class >= startIdx
                                           && r.Class <= endIdx
                                           && r.State == state
                                           && r.DeleteFlg == false
                                           orderby r.Posted descending
                                           select r).Skip(start).Take(count);

            return lst;
        }
        private void findIndex(string _class, out int start, out int end)
        {
            start = 0;
            end = 0;
            if (BaseServices.isNullOrBlank(_class))
            {
                start = -1;
                end = -1;
            }
            if (_class.Length > 5)
            {
                start = -1;
                end = -1;
            }
            if (_class == CommonConstants.AT_EL_CLASS_1_TO_9)
            {
                start = CommonConstants.AT_EL_CLASS_START;
                end = CommonConstants.AT_EL_CLASS_9;
            }
            else if (_class == CommonConstants.AT_EL_CERT_TOEIC)
            {
                start = CommonConstants.AT_EL_CERT_TOEIC_START;
                end = CommonConstants.AT_EL_CERT_TOEIC_END;
            }
            else if (_class == CommonConstants.AT_EL_ABC)
            {
                start = CommonConstants.AT_EL_CERT_ABC_START;
                end = CommonConstants.AT_EL_CERT_ABC_END;
            }
            else if (_class == CommonConstants.AT_EL_CERT_IELTS)
            {
                start = CommonConstants.AT_EL_CERT_IELTS_START;
                end = CommonConstants.AT_EL_CERT_IELTS_END;
            }
            else if (_class == CommonConstants.AT_EL_CERT_TOEFL)
            {
                start = CommonConstants.AT_EL_CERT_TOEFL_START;
                end = CommonConstants.AT_EL_CERT_TOEFL_END;
            }
            else
            {
                start = BaseServices.convertStringToInt(_class);
                end = start;
            }
        }
        public IEnumerable<tblEnglish> searchArticleByClassAndTime(ArticleSCO articleSCO)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            int start = 0; 
            int end = 0;
            int year = BaseServices.getYearFromString(articleSCO.Time);
            IEnumerable<tblEnglish> lst = null;
            //if (articleSCO.Classes == CommonConstants.PARAM_EL_COMMON)
            //{

            //    start = CommonConstants.AT_EL_CLASS_START;
            //    end = CommonConstants.AT_EL_CLASS_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_MAJOR)
            //{
            //    start = CommonConstants.AT_EL_MJ_START;
            //    end = CommonConstants.AT_EL_MJ_END;

            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_CERT)
            //{
            //    start = CommonConstants.AT_EL_CERT_START;
            //    end = CommonConstants.AT_EL_CERT_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_CLASS_1_TO_9)
            //{
            //    start = CommonConstants.AT_EL_CLASS_1;
            //    end = CommonConstants.AT_EL_CLASS_9;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_MATH_ECO)
            //{
            //    start = CommonConstants.AT_EL_MJ_MATH;
            //    end = CommonConstants.AT_EL_MJ_ECO;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_CHEM_BIO_MAT)
            //{
            //    start = CommonConstants.AT_EL_MJ_CHEM;
            //    end = CommonConstants.AT_EL_MJ_MATERIAL;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_PHY_TELE_IT)
            //{
            //    start = CommonConstants.AT_EL_MJ_PHY;
            //    end = CommonConstants.AT_EL_MJ_IT;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_OTHER_MJ)
            //{
            //    start = CommonConstants.AT_EL_MJ_IT + 1;
            //    end = CommonConstants.AT_EL_MJ_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_TOEIC)
            //{
            //    start = CommonConstants.AT_EL_CERT_TOEIC_START;
            //    end = CommonConstants.AT_EL_CERT_TOEIC_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_TOEFL)
            //{
            //    start = CommonConstants.AT_EL_CERT_TOEFL_START;
            //    end = CommonConstants.AT_EL_CERT_TOEFL_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_IELTS)
            //{
            //    start = CommonConstants.AT_EL_CERT_IELTS_START;
            //    end = CommonConstants.AT_EL_CERT_IELTS_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_ABC)
            //{
            //    start = CommonConstants.AT_EL_CERT_ABC_START;
            //    end = CommonConstants.AT_EL_CERT_ABC_END;
            //}
            locateArticleIndex(articleSCO, out start, out end);
            if (start > 0 && end > 0 && end >= start)
            {
                
                                        lst = (from p in DB.tblEnglishes
                                               where p.Posted.Year <= year
                                                     && p.State != CommonConstants.STATE_UNCHECK
                                                     && p.StickyFlg == false
                                                     && p.Class >= start 
                                                     && p.Class <= end 
                                                     && p.DeleteFlg == false
                                               orderby p.Posted descending
                                               select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);
            }
            else if (articleSCO.Classes == CommonConstants.ALL)
            {
                 lst = (from p in DB.tblEnglishes
                       where p.Posted.Year <= year
                             && p.State != CommonConstants.STATE_UNCHECK
                             && p.StickyFlg == false 
                             && p.DeleteFlg == false
                       orderby p.Posted descending
                       select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);
            }
            return lst;
        }

        public IEnumerable<tblEnglish> searchStickyArticleByClassAndTime(ArticleSCO articleSCO)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            int year = BaseServices.getYearFromString(articleSCO.Time);
            int start = 0;
            int end = 0;
            IEnumerable<tblEnglish> lst = null;
            //if (articleSCO.Classes == CommonConstants.PARAM_EL_COMMON)
            //{

            //    start = CommonConstants.AT_EL_CLASS_START;
            //    end = CommonConstants.AT_EL_CLASS_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_MAJOR)
            //{
            //    start = CommonConstants.AT_EL_MJ_START;
            //    end = CommonConstants.AT_EL_MJ_END;

            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_CERT)
            //{
            //    start = CommonConstants.AT_EL_CERT_START;
            //    end = CommonConstants.AT_EL_CERT_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_CLASS_1_TO_9)
            //{
            //    start = CommonConstants.AT_EL_CLASS_1;
            //    end = CommonConstants.AT_EL_CLASS_9;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_MATH_ECO)
            //{
            //    start = CommonConstants.AT_EL_MJ_MATH;
            //    end = CommonConstants.AT_EL_MJ_ECO;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_CHEM_BIO_MAT)
            //{
            //    start = CommonConstants.AT_EL_MJ_CHEM;
            //    end = CommonConstants.AT_EL_MJ_MATERIAL;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_PHY_TELE_IT)
            //{
            //    start = CommonConstants.AT_EL_MJ_PHY;
            //    end = CommonConstants.AT_EL_MJ_IT;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_OTHER_MJ)
            //{
            //    start = CommonConstants.AT_EL_MJ_IT + 1;
            //    end = CommonConstants.AT_EL_MJ_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_TOEIC)
            //{
            //    start = CommonConstants.AT_EL_CERT_TOEIC_START;
            //    end = CommonConstants.AT_EL_CERT_TOEIC_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_TOEFL)
            //{
            //    start = CommonConstants.AT_EL_CERT_TOEFL_START;
            //    end = CommonConstants.AT_EL_CERT_TOEFL_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_IELTS)
            //{
            //    start = CommonConstants.AT_EL_CERT_IELTS_START;
            //    end = CommonConstants.AT_EL_CERT_IELTS_END;
            //}
            //else if (articleSCO.Classes == CommonConstants.PARAM_EL_ABC)
            //{
            //    start = CommonConstants.AT_EL_CERT_ABC_START;
            //    end = CommonConstants.AT_EL_CERT_ABC_END;
            //}
            locateArticleIndex(articleSCO, out start,out end);
            if (start > 0 && end > 0 && end >= start)
            {
                lst = from p in DB.tblEnglishes
                      where p.Posted.Year <= year
                            && p.State != CommonConstants.STATE_UNCHECK
                            && p.StickyFlg == true
                            && p.Class >= start 
                            && p.Class <= end 
                            && p.DeleteFlg == false
                      orderby p.Posted descending
                      select p;
            }
            else if (articleSCO.Classes == CommonConstants.ALL)
            {
                lst = from p in DB.tblEnglishes
                      where p.Posted.Year <= year
                            && p.State != CommonConstants.STATE_UNCHECK
                            && p.StickyFlg == true 
                            && p.DeleteFlg == false
                      orderby p.Posted descending
                      select p;
            }
            return lst;
        }

        public IEnumerable<tblEnglish> searchArticles(ArticleSCO articleSCO)
        {
            /*IEnumerable<tblEnglish> lst1 = searchArticleByClassAndTime(articleSCO);

            IEnumerable<tblEnglish> lst2 = searchStickyArticleByClassAndTime(articleSCO);

            if(lst2 != null)
            {
                if( lst2.Count() > 0)
                {
                    //lst2.ToList().AddRange(lst1.ToList());
                    /*int n = lst1.Count();
                    for (int i = 0; i < n; i++)
                    {
                        lst2.ToList().Add(lst1.ElementAt(i));
                    }
                    //lst1 = lst2;
                    List<tblEnglish> l = lst1.ToList();
                    l.Add(lst1.ElementAt(8));
                    IEnumerable<tblEnglish> h = l;
                    List<tblEnglish> l2 = lst2.ToList();
                    l2.AddRange(lst1.ToList());
                    lst1 = l2;
                }
            }
            return lst1;*/
            IEnumerable<tblEnglish> lst1 = null;
            if (articleSCO.CurrentPage == 1)
            {
                lst1 = searchStickyArticleByClassAndTime(articleSCO);
            }
            if (lst1 != null)
            {
                int remain = articleSCO.NumArticleOnPage - lst1.Count();
                articleSCO.NumArticleOnPage = remain;
            }
            IEnumerable<tblEnglish> lst2 = searchArticleByClassAndTime(articleSCO);
            if (lst1 != null)
            {
                if (lst1.Count() > 0)
                {
                    List<tblEnglish> l1 = lst1.ToList();
                    l1.AddRange(lst2.ToList());
                    lst2 = l1;
                }
            }
            return lst2;

        }
        /// <summary>
        /// get latest sticky article by posted date
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="numberRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblEnglish> getLatestStickyArticlesByPostedDate(int _class, int numberRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (numberRecord <= 0)
                numberRecord = 1;
            IEnumerable<tblEnglish> lst = (from p in DB.tblEnglishes
                                           where p.Class == _class 
                                           && p.StickyFlg == true 
                                           && p.DeleteFlg == false
                                           orderby p.Posted descending
                                           select p).Take(numberRecord);
            
            return lst;
        }

        /// <summary>
        /// get latest article by posted date
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="numberRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblEnglish> getLatestArticlesByPostedDate(int _startClass, int _endClass, int numberRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (numberRecord <= 0)
                numberRecord = 1;
            IEnumerable<tblEnglish> lst = (from p in DB.tblEnglishes
                                           where p.Class >= _startClass 
                                           && p.Class <= _endClass 
                                           && p.StickyFlg == false
                                           && p.State != CommonConstants.STATE_UNCHECK 
                                           && p.DeleteFlg == false
                                           orderby p.Posted descending
                                           select p).Take(numberRecord);
            return lst;
        }

        /// <summary>
        /// get latest sticky article by posted date
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="numberRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblEnglish> getLatestStickyArticlesByPostedDate(int _startClass, int _endClass, int numberRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (numberRecord <= 0)
                numberRecord = 1;
            IEnumerable<tblEnglish> lst = (from p in DB.tblEnglishes
                                           where p.Class >= _startClass 
                                           && p.Class <= _endClass 
                                           && p.StickyFlg == true
                                           && p.State != CommonConstants.STATE_UNCHECK
                                           && p.DeleteFlg == false
                                           orderby p.Posted descending
                                           select p).Take(numberRecord);
            return lst;
        }

        /// <summary>
        /// when check button dislike article
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Boolean Dislike(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var english = DB.tblEnglishes.Single(e => e.ID == _id);
                    if (english.Point > 0)
                    {
                        english.Point -= 1;
                    }
                    english.State = CommonConstants.STATE_BAD; // Bad

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Lấy bài viết liên quan theo loại
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public IList<tblEnglish> getRelativeByType(int _type, int _numberRecords)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = (from record in DB.tblEnglishes
                                           where record.Type == _type 
                                           && record.DeleteFlg == false
                                           select record).Take(_numberRecords);

            return lst.ToList();
        }

        public IList<tblEnglish> listEnglish(string _keyword)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where (record.Title.Contains(_keyword) ||
                                                      record.Tag.Contains(_keyword) ||
                                                      record.Contents.Contains(_keyword))
                                                      && record.DeleteFlg == false
                                          select record;

            return lst.ToList();
        }

        public int count()
        {
            return (from r in DB.tblEnglishes where r.DeleteFlg == false select r).Count();
        }
        /// <summary>
        /// get one article with ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public tblEnglish getArticle(int _id)
        {
            IEnumerable<tblEnglish> lst = from p in DB.tblEnglishes
                                          where p.ID == _id 
                                          && p.DeleteFlg == false
                                          select p;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }
            return null;
        }
        public string getClassName(int _code)
        {
            switch (_code)
            {
                case CommonConstants.AT_EL_CLASS_1:
                    {
                        return CommonConstants.AT_EL_CLASS_1_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_2:
                    {
                        return CommonConstants.AT_EL_CLASS_2_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_3:
                    {
                        return CommonConstants.AT_EL_CLASS_3_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_4:
                    {
                        return CommonConstants.AT_EL_CLASS_4_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_5:
                    {
                        return CommonConstants.AT_EL_CLASS_5_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_6:
                    {
                        return CommonConstants.AT_EL_CLASS_6_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_7:
                    {
                        return CommonConstants.AT_EL_CLASS_7_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_8:
                    {
                        return CommonConstants.AT_EL_CLASS_8_NAME;
                    }
                case CommonConstants.AT_EL_CLASS_9:
                    {
                        return CommonConstants.AT_EL_CLASS_9_NAME;
                    }
                case CommonConstants.AT_EL_IELTS:
                    {
                        return CommonConstants.AT_EL_IELTS_NAME;
                    }
                case CommonConstants.AT_EL_MJ_BIO:
                    {
                        return CommonConstants.AT_EL_MJ_BIO_NAME;
                    }
                case CommonConstants.AT_EL_MJ_CHEM:
                    {
                        return CommonConstants.AT_EL_MJ_CHEM_NAME;
                    }
                case CommonConstants.AT_EL_MJ_ECO:
                    {
                        return CommonConstants.AT_EL_MJ_ECO_NAME;
                    }
                case CommonConstants.AT_EL_MJ_IT:
                    {
                        return CommonConstants.AT_EL_MJ_IT_NAME;
                    }
                case CommonConstants.AT_EL_MJ_MATERIAL:
                    {
                        return CommonConstants.AT_EL_MJ_MATERIAL_NAME;
                    }
                case CommonConstants.AT_EL_MJ_MATH:
                    {
                        return CommonConstants.AT_EL_MJ_MATH_NAME;
                    }
                case CommonConstants.AT_EL_MJ_PHY:
                    {
                        return CommonConstants.AT_EL_MJ_PHY_NAME;
                    }
                case CommonConstants.AT_EL_MJ_TELE:
                    {
                        return CommonConstants.AT_EL_MJ_TELE_NAME;
                    }
                case CommonConstants.AT_EL_TOEFL:
                    {
                        return CommonConstants.AT_EL_TOEFL_NAME;
                    }
                case CommonConstants.AT_EL_TOEIC_300:
                    {
                        return CommonConstants.AT_EL_TOEIC_300_NAME;
                    }
                case CommonConstants.AT_EL_TOEIC_400:
                    {
                        return CommonConstants.AT_EL_TOEIC_400_NAME;
                    }
                case CommonConstants.AT_EL_TOEIC_500:
                    {
                        return CommonConstants.AT_EL_TOEIC_500_NAME;
                    }
                case CommonConstants.AT_EL_TOEIC_600:
                    {
                        return CommonConstants.AT_EL_TOEIC_600_NAME;
                    }
                case CommonConstants.AT_EL_TOEIC_700:
                    {
                        return CommonConstants.AT_EL_TOEIC_700_NAME;
                    }
                case CommonConstants.AT_EL_TOEIC_800:
                    {
                        return CommonConstants.AT_EL_TOEIC_800_NAME;
                    }
                case CommonConstants.AT_EL_TOEIC_900:
                    {
                        return CommonConstants.AT_EL_TOEIC_900_NAME;
                    }
            }
            return CommonConstants.AT_UNCLASSIFIED_NAME;
        }
        #endregion
    }
}
