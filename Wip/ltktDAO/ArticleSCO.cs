using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class ArticleSCO
    {
        private string _subject;

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        private string _class;

        public string Classes
        {
            get { return _class; }
            set { _class = value; }
        }
        private string _library;

        public string Library
        {
            get { return _library; }
            set { _library = value; }
        }
        private string _time;

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
        private string _section;

        public string Section
        {
            get { return _section; }
            set { _section = value; }
        }
        private int _currentPage;

        public int CurrentPage
        {
            get { return _currentPage; }
            set {
                _currentPage = value;
                if (_currentPage < 1)
                {
                    _currentPage = 1;
                }
                
            }
        }
        private int _totalPage;

        public int TotalPage
        {
            get { return _totalPage; }
            set { _totalPage = value; }
        }
        private int _numArticleOnPage;

        public int NumArticleOnPage
        {
            get { return _numArticleOnPage; }
            set { 
                
                _numArticleOnPage = value;
                if (_numArticleOnPage < 1)
                {
                    _numArticleOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
                }
            }
        }
        private string _leitmotif;

        public string Leitmotif
        {
            get { return _leitmotif; }
            set { _leitmotif = value; }
        }
        private int _totalRecord;

        public int TotalRecord
        {
            get { return _totalRecord; }
            set { _totalRecord = value; }
        }
        private int _firstRecord;

        public int FirstRecord
        {
            get { return _firstRecord; }
            set { _firstRecord = value; }
        }
        

    }
}
