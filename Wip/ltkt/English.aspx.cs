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
            numberArtOnPage = control.getValueByInt(CommonConstants.CF_NUM_ARTICLE_ON_EL);
            if (numberArtOnPage < 1)
            {
                numberArtOnPage = CommonConstants.DEFAULT_NUMBER_RECORD_ON_TAB;
            }
            pagerCons.PageSize = numberArtOnPage;

            ArticleSCO articleSCO = new ArticleSCO();
            try
            {
                articleSCO.Classes = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_CLASS]);
                articleSCO.Time = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_TIME]);

                Session[CommonConstants.SES_ARTICLE_SCO] = articleSCO;
                lblTitle.Text = CommonConstants.SEC_ENGLISH_NAME;
                if (!IsPostBack)
                {
                    if (BaseServices.isNullOrBlank(articleSCO.Classes))
                    {
                        articleSCO.Classes = CommonConstants.ALL;
                    }
                    if (BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        articleSCO.Time = CommonConstants.NOW;
                    }
                    if (!BaseServices.isNullOrBlank(articleSCO.Classes) && !BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        string classes = BaseServices.getNameSubjectByCode(articleSCO.Classes);
                        if (classes != CommonConstants.ALL)
                        {
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += CommonConstants.BAR;
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += classes;
                        }
                        IEnumerable<tblEnglish> lst = englishDAO.searchArticles(articleSCO, numberArtOnPage);
                        productList.DataSource = lst;
                        productList.DataBind();

                        //lblOlderLinks.Text = getOlderLinks(articleSCO);
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

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
            
        }
    
        protected void DataPagerArticles_PreRender(object sender, EventArgs e)
        {
            ArticleSCO articleSCO = new ArticleSCO();
            articleSCO = (ArticleSCO)Session[CommonConstants.SES_ARTICLE_SCO];
            lblTitle.Text = CommonConstants.SEC_ENGLISH_NAME;
            if (articleSCO != null)
            {
                try
                {
                    if (BaseServices.isNullOrBlank(articleSCO.Classes))
                    {
                        articleSCO.Classes = CommonConstants.ALL;
                    }
                    if (BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        articleSCO.Time = CommonConstants.NOW;
                    }
                    if (!BaseServices.isNullOrBlank(articleSCO.Classes) && !BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        string classes = BaseServices.getNameSubjectByCode(articleSCO.Classes);
                        if (classes != CommonConstants.ALL && classes != CommonConstants.BLANK)
                        {
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += CommonConstants.BAR;
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += classes;
                        }
                        IEnumerable<tblEnglish> lst = englishDAO.searchArticles(articleSCO, numberArtOnPage);
                        productList.DataSource = lst;
                        productList.DataBind();

                        //lblOlderLinks.Text = getOlderLinks(articleSCO);
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

                    Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_COMMON_ERROR_TEXT;
                    Response.Redirect(CommonConstants.PAGE_ERROR);
                }
            }
        }
        private string getOlderLinks(ArticleSCO articleSCO)
        {
            articleSCO.Section = CommonConstants.SEC_ENGLISH_CODE;

            string links = service.createOlderLink(CommonConstants.TEMP_ENGLISH_LINK, articleSCO, 10);

            return links;
        }

    }
}