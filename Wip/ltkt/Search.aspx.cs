using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt
{
    public partial class Search : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        ltktDAO.English englishDAO = new ltktDAO.English();
        ltktDAO.Contest contestDAO = new ltktDAO.Contest();
        ltktDAO.Control control = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitleHeader.Text = CommonConstants.PAGE_SEARCH_NAME
                               + CommonConstants.SPACE + CommonConstants.HLINE
                               + CommonConstants.SPACE
                               + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

            resultPanel.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyWords = txtboxSearch.Text;
            int topic = Convert.ToInt32(ddlSubject.SelectedValue);
            IList<tblEnglish> lstEnglish = null;
            IList<tblContestForUniversity> lstContest = null;
            IList<tblInformatic> lstInformatics = null;
            try
            {
                // Luyện thi đại học
                if (topic == 0 || topic == 3)
                {
                    int isAll = Convert.ToInt32(ddlSearchingType.SelectedValue);
                    if (isAll == 0)
                    {
                        lstContest = contestDAO.listContest(keyWords);
                    }
                    else
                    {
                        //int branch = 0;//Convert.ToInt32(ddlBranch.SelectedValue);
                        bool isUniversity = Boolean.Parse(ddlTypeContest.SelectedValue);
                        int year = Convert.ToInt32(ddlYear.SelectedValue);

                        lstContest = contestDAO.listContest(isUniversity, year);
                    }
                }

                // Tin học
                if (topic == 1 || topic == 3)
                {
                    lstInformatics = informaticsDAO.listInformatics(keyWords);
                }

                // Anh văn
                if (topic == 2 || topic == 3)
                {
                    lstEnglish = englishDAO.listEnglish(keyWords);
                }
            }
            catch (Exception ex)
            {
                //Write to log
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            resultPanel.Visible = true;

            int idx = 0;
            lblResult.Text = "<p><ul>";
            if (lstContest != null)
            {
                for (idx = 0; idx < lstContest.Count(); ++idx)
                {
                    lblResult.Text =  BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK, 
                                                                        CommonConstants.SEC_UNIVERSITY_CODE, 
                                                                        lstContest[idx].ID.ToString(), 
                                                                        lstContest[idx].Title);
                    lblResult.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, 
                                                                        lblResult.Text);
                }
            }

            if (lstEnglish != null)
            {
                for (idx = 0; idx < lstEnglish.Count(); ++idx)
                {
                    lblResult.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                                        CommonConstants.SEC_ENGLISH_CODE,
                                                                        lstContest[idx].ID.ToString(),
                                                                        lstContest[idx].Title);
                    lblResult.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG,
                                                                        lblResult.Text);
                }
            }

            if (lstInformatics != null)
            {
                for (idx = 0; idx < lstInformatics.Count(); ++idx)
                {
                    lblResult.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                                        CommonConstants.SEC_INFORMATICS_CODE,
                                                                        lstContest[idx].ID.ToString(),
                                                                        lstContest[idx].Title);
                    lblResult.Text = BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG,
                                                                        lblResult.Text);
                }
            }
            lblResult.Text += "</ul></p>";

            if (lblResult.Text == "<p><ul></ul></p>")
            {
                lblResult.Text = CommonConstants.MSG_I_SEARCH_NOT_FOUND;
            }

        }
    }
}