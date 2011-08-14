using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt.Admin
{
    public partial class General : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster page = (AdminMaster)Master;
            page.updateHeader("Tổng quan");

            sumUsers.Text = ltktDAO.Users.numberOfUsers().ToString();
            latestUser.Text = ltktDAO.Users.latestUser();
            sumContest.Text = ltktDAO.Contest.sumContest().ToString();
            sumEnglish.Text = ltktDAO.English.sumEnglish().ToString();
            sumInformatics.Text = ltktDAO.Informatics.sumInformatics().ToString();

        }
    }
}