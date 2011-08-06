using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblWelcomeTitle.Text = "Chào mừng quý vị đến với Website Luyện thi Kinh tế";
        lblWelcomeText.Text = "Tại đây các bạn sẽ được cung cấp kho tư liệu về đề thi cũng như các giải đáp thắc mắc về đề thi các năm."
                            + "Chúng tôi tập trung vào 3 mảng chính: Luyện thi, Tin học và Anh văn";
        IEnumerable<tblContestForUniversity> lst = Contest.getLatestArticleByPostedDate(6);
        IList<tblContestForUniversity> a = lst.ToList();
        
    }
}
