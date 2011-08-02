<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["Viewer"] = 0;
        Application["Domain"] = "www.luyenthikinhte.com";
        Application["UserOnline"] = 0;
        Application["TotalOnline"] = 0;
        //Session.Timeout = 10;

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Application.Lock();
        Application["Viewer"] = (Int32) Application ["Viewer"] + 1;
        Application["TotalOnline"] = (Int32)Application["TotalOnline"] + 1;
        Application.UnLock();

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();
        if ((Int32)(Application["TotalOnline"]) >= 0)
        {
            Application["TotalOnline"] = (Int32)Application["TotalOnline"] - 1;
        }
        Application.UnLock();
    }
       
</script>
