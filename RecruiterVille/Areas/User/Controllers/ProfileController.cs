using RecruiterBAL;
using RecruiterBE;
using RecruiterBE.Requests;
using RecruiterBE.Responses;
using RecruiterVille.CommonClasses;
using RecruiterVille.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace RecruiterVille.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        // GET: User/Profile

        #region Members

        ResumeBal _ResumeBal = new ResumeBal();
        ProfileBal _ProfileBal = new ProfileBal();

        ManageSessions objManageSessions = new ManageSessions();

        #endregion

        #region Views

        public ActionResult myprofiles()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    ProfileCreationMastersResponse objProfileMastersResponse = new ProfileCreationMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objProfileMastersResponse = _ResumeBal.GetMastersForProfileCreation(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objProfileMastersResponse;
                    return View();
                }
                else
                {
                    return Redirect("/login");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult newprofile()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    ProfileCreationMastersResponse objProfileMastersResponse = new ProfileCreationMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objProfileMastersResponse = _ResumeBal.GetMastersForProfileCreation(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objProfileMastersResponse;
                    return View();
                }
                else
                {
                    return Redirect("/login");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult editprofile(string param1)
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    ProfileCreationMastersResponse objProfileMastersResponse = new ProfileCreationMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objProfileMastersResponse = _ResumeBal.GetMastersForProfileCreation(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objProfileMastersResponse;
                    ViewBag.ProfileId = param1;
                    return View();
                }
                else
                {
                    return Redirect("/login");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult viewprofile(string param1)
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.ProfileId = param1;
                    return View();
                }
                else
                {
                    return Redirect("/login");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult profileuploads()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    return View();
                }
                else
                {
                    return Redirect("/login");
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult UploadResume(HttpPostedFileBase file)
        {
            ResumeUploadModal objresponse = new ResumeUploadModal();
            try
            {
                if (ModelState.IsValid)
                {
                    var originalFilename = Path.GetFileNameWithoutExtension(file.FileName);
                    var fileextension = Path.GetExtension(file.FileName);
                    string strFileName = DateTime.Now.ToString("MM-dd-yyyy_HHmmss");
                    string filepath = ConfigurationManager.AppSettings["Resumes"].ToString() + originalFilename + "_" + strFileName + fileextension;

                    var path = Server.MapPath(filepath);
                    objresponse.resumepath = filepath;
                    file.SaveAs(path);

                    //filepath = Path.GetDirectoryName(path);

                    ////var outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
                    ////if (Directory.Exists(outputFolder))
                    ////{
                    ////    Directory.Delete(outputFolder, true);
                    ////}

                    ////Directory.CreateDirectory(outputFolder);

                    //var processor = new ResumeProcessor(new JsonOutputFormatter());

                    ////var files = Directory.GetFiles("Resumes").Select(Path.GetFullPath);
                    ////foreach (var file1 in files)
                    ////{
                    //    var output = processor.Process(filepath);

                    //    Console.WriteLine(output);

                    //    //var outputFileName = filepath.Substring(filepath.LastIndexOf(Path.DirectorySeparatorChar) + 1) + ".txt";
                    //    //using (var writer = new StreamWriter(Path.Combine(outputFolder, outputFileName)))
                    //    //{
                    //    //    writer.Write(output);
                    //    //}
                    ////}
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Actions 

        [HttpPost]
        public JsonResult GetProfilesList(ResumeListRequest request)
        {
            List<ResumeResponse> objresponse = new List<ResumeResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    request.CompanyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));

                    request.IndustryIds = string.IsNullOrEmpty(request.IndustryIds) ? string.Empty : request.IndustryIds;
                    request.QualificationIds = string.IsNullOrEmpty(request.QualificationIds) ? string.Empty : request.QualificationIds;
                    request.Location = string.IsNullOrEmpty(request.Location) ? string.Empty : request.Location;
                    request.Skills = string.IsNullOrEmpty(request.Skills) ? string.Empty : request.Skills;

                    objresponse = _ResumeBal.GetProfilesList(request);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProfileViewDetails(ProfileViewRequest request)
        {
            ProfileView objresponse = new ProfileView();
            try
            {
                if (Session["UserLogin"] != null)
                { 

                    objresponse = _ProfileBal.GetProfileViewDetails(request.strProfileId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertAndUpdateProfileDetails(ProfileSaveRequest objrequest)
        {
            ResumeSaveResponse objresponse = new ResumeSaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.CompanyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));

                    if (!string.IsNullOrEmpty(objrequest.strProfileId))
                    {
                        objrequest.ProfileId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strProfileId));
                    }
                    else
                    {
                        objrequest.ProfileId = 0;
                    }

                    DataTable dtProfileExperiences = new DataTable();

                    dtProfileExperiences.Columns.Add("ProfileExperienceId", typeof(int));
                    dtProfileExperiences.Columns.Add("CompanyName", typeof(string));
                    dtProfileExperiences.Columns.Add("Location", typeof(string));
                    dtProfileExperiences.Columns.Add("Designation", typeof(string));
                    dtProfileExperiences.Columns.Add("StartDate", typeof(string));
                    dtProfileExperiences.Columns.Add("EndDate", typeof(string));
                    dtProfileExperiences.Columns.Add("IsCurrentCompany", typeof(bool));

                    if (objrequest.Experiences != null)
                    {
                        foreach (ProfileExpRequest experience in objrequest.Experiences)
                        {
                            DataRow dr = dtProfileExperiences.NewRow();

                            dr["ProfileExperienceId"] = experience.ProfileExperienceId;
                            dr["CompanyName"] = experience.CompanyName;
                            dr["Location"] = experience.Location;
                            dr["Designation"] = experience.Designation;
                            dr["StartDate"] = experience.StartDate;
                            dr["EndDate"] = experience.EndDate;
                            dr["IsCurrentCompany"] = experience.IsCurrentCompany;

                            dtProfileExperiences.Rows.Add(dr);
                        }
                    }

                    if (!string.IsNullOrEmpty(objrequest.strProfileId))
                    {
                        objrequest.ProfileId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strProfileId));
                    }
                    else
                    {
                        objrequest.ProfileId = 0;
                    }

                    objresponse = _ResumeBal.InsertAndUpdateProfileDetails(objrequest, dtProfileExperiences);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProfileDetailsById(ResumeDetailsRequest request)
        {
            GetResumeResponse objresponse = new GetResumeResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    request.ProfileId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(request.strProfileId));
                    objresponse = _ResumeBal.GetProfileDetailsById(request.ProfileId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadProfiles(HttpPostedFileBase file)
        {
            List<ProfileUploadResponse> objresponse = new List<ProfileUploadResponse>();

            try
            {
                if (Session["UserLogin"] != null)
                {
                    if (ModelState.IsValid)
                    {
                        var originalFilename = Path.GetFileNameWithoutExtension(file.FileName);
                        var fileextension = Path.GetExtension(file.FileName);
                        string strFileName = DateTime.Now.ToString("MM-dd-yyyy_HHmmss");
                        string filepath = ConfigurationManager.AppSettings["ProfileUploads"].ToString() + originalFilename + "_" + strFileName + fileextension;

                        var path = Server.MapPath(filepath);
                        file.SaveAs(path);

                        LoginResponse response = (LoginResponse)Session["UserLogin"];
                        int userloginid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));

                        using (SpreadsheetDocument doc = SpreadsheetDocument.Open(path, false))
                        {
                            //Read the first Sheet from Excel file.
                            Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                            //Get the Worksheet instance.
                            Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                            //Fetch all the rows present in the Worksheet.
                            IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                            //Loop through the Worksheet rows.

                            uint snoindex = 0;
                            uint firstnameindex = 0;
                            uint lastnameindex = 0;
                            uint emailidindex = 0;
                            uint contactnumberindex = 0;
                            uint experienceindex = 0;
                            uint locationindex = 0;
                            uint skillsindex = 0;
                            uint aboutprofileindex = 0;

                            foreach (Row row in rows)
                            {
                                //Use the first row to add columns to DataTable.
                                if (row.RowIndex.Value == 1)
                                {
                                    uint index = 1;

                                    foreach (Cell cell in row.Descendants<Cell>())
                                    {
                                        string value = objManageSessions.GetValue(doc, cell);
                                                    

                                        if (value.Replace(" ", string.Empty).ToLower() == "sno")
                                        {
                                            snoindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "firstname")
                                        {
                                            firstnameindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "lastname")
                                        {
                                            lastnameindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "emailid")
                                        {
                                            emailidindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "contactnumber")
                                        {
                                            contactnumberindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "experience")
                                        {
                                            experienceindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "location")
                                        {
                                            locationindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "skills")
                                        {
                                            skillsindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "aboutprofile")
                                        {
                                            aboutprofileindex = index;
                                        }

                                        index++;
                                    }
                                }
                                else
                                {
                                    ProfileUploadResponse upload = new ProfileUploadResponse();

                                    int i = 0;
                                    bool isValid = true;
                                    string comments = string.Empty;
                                    uint index = 1;

                                    foreach (Cell cell in row.Descendants<Cell>())
                                    {
                                        string value = objManageSessions.GetValue(doc, cell);

                                        if (snoindex == index)
                                        {
                                            upload.Sno = value;
                                        }
                                        else if (firstnameindex == index)
                                        {
                                            upload.FirstName = value;
                                            if (string.IsNullOrEmpty(value))
                                            {
                                                isValid = false;
                                                comments = (string.IsNullOrEmpty(comments)) ? "First name should not be empty" : comments + ", First name should not be empty";
                                            }
                                        }
                                        else if (lastnameindex == index)
                                        {
                                            upload.LastName = value;
                                            if (string.IsNullOrEmpty(value))
                                            {
                                                isValid = false;
                                                comments = (string.IsNullOrEmpty(comments)) ? "Last name should not be empty" : comments + ", Last name should not be empty";
                                            }
                                        }
                                        else if (emailidindex == index)
                                        {
                                            upload.EmailId = value;
                                            if (string.IsNullOrEmpty(value))
                                            {
                                                isValid = false;
                                                comments = (string.IsNullOrEmpty(comments)) ? "EmailId should not be empty" : comments + ", EmailId should not be empty";
                                            }
                                            else if (!CommonMethods.IsValidEmailId(value))
                                            {
                                                isValid = false;
                                                comments = (string.IsNullOrEmpty(comments)) ? "Invalid emailid" : comments + ", Invalid emailid";
                                            }
                                        }
                                        else if (contactnumberindex == index)
                                        {
                                            upload.ContactNumber = value;
                                            if (string.IsNullOrEmpty(value))
                                            {
                                                isValid = false;
                                                comments = (string.IsNullOrEmpty(comments)) ? "Contact number should not be empty" : comments + ", Contact number should not be empty";
                                            }
                                            else if (!CommonMethods.IsPhoneNumber(value))
                                            {
                                                isValid = false;
                                                comments = (string.IsNullOrEmpty(comments)) ? "Invalid contact number" : comments + ", Invalid contact number";
                                            }
                                        }
                                        else if (experienceindex == index)
                                        {
                                            upload.Experience = value;
                                        }
                                        else if (locationindex == index)
                                        {
                                            upload.Location = value;
                                        }
                                        else if (skillsindex == index)
                                        {
                                            upload.Skills = value;
                                        }
                                        else if (aboutprofileindex == index)
                                        {
                                            upload.AboutProfile = value;
                                        }
                                        i++;
                                        index++;
                                    }
                                    upload.IsValid = isValid;
                                    upload.Comments = comments;
                                    upload.FilePath = filepath;

                                    objresponse.Add(upload);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertProfileUploads(ProfileUploadSaveRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    int userLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    int companyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));
                    string profileFilePath = objrequest.FilePath;

                    DataTable dtProfileUploads = new DataTable();

                    dtProfileUploads.Columns.Add("Sno", typeof(int));
                    dtProfileUploads.Columns.Add("FirstName", typeof(string));
                    dtProfileUploads.Columns.Add("LastName", typeof(string));
                    dtProfileUploads.Columns.Add("EmailId", typeof(string));
                    dtProfileUploads.Columns.Add("ContactNumber", typeof(string));
                    dtProfileUploads.Columns.Add("Location", typeof(string));
                    dtProfileUploads.Columns.Add("Experience", typeof(string));
                    dtProfileUploads.Columns.Add("Skills", typeof(string));
                    dtProfileUploads.Columns.Add("AboutProfile", typeof(string));
                    dtProfileUploads.Columns.Add("IsValid", typeof(bool));
                    dtProfileUploads.Columns.Add("Comments", typeof(string));
                    
                    foreach (ImportedProfilesRequest profile in objrequest.ImportedProfiles)
                    {
                        DataRow dr = dtProfileUploads.NewRow();

                        dr["Sno"] = profile.Sno;
                        dr["FirstName"] = profile.FirstName;
                        dr["LastName"] = profile.LastName;
                        dr["EmailId"] = profile.EmailId;
                        dr["ContactNumber"] = profile.ContactNumber;
                        dr["Location"] = profile.Location;
                        dr["Experience"] = profile.Experience;
                        dr["Skills"] = profile.Skills;
                        dr["AboutProfile"] = profile.AboutProfile;
                        dr["IsValid"] = profile.IsValid;
                        dr["Comments"] = profile.Comments;

                        dtProfileUploads.Rows.Add(dr);
                    }

                    objresponse = _ProfileBal.InsertProfileUploads(userLoginId, companyId, profileFilePath, dtProfileUploads);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProfileUploadsList()
        {
            List<ImportedProfilesResponse> objresponse = new List<ImportedProfilesResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _ProfileBal.GetProfileUploadsList(response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}