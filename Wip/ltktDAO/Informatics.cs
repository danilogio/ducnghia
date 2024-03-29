﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.IO;
using System.Windows.Forms;

namespace ltktDAO
{
    public class Informatics
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        EventLog log = new EventLog();
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);

        #region Property
        #region Get Property
        /// <summary>
        /// lấy tiêu đề
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getTitle(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Title.Trim(); ;
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// Lấy điểm checker
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int getScore(int ID)
        {
            //LTEDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return (int)lst.ElementAt(0).Score;
            }

            return 0;
        }

        /// <summary>
        /// Lấy chapeau
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getChapeau(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Chapeau.Trim();
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// lấy loại bài viết
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getType(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            int type = lst.ElementAt(0).Type;
            string strType = "";
            switch (type)
            {
                case CommonConstants.AT_LECTURE:
                    {
                        strType = CommonConstants.AT_LECTURE_NAME;
                        break;
                    }
                case CommonConstants.AT_PRACTISE:
                    {
                        strType = CommonConstants.AT_PRACTISE_NAME;
                        break;
                    }
                case CommonConstants.AT_EXAM:
                    {
                        strType = CommonConstants.AT_EXAM_NAME;
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
        public string getContent(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Contents.Trim();
            }

            return CommonConstants.BLANK;
        }

        /// <summary>
        /// lấy tên tác giả
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getAuthor(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblUser> lst = from author in DB.tblUsers
                                       join record in DB.tblInformatics on author.Username equals record.Author
                                       where record.ID == ID
                                       select author;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).DisplayName.Trim();
            }

            return CommonConstants.BLANK;
        }


        /// <summary>
        /// Lấy ngày đăng
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DateTime getPosted(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public string getState(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
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
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return (int)lst.ElementAt(0).Point;
            }

            return 0;
        }

        /// <summary>
        /// lấy tag
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string getTag(int ID)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == ID
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Tag.Trim();
            }

            return null;
        }

        /// <summary>
        /// Lay comment
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public string getComment(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == _id
                                             select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Comment.Trim();
            }

            return null;
        }

        /// <summary>
        /// Lấy bài viết theo id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public tblInformatic getInformatic(int _id)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where record.ID == _id && record.DeleteFlg == false
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
        /// get max point article
        /// </summary>
        /// <returns></returns>
        public tblInformatic getMaxPoint()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from p in DB.tblInformatics
                                             where p.Point == DB.tblInformatics.Max(p2 => p2.Point) 
                                             && p.DeleteFlg == false
                                             orderby p.Posted descending
                                             select p;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(BaseServices.random(0, lst.Count()));
            }
            return null;
        }
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
                                              where p.Leitmotif >= _mintype
                                                    && p.Leitmotif <= _maxtype
                                                    && p.State != CommonConstants.STATE_UNCHECK
                                                    && p.StickyFlg == false
                                                    && p.DeleteFlg == false
                                              orderby p.Posted descending
                                              select p).Take(_numRecord);
            return lst;
        }

        /// <summary>
        /// Get amount of latest sticky article by posted date with range type
        /// </summary>
        /// <param name="numRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblInformatic> getLatestStickyArticleByPostedDate(int _mintype, int _maxtype, int _numRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (_numRecord <= 0)
                _numRecord = 1;

            IEnumerable<tblInformatic> lst = (from p in DB.tblInformatics
                                              where p.Leitmotif >= _mintype
                                                    && p.Leitmotif <= _maxtype
                                                    && p.State != CommonConstants.STATE_UNCHECK
                                                    && p.StickyFlg == true
                                                    && p.DeleteFlg == false
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
                                              where p.Leitmotif == _type
                                                    && p.State != CommonConstants.STATE_UNCHECK
                                                    && p.StickyFlg == false
                                                    && p.DeleteFlg == false
                                              orderby p.Posted descending
                                              select p).Take(_numRecord);
            return lst;
        }

        /// <summary>
        /// Get amount of latest sticky article by posted date with match type
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_numRecord"></param>
        /// <returns></returns>
        public IEnumerable<tblInformatic> getLatestStickyArticleByPostedDate(int _type, int _numRecord)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (_numRecord <= 0)
                _numRecord = 1;

            IEnumerable<tblInformatic> lst = (from p in DB.tblInformatics
                                              where p.Leitmotif == _type
                                                    && p.State != CommonConstants.STATE_UNCHECK
                                                    && p.StickyFlg == true
                                                    && p.DeleteFlg == false
                                              orderby p.Posted descending
                                              select p).Take(_numRecord);
            return lst;
        }
        /// <summary>
        /// get all article has delete flag is true
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblInformatic> getDeletedArticle()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblInformatic> lst = from p in DB.tblInformatics
                                              where  p.DeleteFlg == true
                                              select p;
            return lst;
        }

        public int countTotalRecord(ArticleSCO articleSCO)
        {
            int num = 0;
            int start = 0;
            int end = 0;
            int year = BaseServices.getYearFromString(articleSCO.Time);
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            locateArticleIndex(articleSCO, out start, out end);
            /*if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE)
            {
                start = CommonConstants.AT_IT_OFFICE_START;
                end = CommonConstants.AT_IT_OFFICE_END;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_SIMPLE)
            {
                start = CommonConstants.AT_IT_SIMPLE_TIP;
                end = CommonConstants.AT_IT_SIMPLE_TIP;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_ADVANCE)
            {
                start = CommonConstants.AT_IT_ADVANCE_TIP;
                end = CommonConstants.AT_IT_ADVANCE_TIP;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_WORD)
            {
                start = CommonConstants.AT_IT_OFFICE_WORD;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_EXCEL)
            {
                start = CommonConstants.AT_IT_OFFICE_EXCEL;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_PP)
            {
                start = CommonConstants.AT_IT_OFFICE_POWERPOINT;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_ACCESS)
            {
                start = CommonConstants.AT_IT_OFFICE_ACCESS;
                end = start;
            }
            else */
            if (articleSCO.Leitmotif == CommonConstants.ALL)
            {
                return (from p in DB.tblInformatics
                        where p.Posted.Year <= year
                                && p.State != CommonConstants.STATE_UNCHECK
                                && p.DeleteFlg == false
                        select p).Count();

            }
            if (start > 0 && end > 0 && end >= start)
            {
                num = (from p in DB.tblInformatics
                       where p.Posted.Year <= year
                         && p.State != CommonConstants.STATE_UNCHECK
                         && p.Leitmotif >= start
                         && p.Leitmotif <= end
                         && p.DeleteFlg == false
                       select p).Count();
            }
            return num;
        }
        public IEnumerable<tblInformatic> searchArticle(ArticleSCO articleSCO)
        {
            IEnumerable<tblInformatic> lst1 = null;
            if (articleSCO.CurrentPage == 1)
            {
                lst1 = searchLatestStickyArticle(articleSCO);
            }
            if (lst1 != null)
            {
                int remain = articleSCO.NumArticleOnPage - lst1.Count();
                articleSCO.NumArticleOnPage = remain;
            }
            IEnumerable<tblInformatic> lst2 = searchLatestArticle(articleSCO);
            if (lst1 != null)
            {
                if (lst1.Count() > 0)
                {
                    List<tblInformatic> l1 = lst1.ToList();
                    l1.AddRange(lst2.ToList());
                    lst2 = l1;
                }
            }
            return lst2;
        }
        public IEnumerable<tblInformatic> searchLatestArticle(ArticleSCO articleSCO)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = null;
            int start = 0;
            int end = 0;
            int year = BaseServices.getYearFromString(articleSCO.Time);
            locateArticleIndex(articleSCO, out start, out end);
            /*if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE)
            {
                start = CommonConstants.AT_IT_OFFICE_START;
                end = CommonConstants.AT_IT_OFFICE_END;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_SIMPLE)
            {
                start = CommonConstants.AT_IT_SIMPLE_TIP;
                end = CommonConstants.AT_IT_SIMPLE_TIP;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_ADVANCE)
            {
                start = CommonConstants.AT_IT_ADVANCE_TIP;
                end = CommonConstants.AT_IT_ADVANCE_TIP;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_WORD)
            {
                start = CommonConstants.AT_IT_OFFICE_WORD;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_EXCEL)
            {
                start = CommonConstants.AT_IT_OFFICE_EXCEL;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_PP)
            {
                start = CommonConstants.AT_IT_OFFICE_POWERPOINT;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_ACCESS)
            {
                start = CommonConstants.AT_IT_OFFICE_ACCESS;
                end = start;
            }*/

            if (articleSCO.Leitmotif == CommonConstants.ALL)
            {
                return (from p in DB.tblInformatics
                        where p.Posted.Year <= year
                                && p.State != CommonConstants.STATE_UNCHECK
                                && p.StickyFlg == false
                                && p.DeleteFlg == false
                        select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);

            }
            if (start > 0 && end > 0 && end >= start)
            {
                lst = (from p in DB.tblInformatics
                       where p.Posted.Year <= year
                         && p.State != CommonConstants.STATE_UNCHECK
                         && p.Leitmotif >= start
                         && p.Leitmotif <= end
                         && p.StickyFlg == false
                         && p.DeleteFlg == false
                       select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);
            }
            return lst;
        }
        public IEnumerable<tblInformatic> searchLatestStickyArticle(ArticleSCO articleSCO)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = null;
            int start = 0;
            int end = 0;
            int year = BaseServices.getYearFromString(articleSCO.Time);
            locateArticleIndex(articleSCO, out start, out end);

            if (articleSCO.Leitmotif == CommonConstants.ALL)
            {
                return (from p in DB.tblInformatics
                        where p.Posted.Year <= year
                                && p.State != CommonConstants.STATE_UNCHECK
                                && p.StickyFlg == true
                                && p.DeleteFlg == false
                        select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);

            }
            if (start > 0 && end > 0 && end >= start)
            {
                lst = (from p in DB.tblInformatics
                       where p.Posted.Year <= year
                         && p.State != CommonConstants.STATE_UNCHECK
                         && p.Leitmotif >= start
                         && p.Leitmotif <= end
                         && p.StickyFlg == true
                         && p.DeleteFlg == false
                       select p).Skip(articleSCO.FirstRecord).Take(articleSCO.NumArticleOnPage);
            }
            return lst;
        }
        private void locateArticleIndex(ArticleSCO articleSCO, out int start, out int end)
        {
            start = 0;
            end = 0;
            if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE)
            {
                start = CommonConstants.AT_IT_OFFICE_START;
                end = CommonConstants.AT_IT_OFFICE_END;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_TIP_SIMPLE)
            {
                start = CommonConstants.AT_IT_SIMPLE_TIP_START;
                end = CommonConstants.AT_IT_SIMPLE_TIP_END;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_TIP_ADVANCE)
            {
                start = CommonConstants.AT_IT_ADVANCE_TIP_START;
                end = CommonConstants.AT_IT_ADVANCE_TIP_END;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_WORD)
            {
                start = CommonConstants.AT_IT_OFFICE_WORD;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_EXCEL)
            {
                start = CommonConstants.AT_IT_OFFICE_EXCEL;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_PP)
            {
                start = CommonConstants.AT_IT_OFFICE_POWERPOINT;
                end = start;
            }
            else if (articleSCO.Leitmotif == CommonConstants.PARAM_IT_OFFICE_ACCESS)
            {
                start = CommonConstants.AT_IT_OFFICE_ACCESS;
                end = start;
            }
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
            string _author, DateTime _posted, int _leitmotif, string _location, string _tag, string _folderID)
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
                    record.Leitmotif = _leitmotif;
                    record.Author = _author;
                    record.Posted = _posted;
                    record.Point = 0;
                    record.State = CommonConstants.STATE_UNCHECK;
                    record.Location = _location;
                    record.Tag = _tag;
                    record.StickyFlg = false;
                    record.Score = 0;
                    record.DeleteFlg = false;
                    record.FolderID = _folderID;

                    DB.tblInformatics.InsertOnSubmit(record);
                    DB.SubmitChanges();
                    ts.Complete();

                    ltktDAO.Statistics statisticDAO = new ltktDAO.Statistics();
                    statisticDAO.add(CommonConstants.SF_NUM_UPLOAD, CommonConstants.CONST_ONE);

                    log.writeLog(DBHelper.strPathLogFile, record.Author,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                    _title,
                                                                    CommonConstants.SQL_TABLE_INFORMATICS));
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

        //public Boolean insertInformatic(string _title, int _type, string _content,
        //    string _author, DateTime _posted, string _location, string _tag)
        //{
        //    return false;
        //}

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
                    if (informatic != null)
                    {
                        informatic.Title = update.Title;
                        informatic.Type = update.Type;
                        informatic.Chapeau = update.Chapeau;
                        informatic.Contents = update.Contents;
                        informatic.Author = update.Author;
                        informatic.Posted = update.Posted;
                        ltktDAO.Users userDao = new ltktDAO.Users();
                        if (informatic.State == CommonConstants.STATE_UNCHECK
                        && update.State == CommonConstants.STATE_CHECKED)
                        {
                            userDao.addNumberOfArticle(informatic.Author.Trim());
                        }
                        else if (informatic.State == CommonConstants.STATE_CHECKED
                        && update.State == CommonConstants.STATE_UNCHECK)
                        {
                            userDao.subNumberOfArticle(informatic.Author.Trim());
                        }
                        informatic.State = update.State;
                        informatic.Tag = update.Tag;
                        informatic.HtmlEmbedLink = update.HtmlEmbedLink;
                        informatic.HtmlPreview = update.HtmlPreview;
                        //informatic.DeleteFlg = false;
                        informatic.Checker = update.Checker;
                        informatic.Leitmotif = update.Leitmotif;
                        informatic.StickyFlg = update.StickyFlg;
                        informatic.Comment = update.Comment;
                        informatic.Thumbnail = update.Thumbnail;
                        informatic.Location = update.Location;

                        DB.SubmitChanges();
                    }
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
                log.writeLog(DBHelper.strPathLogFile, currentUsername, e.Message
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
        /// Tổng số các bài viết về chủ đề tin học
        /// </summary>
        /// <returns></returns>
        public int sumInformatics()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            return (from informatics in DB.tblInformatics
                    where informatics.DeleteFlg == false
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
                    informatic.Comment += "<br /><br />;";

                    DB.SubmitChanges();
                    ts.Complete();

                    //Cho cái này vào bị lỗi liên tục
                    //2011-09-27 16:09 tktung bỏ
                    //ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                    //statDAO.add(CommonConstants.SF_NUM_COMMENT_A_DAY, "1");
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, currentUsername, e.Message
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

        public Boolean Like(int _id)
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

        public Boolean Dislike(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var informatic = DB.tblInformatics.Single(info => info.ID == _id);
                    if (informatic.Point > 0)
                    {
                        informatic.Point -= 1;
                    }
                    informatic.State = CommonConstants.STATE_BAD; // Bad

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
        public IList<tblInformatic> getRelativeByType(int _type, int _numberRecords)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (_numberRecords < 1)
                _numberRecords = CommonConstants.DEFAULT_NUMBER_RECORD_RELATIVE;
            IEnumerable<tblInformatic> lst = (from record in DB.tblInformatics
                                              where record.Type == _type && record.DeleteFlg == false
                                              select record).Take(_numberRecords);

            return lst.ToList();
        }

        public IList<tblInformatic> listInformatics(string _keyword)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblInformatic> lst = from record in DB.tblInformatics
                                             where (record.Title.Contains(_keyword) ||
                                                         record.Tag.Contains(_keyword) ||
                                                         record.Contents.Contains(_keyword))
                                                         && record.DeleteFlg == false
                                             select record;

            return lst.ToList();
        }

        public int countInf()
        {
            return (from r in DB.tblInformatics where r.DeleteFlg == false select r).Count();
        }
        public int countInfListByState(int state)
        {
            int num = 0;
            num = (from r in DB.tblInformatics
                   where r.State == state
                   && r.DeleteFlg == false
                   select r).Count();

            return num;
        }
        public int countInfByLeitmotif(int leitmotif)
        {
            int num = (from r in DB.tblInformatics
                       where r.Leitmotif == leitmotif
                       && r.DeleteFlg == false
                       select r).Count();

            return num;
        }

        public int countInfListByStateAndLeimotif(int leitmotif, int state)
        {
            int num = (from r in DB.tblInformatics
                       where r.Leitmotif == leitmotif 
                       && r.State == state
                       && r.DeleteFlg == false
                       select r).Count();

            return num;
        }
        /// <summary>
        /// count sticky article
        /// </summary>
        /// <returns></returns>
        public int countStickyInfArticle()
        {
            int num = (from p in DB.tblInformatics
                      where p.DeleteFlg == false
                      && p.StickyFlg == true
                      select p).Count();
            return num;
        }
        /// <summary>
        /// count sticky informatics article
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public int countStickyInfArticleByState(int state)
        {
            int num = (from p in DB.tblInformatics
                       where p.DeleteFlg == false
                       && p.State == state
                       && p.StickyFlg == true
                       select p).Count();
            return num;
        }
        /// <summary>
        /// count article matching with keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public int countArticles(string keyword)
        {
            int num = (from p in DB.tblInformatics
                       where p.DeleteFlg == false
                       && (p.Title.Contains(keyword) || p.Tag.Contains(keyword))
                       select p).Count();
            return num;
        }
        /// <summary>
        /// search article is matched with keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<tblInformatic> searchArticles(string keyword, int start, int count)
        {
            IEnumerable<tblInformatic> lst = (from p in DB.tblInformatics
                       where p.DeleteFlg == false
                       && (p.Title.Contains(keyword) || p.Tag.Contains(keyword))
                       select p).Skip(start).Take(count);
            return lst;
        }
        /// <summary>
        /// get all sticky article
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblInformatic> getStickyArticles(int start, int count)
        {
            IEnumerable<tblInformatic> lst = (from p in DB.tblInformatics
                                             where p.DeleteFlg == false
                                             && p.StickyFlg == true
                                             orderby p.Posted descending
                                             select p).Skip(start).Take(count);
            return lst;
        }
        /// <summary>
        /// get sticky article by state
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<tblInformatic> getStickyArticlesByState(int state, int start, int count)
        {
            IEnumerable<tblInformatic> lst = (from p in DB.tblInformatics
                                              where p.DeleteFlg == false
                                              && p.StickyFlg == true
                                              && p.State == state
                                              orderby p.Posted descending
                                              select p).Skip(start).Take(count);
            return lst;
        }
        public IEnumerable<tblInformatic> fetchInfList(int start, int count)
        {
            IEnumerable<tblInformatic> lst = (from r in DB.tblInformatics
                                              where r.DeleteFlg == false
                                              orderby r.Posted descending
                                              select r).Skip(start).Take(count);

            return lst;
        }

        public IEnumerable<tblInformatic> fetchInfList(int state, int start, int count)
        {
            IEnumerable<tblInformatic> lst = (from r in DB.tblInformatics
                                              where r.State == state 
                                              && r.DeleteFlg == false
                                              orderby r.Posted descending
                                              select r).Skip(start).Take(count);

            return lst;
        }

        public IEnumerable<tblInformatic> fetchInfListWithLeitmotif(int leitmotif, int start, int count)
        {
            IEnumerable<tblInformatic> lst = (from r in DB.tblInformatics
                                              where r.Leitmotif == leitmotif
                                              && r.DeleteFlg == false
                                              orderby r.Posted descending
                                              select r).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblInformatic> fetchInfList(int leitmotif, int state, int start, int count)
        {
            IEnumerable<tblInformatic> lst = (from r in DB.tblInformatics
                                              where r.Leitmotif == leitmotif 
                                              && r.State == state
                                              && r.DeleteFlg == false
                                              orderby r.Posted descending
                                              select r).Skip(start).Take(count);

            return lst;
        }
        public bool isState(int _id, int _state)
        {
            IEnumerable<tblInformatic> lst = from p in DB.tblInformatics
                                             where p.ID == _id
                                             select p;
            if (lst.Count() > 0)
            {
                if (lst.ElementAt(0).State == _state)
                {
                    return true;
                }
            }
            return false;
        }

        public string getName(int leimotif)
        {
            switch (leimotif)
            {
                case CommonConstants.AT_IT_OFFICE_WORD:
                    {
                        return CommonConstants.AT_IT_OFFICE_WORD_NAME;
                    }
                case CommonConstants.AT_IT_OFFICE_POWERPOINT:
                    {
                        return CommonConstants.AT_IT_OFFICE_POWERPOINT_NAME;
                    }
                case CommonConstants.AT_IT_OFFICE_EXCEL:
                    {
                        return CommonConstants.AT_IT_OFFICE_EXCEL_NAME;
                    }
                case CommonConstants.AT_IT_OFFICE_ACCESS:
                    {
                        return CommonConstants.AT_IT_OFFICE_ACCESS_NAME;
                    }
                case CommonConstants.AT_IT_ADVANCE_TIP:
                    {
                        return CommonConstants.AT_IT_ADVANCE_TIP_NAME;
                    }
                case CommonConstants.AT_IT_SIMPLE_TIP:
                    {
                        return CommonConstants.AT_IT_SIMPLE_TIP_NAME;
                    }
                default:
                    {
                        return CommonConstants.AT_UNCLASSIFIED_NAME;
                    }

            }
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
                    var inf = DB.tblInformatics.Single(a => a.ID == _id);
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
                                                                    CommonConstants.SQL_TABLE_INFORMATICS));
                
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_FAILED_TEMPLATE,
                                                                      _id.ToString(),
                                                                      CommonConstants.SQL_TABLE_INFORMATICS));
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
        /// count number of article is deleted
        /// </summary>
        /// <returns></returns>
        public int countDeletedArticles()
        {
            int num = (from p in DB.tblInformatics
                      where p.DeleteFlg == true
                      select p).Count();
            return num;
        }
        public bool deleteInf(string _username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    IEnumerable<tblInformatic> lst = from p in DB.tblInformatics
                                                     where p.DeleteFlg == true
                                                     select p;
                    //File.Delete(DBHelper.strCurrentPath + inf.Location);

                    DB.tblInformatics.DeleteAllOnSubmit(lst);
                    DB.SubmitChanges();

                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _username,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_SUCCESSFUL_TEMPLATE,
                                                                    "all deleted Article",
                                                                    CommonConstants.SQL_TABLE_INFORMATICS));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_FAILED_TEMPLATE,
                                                                      "all deleted Article",
                                                                      CommonConstants.SQL_TABLE_INFORMATICS));
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
