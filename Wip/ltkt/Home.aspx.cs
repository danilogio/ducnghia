using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ltktDAO;

public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        lblWelcomeTitle.Text = "Chào mừng quý vị đến với Website Luyện thi Kinh tế";
        lblWelcomeText.Text = "Tại đây các bạn sẽ được cung cấp kho tư liệu về đề thi cũng như các giải đáp thắc mắc về đề thi các năm."
                            + "Chúng tôi tập trung vào 3 mảng chính: Luyện thi, Tin học và Anh văn";
       
    }

    public string loadDataForUniversityArticles()
    {
        IEnumerable<tblContestForUniversity> lst = Contest.getLatestArticleByPostedDate(CommonConstants.NUMBER_RECORD_ON_TAB);
        IList<tblContestForUniversity> items = lst.ToList();
        string data = "";
        if (items.Count > 0)
        {
            
            foreach (var item in items)
            {
                data += buildExamLessonForUniversity(item);
            }
            data += "<br/>\n<div class='referlink'>\n"
                    + "<a href='ContestUniversity.aspx'>Xem thêm</a></div>\n";

            
        }
        else
        {
            data = CommonConstants.ARTICLE_EMPTY_RECORD;
        }
        return data;
    }
    /// <summary>
    /// load data for Lecture Tab
    /// </summary>
    /// <returns></returns>
    public string loadDataForITLectures()
    {
        IEnumerable<tblInformatic> lst = ltktDAO.Informatics.getLatestArticleByPostedDate(CommonConstants.ARTICLE_TYPE_LECTURE, CommonConstants.NUMBER_RECORD_ON_TAB);
        IList<tblInformatic> items = lst.ToList();
        return loadDetailsForITArticles(items);
    }
    /// <summary>
    /// load data for Practise Tab
    /// </summary>
    /// <returns></returns>
    public string loadDataForITPractise()
    {
        IEnumerable<tblInformatic> lst = ltktDAO.Informatics.getLatestArticleByPostedDate(CommonConstants.ARTICLE_TYPE_PRACTISE, CommonConstants.NUMBER_RECORD_ON_TAB);
        IList<tblInformatic> items = lst.ToList();
        return loadDetailsForITArticles(items);
    }
    /// <summary>
    /// Load data for Examination Tab
    /// </summary>
    /// <returns></returns>
    public string loadDataForITExamination()
    {
        IEnumerable<tblInformatic> lst = ltktDAO.Informatics.getLatestArticleByPostedDate(CommonConstants.ARTICLE_TYPE_EXAM, CommonConstants.NUMBER_RECORD_ON_TAB);
        IList<tblInformatic> items = lst.ToList();
        return loadDetailsForITArticles(items);
    }
   
    /// <summary>
    /// load data for Lecture Tab
    /// </summary>
    /// <returns></returns>
    public string loadDataForELLectures()
    {
        IEnumerable<tblEnglish> items = ltktDAO.English.getLatestArticlesByPostedDate(CommonConstants.ARTICLE_TYPE_LECTURE, CommonConstants.NUMBER_RECORD_ON_TAB);
        IList<tblEnglish> lst = items.ToList();
        return loadDetailsForELArticles(lst);

    }
    /// <summary>
    /// load data for Practise Tab
    /// </summary>
    /// <returns></returns>
    public string loadDataForELPractise()
    {
        
        IEnumerable<tblEnglish> items = ltktDAO.English.getLatestArticlesByPostedDate(CommonConstants.ARTICLE_TYPE_PRACTISE, CommonConstants.NUMBER_RECORD_ON_TAB);
        IList<tblEnglish> lst = items.ToList();
        return loadDetailsForELArticles(lst);
    }
    /// <summary>
    /// Load data for Examination Tab
    /// </summary>
    /// <returns></returns>
    public string loadDataForELExamination()
    {
        IEnumerable<tblEnglish> items = ltktDAO.English.getLatestArticlesByPostedDate(CommonConstants.ARTICLE_TYPE_EXAM, CommonConstants.NUMBER_RECORD_ON_TAB);
        IList<tblEnglish> lst = items.ToList();
        return loadDetailsForELArticles(lst);
    }
    public string loadLatestNews()
    {
        string data = "";
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
            data = CommonConstants.ARTICLE_EMPTY_RECORD;
        }
        return data;
    }
    private string buildTopNews(tblNew item)
    {
        string data = "";
        data+= "<h3>\n";
        data += "                " + item.Title.Trim() + "</h3>\n";
        data += "            <h5>\n";
        data += "                Post ngày " + item.Posted + " bởi <b>"+item.Author.Trim()+"</b></h5>\n";
        data += "            <p>\n";
        data += item.Chapaeu.Trim() + "...";
        data += "              <a href='News.aspx?id='"+item.ID+">Xem tiếp >></a>\n";
        data += "            </p>\n";
        return data;
    }

    private string buildListNews(IList<tblNew> items)
    {
        string data = "";
        data += "<ul>";
        for (int i = 1; i < items.Count; i++)
        {
            data += "                <li>";
            data += "                    <a href='News.aspx?id="+items[i].ID+"'>"+ items[i].Title.Trim() +"</a><div";
            data += "                        class='date'>";
            data += "                        ("+items[i].Posted+")</div>";
            data += "                </li>";

        }
        data += "</ul>";
        return data;
    }
    private string loadDetailsForELArticles(IList<tblEnglish> lst)
    {
        
        string data = "";
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
            data = CommonConstants.ARTICLE_EMPTY_RECORD;
        }
        return data;
    }
    private string loadDetailsForITArticles(IList<tblInformatic> lst)
    {
        string data = "";
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
            data = CommonConstants.ARTICLE_EMPTY_RECORD;
        }
        return data;
    }
    private string buildArticleForEnglish(tblEnglish item)
    {
        string data = "";
        BaseServices bs = new BaseServices();
        data += "              <div class='block_details'>\n"
                + "                <div class='block_details_img'>\n"
                + "                    <img width='50px' height='50px' src='" + bs.getThumbnail(item.Thumbnail, item.Location) + "' alt=\""+ item.Title.Trim()+"\" />\n"
                + "                </div>\n"
                + "                <div class='block_details_title'>\n"
                + "                    <a href=\"ArticleDetails.aspx?sec=el&id=" + item.ID + "\">" + item.Title.Trim() + "</a>\n"
                + "                </div>\n"
                + "            </div>\n";
        return data;
    }


    private string buildArticleForInformatics(tblInformatic item)
    {
        string data = "";
        BaseServices bs = new BaseServices();
        data += "              <div class='block_details'>\n"
                + "                <div class='block_details_img'>\n"
                + "                    <img width='50px' height='50px' src='" + bs.getThumbnail(item.Thumbnail, item.Location) + "' alt=\"" + item.Title + "\" />\n"
                + "                </div>\n"
                + "                <div class='block_details_title'>\n"
                + "                    <a href=\"ArticleDetails.aspx?sec=it&id=" + item.ID + "\">" + item.Title.Trim() + "</a>\n"
                + "                </div>\n"
                + "            </div>\n";
        return data;
    }
    private string buildExamLessonForUniversity(tblContestForUniversity item)
    {
        string res = "";
        BaseServices bs = new BaseServices();
        res += "                <div class='block_details'>\n"
                + "                <div class='block_details_img'>\n"
                + "                    <img width='50px' height='50px' src='" + bs.getThumbnail(item.Thumbnail, item.Location) + "' alt='"+item.Title+"' />\n"
                + "                </div>\n"
                + "                <div class='block_details_title'>\n"
                + "                    <a href=\"ArticleDetails.aspx?sec=uni&id=" + item.ID + "\">" + item.Title.Trim() + "</a>\n"
                + "                </div>\n"
                + "                <div class='block_details_text'>\n"
                + "                    " + item.Subject.Trim() + "<br />\n"
                + Contest.getBranch(item.ID) + "<br/>\n"
                + item.Year
                + "                </div>\n"
                + "            </div>\n";
                
        return res;
    }

    
}
