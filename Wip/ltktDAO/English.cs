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
        public static string getType(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static string getContent(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static string getAuthor(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static DateTime getPosted(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static string getState(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static int getPoint(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static string getComments(int _id)
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
        /// get max point article
        /// </summary>
        /// <returns></returns>
        public tblEnglish getMaxPoint()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from p in DB.tblEnglishes
                             where p.Point == DB.tblEnglishes.Max(p2=>p2.Point)
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
            }
            catch (Exception e)
            {
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
            string _author, DateTime _posted, string _location, string _tag)
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
                    record.Location = _location;
                    record.State = 0;
                    record.Point = 0;
                    record.Tag = _tag;
                    record.StickyFlg = false;
                    record.Class = CommonConstants.AT_UNCLASSIFIED;

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
                    english.StickyFlg = english.StickyFlg;

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
        public int sumEnglish()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            return (from english in DB.tblEnglishes
                    select english).Count();

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
                    english.Comment += "<br /><br />";

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e) { return false; }

            return true;
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
                                           orderby p.Posted descending
                                           select p).Take(numberRecord);
            return lst;
        }
        private IEnumerable<tblEnglish> searchArticleByClassAndTime(ArticleSCO articleSCO, int numberRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (numberRecord < 1)
                numberRecord = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;

            int start = 0; 
            int end = 0;
            int year = BaseServices.getYearFromString(articleSCO.Time);
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
            else if (articleSCO.Classes == CommonConstants.PARAM_EL_CERT)
            {
                start = CommonConstants.AT_EL_CERT_START;
                end = CommonConstants.AT_EL_CERT_END;
            }
            else if (articleSCO.Classes == CommonConstants.PARAM_EL_CLASS_1_TO_9)
            {
                start = CommonConstants.AT_EL_CLASS_1;
                end = CommonConstants.AT_EL_CLASS_9;
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
            if (start > 0 && end > 0 && end >= start)
            {
                
                IEnumerable<tblEnglish> lst1 = (from p in DB.tblEnglishes
                                               where p.Posted.Year <= year
                                                     && p.State != CommonConstants.STATE_UNCHECK
                                                     && p.StickyFlg == false
                                                     && p.Class >= start && p.Class <= end
                                               orderby p.Posted descending
                                               select p).Take(numberRecord);
                return lst1;
            }
            if (articleSCO.Classes != CommonConstants.ALL)
            {
                IEnumerable<tblEnglish> lst2 = (from p in DB.tblEnglishes
                                                where p.Posted.Year <= year
                                                      && p.State != CommonConstants.STATE_UNCHECK
                                                      && p.StickyFlg == false
                                                      && p.Class == BaseServices.getValueClassByCode(articleSCO.Classes)
                                                orderby p.Posted descending
                                                select p).Take(numberRecord);
                return lst2;
            }

            IEnumerable<tblEnglish> lst3 = (from p in DB.tblEnglishes
                                            where p.Posted.Year <= year
                                                  && p.State != CommonConstants.STATE_UNCHECK
                                                  && p.StickyFlg == false
                                            orderby p.Posted descending
                                            select p).Take(numberRecord);
            return lst3;
        }

        private IEnumerable<tblEnglish> searchStickyArticleByClassAndTime(ArticleSCO articleSCO, int numberRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            int year = BaseServices.getYearFromString(articleSCO.Time);
            if (numberRecord < 1)
                numberRecord = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;

            int start = 0;
            int end = 0;
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
            else if (articleSCO.Classes == CommonConstants.PARAM_EL_CERT)
            {
                start = CommonConstants.AT_EL_CERT_START;
                end = CommonConstants.AT_EL_CERT_END;
            }
            else if (articleSCO.Classes == CommonConstants.PARAM_EL_CLASS_1_TO_9)
            {
                start = CommonConstants.AT_EL_CLASS_1;
                end = CommonConstants.AT_EL_CLASS_9;
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
            if (start > 0 && end > 0 && end >= start)
            {
                IEnumerable<tblEnglish> lst1 = (from p in DB.tblEnglishes
                                                where p.Posted.Year <= year
                                                      && p.State != CommonConstants.STATE_UNCHECK
                                                      && p.StickyFlg == true
                                                      && p.Class >= start && p.Class <= end
                                                orderby p.Posted descending
                                                select p).Take(numberRecord);
                return lst1;
            }
            if (articleSCO.Classes != CommonConstants.ALL)
            {
                IEnumerable<tblEnglish> lst2 = (from p in DB.tblEnglishes
                                                where p.Posted.Year <= year
                                                      && p.State != CommonConstants.STATE_UNCHECK
                                                      && p.StickyFlg == true
                                                      && p.Class == BaseServices.getValueClassByCode(articleSCO.Classes)
                                                orderby p.Posted descending
                                                select p).Take(numberRecord);
                return lst2;
            }
            IEnumerable<tblEnglish> lst3 = (from p in DB.tblEnglishes
                                            where p.Posted.Year <= year
                                                  && p.State != CommonConstants.STATE_UNCHECK
                                                  && p.StickyFlg == true
                                            orderby p.Posted descending
                                            select p).Take(numberRecord);
            return lst3;

        }

        public IEnumerable<tblEnglish> searchArticles(ArticleSCO articleSCO, int numberRecord)
        {
            IEnumerable<tblEnglish> lst1 = searchArticleByClassAndTime(articleSCO, numberRecord);

            IEnumerable<tblEnglish> lst2 = searchStickyArticleByClassAndTime(articleSCO, numberRecord);

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
                    IEnumerable<tblEnglish> h = l;*/
                    List<tblEnglish> l2 = lst2.ToList();
                    l2.AddRange(lst1.ToList());
                    lst1 = l2;
                }
            }
            return lst1;
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
                                           where p.Class == _class && p.StickyFlg == true
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
                                           where p.Class >= _startClass && p.Class <= _endClass && p.StickyFlg == false
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
                                           where p.Class >= _startClass && p.Class <= _endClass && p.StickyFlg == true
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
                                           select record).Take(_numberRecords);

            return lst.ToList();
        }

        public IList<tblEnglish> listEnglish(string _keyword)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblEnglish> lst = from record in DB.tblEnglishes
                                          where record.Title.Contains(_keyword) ||
                                                      record.Tag.Contains(_keyword) ||
                                                      record.Contents.Contains(_keyword)
                                          select record;

            return lst.ToList();
        }

        #endregion
    }
}
