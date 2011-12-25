using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ltktDAO;

namespace ltkt
{
    public partial class Home : System.Web.UI.Page
    {
        private EventLog log = new EventLog();
        private ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        private ltktDAO.English englishDAO = new ltktDAO.English();
        private ltktDAO.Contest contestDAO = new ltktDAO.Contest();
        private ltktDAO.Control controlDAO = new ltktDAO.Control();
        private ltktDAO.News newsDAO = new ltktDAO.News();
        private ltktDAO.Statistics statisDAO = new ltktDAO.Statistics();
        private int numberArtOnTab = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
        private int numberStickyArtOnTab = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblWelcomeTitle.Text = controlDAO.getNameString(CommonConstants.CF_WELCOME_TEXT);
                lblWelcomeText.Text = controlDAO.getValueString(CommonConstants.CF_WELCOME_TEXT);

                liTitle.Text = CommonConstants.PAGE_HOME_NAME + CommonConstants.SPACE
                    + CommonConstants.HLINE + CommonConstants.SPACE
                    + controlDAO.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
                //init
                numberArtOnTab = controlDAO.getValueByInt(CommonConstants.CF_NUM_ARTICLE_ON_TAB);
                numberStickyArtOnTab = controlDAO.getValueByInt(CommonConstants.CF_NUM_ARTICLE_STICKY);
                lNumUni.Text = statisDAO.getValue(CommonConstants.SF_NUM_ARTICLE_ON_UNI).ToString()
                                + CommonConstants.SPACE
                                + CommonConstants.TXT_ARTICLE_NAME;
                lNumEL.Text = statisDAO.getValue(CommonConstants.SF_NUM_ARTICLE_ON_EL).ToString()
                                + CommonConstants.SPACE
                                + CommonConstants.TXT_ARTICLE_NAME; ;
                lNumIT.Text = statisDAO.getValue(CommonConstants.SF_NUM_ARTICLE_ON_IT).ToString()
                                + CommonConstants.SPACE
                                + CommonConstants.TXT_ARTICLE_NAME; ;
                
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message 
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink );
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }

        }

        public string loadDataForUniversityArticles()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IList<tblContestForUniversity> items1 = null;
                IEnumerable<tblContestForUniversity> lst1 = contestDAO.getStickyArticlebyPostedDay(BaseServices.min(numberArtOnTab, 
                                                                                                                    numberStickyArtOnTab));
                int remain = 0;
                if (lst1 != null)
                {
                    remain = lst1.Count();
                    items1 = lst1.ToList();
                }
                IEnumerable<tblContestForUniversity> lst2 = contestDAO.getLatestArticleByPostedDate(numberArtOnTab - remain);
                
                IList<tblContestForUniversity> items2 = lst2.ToList();

                if (items1 != null)
                {
                    if (items1.Count > 0)
                    {

                        foreach (var item in items1)
                        {
                            data += buildExamLessonForUniversity(item);
                        }
                    }
                }
                if (items2.Count > 0)
                {
                    foreach (var item in items2)
                    {

                        data += buildExamLessonForUniversity(item);

                    }
                }
                if (data != CommonConstants.BLANK)
                {
                    data += CommonConstants.TEMP_BR_TAG
                       + BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS,
                                                           CommonConstants.CSS_REFERLINK,
                                                           BaseServices.createMsgByTemplate(CommonConstants.TEMP_UNI_LINK,
                                                                                           CommonConstants.ALL,
                                                                                           CommonConstants.NOW,
                                                                                           CommonConstants.PAGE_NUMBER_FIRST,
                                                                                           CommonConstants.TXT_VIEW_MORE));
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        /// <summary>
        /// load data for Lecture Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForITOffice()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IList<tblInformatic> items1 = null;
                IEnumerable<tblInformatic> lst1 = informaticsDAO.getLatestStickyArticleByPostedDate(CommonConstants.AT_IT_OFFICE_START, 
                                                                                                    CommonConstants.AT_IT_OFFICE_END, 
                                                                                                    BaseServices.min(numberArtOnTab, 
                                                                                                                    numberStickyArtOnTab));
                int remain = 0;
                if (lst1 != null)
                {
                    remain = lst1.Count();
                    items1 = lst1.ToList();
                }
                IEnumerable<tblInformatic> lst2 = informaticsDAO.getLatestArticleByPostedDate(CommonConstants.AT_IT_OFFICE_START, 
                                                                                                CommonConstants.AT_IT_OFFICE_END, 
                                                                                               numberArtOnTab - remain);
                IList<tblInformatic> items2 = lst2.ToList();
                if (items1 != null)
                {
                    if (items1.Count > 0)
                    {
                        data += loadDetailsForITArticles(items1);
                    }
                }
                if (items2.Count > 0)
                {
                    data += loadDetailsForITArticles(items2);
                }
                if (!BaseServices.isNullOrBlank(data))
                {
                    data += CommonConstants.TEMP_BR_TAG
                       + BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS,
                                                           CommonConstants.CSS_REFERLINK,
                                                           BaseServices.createMsgByTemplate(CommonConstants.TEMP_INFORMATICS_LINK,
                                                                                           CommonConstants.PARAM_IT_OFFICE,
                                                                                           CommonConstants.NOW,
                                                                                           CommonConstants.PAGE_NUMBER_FIRST,
                                                                                           CommonConstants.TXT_VIEW_MORE));
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        /// <summary>
        /// load data for Practise Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForITTipSimple()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IList<tblInformatic> items1 = null;
                IEnumerable<tblInformatic> lst1 = informaticsDAO.getLatestStickyArticleByPostedDate(CommonConstants.AT_IT_SIMPLE_TIP,
                                                                                                    BaseServices.min(numberArtOnTab,
                                                                                                                    numberStickyArtOnTab));
                int remain = 0;
                if (lst1 != null)
                {
                    remain = lst1.Count();
                    items1 = lst1.ToList();
                }
                IEnumerable<tblInformatic> lst2 = informaticsDAO.getLatestArticleByPostedDate(CommonConstants.AT_IT_SIMPLE_TIP,
                                                                                               numberArtOnTab - remain);
                IList<tblInformatic> items2 = lst2.ToList();
                if (items1 != null)
                {
                    if (items1.Count > 0)
                    {
                        data += loadDetailsForITArticles(items1);
                    }
                }
                if (items2.Count > 0)
                {
                    data += loadDetailsForITArticles(items2);
                }
                if (!BaseServices.isNullOrBlank(data))
                {
                    data += CommonConstants.TEMP_BR_TAG
                       + BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS,
                                                           CommonConstants.CSS_REFERLINK,
                                                           BaseServices.createMsgByTemplate(CommonConstants.TEMP_INFORMATICS_LINK,
                                                                                           CommonConstants.PARAM_IT_TIP_SIMPLE,
                                                                                           CommonConstants.NOW,
                                                                                           CommonConstants.PAGE_NUMBER_FIRST,
                                                                                           CommonConstants.TXT_VIEW_MORE));
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        /// <summary>
        /// Load data for Examination Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForITTipAdvance()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IList<tblInformatic> items1 = null;
                IEnumerable<tblInformatic> lst1 = informaticsDAO.getLatestStickyArticleByPostedDate(CommonConstants.AT_IT_ADVANCE_TIP,
                                                                                                    BaseServices.min(numberArtOnTab,
                                                                                                                    numberStickyArtOnTab));
                int remain = 0;
                if (lst1 != null)
                {
                    remain = lst1.Count();
                    items1 = lst1.ToList();
                }
                IEnumerable<tblInformatic> lst2 = informaticsDAO.getLatestArticleByPostedDate(CommonConstants.AT_IT_ADVANCE_TIP,
                                                                                               numberArtOnTab - remain);
                IList<tblInformatic> items2 = lst2.ToList();
                if (items1 != null)
                {
                    if (items1.Count > 0)
                    {
                        data += loadDetailsForITArticles(items1);
                    }
                }
                if (items2.Count > 0)
                {
                    data += loadDetailsForITArticles(items2);
                }
                if (!BaseServices.isNullOrBlank(data))
                {
                    data += CommonConstants.TEMP_BR_TAG
                       + BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS,
                                                           CommonConstants.CSS_REFERLINK,
                                                           BaseServices.createMsgByTemplate(CommonConstants.TEMP_INFORMATICS_LINK,
                                                                                           CommonConstants.PARAM_IT_TIP_ADVANCE,
                                                                                           CommonConstants.NOW,
                                                                                           CommonConstants.PAGE_NUMBER_FIRST,
                                                                                           CommonConstants.TXT_VIEW_MORE));
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }

        /// <summary>
        /// load data for Lecture Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForELCommon()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IList<tblEnglish> items1 = null;
                IEnumerable<tblEnglish> lst1 = englishDAO.getLatestStickyArticlesByPostedDate(CommonConstants.AT_EL_CLASS_START,
                                                                                                    CommonConstants.AT_EL_CLASS_END,
                                                                                                    BaseServices.min(numberArtOnTab,
                                                                                                                    numberStickyArtOnTab));
                int remain = 0;
                if (lst1 != null)
                {
                    remain = lst1.Count();
                    items1 = lst1.ToList();
                }
                IEnumerable<tblEnglish> lst2 = englishDAO.getLatestArticlesByPostedDate(CommonConstants.AT_EL_CLASS_START,
                                                                                       CommonConstants.AT_EL_CLASS_END,
                                                                                       numberArtOnTab - remain);
                IList<tblEnglish> items2 = lst2.ToList();
                if (items1 != null)
                {
                    if (items1.Count > 0)
                    {
                        data += loadDetailsForELArticles(items1);
                    }
                }
                if (items2.Count > 0)
                {
                    data += loadDetailsForELArticles(items2);
                }
                if (!BaseServices.isNullOrBlank(data))
                {
                    data += CommonConstants.TEMP_BR_TAG
                       + BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS,
                                                           CommonConstants.CSS_REFERLINK,
                                                           BaseServices.createMsgByTemplate(CommonConstants.TEMP_ENGLISH_LINK,
                                                                                           CommonConstants.PARAM_EL_COMMON,
                                                                                           CommonConstants.NOW,
                                                                                           CommonConstants.PAGE_NUMBER_FIRST,
                                                                                           CommonConstants.TXT_VIEW_MORE));
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;

        }
        /// <summary>
        /// load data for Practise Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForELMajor()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IList<tblEnglish> items1 = null;
                IEnumerable<tblEnglish> lst1 = englishDAO.getLatestStickyArticlesByPostedDate(CommonConstants.AT_EL_MJ_START,
                                                                                                    CommonConstants.AT_EL_MJ_END,
                                                                                                    BaseServices.min(numberArtOnTab,
                                                                                                                    numberStickyArtOnTab));
                int remain = 0;
                if (lst1 != null)
                {
                    remain = lst1.Count();
                    items1 = lst1.ToList();
                }
                IEnumerable<tblEnglish> lst2 = englishDAO.getLatestArticlesByPostedDate(CommonConstants.AT_EL_MJ_START,
                                                                                        CommonConstants.AT_EL_MJ_END,
                                                                                        numberArtOnTab - remain);
                IList<tblEnglish> items2 = lst2.ToList();
                if (items1 != null)
                {
                    if (items1.Count > 0)
                    {
                        data += loadDetailsForELArticles(items1);
                    }
                }
                if (items2.Count > 0)
                {
                    data += loadDetailsForELArticles(items2);
                }
                if (!BaseServices.isNullOrBlank(data))
                {
                    data += CommonConstants.TEMP_BR_TAG
                       + BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS,
                                                           CommonConstants.CSS_REFERLINK,
                                                           BaseServices.createMsgByTemplate(CommonConstants.TEMP_ENGLISH_LINK,
                                                                                           CommonConstants.PARAM_EL_MAJOR,
                                                                                           CommonConstants.NOW,
                                                                                           CommonConstants.PAGE_NUMBER_FIRST,
                                                                                           CommonConstants.TXT_VIEW_MORE));
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        /// <summary>
        /// Load data for Examination Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForELCertificate()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IList<tblEnglish> items1 = null;
                IEnumerable<tblEnglish> lst1 = englishDAO.getLatestStickyArticlesByPostedDate(CommonConstants.AT_EL_CERT_START,
                                                                                                    CommonConstants.AT_EL_CERT_END,
                                                                                                    BaseServices.min(numberArtOnTab,
                                                                                                                    numberStickyArtOnTab));
                int remain = 0;
                if (lst1 != null)
                {
                    remain = lst1.Count();
                    items1 = lst1.ToList();
                }
                IEnumerable<tblEnglish> lst2 = englishDAO.getLatestArticlesByPostedDate(CommonConstants.AT_EL_CERT_START,
                                                                                        CommonConstants.AT_EL_CERT_END,
                                                                                        numberArtOnTab - remain);
                IList<tblEnglish> items2 = lst2.ToList();
                if (items1 != null)
                {
                    if (items1.Count > 0)
                    {
                        data += loadDetailsForELArticles(items1);
                    }
                }
                if (items2.Count > 0)
                {
                    data += loadDetailsForELArticles(items2);
                }
                if (!BaseServices.isNullOrBlank(data))
                {
                    data += CommonConstants.TEMP_BR_TAG
                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS,
                                                            CommonConstants.CSS_REFERLINK,
                                                            BaseServices.createMsgByTemplate(CommonConstants.TEMP_ENGLISH_LINK,
                                                                                            CommonConstants.PARAM_EL_CERT,
                                                                                            CommonConstants.NOW,
                                                                                            CommonConstants.PAGE_NUMBER_FIRST,
                                                                                            CommonConstants.TXT_VIEW_MORE));
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        /// <summary>
        /// load details data for English
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        private string loadDetailsForELArticles(IList<tblEnglish> lst)
        {

            string data = CommonConstants.BLANK;
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        data += buildArticleForEnglish(item);
                    }
                }
            return data;
        }

        /// <summary>
        /// load latest news
        /// </summary>
        /// <returns></returns>
        public string loadLatestNews()
        {
            string data = CommonConstants.BLANK;
            try
            {
                IEnumerable<tblNew> lst = newsDAO.getLatestNewsByDate(CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB);
                IList<tblNew> items = lst.ToList();
                if (items.Count > 0)
                {
                    //build top news
                    data += buildTopNews(items[0]);
                    //build list news
                    if (items.Count > 1)
                    {
                        data += buildListNews(items);
                    }
                }
                else
                {
                    data = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                }
                if (!BaseServices.isNullOrBlank(data))
                {
                    data = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG, data);
                    data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS, 
                                                            CommonConstants.CSS_REFERLINK, 
                                                            BaseServices.createMsgByTemplate(CommonConstants.TEMP_NEWS_LINK, 
                                                                                            items[0].ID.ToString(), 
                                                                                            CommonConstants.TXT_VIEW_ALL));
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        private string buildTopNews(tblNew item)
        {
            string data = "";
            try
            {
                data += "<h3>\n";
                data += "                " + item.Title + "";
                if (DateTime.Today.DayOfYear - item.Posted.DayOfYear <= 4)
                {
                    data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_NEW_LINK, CommonConstants.PATH_NEW_LINK_ICON);
                }
                data += "</h3>\n";
                data += "            <h5>\n";
                data += "                Post ngày " + item.Posted + " bởi <b>" + item.tblUser.DisplayName.Trim() + "</b></h5>\n";
                data += "            <p>\n";
                data += item.Chapaeu.Trim() + "...";
                data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_NEWS_LINK, item.ID.ToString(), CommonConstants.TXT_VIEW_MORE);
                data += "            </p>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }

        private string buildListNews(IList<tblNew> items)
        {
            string data = "";
            try
            {
                data += "<ul>";
                for (int i = 1; i < items.Count; i++)
                {
                    data += "                <li>";
                    data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_NEWS_LINK, items[i].ID.ToString(), items[i].Title.Trim());
                    if (DateTime.Today.DayOfYear - items[i].Posted.DayOfYear <= 4)
                    {
                        data += BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_NEW_LINK, CommonConstants.PATH_NEW_LINK_ICON);
                    }
                    data += "                        <div class='date'>";
                    data += "                        (" + items[i].Posted + ")</div>";
                    data += "                </li>";

                }
                data += "</ul>";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        
        /// <summary>
        /// load details for informatics article
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        private string loadDetailsForITArticles(IList<tblInformatic> lst)
        {
            string data = CommonConstants.BLANK;
            if (lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    data += buildArticleForInformatics(item);
                }
            }
                   
            return data;
        }

        /// <summary>
        /// build article for english
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string buildArticleForEnglish(tblEnglish item)
        {
            string data = CommonConstants.BLANK;
            try
            {

                BaseServices bs = new BaseServices();
                data += "              <div class='block_details'>\n"
                        + "                <div class='block_details_img'>\n"
                        + "                    <span title='" + item.Title + "'>" 
                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_THUMBNAIL, bs.getThumbnail(item.Thumbnail, item.Location),item.Title.Trim()) 
                        + "</span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_title'>\n"
                        + "                    <span title='" + item.Title + "'>"
                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK, CommonConstants.SEC_ENGLISH_CODE, item.ID.ToString(), bs.subString(item.Title))
                        + "                </div>\n"
                        + "            </div>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }

        /// <summary>
        /// build article for informatics
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string buildArticleForInformatics(tblInformatic item)
        {
            string data = CommonConstants.BLANK;
            try
            {
                BaseServices bs = new BaseServices();
                data += "              <div class='block_details'>\n"
                        + "                <div class='block_details_img'>\n"
                        + "                    <span title='" + item.Title + "'>"
                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_THUMBNAIL, bs.getThumbnail(item.Thumbnail, item.Location), item.Title.Trim()) 
                        + "</span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_title'>\n"
                        + "                    <span title='" + item.Title + "'>"
                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK, CommonConstants.SEC_INFORMATICS_CODE, item.ID.ToString(), bs.subString(item.Title))
                        + "</span>\n"
                        + "                </div>\n"
                        + "            </div>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;

        }

        /// <summary>
        /// build exam lesson for university
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string buildExamLessonForUniversity(tblContestForUniversity item)
        {
            string res = CommonConstants.BLANK;
            try
            {
                BaseServices bs = new BaseServices();
                res += "                <div class='block_details'>\n"
                        + "                <div class='block_details_img'>\n"
                        + "                    <span title='" + item.Title.Trim() + "'>"
                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_THUMBNAIL, bs.getThumbnail(item.Thumbnail, item.Location), item.Title.Trim()) 
                        + "</span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_title'>\n"
                        + "                    <span title='" + item.Title.Trim() + "'>"
                        + BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK, CommonConstants.SEC_UNIVERSITY_CODE, item.ID.ToString(), bs.subString(item.Title))
                        + "</span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_text'>\n"
                        + "                    " + BaseServices.getNameSubjectByCode(item.Subject.Trim()) + "<br />\n"
                        + contestDAO.getBranch(item.ID) + "<br/>\n"
                        + item.Year
                        + "                </div>\n"
                        + "            </div>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), ex.Message
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.Source
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.StackTrace
                                                                            + CommonConstants.NEWLINE
                                                                            + ex.HelpLink);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }

            return res;
        }
    }
}