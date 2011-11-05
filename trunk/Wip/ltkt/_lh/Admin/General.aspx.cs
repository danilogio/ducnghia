﻿using System;
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
                }
                else
                {
                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                    //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                    Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
                }
            }
        }
    }
}