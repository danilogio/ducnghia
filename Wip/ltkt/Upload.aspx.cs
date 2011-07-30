using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ltkt
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selIndex = Request["selIndex"];
            int selectedIndex;

            if (selIndex == null)
            {
                selectedIndex = 0;
            }
            else
            {
                selectedIndex = Int32.Parse(selIndex);

                if (selectedIndex == 0)
                {
                    //ddlType.Visible = false;
                    //lessonType.Visible = false;
                }
                else
                {
                    //ddlType.Visible = true;
                    //lessonType.Visible = true;
                }
                Response.End();
            }

        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (FileUpload1.HasFile)
            //    try
            //    {
            //        FileUpload1.SaveAs("C:\\Uploads\\" +
            //             FileUpload1.FileName);
            //        Label1.Text = "File name: " +
            //             FileUpload1.PostedFile.FileName + "<br>" +
            //             FileUpload1.PostedFile.ContentLength + " kb<br>" +
            //             "Content type: " +
            //             FileUpload1.PostedFile.ContentType;
            //    }
            //    catch (Exception ex)
            //    {
            //        Label1.Text = "ERROR: " + ex.Message.ToString();
            //    }
            //else
            //{
            //    Label1.Text = "You have not specified a file.";
            //}
        }


    }
}