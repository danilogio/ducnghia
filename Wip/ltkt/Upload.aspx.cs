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

            bool isOK = true;
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

                    if (ddlEnglishType.Items.Count == 0)
                    {
                        ddlEnglishType.Items.Add(new ListItem(CommonConstants.PARAM_EL_COMMON_NAME, CommonConstants.PARAM_EL_COMMON));
                        ddlEnglishType.Items.Add(new ListItem(CommonConstants.PARAM_EL_MAJOR_NAME, CommonConstants.PARAM_EL_MAJOR));
                        ddlEnglishType.Items.Add(new ListItem(CommonConstants.PARAM_EL_CERT_NAME, CommonConstants.PARAM_EL_CERT));
                    }

                    initEnglishCommon();
                    initEnglishMajor();
                    initEnglishCert();

                    if (ddlInfType.Items.Count == 0)
                    {
                        ddlInfType.Items.Add(new ListItem(CommonConstants.PARAM_IT_OFFICE_NAME, CommonConstants.PARAM_IT_OFFICE));
                        ddlInfType.Items.Add(new ListItem(CommonConstants.PARAM_IT_TIP_NAME, CommonConstants.PARAM_IT_TIP));
                    }

                    if (ddlSub.Items.Count == 0)
                    {
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_MATHEMATICS, CommonConstants.SUB_MATHEMATICS_CODE));
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_PHYSICAL, CommonConstants.SUB_PHYSICAL_CODE));
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_CHEMICAL, CommonConstants.SUB_CHEMICAL_CODE));
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_BIOGRAPHY, CommonConstants.SUB_BIOGRAPHY_CODE));
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_LITERATURE, CommonConstants.SUB_LITERATURE_CODE));
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_HISTORY, CommonConstants.SUB_HISTORY_CODE));
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_GEOGRAPHY, CommonConstants.SUB_GEOGRAPHY_CODE));
                        ddlSub.Items.Add(new ListItem(CommonConstants.SUB_ENGLISH, CommonConstants.SUB_ENGLISH_CODE));
                    }

                    if (ddlYear.Items.Count == 0)
                        for (int idx = 2002; idx <= DateTime.Now.Year; ++idx)
                            ddlYear.Items.Add(new ListItem(Convert.ToString(idx), Convert.ToString(idx)));

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
                else
                {
                    isOK = false;
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

            if (!isOK)
                Response.Redirect(CommonConstants.PAGE_LOGIN);
        }

        public void btnSubmitUpload_Click(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (fileContent.HasFile)
                {
                    string folder = CommonConstants.BLANK;
                    // 0 - ltdh
                    // 1 - english
                    // 2 - tin học
                    int type = ddlSubject.SelectedIndex;
                    switch (type)
                    {
                        case 0:
                            {
                                folder = CommonConstants.FOLDER_UNI;
                                folder += Convert.ToString(ddlYear.SelectedValue);

                                break;
                            }
                        case 1:
                            {
                                folder = CommonConstants.FOLDER_IT;
                                folder += Convert.ToString(DateTime.Now.Year);
                                break;
                            }
                        case 2:
                            {
                                folder = CommonConstants.FOLDER_EL;
                                folder += Convert.ToString(DateTime.Now.Year);
                                break;
                            }
                    }

                    string rootFolder = Server.MapPath("~") + "/" + folder + "/";
                    string filename = bs.fileNameToSave(rootFolder + fileContent.FileName);
                    string fileSave = filename.Substring(filename.LastIndexOf(CommonConstants.FOLDER_DATA));
                    string fileSolvingSave = CommonConstants.BLANK;
                    // save file
                    if (!Directory.Exists(rootFolder))
                    {
                        Directory.CreateDirectory(rootFolder);
                    }

                    try
                    {
                        // ghi xuống db
                        switch (type)
                        {
                            case 0:
                                {
                                    contestDAO.insertContest(txtboxTitle.Text,
                                                                        txtboxSummary.Text,
                                                                        user.Username,
                                                                        DateTime.Now,
                                                                        Boolean.Parse(ddlTypeContest.SelectedValue),
                                                                        ddlSub.SelectedValue,
                                                                        Convert.ToInt32(ddlYear.SelectedValue),
                                                                        fileSave,
                                                                        txtboxTag.Text,
                                                                        fileSolvingSave);

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
                            //fileSolving.SaveAs(Server.MapPath("~") + "/" + folder + "/" +
                            //    Path.GetFileNameWithoutExtension(newFileName) +
                            //    "_solved" + Path.GetExtension(fileSolving.FileName));

                            //fileSolvingSave = folder + "/" +
                            //    Path.GetFileNameWithoutExtension(fileContent.FileName) +
                            //    "_solved" + Path.GetExtension(fileSolving.FileName);
                        }
                        else
                            throw new Exception(CommonConstants.MSG_E_UPLOAD);

                        uploadPanel.Visible = false;
                        message.Visible = true;
                        liMessage.Text = CommonConstants.MSG_I_UPLOAD_SUCCESSFUL;
                        liMessage.Text += CommonConstants.MSG_I_THANKS_FOR_UPLOADING;
                        liMessage.Text += CommonConstants.MSG_I_WAITING_FOR_CHECKED;
                        liMessage.Text += CommonConstants.MSG_I_BACK_TO_HOME;
                    }
                    catch (Exception ex)
                    {
                        uploadPanel.Visible = false;
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



        private void initEnglishCommon()
        {
            if (ddlEnglishCommon.Items.Count == 0)
            {
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_1_TO_9_NAME, CommonConstants.PARAM_EL_CLASS_1_TO_9));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_10_NAME, CommonConstants.PARAM_EL_CLASS_10));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_11_NAME, CommonConstants.PARAM_EL_CLASS_11));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_12_NAME, CommonConstants.PARAM_EL_CLASS_12));
            }
        }

        private void initEnglishMajor()
        {
            if (ddlEnglishMajor.Items.Count == 0)
            {
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_MATH_ECO_NAME, CommonConstants.PARAM_EL_MATH_ECO));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_CHEM_BIO_MAT_NAME, CommonConstants.PARAM_EL_CHEM_BIO_MAT));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_PHY_TELE_IT_NAME, CommonConstants.PARAM_EL_PHY_TELE_IT));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_OTHER_MJ_NAME, CommonConstants.PARAM_EL_OTHER_MJ));
            }
        }

        private void initEnglishCert()
        {
            if (ddlEnglishCert.Items.Count == 0)
            {
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_TOEFL_NAME, CommonConstants.PARAM_EL_TOEFL));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_TOEIC_NAME, CommonConstants.PARAM_EL_TOEIC));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_IELTS_NAME, CommonConstants.PARAM_EL_IELTS));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_ABC_NAME, CommonConstants.PARAM_EL_ABC));
            }
        }

        protected void ddlInfType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}