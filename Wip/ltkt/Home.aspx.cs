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
        IEnumerable<tblContestForUniversity> lst = Contest.getLatestArticleByPostedDate(6);
        IList<tblContestForUniversity> items = lst.ToList();
        string data = "";
        foreach (var item in items)
        {
            data += buildExamLessonForUniversity(item);
        }
        if (data == "")
        {
            data = "Hiện tại chưa có đề thi nào";
        }
        ExamLesson01.InnerHtml = data;
    }

    private string buildExamLessonForUniversity(tblContestForUniversity item)
    {
        string res = "";
        BaseServices bs = new BaseServices();
        res += "<div class='block_details'>"
                + "                <div class='block_details_img'>"
                + "                    <img width='50px' height='50px' src='" + bs.getThumbnail(item.Thumbnail, item.Location) + "' alt='Eden' />"
                + "                </div>"
                + "                <div class='block_details_title'>"
                + "                    <a href='#'>" + item.Title + "</a>"
                + "                </div>"
                + "                <div class='block_details_text'>"
                + "                    " + item.Subject + "<br />"
                +                       Contest.getBranch(item.ID)
                + "                </div>"
                + "            </div>";

        return res;
    }

    
}
