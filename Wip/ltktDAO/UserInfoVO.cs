using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class UserInfoVO
    {
        string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
        string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        int _numArticle;

        public int NumArticle
        {
            get { return _numArticle; }
            set { _numArticle = value; }
        }
        bool _sex;

        public bool Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

    }
}
