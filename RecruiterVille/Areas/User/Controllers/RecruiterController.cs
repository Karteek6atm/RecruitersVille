using RecruiterBAL;
using RecruiterBE;
using RecruiterBE.Requests;
using RecruiterBE.Responses;
using RecruiterVille.CommonClasses;
using RecruiterVille.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace RecruiterVille.Areas.User.Controllers
{
    public class RecruiterController : Controller
    {
        // GET: user/recruiter

        #region Members

        ProfileBal _ProfileBal = new ProfileBal();
        UserBal _UserBal = new UserBal();
        VendorBal _VendorBal = new VendorBal();
        ManageSessions objManageSessions = new ManageSessions();

        #endregion

        #region Views 

        public ActionResult dashboard()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
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

        public ActionResult profile()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    ProfileMastersResponse objprofilemastersresponse = new ProfileMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objprofilemastersresponse = _ProfileBal.GetMastersForProfile(response.UserLoginId, response.CompanyId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objprofilemastersresponse;
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

        public ActionResult transactions()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
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

        public ActionResult users()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    UserMasterResponse objusermasterresponse = new UserMasterResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];

                    if (response.PackageId == 4)
                    {
                        objusermasterresponse = _UserBal.GetMastersForUsers(response.CompanyId);
                        ViewBag.LoginId = response.UserLoginId;
                        ViewBag.CompanyId = response.CompanyId;
                        ViewBag.Masters = objusermasterresponse;
                        return View();
                    }
                    else
                    {
                        return Redirect("/error");
                    }
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

        public ActionResult permissions()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
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

        public ActionResult vendors()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    VendorMasterResponse objvendormasterresponse = new VendorMasterResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objvendormasterresponse = _VendorBal.GetMastersForVendors(response.CompanyId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.Masters = objvendormasterresponse;
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

        public ActionResult vendoruploads()
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

        #endregion

        #region Actions 

        #region Profile

        [HttpGet]
        public JsonResult GetProfileDetails()
        {
            ProfileResponse objresponse = new ProfileResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _ProfileBal.GetProfileDetails(response.UserLoginId, response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UploadUserProfilePic(HttpPostedFileBase file)
        {
            ImageUploadModal objresponse = new ImageUploadModal();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    if (ModelState.IsValid)
                    {
                        var originalFilename = Path.GetFileNameWithoutExtension(file.FileName);
                        var fileextension = Path.GetExtension(file.FileName);
                        string strFileName = DateTime.Now.ToString("MM-dd-yyyy_HHmmss");
                        string filepath = ConfigurationManager.AppSettings["UserImages"].ToString() + originalFilename + "_" + strFileName + fileextension;

                        var path = Server.MapPath(filepath);
                        objresponse.imagepath = filepath;
                        file.SaveAs(path);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UploadCompanyLogo(HttpPostedFileBase file)
        {
            ImageUploadModal objresponse = new ImageUploadModal();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    if (ModelState.IsValid)
                    {
                        var originalFilename = Path.GetFileNameWithoutExtension(file.FileName);
                        var fileextension = Path.GetExtension(file.FileName);
                        string strFileName = DateTime.Now.ToString("MM-dd-yyyy_HHmmss");
                        string filepath = ConfigurationManager.AppSettings["CompanyLogos"].ToString() + originalFilename + "_" + strFileName + fileextension;

                        var path = Server.MapPath(filepath);
                        objresponse.imagepath = filepath;
                        file.SaveAs(path);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUserPersonalDetails(ProfileRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objresponse = _ProfileBal.UpdateUserPersonalDetails(objrequest);

                    if (objresponse.StatusId == 1)
                    {
                        response.ProfilePicPath = objrequest.ProfilePicPath;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCompanyDetails(CompanyProfileRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.CompanyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));
                    objresponse = _ProfileBal.UpdateCompanyDetails(objrequest);

                    if (objresponse.StatusId == 1)
                    {
                        response.CompanyLogoPath = objrequest.CompanyLogoPath;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUserProfessionalDetails(ProfessionalRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objresponse = _ProfileBal.UpdateUserProfessionalDetails(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUserPassword(UserPasswordRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objresponse = _ProfileBal.UpdateUserPassword(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Users 

        [HttpGet]
        public JsonResult GetUsersList()
        {
            List<UserResponse> objresponse = new List<UserResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _UserBal.GetUsersList(response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertAndUpdateUserDetails(UserRequest objrequest)
        {
            UserSaveResponse objresponse = new UserSaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.CompanyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));
                    objresponse = _UserBal.InsertAndUpdateUserDetails(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserDetailsById(int param1) // param1 = userid
        {
            UserDetailsResponse objresponse = new UserDetailsResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    objresponse = _UserBal.GetUserDetailsById(param1);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteUserDetails(int param1) // param1 = userid
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    int userloginid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objresponse = _UserBal.DeleteUserDetails(userloginid, param1);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Vendors 

        [HttpGet]
        public JsonResult GetVendorsList()
        {
            List<VendorResponse> objresponse = new List<VendorResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _VendorBal.GetVendorsList(response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertAndUpdateVendorDetails(VendorRequest objrequest)
        {
            VendorSaveResponse objresponse = new VendorSaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.CompanyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));
                    objresponse = _VendorBal.InsertAndUpdateVendorDetails(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetVendorDetailsById(int param1) // param1 = vendorid
        {
            VendorDetailsResponse objresponse = new VendorDetailsResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    objresponse = _VendorBal.GetVendorDetailsById(param1);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteVendorDetails(int param1) // param1 = vendorid
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    int userloginid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objresponse = _VendorBal.DeleteVendorDetails(userloginid, param1);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadVendors(HttpPostedFileBase file)
        {
            List<VendorUploadResponse> objresponse = new List<VendorUploadResponse>();

            try
            {
                if (Session["UserLogin"] != null)
                {
                    if (ModelState.IsValid)
                    {
                        var originalFilename = Path.GetFileNameWithoutExtension(file.FileName);
                        var fileextension = Path.GetExtension(file.FileName);
                        string strFileName = DateTime.Now.ToString("MM-dd-yyyy_HHmmss");
                        string filepath = ConfigurationManager.AppSettings["VendorUploads"].ToString() + originalFilename + "_" + strFileName + fileextension;

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
                            uint nameindex = 0;
                            uint emailidindex = 0;
                            uint contactnumberindex = 0;
                            uint isemployerindex = 0;
                            uint technologiesindex = 0;
                            uint streetindex = 0;
                            uint landmarkindex = 0;
                            uint cityindex = 0;
                            uint stateindex = 0;
                            uint countryindex = 0;
                            uint zipcodeindex = 0;

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
                                        else if (value.Replace(" ", string.Empty).ToLower() == "vendorname")
                                        {
                                            nameindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "emailid")
                                        {
                                            emailidindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "contactnumber")
                                        {
                                            contactnumberindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "isemployer?")
                                        {
                                            isemployerindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "technologies")
                                        {
                                            technologiesindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "street")
                                        {
                                            streetindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "landmark")
                                        {
                                            landmarkindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "city")
                                        {
                                            cityindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "state")
                                        {
                                            stateindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "country")
                                        {
                                            countryindex = index;
                                        }
                                        else if (value.Replace(" ", string.Empty).ToLower() == "zipcode")
                                        {
                                            zipcodeindex = index;
                                        }

                                        index++;
                                    }
                                }
                                else
                                {
                                    VendorUploadResponse upload = new VendorUploadResponse();

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
                                        else if (nameindex == index)
                                        {
                                            upload.VendorName = value;
                                            //if (string.IsNullOrEmpty(value))
                                            //{
                                            //    isValid = false;
                                            //    comments = (string.IsNullOrEmpty(comments)) ? "Vendor name should not be empty" : comments + ", Vendor name should not be empty";
                                            //}
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
                                            //if (string.IsNullOrEmpty(value))
                                            //{
                                            //    isValid = false;
                                            //    comments = (string.IsNullOrEmpty(comments)) ? "Contact number should not be empty" : comments + ", Contact number should not be empty";
                                            //}
                                            //else if (!CommonMethods.IsPhoneNumber(value))
                                            //{
                                            //    isValid = false;
                                            //    comments = (string.IsNullOrEmpty(comments)) ? "Invalid contact number" : comments + ", Invalid contact number";
                                            //}
                                        }
                                        else if (isemployerindex == index)
                                        {
                                            upload.IsEmployer = value;
                                        }
                                        else if (technologiesindex == index)
                                        {
                                            upload.Technologies = value;
                                        }
                                        else if (streetindex == index)
                                        {
                                            upload.Street = value;
                                        }
                                        else if (landmarkindex == index)
                                        {
                                            upload.Landmark = value;
                                        }
                                        else if (cityindex == index)
                                        {
                                            upload.City = value;
                                        }
                                        else if (stateindex == index)
                                        {
                                            upload.State = value;
                                        }
                                        else if (countryindex == index)
                                        {
                                            upload.Country = value;
                                        }
                                        else if (zipcodeindex == index)
                                        {
                                            upload.Zipcode = value;
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
        public JsonResult InsertVendorUploads(VendorUploadSaveRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    int userLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    int companyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));
                    string vendorFilePath = objrequest.FilePath;

                    DataTable dtVendorUploads = new DataTable();

                    dtVendorUploads.Columns.Add("Sno", typeof(int));
                    dtVendorUploads.Columns.Add("VendorName", typeof(string));
                    dtVendorUploads.Columns.Add("EmailId", typeof(string));
                    dtVendorUploads.Columns.Add("ContactNumber", typeof(string));
                    dtVendorUploads.Columns.Add("IsEmployer", typeof(bool));
                    dtVendorUploads.Columns.Add("Technologies", typeof(string));
                    dtVendorUploads.Columns.Add("Street", typeof(string));
                    dtVendorUploads.Columns.Add("Landmark", typeof(string));
                    dtVendorUploads.Columns.Add("City", typeof(string));
                    dtVendorUploads.Columns.Add("State", typeof(string));
                    dtVendorUploads.Columns.Add("Country", typeof(string));
                    dtVendorUploads.Columns.Add("Zipcode", typeof(string));
                    dtVendorUploads.Columns.Add("IsValid", typeof(bool));
                    dtVendorUploads.Columns.Add("Comments", typeof(string));

                    foreach(ImportedVendorsRequest vendor in objrequest.ImportedVendors)
                    {
                        DataRow dr = dtVendorUploads.NewRow();

                        dr["Sno"] = vendor.Sno;
                        dr["VendorName"] = vendor.VendorName;
                        dr["EmailId"] = vendor.EmailId;
                        dr["ContactNumber"] = vendor.ContactNumber;
                        dr["IsEmployer"] = vendor.IsEmployer;
                        dr["Technologies"] = vendor.Technologies;
                        dr["Street"] = vendor.Street;
                        dr["Landmark"] = vendor.Landmark;
                        dr["City"] = vendor.City;
                        dr["State"] = vendor.State;
                        dr["Country"] = vendor.Country;
                        dr["Zipcode"] = vendor.Zipcode;
                        dr["IsValid"] = vendor.IsValid;
                        dr["Comments"] = vendor.Comments;

                        dtVendorUploads.Rows.Add(dr);
                    }

                    objresponse = _VendorBal.InsertVendorUploads(userLoginId, companyId, vendorFilePath, dtVendorUploads);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetVendorUploadsList()
        {
            List<ImportedVendorsResponse> objresponse = new List<ImportedVendorsResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _VendorBal.GetVendorUploadsList(response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion
    }
}