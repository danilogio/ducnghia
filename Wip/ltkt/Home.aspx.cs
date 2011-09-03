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
        EventLog log = new EventLog();
        ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        ltktDAO.English englishDAO = new ltktDAO.English();
        ltktDAO.Contest contestDAO = new ltktDAO.Contest();
        ltktDAO.Control controlDAO = new ltktDAO.Control();
        ltktDAO.Sticky stickDAO = new ltktDAO.Sticky();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcomeTitle.Text = controlDAO.getNameString(CommonConstants.CF_WELCOME_TEXT);
            lblWelcomeText.Text = controlDAO.getValueString(CommonConstants.CF_WELCOME_TEXT);
            MasterPage page = (MasterPage)Master;
            //page.updateTitle("");
            Label headerTxt = (Label)page.FindControl("lblHeaderTitle");
            if (headerTxt != null)
            {
                headerTxt.Text = CommonConstants.PAGE_HOME_NAME 
                            + CommonConstants.SPACE
                            + CommonConstants.HLINE
                            + CommonConstants.SPACE
                            + controlDAO.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            
            }
            //lblTitle.Text = 
        }

        public string loadDataForUniversityArticles()
        {
            string data = CommonConstants.BLANK;
            try
            {
                int numberArtOnTab = controlDAO.getValueByInt(CommonConstants.CF_NUM_ARTICLE_ON_TAB);
                int numberStickyArtOnTab = controlDAO.getValueByInt(CommonConstants.CF_NUM_ARTICLE_STICKY);

                IEnumerable<tblContestForUniversity> lst1 = contestDAO.getStickyArticlebyPostedDay(numberStickyArtOnTab);
                IEnumerable<tblContestForUniversity> lst2 = contestDAO.getLatestArticleByPostedDate(numberArtOnTab - lst1.Count());
                
                IList<tblContestForUniversity> items1 = lst1.ToList();
                IList<tblContestForUniversity> items2 = lst2.ToList();
                

                if (items1.Count > 0)
                {

                    foreach (var item in items1)
                    {
                        data += buildExamLessonForUniversity(item);
                    }
                    if (items1.Count > 0)
                    {
                        foreach (var item in items2)
                        {
                            if (!stickDAO.checkExisted(item.ID, CommonConstants.ST_UNI))
                            {
                                data += buildExamLessonForUniversity(item);
                            }
                        }
                    }
                    data += "<br/>\n<div class='referlink'>\n"
                            + "<a href='ContestUniversity.aspx'>Xem thêm</a></div>\n";


                }
                else
                {
                    data = CommonConstants.MSG_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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
            try
            {
                IEnumerable<tblInformatic> lst = informaticsDAO.getLatestArticleByPostedDate(CommonConstants.AT_IT_OFFICE_WORD, CommonConstants.AT_IT_OFFICE_ACCESS, CommonConstants.NUMBER_RECORD_ON_TAB);
                IList<tblInformatic> items = lst.ToList();
                return loadDetailsForITArticles(items);
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return null;
        }
        /// <summary>
        /// load data for Practise Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForITTipSimple()
        {
            try
            {
                IEnumerable<tblInformatic> lst = informaticsDAO.getLatestArticleByPostedDate(CommonConstants.AT_IT_OFFICE_SIMPLE_TIP, CommonConstants.NUMBER_RECORD_ON_TAB);
                IList<tblInformatic> items = lst.ToList();
                return loadDetailsForITArticles(items);
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return null;
        }
        /// <summary>
        /// Load data for Examination Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForITTipAdvance()
        {
            try
            {
                IEnumerable<tblInformatic> lst = informaticsDAO.getLatestArticleByPostedDate(CommonConstants.AT_IT_OFFICE_ADVANCE_TIP, CommonConstants.NUMBER_RECORD_ON_TAB);
                IList<tblInformatic> items = lst.ToList();
                return loadDetailsForITArticles(items);
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return null;
        }

        /// <summary>
        /// load data for Lecture Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForELLectures()
        {
            try
            {
                IEnumerable<tblEnglish> items = englishDAO.getLatestArticlesByPostedDate(CommonConstants.AT_LECTURE, CommonConstants.NUMBER_RECORD_ON_TAB);
                IList<tblEnglish> lst = items.ToList();
                return loadDetailsForELArticles(lst);
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return null;

        }
        /// <summary>
        /// load data for Practise Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForELPractise()
        {
            try
            {
                IEnumerable<tblEnglish> items = englishDAO.getLatestArticlesByPostedDate(CommonConstants.AT_PRACTISE, CommonConstants.NUMBER_RECORD_ON_TAB);
                IList<tblEnglish> lst = items.ToList();
                return loadDetailsForELArticles(lst);
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return null;

        }
        /// <summary>
        /// Load data for Examination Tab
        /// </summary>
        /// <returns></returns>
        public string loadDataForELExamination()
        {
            try
            {
                IEnumerable<tblEnglish> items = englishDAO.getLatestArticlesByPostedDate(CommonConstants.AT_EXAM, CommonConstants.NUMBER_RECORD_ON_TAB);
                IList<tblEnglish> lst = items.ToList();
                return loadDetailsForELArticles(lst);
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return null;
        }
        public string loadLatestNews()
        {
            string data = "";
            try
            {
                IEnumerable<tblNew> lst = ltktDAO.News.getLatestNewsByDate(CommonConstants.NUMBER_RECORD_ON_TAB);
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
                    data = CommonConstants.MSG_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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
                data += "                " + item.Title + "</h3>\n";
                data += "            <h5>\n";
                data += "                Post ngày " + item.Posted + " bởi <b>" + item.tblUser.DisplayName.Trim() + "</b></h5>\n";
                data += "            <p>\n";
                data += item.Chapaeu.Trim() + "...";
                data += "              <a href='News.aspx?id=" + item.ID + "'>Xem tiếp >></a>\n";
                data += "            </p>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
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
                    data += "                    <a href='News.aspx?id=" + items[i].ID + "'>" + items[i].Title.Trim() + "</a><div";
                    data += "                        class='date'>";
                    data += "                        (" + items[i].Posted + ")</div>";
                    data += "                </li>";

                }
                data += "</ul>";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }
        private string loadDetailsForELArticles(IList<tblEnglish> lst)
        {

            string data = "";
            try
            {
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        data += buildArticleForEnglish(item);

                    }
                    data += "<br/>\n<div class='referlink'>\n"
                            + "<a href='English.aspx'>Xem thêm</a></div>\n";

                }
                else
                {
                    data = CommonConstants.MSG_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }

        private string loadDetailsForITArticles(IList<tblInformatic> lst)
        {
            string data = "";
            try
            {
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        data += buildArticleForInformatics(item);

                    }
                    data += "<br/>\n<div class='referlink'>\n"
                            + "<a href='Informatics.aspx'>Xem thêm</a></div>\n";

                }
                else
                {
                    data = CommonConstants.MSG_ARTICLE_EMPTY_RECORD;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }

        private string buildArticleForEnglish(tblEnglish item)
        {
            string data = "";
            try
            {

                BaseServices bs = new BaseServices();
                data += "              <div class='block_details'>\n"
                        + "                <div class='block_details_img'>\n"
                        + "                    <span title='" + item.Title + "'><img width='50px' height='50px' src='" + bs.getThumbnail(item.Thumbnail, item.Location) + "' alt='" + item.Title.Trim() + "'/></span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_title'>\n"
                        + "                    <span title='" + item.Title + "'><a href=\"ArticleDetails.aspx?sec=el&id=" + item.ID + "\">" + bs.subString(item.Title) + "</a></span>\n"
                        + "                </div>\n"
                        + "            </div>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;
        }

        private string buildArticleForInformatics(tblInformatic item)
        {
            string data = "";
            try
            {
                BaseServices bs = new BaseServices();
                data += "              <div class='block_details'>\n"
                        + "                <div class='block_details_img'>\n"
                        + "                    <span title='" + item.Title + "'><img width='50px' height='50px' src='" + bs.getThumbnail(item.Thumbnail, item.Location) + "' alt='" + item.Title + "' /></span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_title'>\n"
                        + "                    <span title='" + item.Title + "'><a href=\"ArticleDetails.aspx?sec=it&id=" + item.ID + "\">" + bs.subString(item.Title) + "</a></span>\n"
                        + "                </div>\n"
                        + "            </div>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            return data;

        }
        private string buildExamLessonForUniversity(tblContestForUniversity item)
        {
            string res = "";
            try
            {
                BaseServices bs = new BaseServices();
                res += "                <div class='block_details'>\n"
                        + "                <div class='block_details_img'>\n"
                        + "                    <span title='" + item.Title + "'><img width='50px' height='50px' src='" + bs.getThumbnail(item.Thumbnail, item.Location) + "' alt='" + item.Title + "' /></span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_title'>\n"
                        + "                    <span title='" + item.Title + "'><a href=\"ArticleDetails.aspx?sec=uni&id=" + item.ID + "\">" + bs.subString(item.Title) + "</a></span>\n"
                        + "                </div>\n"
                        + "                <div class='block_details_text'>\n"
                        + "                    " + BaseServices.getNameByCode(item.Subject.Trim()) + "<br />\n"
                        + Contest.getBranch(item.ID) + "<br/>\n"
                        + item.Year
                        + "                </div>\n"
                        + "            </div>\n";
            }
            catch (Exception ex)
            {
                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), ex.Message);
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }

            return res;
        }


    }
}