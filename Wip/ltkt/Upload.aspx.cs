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

                    
                    initEnglishType();
                    initEnglishCommon();
                    initEnglishMajor();
                    initEnglishCert();

                    initInfType();
                    initITOffice();
                    initITTip();

                    initContestSubject();
                    

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
                    string folderId = CommonConstants.BLANK;
                    long keyCode = 0;
                    // 0 - ltdh
                    // 1 - english
                    // 2 - tin học
                    int type = ddlSubject.SelectedIndex;
                    int _leitmotif = 0;
                    int _class = 0;

                    switch (type)
                    {
                        case 0:
                            {
                                folder = CommonConstants.FOLDER_UNI;
                                keyCode = control.getValueByLong(CommonConstants.CF_KEY_CODE_UNI);
                                folder += "/" + Convert.ToString(ddlYear.SelectedValue);
                                folder += "/" + bs.getSubjectFolder(ddlSub.SelectedValue);
                                break;
                            }
                        case 1:
                            {
                                folder = CommonConstants.FOLDER_IT;
                                keyCode = control.getValueByLong(CommonConstants.CF_KEY_CODE_IT);
                                folder += "/" + Convert.ToString(DateTime.Now.Year);
                                _leitmotif = bs.getLeitmotif(ddlInfType.SelectedValue, ddlInfOffice.SelectedValue, ddlInfTip.SelectedValue);
                                break;
                            }
                        case 2:
                            {
                                //totalRecord = englishDAO.count();
                                keyCode = control.getValueByLong(CommonConstants.CF_KEY_CODE_EL);
                                folder = CommonConstants.FOLDER_EL;
                                //folder += "/" + Convert.ToString(DateTime.Now.Year);
                                folderId += "/" + Convert.ToString(DateTime.Now.Year);

                                _class = bs.getClassEng(ddlEnglishType.SelectedValue, ddlEnglishCommon.SelectedValue, ddlEnglishMajor.SelectedValue, ddlEnglishCert.SelectedValue);

                                break;
                            }
                    }
                    folderId += "/" + BaseServices.getProperlyFolderID(keyCode);
                    folder += "/" + folderId;
                    string rootFolder = Server.MapPath("~") + "/" + folder + "/";
                    while(BaseServices.isFolderExisted(rootFolder))
                    {
                        rootFolder += BaseServices.random(0, 1000);
                    }
                    string filename = bs.fileNameToSave(rootFolder + fileContent.FileName);
                    string fileSave = filename.Substring(filename.LastIndexOf(CommonConstants.FOLDER_DATA));
                    bool fileContentGood = false;
                    bool fileSolvingGood = false;
                    string fileSolvingSave = CommonConstants.BLANK;
                    string _fileSolving = CommonConstants.BLANK;
                    string fileTypes = control.getValueString(CommonConstants.CF_FILE_TYPE_ALLOW);
                    int maxSize = control.getValueByInt(CommonConstants.CF_MAX_FILE_SIZE);
                    maxSize = maxSize * 1024 * 1024;


                    try
                    {
                        if (fileSolving.HasFile)
                        {
                            if (bs.checkFileType(fileSolving.FileName, fileTypes)
                                && fileSolving.PostedFile.ContentLength <= maxSize)
                            {
                                _fileSolving = filename.Substring(0, filename.LastIndexOf(".")) + "_solved" + Path.GetExtension(fileSolving.FileName);
                                _fileSolving = bs.fileNameToSave(_fileSolving);
                                fileSolvingGood = true;
                            }
                            else
                                throw new Exception(CommonConstants.MSG_E_UPLOAD);
                        }
                        

                        //fileContent.SaveAs(filename);
                        if (bs.checkFileType(fileContent.FileName, fileTypes)
                            && fileContent.PostedFile.ContentLength <= maxSize)
                            fileContentGood = true;
                        else
                            throw new Exception(CommonConstants.MSG_E_UPLOAD);


                        // save file
                        if (!Directory.Exists(rootFolder))
                        {
                            Directory.CreateDirectory(rootFolder);
                        }

                        bool isOK = false;
                        // ghi xuống db
                        switch (type)
                        {
                            case 0:
                                {
                                    isOK = contestDAO.insertContest(txtboxTitle.Text,
                                                                        txtboxSummary.Text,
                                                                        user.Username,
                                                                        DateTime.Now,
                                                                        Boolean.Parse(ddlTypeContest.SelectedValue),
                                                                        ddlSub.SelectedValue,
                                                                        Convert.ToInt32(ddlYear.SelectedValue),
                                                                        fileSave,
                                                                        txtboxTag.Text,
                                                                        fileSolvingSave);
                                    if (isOK)
                                    {
                                        control.add(CommonConstants.CF_KEY_CODE_UNI, CommonConstants.CONST_ONE);
                                    }

                                    break;
                                }
                            case 1:
                                {
                                    isOK = informaticsDAO.insertInformatic(txtboxTitle.Text,
                                                                            0,
                                                                            txtboxSummary.Text,
                                                                            user.Username,
                                                                            DateTime.Now,
                                                                            _leitmotif,
                                                                            fileSave,
                                                                            txtboxTag.Text, folderId);
                                    if (isOK)
                                    {
                                        control.add(CommonConstants.CF_KEY_CODE_IT, CommonConstants.CONST_ONE);
                                    }
                                    break;
                                }
                            case 2:
                                {
                                   
                                    isOK = englishDAO.insertEnglish(txtboxTitle.Text,
                                                                    0
                                                                    -1,
                                                                    txtboxSummary.Text,
                                                                    user.Username,
                                                                    DateTime.Now,
                                                                    _class,
                                                                    fileSave,
                                                                    txtboxTag.Text, folderId);
                                    if (isOK)
                                    {
                                        control.add(CommonConstants.CF_KEY_CODE_EL, CommonConstants.CONST_ONE);
                                    }

                                    break;
                                }
                        }


                        if (isOK)
                        {
                            if (fileContentGood)
                            {
                                fileContent.SaveAs(filename);
                            }
                            if (fileSolvingGood)
                            {
                                fileSolving.SaveAs(_fileSolving);
                            }
                        }
                        else
                            throw new Exception(CommonConstants.MSG_E_COMMON_ERROR_TEXT);

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

        private void initEnglishType()
        {
            if (ddlEnglishType.Items.Count == 0)
            {
                ddlEnglishType.Items.Add(new ListItem(CommonConstants.PARAM_EL_COMMON_NAME, CommonConstants.PARAM_EL_COMMON));
                ddlEnglishType.Items.Add(new ListItem(CommonConstants.PARAM_EL_MAJOR_NAME, CommonConstants.PARAM_EL_MAJOR));
                ddlEnglishType.Items.Add(new ListItem(CommonConstants.PARAM_EL_CERT_NAME, CommonConstants.PARAM_EL_CERT));
            }
        }

        private void initInfType()
        {
            if (ddlInfType.Items.Count == 0)
            {
                ddlInfType.Items.Add(new ListItem(CommonConstants.PARAM_IT_OFFICE_NAME, CommonConstants.PARAM_IT_OFFICE));
                ddlInfType.Items.Add(new ListItem(CommonConstants.PARAM_IT_TIP_NAME, CommonConstants.PARAM_IT_TIP));
            }
        }

        private void initEnglishCommon()
        {
            if (ddlEnglishCommon.Items.Count == 0)
            {
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_1_NAME, CommonConstants.PARAM_EL_CLASS_1));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_2_NAME, CommonConstants.PARAM_EL_CLASS_2));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_3_NAME, CommonConstants.PARAM_EL_CLASS_3));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_4_NAME, CommonConstants.PARAM_EL_CLASS_4));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_5_NAME, CommonConstants.PARAM_EL_CLASS_5));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_6_NAME, CommonConstants.PARAM_EL_CLASS_6));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_7_NAME, CommonConstants.PARAM_EL_CLASS_7));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_8_NAME, CommonConstants.PARAM_EL_CLASS_8));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_9_NAME, CommonConstants.PARAM_EL_CLASS_9));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_10_NAME, CommonConstants.PARAM_EL_CLASS_10));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_11_NAME, CommonConstants.PARAM_EL_CLASS_11));
                ddlEnglishCommon.Items.Add(new ListItem(CommonConstants.PARAM_EL_CLASS_12_NAME, CommonConstants.PARAM_EL_CLASS_12));
            }
        }

        private void initEnglishMajor()
        {
            if (ddlEnglishMajor.Items.Count == 0)
            {
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_MATH_NAME, CommonConstants.PARAM_EL_MATH));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_ECO_NAME, CommonConstants.PARAM_EL_ECO));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_CHEM_NAME, CommonConstants.PARAM_EL_CHEM));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_BIO_NAME, CommonConstants.PARAM_EL_BIO));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_MAT_NAME, CommonConstants.PARAM_EL_MAT));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_PHY_NAME, CommonConstants.PARAM_EL_PHY));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_TELE_NAME, CommonConstants.PARAM_EL_TELE));
                ddlEnglishMajor.Items.Add(new ListItem(CommonConstants.PARAM_EL_IT_NAME, CommonConstants.PARAM_EL_IT));
            }
        }

        private void initEnglishCert()
        {
            if (ddlEnglishCert.Items.Count == 0)
            {
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_TOEFL_NAME, CommonConstants.PARAM_EL_TOEFL));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_TOEIC_NAME, CommonConstants.PARAM_EL_TOEIC));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_IELTS_NAME, CommonConstants.PARAM_EL_IELTS));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_A_NAME, CommonConstants.PARAM_EL_A));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_B_NAME, CommonConstants.PARAM_EL_B));
                ddlEnglishCert.Items.Add(new ListItem(CommonConstants.PARAM_EL_C_NAME, CommonConstants.PARAM_EL_C));
            }
        }

        private void initITOffice()
        {
            if (ddlInfOffice.Items.Count == 0)
            {
                ddlInfOffice.Items.Add(new ListItem(CommonConstants.PARAM_IT_OFFICE_WORD_NAME, CommonConstants.PARAM_IT_OFFICE_WORD));
                ddlInfOffice.Items.Add(new ListItem(CommonConstants.PARAM_IT_OFFICE_EXCEL_NAME, CommonConstants.PARAM_IT_OFFICE_EXCEL));
                ddlInfOffice.Items.Add(new ListItem(CommonConstants.PARAM_IT_OFFICE_PP_NAME, CommonConstants.PARAM_IT_OFFICE_PP));
                ddlInfOffice.Items.Add(new ListItem(CommonConstants.PARAM_IT_OFFICE_ACCESS_NAME, CommonConstants.PARAM_IT_OFFICE_ACCESS));
            }
        }

        private void initITTip()
        {
            if (ddlInfTip.Items.Count == 0)
            {
                ddlInfTip.Items.Add(new ListItem(CommonConstants.PARAM_IT_TIP_SIMPLE_NAME, CommonConstants.PARAM_IT_TIP_SIMPLE));
                ddlInfTip.Items.Add(new ListItem(CommonConstants.PARAM_IT_TIP_ADVANCE_NAME, CommonConstants.PARAM_IT_TIP_ADVANCE));
            }
        }

        private void initContestSubject()
        {
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
        }

    }
}