using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
namespace ltkt
{
    public partial class ContestUniversity : System.Web.UI.Page
    {
        Contest contestDAO = new Contest();
        EventLog log = new EventLog();
        BaseServices service = new BaseServices();
        ltktDAO.Control control = new ltktDAO.Control();
        private int numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;

        public void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_UNIVERSITY_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            numberArtOnPage = control.getValueByInt(CommonConstants.CF_NUM_ARTICLE_ON_UNI);
            if (numberArtOnPage < 1)
            {
                numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
            }
            

            ArticleSCO articleSCO = new ArticleSCO();
            try
            {
                articleSCO.Subject = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_SUBJECT]);
                articleSCO.Time = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_TIME]);
                articleSCO.CurrentPage = BaseServices.convertStringToInt(BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_PAGE]));
                articleSCO.NumArticleOnPage = numberArtOnPage;

                Session[CommonConstants.SES_ARTICLE_SCO] = articleSCO;
                lblTitle.Text = CommonConstants.SEC_UNIVERSITY_NAME;

                if (!IsPostBack)
                {
                    if(BaseServices.isNullOrBlank(articleSCO.Subject))
                    {
                        articleSCO.Subject = CommonConstants.ALL;
                    }
                    if(BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        articleSCO.Time = CommonConstants.NOW;
                    }
                    articleSCO.TotalRecord = contestDAO.countTotalRecord(articleSCO);
                    if (articleSCO.TotalRecord > 0)
                    {
                        articleSCO.FirstRecord = BaseServices.getRecordFrom(articleSCO.CurrentPage, articleSCO.NumArticleOnPage);
                        articleSCO.TotalPage = BaseServices.getTotalPage(articleSCO.TotalRecord, articleSCO.NumArticleOnPage);
                        string subject = BaseServices.getNameSubjectByCode(articleSCO.Subject);
                        if (subject != CommonConstants.ALL)
                        {
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += CommonConstants.BAR;
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += subject;
                        }
                        if (articleSCO.CurrentPage <= articleSCO.TotalPage 
                            && articleSCO.CurrentPage >= BaseServices.convertStringToInt(CommonConstants.PAGE_NUMBER_FIRST))
                        {
                            
                            if (articleSCO.CurrentPage == BaseServices.convertStringToInt(CommonConstants.PAGE_NUMBER_FIRST))
                            {
                                IEnumerable<tblContestForUniversity> slst = contestDAO.searchLatestStickyArticles(articleSCO);
                                if (slst != null)
                                {
                                    list_stickyItems.Text = listSItem(slst.ToList(), articleSCO.NumArticleOnPage);
                                }
                            }
                            IEnumerable<tblContestForUniversity> lst = contestDAO.searchLatestArticleBySubjectAndTime(articleSCO);

                            if (lst != null)
                            {
                                list_items.Text = listItem(lst.ToList());
                                lDataPager.Text = CommonConstants.TEMP_HR_TAG
                                                + BaseServices.createPagingLink(BaseServices.createMsgByTemplate(CommonConstants.TEMP_UNI_URL, articleSCO.Subject, articleSCO.Time),
                                                                                articleSCO.CurrentPage,
                                                                                articleSCO.TotalPage);
                            }
                            lblOlderLinks.Text = getOlderLinks(articleSCO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message + CommonConstants.NEWLINE + ex.StackTrace);
                
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }
        private string listItem(List<tblContestForUniversity> items)
        {
            string datas = CommonConstants.BLANK;
            for (int i = 0; i < items.Count; i++)
            {
                string data = CommonConstants.BLANK;
                string thumbnailTag = CommonConstants.BLANK;
                string titleTag = CommonConstants.BLANK;
                string publishYear = CommonConstants.BLANK;
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, BaseServices.nullToBlank(items[i].Title));
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                            CommonConstants.SEC_ENGLISH_CODE,
                                                            items[i].ID.ToString(),
                                                            titleTag);
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_ARTICLE_DETAIL_THUMBNAIL, BaseServices.nullToBlank(items[i].Thumbnail));
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, thumbnailTag);

                publishYear = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, items[i].Year.ToString());
                publishYear = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS, CommonConstants.CSS_BLOCK_DETAIL_TEXT, publishYear);
                data = thumbnailTag
                        + CommonConstants.TEMP_BR_TAG
                        + CommonConstants.TEMP_BR_TAG
                        + titleTag
                        + publishYear;
                data = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_ARTICLE_DETAIL, (i + 1).ToString(), data);
                data = BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, data);
                datas += data;
            }
            if (datas != CommonConstants.BLANK)
            {
                datas = BaseServices.createMsgByTemplate(CommonConstants.TEMP_UL_TAG_WITH_CLASS, CommonConstants.CSS_ARTICLE_LIST, datas);
            }
            return datas;
        }
        private string listSItem(List<tblContestForUniversity> items, int maxRecord)
        {
            string datas = CommonConstants.BLANK;
            int size = items.Count;
            int limit = BaseServices.min(maxRecord / 2, size);
            for (int i = 0; i < limit; i++)
            {
                string data = CommonConstants.BLANK;
                string thumbnailTag = CommonConstants.BLANK;
                string titleTag = CommonConstants.BLANK;
                string publishYear = CommonConstants.BLANK;
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, items[i].Title);
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                            CommonConstants.SEC_INFORMATICS_CODE,
                                                            items[i].ID.ToString(),
                                                            titleTag);
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_ARTICLE_DETAIL_THUMBNAIL, items[i].Thumbnail);
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, thumbnailTag);

                publishYear = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, items[i].Year.ToString());
                publishYear = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_WITH_CLASS, CommonConstants.CSS_BLOCK_DETAIL_TEXT, publishYear);
                data = thumbnailTag
                        + CommonConstants.TEMP_BR_TAG
                        + CommonConstants.TEMP_BR_TAG
                        + titleTag
                        + publishYear;
                data = BaseServices.createMsgByTemplate(CommonConstants.TEMP_DIV_TAG_ARTICLE_DETAIL, (i + maxRecord + 1).ToString(), data);
                data = BaseServices.createMsgByTemplate(CommonConstants.TEMP_LI_TAG, data);
                datas += data;
            }
            if (datas != CommonConstants.BLANK)
            {
                datas = BaseServices.createMsgByTemplate(CommonConstants.TEMP_UL_TAG_WITH_CLASS, CommonConstants.CSS_ARTICLE_LIST, datas);
            }
            return datas;
        }
        //protected void DataPagerArticles_PreRender(object sender, EventArgs e)
        //{
        //    ArticleSCO articleSCO = new ArticleSCO();
        //    articleSCO = (ArticleSCO)Session[CommonConstants.SES_ARTICLE_SCO];
        //    lblTitle.Text = CommonConstants.SEC_UNIVERSITY_NAME;
        //    if (articleSCO != null)
        //    {
        //        try
        //        {
        //            if (BaseServices.isNullOrBlank(articleSCO.Subject))
        //            {
        //                articleSCO.Subject = CommonConstants.ALL;
        //            }
        //            if (BaseServices.isNullOrBlank(articleSCO.Time))
        //            {
        //                articleSCO.Time = CommonConstants.NOW;
        //            }
        //            if (!BaseServices.isNullOrBlank(articleSCO.Subject) && !BaseServices.isNullOrBlank(articleSCO.Time))
        //            {
        //                string subject = BaseServices.getNameSubjectByCode(articleSCO.Subject);
        //                if(subject != CommonConstants.ALL)
        //                {
        //                    lblTitle.Text += CommonConstants.SPACE;
        //                    lblTitle.Text += CommonConstants.BAR;
        //                    lblTitle.Text += CommonConstants.SPACE;
        //                    lblTitle.Text += subject;
        //                }
        //                IEnumerable<tblContestForUniversity> lst = contestDAO.getArticleBySubjectAndTime(articleSCO);
        //                productList.DataSource = lst;
        //                productList.DataBind();

        //                lblOlderLinks.Text = getOlderLinks(articleSCO);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
        //            string username = CommonConstants.USER_GUEST;
        //            if (user != null)
        //            {
        //                username = user.Username;
        //            }

        //            log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

        //            Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
        //            Response.Redirect(CommonConstants.PAGE_ERROR);
        //        }
        //    }
        //}

        private string getOlderLinks(ArticleSCO articleSCO)
        {
            articleSCO.Section = CommonConstants.SEC_UNIVERSITY_CODE;

            string links = service.createOlderLink(CommonConstants.TEMP_UNI_LINK, articleSCO, 10);

            return links;
        }
       
    }
}