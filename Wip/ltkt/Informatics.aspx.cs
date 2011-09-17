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
        int currentPage = 1;
        private int numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
        protected void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_INFORMATICS_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
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
            if (articleSCO.TotalRecord > 0)
            {
                articleSCO.FirstRecord = BaseServices.getRecordFrom(articleSCO.CurrentPage, articleSCO.NumArticleOnPage);
                IEnumerable<tblInformatic> lst = infoDAO.searchArticle(articleSCO);
                if (lst != null)
                {
                    if (lst.Count() > 0)
                    {
                        hasRecord = true;
                        list_items.Text = listItem(lst.ToList());
                    }
                }
            }
            if(!hasRecord)
            {
                list_items.Text = CommonConstants.MSG_ARTICLE_EMPTY_RECORD;
            }

        }
        protected string listItem(List<tblInformatic> items)
        {
            string data = CommonConstants.BLANK;
            data = items.Count.ToString();
            return data;
        }
    }
}