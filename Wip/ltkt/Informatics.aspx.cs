using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt
{
    public partial class Informatics : System.Web.UI.Page
    {
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.Informatics infoDAO = new ltktDAO.Informatics();
        private int numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
        protected void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_INFORMATICS_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            lblSubTitle.Text = CommonConstants.PAGE_INFORMATICS_NAME;

            ArticleSCO articleSCO = new ArticleSCO();
            numberArtOnPage = control.getValueByInt(CommonConstants.CF_NUM_ARTICLE_ON_IT);
            if (numberArtOnPage < 1)
            {
                numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
            }
            articleSCO.CurrentPage = BaseServices.convertStringToInt(Request.QueryString[CommonConstants.REQ_PAGE]);
            articleSCO.Leitmotif = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_LEITMOTIF]);
            articleSCO.Time = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_TIME]);
            articleSCO.NumArticleOnPage = numberArtOnPage;

            if (BaseServices.isNullOrBlank(articleSCO.Leitmotif))
            {
                articleSCO.Leitmotif = CommonConstants.ALL;
            }
            if (BaseServices.isNullOrBlank(articleSCO.Time))
            {
                articleSCO.Time = CommonConstants.NOW;
            }
            articleSCO.TotalRecord = infoDAO.countTotalRecord(articleSCO);
            bool hasRecord = false;
            bool hasSRecord = false;
            if (articleSCO.TotalRecord > 0)
            {
                articleSCO.FirstRecord = BaseServices.getRecordFrom(articleSCO.CurrentPage, articleSCO.NumArticleOnPage);
                articleSCO.TotalPage = BaseServices.getTotalPage(articleSCO.TotalRecord, articleSCO.NumArticleOnPage);
                if (articleSCO.CurrentPage <= articleSCO.TotalPage && articleSCO.CurrentPage >= BaseServices.convertStringToInt(CommonConstants.PAGE_NUMBER_FIRST))
                {
                    if (articleSCO.CurrentPage == 1)
                    {
                        IEnumerable<tblInformatic> slst = infoDAO.searchLatestStickyArticle(articleSCO);

                        if (slst != null)
                        {
                            hasSRecord = true;
                            list_stickyItems.Text = listSItem(slst.ToList(), articleSCO.NumArticleOnPage);
                        }
                    }
                    IEnumerable<tblInformatic> lst = infoDAO.searchLatestArticle(articleSCO);
                    if (lst != null)
                    {
                        if (lst.Count() > 0)
                        {
                            hasRecord = true;
                            list_items.Text = listItem(lst.ToList());
                            lDataPager.Text = CommonConstants.TEMP_HR_TAG 
                                            + BaseServices.createPagingLink(BaseServices.createMsgByTemplate(CommonConstants.TEMP_INFORMATICS_URL, articleSCO.Leitmotif, articleSCO.Time),
                                                                            articleSCO.CurrentPage, 
                                                                            articleSCO.TotalPage);
                        }
                    }
                }
            }
            if(!hasRecord)
            {
                if (!hasSRecord)
                {
                    list_items.Text = CommonConstants.MSG_ARTICLE_EMPTY_RECORD;
                }

                lDataPager.Visible = false;
            }

        }
        private string listItem(List<tblInformatic> items)
        {
            string datas = CommonConstants.BLANK;
            for(int i = 0; i < items.Count; i++)
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
        private string listSItem(List<tblInformatic> items, int maxRecord)
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
    }
}