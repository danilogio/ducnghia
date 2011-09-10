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
            pagerCons.PageSize = numberArtOnPage;

            ArticleSCO articleSCO = new ArticleSCO();
            try
            {
                articleSCO.Subject = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_SUBJECT]);
                articleSCO.Time = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_TIME]);

                Session[CommonConstants.SES_ARTICLE_SCO] = articleSCO;
                lblTitle.Text = CommonConstants.SEC_UNIVERSITY_NAME;

                if (!IsPostBack)
                {
                    if (!BaseServices.isNullOrBlank(articleSCO.Subject) && !BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        string subject = BaseServices.getNameByCode(articleSCO.Subject);
                        if (subject != CommonConstants.ALL)
                        {
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += CommonConstants.BAR;
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += subject;
                        }
                        IEnumerable<tblContestForUniversity> lst = contestDAO.getArticleBySubjectAndTime(articleSCO);
                        productList.DataSource = lst;
                        productList.DataBind();

                        lblOlderLinks.Text = getOlderLinks(articleSCO);
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
            lblTitle.Text = CommonConstants.SEC_UNIVERSITY_NAME;
            if (articleSCO != null)
            {
                try
                {
                    if (!BaseServices.isNullOrBlank(articleSCO.Subject) && !BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        string subject = BaseServices.getNameByCode(articleSCO.Subject);
                        if(subject != CommonConstants.ALL)
                        {
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += CommonConstants.BAR;
                            lblTitle.Text += CommonConstants.SPACE;
                            lblTitle.Text += subject;
                        }
                        IEnumerable<tblContestForUniversity> lst = contestDAO.getArticleBySubjectAndTime(articleSCO);
                        productList.DataSource = lst;
                        productList.DataBind();

                        lblOlderLinks.Text = getOlderLinks(articleSCO);
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
            articleSCO.Section = CommonConstants.SEC_UNIVERSITY_CODE;

            string links = service.createOlderLink(CommonConstants.TEMP_UNI_LINK, articleSCO, 10);

            return links;
        }
       
    }
}