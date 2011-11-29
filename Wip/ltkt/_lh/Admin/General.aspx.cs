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
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();
        ltktDAO.Contact contactDAO = new ltktDAO.Contact();
        ltktDAO.Ads adsDAO = new ltktDAO.Ads();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_GENERAL)
                    || userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    if (adminDAO.isON(CommonConstants.AF_UNDERCONTRUCTION))
                    {
                        string message = adminDAO.getReason(CommonConstants.AF_UNDERCONTRUCTION);
                        if (BaseServices.isNullOrBlank(message))
                        {
                            message = CommonConstants.MSG_I_UNDERCONSTRUCTION;
                        }
                        liStatusMessage.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_MARQUEE_TAG,
                                                                   CommonConstants.CS_ANNOUCEMENT_BGCOLOR,
                                                                   CommonConstants.CS_ANNOUCEMENT_TEXTCOLOR,
                                                                  CommonConstants.TXT_INFORM + CommonConstants.SPACE + message);
                        statusMessagePanel.Visible = true;
                    }
                    if (Page.IsPostBack)
                    {
                        return;
                    }
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
                    sumStickyEL.Text = statisticDAO.getValue(CommonConstants.SF_NUM_STICKED_ON_EL);
                    sumStickyIT.Text = statisticDAO.getValue(CommonConstants.SF_NUM_STICKED_ON_IT);
                    sumStickyUni.Text = statisticDAO.getValue(CommonConstants.SF_NUM_STICKED_ON_UNI);
                    int numAdv = BaseServices.convertStringToInt(statisticDAO.getValue(CommonConstants.SF_NUM_NEW_ADV_CONTACT));
                    if (numAdv > 0)
                    {
                        string url = CommonConstants.PAGE_ADMIN_ADS
                                        + CommonConstants.ADD_PARAMETER
                                        + CommonConstants.REQ_ACTION
                                        + CommonConstants.EQUAL
                                        + CommonConstants.ACT_SEARCH
                                        + CommonConstants.AND
                                        + CommonConstants.REQ_KEY
                                        + CommonConstants.EQUAL
                                        + CommonConstants.STATE_UNCHECK;
                        newAdsContact.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG, url, numAdv.ToString());
                    }
                    
                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                    //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }
            }
        }
        public void btnStatistic_Click(object sender, EventArgs e)
        {
            //count total users
            int total = userDAO.numberOfUsers();
            statisticDAO.setValue(CommonConstants.SF_NUM_USER, total.ToString());
            sumUsers.Text = total.ToString();
            //get latest user
            latestUser.Text = userDAO.formatUsername(userDAO.latestUser());
            //count total new users
            total = userDAO.sumNewRegisterUser();
            statisticDAO.setValue(CommonConstants.SF_NUM_USER_REGISTRY, total.ToString());
            latestRegistryNum.Text = total.ToString();
            //get latest login user
            latestLogin.Text = userDAO.getLatestLogin();
            //total english articles
            int sumEngLishArticle = englishDAO.sumEnglish();
            sumEnglish.Text = sumEngLishArticle.ToString();
            statisticDAO.setValue(CommonConstants.SF_NUM_ARTICLE_ON_EL, sumEngLishArticle.ToString());
            //total uni article
            int sumContestArticle = contestDAO.sumContest();
            sumContest.Text = sumContestArticle.ToString();
            statisticDAO.setValue(CommonConstants.SF_NUM_ARTICLE_ON_UNI, sumContestArticle.ToString());
            //total informatics article
            int sumInfArticle = informaticsDAO.sumInformatics();
            sumInformatics.Text = sumInfArticle.ToString();
            statisticDAO.setValue(CommonConstants.SF_NUM_ARTICLE_ON_IT, sumInfArticle.ToString());
            //total articles
            total = sumInfArticle + sumContestArticle + sumEngLishArticle;
            statisticDAO.setValue(CommonConstants.SF_NUM_ARTICLE, total.ToString());
            sumArticle.Text = total.ToString();
            //total stickied english article 
            total = englishDAO.countStickyArticle();
            statisticDAO.setValue(CommonConstants.SF_NUM_STICKED_ON_EL, total.ToString());
            sumStickyEL.Text = total.ToString();
            //total stickied informatics article
            total = informaticsDAO.countStickyInfArticle();
            statisticDAO.setValue(CommonConstants.SF_NUM_STICKED_ON_IT, total.ToString());
            sumStickyIT.Text = total.ToString();
            //total stickied contest article
            total = contestDAO.countStickyArticle();
            statisticDAO.setValue(CommonConstants.SF_NUM_STICKED_ON_UNI, total.ToString());
            sumStickyUni.Text = total.ToString();
            //total new email
            total = contactDAO.sumUnread();
            statisticDAO.setValue(CommonConstants.SF_NUM_NEW_EMAIL, total.ToString());
            newsMails.Text = total.ToString();
            //page view
            if(Application["Viewer"] != null) {
                double totalViewer = (Int32) Application["Viewer"];
                pageView.Text = totalViewer.ToString();
                statisticDAO.setValue(CommonConstants.SF_NUM_VIEWER, totalViewer.ToString());
            } else {
                pageView.Text = statisticDAO.getValue(CommonConstants.SF_NUM_VIEWER);
            }
            //total download
            sumDownload.Text = statisticDAO.getValue(CommonConstants.SF_NUM_DOWNLOAD_A_DAY);
            //total upload
            sumUpload.Text = statisticDAO.getValue(CommonConstants.SF_NUM_UPLOAD);
            //total comment
            sumCommentADay.Text = statisticDAO.getValue(CommonConstants.SF_NUM_COMMENT_A_DAY);
            //total new advertisement
            total = adsDAO.countAdsListByState(CommonConstants.STATE_UNCHECK);
            if (total > 0)
            {
                string url = CommonConstants.PAGE_ADMIN_ADS
                                + CommonConstants.ADD_PARAMETER
                                + CommonConstants.REQ_ACTION
                                + CommonConstants.EQUAL
                                + CommonConstants.ACT_SEARCH
                                + CommonConstants.AND
                                + CommonConstants.REQ_KEY
                                + CommonConstants.EQUAL
                                + CommonConstants.STATE_UNCHECK;
                newAdsContact.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_A_TAG, url, total.ToString());
            }
            
        }
    }
    
}