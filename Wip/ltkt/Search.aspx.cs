using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;

namespace ltkt
{
    public partial class Search : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        ltktDAO.English englishDAO = new ltktDAO.English();
        ltktDAO.Contest contestDAO = new ltktDAO.Contest();

        protected void Page_Load(object sender, EventArgs e)
        {
            resultPanel.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (!recaptcha.IsValid)
            //{
            //    return;
            //}

            string keyWords = txtboxSearch.Text;
            int topic = Convert.ToInt32(ddlSubject.SelectedValue);
            IList<tblEnglish> lstEnglish = null;
            IList<tblContestForUniversity> lstContest = null;
            IList<tblInformatic> lstInformatics = null;

            // Luyện thi đại học
            if (topic == 0 || topic == 3)
            {
                int isAll = Convert.ToInt32(ddlSearchingType.SelectedValue);
                if (isAll == 0)
                {
                    lstContest = contestDAO.listContest(keyWords);
                }
                else
                {
                    //int branch = 0;//Convert.ToInt32(ddlBranch.SelectedValue);
                    bool isUniversity = Boolean.Parse(ddlTypeContest.SelectedValue);
                    int year = Convert.ToInt32(ddlYear.SelectedValue);

                    lstContest = contestDAO.listContest(isUniversity, year);
                }
            }

            // Tin học
            if (topic == 1 || topic == 3)
            {
                lstInformatics = informaticsDAO.listInformatics(keyWords);
            }

            // Anh văn
            if (topic == 2 || topic == 3)
            {
                lstEnglish = englishDAO.listEnglish(keyWords);
            }

            resultPanel.Visible = true;

            int idx = 0;
            lblResult.Text = "<p><ul>";
            if (lstContest != null)
            {
                for (idx = 0; idx < lstContest.Count(); ++idx)
                {
                    lblResult.Text += "<li>";
                    lblResult.Text += "<a href='ArticleDetails.aspx?sec=uni&id=" + lstContest[idx].ID + "'>" + lstContest[idx].Title.Trim() + "</a>";
                    lblResult.Text += "</li>";
                }
            }

            if (lstEnglish != null)
            {
                for (idx = 0; idx < lstEnglish.Count(); ++idx)
                {
                    lblResult.Text += "<li>";
                    lblResult.Text += "<a href='ArticleDetails.aspx?sec=el&id=" + lstEnglish[idx].ID + "'>" + lstEnglish[idx].Title.Trim() + "</a>";
                    lblResult.Text += "</li>";
                }
            }

            if (lstInformatics != null)
            {
                for (idx = 0; idx < lstInformatics.Count(); ++idx)
                {
                    lblResult.Text += "<li>";
                    lblResult.Text += "<a href='ArticleDetails.aspx?sec=it&id=" + lstInformatics[idx].ID + "'>" + lstInformatics[idx].Title.Trim() + "</a>";
                    lblResult.Text += "</li>";
                }
            }
            lblResult.Text += "</ul></p>";

            if (lblResult.Text == "<p><ul></ul></p>")
            {
                lblResult.Text = "<p><br />Rất tiếc, không có kết quả nào phù hợp với yêu cầu tìm kiếm của bạn.</p>";
            }

        }
    }
}