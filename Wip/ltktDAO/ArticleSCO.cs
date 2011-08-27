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

    }
}
