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
        ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        ltktDAO.English englishDAO = new ltktDAO.English();
        ltktDAO.Contest contestDAO = new ltktDAO.Contest();
        ltktDAO.Users userDAO = new ltktDAO.Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminMaster page = (AdminMaster)Master;
            page.updateHeader("Tổng quan");

            sumUsers.Text = userDAO.numberOfUsers().ToString();
            latestUser.Text = userDAO.latestUser();
            sumContest.Text = contestDAO.sumContest().ToString();
            sumEnglish.Text = englishDAO.sumEnglish().ToString();
            sumInformatics.Text = informaticsDAO.sumInformatics().ToString();

        }
    }
}