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
        ltktDAO.Statistics statisticDAO = new ltktDAO.Statistics();
        ltktDAO.Permission permitDAO = new ltktDAO.Permission();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_GENERAL)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader("Tổng quan");
                    sumUsers.Text = userDAO.numberOfUsers().ToString();
                    latestUser.Text = userDAO.formatUsername(userDAO.latestUser());
                    latestRegistryNum.Text = statisticDAO.getValue(CommonConstants.SF_NUM_USER_REGISTRY);
                    latestLogin.Text = userDAO.getLatestLogin();
                    sumArticle.Text = statisticDAO.getValue(CommonConstants.SF_NUM_ARTICLE);
                    sumContest.Text = contestDAO.sumContest().ToString();
                    sumEnglish.Text = englishDAO.sumEnglish().ToString();
                    sumInformatics.Text = informaticsDAO.sumInformatics().ToString();
                    newsMails.Text = statisticDAO.getValue(CommonConstants.SF_NUM_NEW_EMAIL);
                    pageView.Text = statisticDAO.getValue(CommonConstants.SF_NUM_VIEWER);
                    pageViewADay.Text = statisticDAO.getValue(CommonConstants.SF_NUM_VIEWER_DAY);
                    sumDownload.Text = statisticDAO.getValue(CommonConstants.SF_NUM_DOWNLOAD_A_DAY);
                    sumUpload.Text = statisticDAO.getValue(CommonConstants.SF_NUM_UPLOAD);
                    sumCommentADay.Text = statisticDAO.getValue(CommonConstants.SF_NUM_COMMENT_A_DAY);
                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_ACCESS_DENIED;
                    Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                }
            }
        }
    }
}