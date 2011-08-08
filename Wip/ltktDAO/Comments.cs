using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class Comments
    {
        int _articleID;
        string _author;
        DateTime _posted;
        string _comment;

        public int articleID
        {
            get { return _articleID; }
            protected set { _articleID = value; }
        }

        public string author
        {
            get { return _author; }
            protected set { _author = value; }
        }

        public DateTime posted 
        {
            get { return _posted; } 
            protected set { _posted = value; } 
        }

        public string comment
        {
            get { return _comment; }
            protected set { _comment = value; }
            
        }

        public List <Comments> parseComments(string _comments)
        {
            List<Comments> lstComment = new List<Comments>();
            
            

            return lstComment;
        }
    }
}
