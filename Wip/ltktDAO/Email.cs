using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class Email
    {
        string _host;
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }
        
        string _hostPort;
        public string HostPort
        {
            get { return _hostPort; }
            set { _hostPort = value; }
        }

        string _smptServer;
        public string SmptServer
        {
            get { return _smptServer; }
            set { _smptServer = value; }
        }

        string _smptPort;
        public string SmptPort
        {
            get { return _smptPort; }
            set { _smptPort = value; }
        }

        string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
