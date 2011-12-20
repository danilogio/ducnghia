using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.IO;

namespace ltktDAO
{
    public class Contest
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        EventLog log = new EventLog();
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);

        #region Property
        #region Get Property
        /// <summary>
        /// Lấy tiêu đề bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getTitle(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Title.Trim();
            }
            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lấy nội dung bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getContent(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Contents.Trim();
            }
            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lời giải của đề thi
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getSolving(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Solving.Trim();
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
                                       join record in DB.tblContestForUniversities on author.Username equals record.Author
                                       where record.ID == ID && record.DeleteFlg == false
                                       select author;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).DisplayName.Trim();
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lấy ngày đăng tin
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DateTime getPosted(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Posted;
            }

            return new DateTime(1970, 1, 1);
        }

        /// <summary>
        /// Lấy trạng thái của bài viêt
        /// 0 - uncheck
        /// 1 - checked
        /// 2 - bad
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getState(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            int state = lst.ElementAt(0).State;
            string strState = CommonConstants.BLANK;
            switch (state)
            {
                case CommonConstants.STATE_CHECKED:
                    {
                        strState = CommonConstants.STATE_CHECKED_NAME;
                        break;
                    }
                case CommonConstants.STATE_UNCHECK:
                    {
                        strState = CommonConstants.STATE_UNCHECK_NAME;
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
        /// Lấy ra loại đề thi, cao đẳng hay đại học?
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getContestType(int ID)
        {

            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.ElementAt(0).isUniversity == false)
            {
                return CommonConstants.TXT_UNIVERSITY;
            }

            return CommonConstants.TXT_COLLEAGUE;
        }

        /// <summary>
        /// Đề thi này của khối nào?
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getBranch(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            int branch = lst.ElementAt(0).Branch;
            string strBranch = CommonConstants.BLANK;
            switch (branch)
            {
                case CommonConstants.AT_UNI_BRANCH_A:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_A_NAME;
                        break;
                    }
                case CommonConstants.AT_UNI_BRANCH_B:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_B_NAME;
                        break;
                    }
                case CommonConstants.AT_UNI_BRANCH_C:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_C_NAME;
                        break;
                    }
                case CommonConstants.AT_UNI_BRANCH_D:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_D_NAME;
                        break;
                    }
                default:
                    break;
            }

            return strBranch;
        }

        /// <summary>
        /// Đề thi năm nào?
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int getYear(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Year;
            }

            return 1970;
        }
        /// <summary>
        /// Lấy điểm bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int getPoint(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Point;
            }

            return 0;
        }

        /// <summary>
        /// Lấy tag của bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getTag(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Tag.Trim();
            }

            return CommonConstants.BLANK;
        }

        public int getScore(int ID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == ID && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Score;
            }

            return 0;
        }
        /// <summary>
        /// Lấy comment
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public string getComments(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == _id && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Comment.Trim();
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lấy ra 1 đề thi theo id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public tblContestForUniversity getContest(int _id)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.ID == _id && record.DeleteFlg == false
                                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }

            return null;
        }

        #endregion
        /*
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
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
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
        /// Xét nội dung
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_content"></param>
        /// <returns></returns>
        public static Boolean setContent(int ID, string _content)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                    record.Contents = _content;
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
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
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
        /// Xét ngày đăng
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
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
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
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
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
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                    record.isUniversity = _isUniversity;
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
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                    record.Branch = _branch;
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
        /// Xét năm thi của đề
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_year"></param>
        /// <returns></returns>
        public static Boolean setYear(int ID, int _year)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                    record.Year = _year;
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
        /// Xét lời giải cho đề thi
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_solving"></param>
        /// <returns></returns>
        public static Boolean setSolving(int ID, string _solving)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                    record.Solving = _solving;
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
        /// Xét diểm bài viết
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
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
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
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
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

        /// <summary>
        /// Xét comment
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="_comment"></param>
        /// <returns></returns>
        public static Boolean setComment(int ID, string _comment)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContestForUniversities.Single(TB => TB.ID == ID);
                    record.Comment = _comment;
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
        */
        #endregion

        #region Method
        /// <summary>
        /// get max point article
        /// </summary>
        /// <returns></returns>
        public tblContestForUniversity getMaxPoint()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from p in DB.tblContestForUniversities
                                                       where p.Point == DB.tblContestForUniversities.Max(p2 => p2.Point)
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
        /// get Article by Subject and by time
        /// </summary>
        /// <param name="articleSCO"></param>
        /// <returns></returns>
        public IEnumerable<tblContestForUniversity> searchLatestArticleBySubjectAndTime(ArticleSCO articleSCO)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = null;
            if (articleSCO.Subject == CommonConstants.ALL)
            {
                lst = (from p in DB.tblContestForUniversities
                       where p.Year <= BaseServices.getYearFromString(articleSCO.Time)
                       && p.State != CommonConstants.STATE_UNCHECK
                       && p.StickyFlg == false
                       && p.DeleteFlg == false
                       orderby p.Year descending
                       select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);
            }
            else
            {
                lst = (from p in DB.tblContestForUniversities
                       where p.Subject == articleSCO.Subject && p.Year <= BaseServices.getYearFromString(articleSCO.Time)
                       && p.State != CommonConstants.STATE_UNCHECK
                       && p.StickyFlg == false
                       && p.DeleteFlg == false
                       orderby p.Year descending
                       select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);
            }
            return lst;
        }

        public IEnumerable<tblContestForUniversity> searchLatestStickyArticles(ArticleSCO articleSCO)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = null;
            if (articleSCO.Subject == CommonConstants.ALL)
            {
                lst = from p in DB.tblContestForUniversities
                      where p.Year <= BaseServices.getYearFromString(articleSCO.Time)
                      && p.State != CommonConstants.STATE_UNCHECK
                      && p.StickyFlg == true
                      && p.DeleteFlg == false
                      orderby p.Year descending
                      select p;
            }
            else
            {
                lst = from p in DB.tblContestForUniversities
                      where p.Subject == articleSCO.Subject && p.Year <= BaseServices.getYearFromString(articleSCO.Time)
                      && p.State != CommonConstants.STATE_UNCHECK
                      && p.StickyFlg == true
                      && p.DeleteFlg == false
                      orderby p.Year descending
                      select p;
            }
            return lst;
        }
        public int countTotalRecord(ArticleSCO articleSCO)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            int num = 0;
            if (articleSCO.Subject == CommonConstants.ALL)
            {
                num = (from p in DB.tblContestForUniversities
                       where p.Year <= BaseServices.getYearFromString(articleSCO.Time)
                       && p.State != CommonConstants.STATE_UNCHECK
                       && p.DeleteFlg == false
                       orderby p.Year descending
                       select p).Count();
            }
            else
            {
                num = (from p in DB.tblContestForUniversities
                       where p.Subject == articleSCO.Subject && p.Year <= BaseServices.getYearFromString(articleSCO.Time)
                       && p.State != CommonConstants.STATE_UNCHECK
                       && p.DeleteFlg == false
                       orderby p.Year descending
                       select p).Count();
            }
            return num;
        }

        /// <summary>
        /// count all article is deleted
        /// </summary>
        /// <returns></returns>
        public int countDeletedArticles()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            int num = 0;
            num = (from p in DB.tblContestForUniversities
                   where p.DeleteFlg == true
                   select p).Count();
            return num;
        }
        /// <summary>
        /// get all article has deleted flag is true
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblContestForUniversity> getDeletedArticle()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblContestForUniversity> lst = from p in DB.tblContestForUniversities
                                                       where p.DeleteFlg == true
                                                       select p;
            return lst;
        }
        /// <summary>
        /// get all records of Contest
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblContestForUniversity> getAll()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from p in DB.tblContestForUniversities
                                                       where p.DeleteFlg == false
                                                       select p;
            return lst;
        }
        public IEnumerable<tblContestForUniversity> getTopPointArticle()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = (from p in DB.tblContestForUniversities
                                                        where p.DeleteFlg == false
                                                        select p);

            return lst;

        }
        /// <summary>
        /// get latest record
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="numberRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblContestForUniversity> getArticleByDate(string Date, int numberRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            DateTime date = new DateTime();
            bool isValid = DateTime.TryParse(Date, out date);
            if (!isValid)
            {
                return null;
            }
            if (numberRecord <= 0)
            {
                numberRecord = 1;
            }
            IEnumerable<tblContestForUniversity> lst = (from p in DB.tblContestForUniversities
                                                        where p.Posted == date && p.DeleteFlg == false
                                                        select p).Take(numberRecord);
            return lst;

        }
        /// <summary>
        /// get number sticky article by posted day
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<tblContestForUniversity> getStickyArticlebyPostedDay(int number)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = null;
            if (number <= 0)
                number = 1;
            try
            {
                lst = (from p in DB.tblContestForUniversities
                       where p.StickyFlg == true
                       && p.DeleteFlg == false
                       orderby p.Posted descending
                       select p).Take(number);
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
            }
            return lst;
        }
        /// <summary>
        /// get number latest article by posted day
        /// </summary>
        /// <param name="number"></param>
        /// <returns>return article checked</returns>
        public IEnumerable<tblContestForUniversity> getLatestArticleByPostedDate(int number)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = null;
            if (number <= 0)
                return getAll();
            try
            {
                lst = (from p in DB.tblContestForUniversities
                       where p.State != CommonConstants.STATE_UNCHECK
                       && p.StickyFlg == false
                       && p.DeleteFlg == false
                       orderby p.Posted descending
                       select p).Take(number);
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
            }
            return lst;
        }

        /// <summary>
        /// Thêm một đề thi
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Boolean insertContest(tblContestForUniversity record, string _username)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DB.tblContestForUniversities.InsertOnSubmit(record);

                    DB.SubmitChanges();

                    ts.Complete();
                    log.writeLog(DBHelper.strPathLogFile,
                                        _username,
                                        BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                         record.ID.ToString(),
                                                                         CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message
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
        /// Thêm một đề thi
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_content"></param>
        /// <param name="_author"></param>
        /// <param name="_posted"></param>
        /// <param name="_isUniversity"></param>
        /// <param name="_branch"></param>
        /// <param name="_year"></param>
        /// <param name="_location"></param>
        /// <returns></returns>
        public Boolean insertContest(string _title, string _content, string _author,
            DateTime _posted, Boolean _isUniversity, string _sub, int _year, string _location,
            string _tag, string fileSolved, string _folderID)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblContestForUniversity record = new tblContestForUniversity();
                    record.Title = _title;
                    record.Contents = _content;
                    record.Author = _author;
                    record.Posted = _posted;
                    record.State = CommonConstants.STATE_UNCHECK;//Chưa duyệt
                    record.isUniversity = _isUniversity;
                    record.Subject = _sub;
                    record.Year = _year;
                    record.Point = 0;//điểm = số người view
                    record.Location = _location;
                    record.Tag = _tag;
                    record.StickyFlg = false;
                    record.Score = 0;//điểm của checker
                    record.Solving = fileSolved;
                    record.FolderID = _folderID;

                    DB.tblContestForUniversities.InsertOnSubmit(record);

                    DB.SubmitChanges();

                    ts.Complete();

                    ltktDAO.Statistics statisticDAO = new ltktDAO.Statistics();
                    statisticDAO.add(CommonConstants.SF_NUM_UPLOAD, CommonConstants.CONST_ONE);

                    log.writeLog(DBHelper.strPathLogFile,
                                        _author,
                                        BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                         record.ID.ToString(),
                                                                         CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                }
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
        /// Cập nhật đề thi
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public Boolean updateContest(int _id, tblContestForUniversity update, string _username)
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
                    contest.StickyFlg = update.StickyFlg;
                    contest.Score = update.Score;
                    contest.HtmlEmbedLink = update.HtmlEmbedLink;
                    contest.HtmlPreview = update.HtmlPreview;
                    contest.Location = update.Location;

                    DB.SubmitChanges();
                    ts.Complete();
                    log.writeLog(DBHelper.strPathLogFile,
                                        _username,
                                        BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE,
                                                                         contest.ID.ToString(),
                                                                         CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message
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
        /// Tổng các đề thi
        /// </summary>
        /// <returns></returns>
        public int sumContest()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            return (from contest in DB.tblContestForUniversities
                    where contest.DeleteFlg == false
                    select contest).Count();
        }

        /// <summary>
        /// Chuyển từ khối qua chuỗi (mặc định khối là số)
        /// </summary>
        /// <param name="_branch"></param>
        /// <returns></returns>
        public static string convertBranchToString(int _branch)
        {
            string strBranch = CommonConstants.BLANK;
            switch (_branch)
            {
                case CommonConstants.AT_UNI_BRANCH_A:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_A_NAME;
                        break;
                    }
                case CommonConstants.AT_UNI_BRANCH_B:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_B_NAME;
                        break;
                    }
                case CommonConstants.AT_UNI_BRANCH_C:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_C_NAME;
                        break;
                    }
                case CommonConstants.AT_UNI_BRANCH_D:
                    {
                        strBranch = CommonConstants.AT_UNI_BRANCH_D_NAME;
                        break;
                    }
                default:
                    break;
            }

            return strBranch;
        }

        /// <summary>
        /// Thêm 1 comment vào bài viết
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_newComment"></param>
        /// <returns></returns>
        public Boolean insertComment(int _id, string _newComment)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var contest = DB.tblContestForUniversities.Single(cont => cont.ID == _id);
                    contest.Comment += _newComment;
                    contest.Comment += "<br /><br />;";
                    DB.SubmitChanges();
                    ts.Complete();

                    //Cho cái này vào bị lỗi liên tục
                    //2011-09-27 16:09 tktung bỏ
                    //ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                    //statDAO.add(CommonConstants.SF_NUM_COMMENT_A_DAY, "1");

                    log.writeLog(DBHelper.strPathLogFile, "insert comment for contest id=" + _id + " successfully");
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
        /// Thích
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Boolean Like(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var contest = DB.tblContestForUniversities.Single(cont => cont.ID == _id);
                    contest.Point += 1;

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
        /// Báo xấu
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
                    var contest = DB.tblContestForUniversities.Single(cont => cont.ID == _id);
                    if (contest.Point > 0)
                    {
                        contest.Point -= 1;
                    }
                    contest.State = CommonConstants.STATE_BAD; // Bad

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
        /// Lấy các đề thi cùng năm
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public IList<tblContestForUniversity> getRelativeByYear(int _year, int _numberRecords)
        {
            if (_numberRecords < 1)
                _numberRecords = CommonConstants.DEFAULT_NUMBER_RECORD_RELATIVE;
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = (from record in DB.tblContestForUniversities
                                                        where record.Year == _year
                                                        && record.DeleteFlg == false
                                                        select record).Take(_numberRecords);

            return lst.ToList();
        }

        /// <summary>
        /// Lấy danh sách đề thi 
        /// </summary>
        /// <param name="_isUniversity"></param>
        /// <param name="_year"></param>
        /// <returns></returns>
        public IList<tblContestForUniversity> listContest(bool _isUniversity, int _year)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where record.isUniversity == _isUniversity
                                                       && record.DeleteFlg == false
                                                       && record.Year == _year
                                                       select record;

            return lst.ToList();
        }

        public IList<tblContestForUniversity> listContest(String _keyword)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from record in DB.tblContestForUniversities
                                                       where (record.Title.Contains(_keyword) ||
                                                       record.Tag.Contains(_keyword) ||
                                                       record.Contents.Contains(_keyword))
                                                       && record.DeleteFlg == false
                                                       select record;

            return lst.ToList();
        }

        public int count()
        {
            return (from r in DB.tblContestForUniversities select r).Count();
        }

        public IEnumerable<tblContestForUniversity> fetchArticleList(int start, int count)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblContestForUniversity> lst = (from record in DB.tblContestForUniversities
                                                        where record.DeleteFlg == false
                                                        orderby record.Posted descending
                                                        select record).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblContestForUniversity> fetchArticleList(string subject, int start, int count)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblContestForUniversity> lst = (from record in DB.tblContestForUniversities
                                                        where record.Subject == subject
                                                        && record.DeleteFlg == false
                                                        orderby record.Posted descending
                                                        select record).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblContestForUniversity> fetchArticleList(int state, int start, int count)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblContestForUniversity> lst = (from record in DB.tblContestForUniversities
                                                        where record.State == state
                                                        && record.DeleteFlg == false
                                                        orderby record.Posted descending
                                                        select record).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblContestForUniversity> fetchArticleList(string subject, int state, int start, int count)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblContestForUniversity> lst = (from record in DB.tblContestForUniversities
                                                        where record.Subject == subject && record.State == state
                                                        && record.DeleteFlg == false
                                                        orderby record.Posted descending
                                                        select record).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblContestForUniversity> fetchStickyContestList(int start, int count)
        {
            IEnumerable<tblContestForUniversity> lst = (from r in DB.tblContestForUniversities
                                                        where r.StickyFlg == true
                                                        && r.DeleteFlg == false
                                                        orderby r.Posted descending
                                                        select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblContestForUniversity> fetchStickyContestList(int state, int start, int count)
        {
            IEnumerable<tblContestForUniversity> lst = (from r in DB.tblContestForUniversities
                                                        where r.StickyFlg == true
                                                        && r.State == state
                                                        && r.DeleteFlg == false
                                                        orderby r.Posted descending
                                                        select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblContestForUniversity> searchArticles(string keyword, int start, int count)
        {
            IEnumerable<tblContestForUniversity> lst = (from r in DB.tblContestForUniversities
                                                        where (r.Title.Contains(keyword) || r.Tag.Contains(keyword))
                                                        && r.DeleteFlg == false
                                                        orderby r.Posted descending
                                                        select r).Skip(start).Take(count);

            return lst;
        }
        public int countStickyContestList(int state)
        {
            int num = (from r in DB.tblContestForUniversities
                       where r.StickyFlg == true
                       && r.State == state
                       && r.DeleteFlg == false
                       select r).Count();

            return num;
        }
        /// <summary>
        /// count article by keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public int countArticles(string keyword)
        {
            int num = (from r in DB.tblContestForUniversities
                       where (r.Title.Contains(keyword) || r.Tag.Contains(keyword))
                       && r.DeleteFlg == false
                       orderby r.Posted descending
                       select r).Count();

            return num;
        }
        public int countArticleBySubject(string subject)
        {
            int num = 0;

            num = (from record in DB.tblContestForUniversities
                   where record.Subject == subject && record.DeleteFlg == false
                   select record).Count();

            return num;
        }
        public int countArticleBySubjectAndState(string subject, int state)
        {
            int num = 0;

            num = (from record in DB.tblContestForUniversities
                   where record.Subject == subject
                   && record.State == state
                   && record.DeleteFlg == false
                   select record).Count();

            return num;
        }
        public int countArticleByState(int state)
        {
            int num = 0;

            num = (from record in DB.tblContestForUniversities
                   where record.State == state
                   && record.DeleteFlg == false
                   select record).Count();

            return num;
        }
        /// <summary>
        /// count all article is stikied
        /// </summary>
        /// <returns></returns>
        public int countStickyArticle()
        {
            int num = 0;

            num = (from record in DB.tblContestForUniversities
                   where record.StickyFlg == true
                   && record.DeleteFlg == false
                   select record).Count();

            return num;
        }
        /// <summary>
        /// set delete Flag is true
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_username"></param>
        public bool setDeleteFlag(int _id, string _username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var inf = DB.tblContestForUniversities.Single(a => a.ID == _id);
                    inf.DeleteFlg = true;
                    if (inf.State == CommonConstants.STATE_CHECKED)
                    {
                        ltktDAO.Users userDao = new ltktDAO.Users();
                        userDao.subNumberOfArticle(inf.Author.Trim());
                    }
                    DB.SubmitChanges();

                    ts.Complete();
                }
                log.writeLog(DBHelper.strPathLogFile, _username,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_SUCCESSFUL_TEMPLATE,
                                                                    _id.ToString(),
                                                                    CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));

            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_FAILED_TEMPLATE,
                                                                      _id.ToString(),
                                                                      CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message
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
        /// delete a article of contest of university
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool deleteArticle(int id, string username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var cont = DB.tblContestForUniversities.Single(a => a.ID == id);

                    File.Delete(DBHelper.strCurrentPath + cont.Location);
                    if (File.Exists(DBHelper.strCurrentPath + cont.Solving))
                        File.Delete(DBHelper.strCurrentPath + cont.Solving);

                    DB.tblContestForUniversities.DeleteOnSubmit(cont);
                    DB.SubmitChanges();

                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, username,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_SUCCESSFUL_TEMPLATE,
                                                                    Convert.ToString(id),
                                                                    CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, username,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_FAILED_TEMPLATE,
                                                                      Convert.ToString(id),
                                                                      CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                log.writeLog(DBHelper.strPathLogFile, username, e.Message
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

        public bool isState(int id, int state)
        {
            IEnumerable<tblContestForUniversity> lst = from p in DB.tblContestForUniversities
                                                       where p.ID == id && p.DeleteFlg == false
                                                       select p;
            if (lst.Count() > 0)
            {
                if (lst.ElementAt(0).State == state)
                {
                    return true;
                }
            }
            return false;
        }

        public bool updateContest(int id,
                                string userAdmin,
                                string _title,
                                int _state,
                                bool _isSticky,
                                bool _isUniversity,
                                int _branch,
                                string _sub,
                                int _year,
                                string _content,
                                string _tag,
                                int _score,
                                string _fileContent,
                                string _fileSolving,
                                string _fileThumbnail,
                                string _htmlPreview,
                                string _htmlEmbed,
                                string _checker)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var cont = DB.tblContestForUniversities.Single(u => u.ID == id);

                    cont.Title = _title;
                    cont.Contents = _content;
                    ltktDAO.Users userDao = new ltktDAO.Users();
                    if (cont.State == CommonConstants.STATE_UNCHECK 
                        && _state == CommonConstants.STATE_CHECKED)
                    {
                        userDao.addNumberOfArticle(cont.Author.Trim());
                    }
                    else if (cont.State == CommonConstants.STATE_CHECKED
                        && _state == CommonConstants.STATE_UNCHECK)
                    {
                        userDao.subNumberOfArticle(cont.Author.Trim());
                    }
                    cont.State = _state;
                    cont.isUniversity = _isUniversity;
                    cont.Branch = _branch;
                    cont.Year = _year;
                    cont.Score = _score;
                    cont.Tag = _tag;
                    cont.Subject = _sub;
                    cont.StickyFlg = _isSticky;
                    cont.Location = _fileContent;
                    cont.Solving = _fileSolving;
                    cont.Thumbnail = _fileThumbnail;
                    cont.HtmlPreview = _htmlPreview;
                    cont.HtmlEmbedLink = _htmlEmbed;
                    cont.Checker = _checker;

                    DB.SubmitChanges();
                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, userAdmin,
                                        BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE,
                                                                         Convert.ToString(id),
                                                                         CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, userAdmin,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_FAILED_TEMPLATE,
                                                                      Convert.ToString(id),
                                                                      CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                log.writeLog(DBHelper.strPathLogFile, userAdmin, e.Message
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
        public bool deleteContest(string _username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    IEnumerable<tblContestForUniversity> lst = from p in DB.tblContestForUniversities
                                                               where p.DeleteFlg == true
                                                               select p;
                    //File.Delete(DBHelper.strCurrentPath + inf.Location);

                    DB.tblContestForUniversities.DeleteAllOnSubmit(lst);
                    DB.SubmitChanges();

                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _username,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_SUCCESSFUL_TEMPLATE,
                                                                    "ALL DELETED ARTICLES",
                                                                    CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_FAILED_TEMPLATE,
                                                                      "ALL DELETED ARTICLES",
                                                                      CommonConstants.SQL_TABLE_CONTEST_UNIVERSITY));
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message
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
        #endregion
    }
}
