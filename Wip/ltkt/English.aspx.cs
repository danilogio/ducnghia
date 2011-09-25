using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt
{
    public partial class English : System.Web.UI.Page
    {
        ltktDAO.English englishDAO = new ltktDAO.English();
        EventLog log = new EventLog();
        BaseServices service = new BaseServices();
        ltktDAO.Control control = new ltktDAO.Control();
        private int numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitleHeader.Text = CommonConstants.PAGE_ENGLISH_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            lblTitle.Text = CommonConstants.BLANK;
            numberArtOnPage = control.getValueByInt(CommonConstants.CF_NUM_ARTICLE_ON_EL);
            if (numberArtOnPage < 1)
            {
                numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
            }

            ArticleSCO articleSCO = new ArticleSCO();
            try
            {
                articleSCO.Classes = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_CLASS]);
                articleSCO.Time = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_TIME]);
                articleSCO.CurrentPage = BaseServices.convertStringToInt(BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_PAGE]));
                articleSCO.NumArticleOnPage = numberArtOnPage;

                if (BaseServices.isNullOrBlank(articleSCO.Classes))
                {
                    articleSCO.Classes = CommonConstants.ALL;
                }
                if (BaseServices.isNullOrBlank(articleSCO.Time))
                {
                    articleSCO.Time = CommonConstants.NOW;
                }
                articleSCO.TotalRecord = englishDAO.countTotalArticles(articleSCO);
                if (articleSCO.TotalRecord > 0)
                {
                    string classes = BaseServices.getNameSubjectByCode(articleSCO.Classes);
                    if (classes != CommonConstants.ALL && !BaseServices.isNullOrBlank(classes))
                    {
                        lblTitle.Text += classes;
                    }
                    else
                    {
                        lblTitle.Text = CommonConstants.TXT_ENGLISH;
                    }
                    articleSCO.FirstRecord = BaseServices.getRecordFrom(articleSCO.CurrentPage, articleSCO.NumArticleOnPage);
                    articleSCO.TotalPage = BaseServices.getTotalPage(articleSCO.TotalRecord, articleSCO.NumArticleOnPage);
                    if (articleSCO.CurrentPage <= articleSCO.TotalPage && articleSCO.CurrentPage >= BaseServices.convertStringToInt(CommonConstants.PAGE_NUMBER_FIRST))
                    {
                        if (articleSCO.CurrentPage == BaseServices.convertStringToInt(CommonConstants.PAGE_NUMBER_FIRST))
                        {
                            IEnumerable<tblEnglish> slst = englishDAO.searchStickyArticleByClassAndTime(articleSCO);
                            if (slst != null)
                            {
                                list_stickyItems.Text = listSItem(slst.ToList(), articleSCO.NumArticleOnPage);
                            }
                        }
                        IEnumerable<tblEnglish> lst = englishDAO.searchArticleByClassAndTime(articleSCO);
                        if (lst != null)
                        {
                            list_items.Text = listItem(lst.ToList());
                            lDataPager.Text = CommonConstants.TEMP_HR_TAG
                                            + BaseServices.createPagingLink(BaseServices.createMsgByTemplate(CommonConstants.TEMP_ENGLISH_URL, articleSCO.Classes, articleSCO.Time),
                                                                            articleSCO.CurrentPage,
                                                                            articleSCO.TotalPage);
                        }
                    }
                    //lblOlderLinks.Text = getOlderLinks(articleSCO);
                }
                if (BaseServices.isNullOrBlank(list_items.Text))
                {
                    if (BaseServices.isNullOrBlank(list_stickyItems.Text))
                    {
                        list_items.Text = CommonConstants.MSG_I_ARTICLE_EMPTY_RECORD;
                    }
                    lDataPager.Visible = false;
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

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);
                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            
        }
        private string listItem(List<tblEnglish> items)
        {
            string datas = CommonConstants.BLANK;
            for (int i = 0 ; i < items.Count; i++)
            {
                string data = CommonConstants.BLANK;
                string thumbnailTag = CommonConstants.BLANK;
                string titleTag = CommonConstants.BLANK;
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, BaseServices.nullToBlank( items[i].Title));
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                            CommonConstants.SEC_ENGLISH_CODE,
                                                            items[i].ID.ToString(),
                                                            titleTag);
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_ARTICLE_DETAIL_THUMBNAIL, BaseServices.nullToBlank(items[i].Thumbnail));
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, thumbnailTag);
                data = thumbnailTag
                        + CommonConstants.TEMP_BR_TAG
                        + CommonConstants.TEMP_BR_TAG
                        + titleTag;
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

        private string listSItem(List<tblEnglish> items, int maxRecord)
        {
            string datas = CommonConstants.BLANK;
            int size = items.Count;
            int limit = BaseServices.min(maxRecord / 2, size);
            for (int i = 0; i < limit; i++)
            {
                string data = CommonConstants.BLANK;
                string thumbnailTag = CommonConstants.BLANK;
                string titleTag = CommonConstants.BLANK;
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, items[i].Title);
                titleTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_ARTICLE_DETAILS_LINK,
                                                            CommonConstants.SEC_INFORMATICS_CODE,
                                                            items[i].ID.ToString(),
                                                            titleTag);
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_IMG_ARTICLE_DETAIL_THUMBNAIL, items[i].Thumbnail);
                thumbnailTag = BaseServices.createMsgByTemplate(CommonConstants.TEMP_CENTER_TAG, thumbnailTag);
                data = thumbnailTag
                        + CommonConstants.TEMP_BR_TAG
                        + CommonConstants.TEMP_BR_TAG
                        + titleTag;
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
        //    lblTitle.Text = CommonConstants.SEC_ENGLISH_NAME;
        //    if (articleSCO != null)
        //    {
        //        try
        //        {
        //            if (BaseServices.isNullOrBlank(articleSCO.Classes))
        //            {
        //                articleSCO.Classes = CommonConstants.ALL;
        //            }
        //            if (BaseServices.isNullOrBlank(articleSCO.Time))
        //            {
        //                articleSCO.Time = CommonConstants.NOW;
        //            }
        //            if (!BaseServices.isNullOrBlank(articleSCO.Classes) && !BaseServices.isNullOrBlank(articleSCO.Time))
        //            {
        //                string classes = BaseServices.getNameSubjectByCode(articleSCO.Classes);
        //                if (classes != CommonConstants.ALL && classes != CommonConstants.BLANK)
        //                {
        //                    lblTitle.Text += CommonConstants.SPACE;
        //                    lblTitle.Text += CommonConstants.BAR;
        //                    lblTitle.Text += CommonConstants.SPACE;
        //                    lblTitle.Text += classes;
        //                }
        //                IEnumerable<tblEnglish> lst = englishDAO.searchArticles(articleSCO, numberArtOnPage);
        //                productList.DataSource = lst;
        //                productList.DataBind();

        //                //lblOlderLinks.Text = getOlderLinks(articleSCO);
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
            articleSCO.Section = CommonConstants.SEC_ENGLISH_CODE;

            string links = service.createOlderLink(CommonConstants.TEMP_ENGLISH_LINK, articleSCO, 10);

            return links;
        }

    }
}