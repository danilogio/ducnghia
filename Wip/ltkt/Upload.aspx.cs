using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using ltktDAO;
using System.IO;


namespace ltkt
{
    public partial class Upload : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        ltktDAO.English englishDAO = new ltktDAO.English();
        ltktDAO.Contest contestDAO = new ltktDAO.Contest();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.BaseServices bs = new ltktDAO.BaseServices();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitle.Text = CommonConstants.PAGE_UPLOAD_NAME
                               + CommonConstants.SPACE + CommonConstants.HLINE
                               + CommonConstants.SPACE
                               + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
            try
            {
                //if (Session[CommonConstants.SES_USER] == null)
                //{
                //    Response.Redirect(CommonConstants.PAGE_LOGIN);
                //}
                //else
                //{

                if (Session[CommonConstants.SES_USER] != null)
                {
                    liFileSize.Text = "(<=";
                    liFileSize.Text += control.getValueByInt(CommonConstants.CF_MAX_FILE_SIZE);
                    liFileSize.Text += "MB)";

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

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_LOGIN);
            }
        }

        public void btnSubmitUpload_Click(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (fileContent.HasFile)
                {
                    string folder = "Data";
                    // 0 - ltdh
                    // 1 - english
                    // 2 - tin học
                    int type = ddlSubject.SelectedIndex;
                    switch (type)
                    {
                        case 0:
                            {
                                folder += "\\University\\";
                                folder += Convert.ToString(ddlYear.SelectedValue);
                                break;
                            }
                        case 1:
                            {
                                folder += "\\Informatics\\";
                                folder += Convert.ToString(DateTime.Now.Year);
                                break;
                            }
                        case 2:
                            {
                                folder += "\\English\\";
                                folder += Convert.ToString(DateTime.Now.Year);
                                break;
                            }
                    }

                    string rootFolder = Server.MapPath("~") + "\\" + folder + "\\";
                    string newFileName = bs.fileNameToSave(fileContent.FileName);
                    string filename = rootFolder + newFileName;
                    string fileSave = folder + "\\" + newFileName;
                    
                    string fileSolvingSave = CommonConstants.BLANK;
                    // save file
                    if (!Directory.Exists(rootFolder))
                    {
                        Directory.CreateDirectory(rootFolder);
                    }

                    try
                    {
                        int maxSize = control.getValueByInt(CommonConstants.CF_MAX_FILE_SIZE);
                        maxSize = maxSize * 1024 * 1024;

                        if (bs.checkFileType(fileContent.FileName, control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW))
                            && fileContent.PostedFile.ContentLength <= maxSize)
                            fileContent.SaveAs(filename);
                        else
                            throw new Exception(CommonConstants.MSG_E_UPLOAD);

                        if (fileSolving.HasFile
                            && bs.checkFileType(fileSolving.FileName, control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW))
                            && fileSolving.PostedFile.ContentLength <= maxSize)
                        {
                            fileSolving.SaveAs(Server.MapPath("~") + "\\" + folder + "\\" +
                                Path.GetFileNameWithoutExtension(newFileName) +
                                "_solved" + Path.GetExtension(fileSolving.FileName));

                            fileSolvingSave = folder + "\\" +
                                Path.GetFileNameWithoutExtension(fileContent.FileName) +
                                "_solved" + Path.GetExtension(fileSolving.FileName);
                        }

                        // ghi xuống db
                        //try
                        //{
                        switch (type)
                        {
                            case 0:
                                {
                                    if (fileSolvingSave != CommonConstants.BLANK)
                                    {
                                        contestDAO.insertContest(txtboxTitle.Text,
                                                                        txtboxSummary.Text,
                                                                        user.Username,
                                                                        DateTime.Now,
                                                                        Boolean.Parse(ddlTypeContest.SelectedValue),
                                                                        Convert.ToInt32(ddlBranch.SelectedValue),
                                                                        Convert.ToInt32(ddlYear.SelectedValue),
                                                                        fileSave,
                                                                        txtboxTag.Text,
                                                                        true,
                                                                        fileSolvingSave);
                                    }
                                    else
                                    {
                                        contestDAO.insertContest(txtboxTitle.Text,
                                                                           txtboxSummary.Text,
                                                                           user.Username,
                                                                           DateTime.Now,
                                                                           Boolean.Parse(ddlTypeContest.SelectedValue),
                                                                           Convert.ToInt32(ddlBranch.SelectedValue),
                                                                           Convert.ToInt32(ddlYear.SelectedValue),
                                                                           fileSave,
                                                                           txtboxTag.Text,
                                                                           false,
                                                                           null);
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    informaticsDAO.insertInformatic(txtboxTitle.Text,
                                        0,
                                        txtboxSummary.Text,
                                        user.Username,
                                        DateTime.Now,
                                        fileSave,
                                        txtboxTag.Text);
                                    break;
                                }
                            case 2:
                                {
                                    englishDAO.insertEnglish(txtboxTitle.Text,
                                        0,
                                        txtboxSummary.Text,
                                        user.Username,
                                        DateTime.Now,
                                        fileSave,
                                        txtboxTag.Text);
                                    break;
                                }
                        }

                        upload.Visible = false;
                        message.Visible = true;
                        liMessage.Text = CommonConstants.MSG_I_UPLOAD_SUCCESSFUL;
                        liMessage.Text += CommonConstants.MSG_I_THANKS_FOR_UPLOADING;
                        liMessage.Text += CommonConstants.MSG_I_WAITING_FOR_CHECKED;
                        liMessage.Text += CommonConstants.MSG_I_BACK_TO_HOME;
                    }
                    catch (Exception ex)
                    {
                        upload.Visible = false;
                        message.Visible = true;
                        liMessage.Text = CommonConstants.MSG_I_THANKS_FOR_UPLOADING;
                        liMessage.Text += "<br />";
                        liMessage.Text += "<br />";
                        liMessage.Text += CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                        liMessage.Text += "<br />";
                        liMessage.Text += CommonConstants.MSG_E_UPLOAD;
                        liMessage.Text += "<br />Danh sách tập tin được hỗ trợ: ";
                        liMessage.Text += control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);
                        liMessage.Text += CommonConstants.MSG_I_UPLOAD_AGAIN;


                        log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message);

                        Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                        //Response.Redirect(CommonConstants.PAGE_ERROR);
                    }
                }
            }
            else
            {
                Response.Redirect(CommonConstants.PAGE_LOGIN);
            }
        }

        
    }
}