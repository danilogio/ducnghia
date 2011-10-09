using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class SecurityAdminVO
    {
        private bool ischecked;

        public bool Ischecked
        {
            get { return ischecked; }
            set { ischecked = value; }
        }
        private string sReason;

        public string SReason
        {
            get { return sReason; }
            set { sReason = value; }
        }
        private string sMessage;

        public string SMessage
        {
            get { return sMessage; }
            set { sMessage = value; }
        }

    }
}
