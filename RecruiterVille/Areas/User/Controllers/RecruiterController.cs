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
using System.Web.Mvc;

namespace RecruiterVille.Areas.User.Controllers
{
    public class RecruiterController : Controller
    {
        // GET: user/recruiter

        #region Members

        ProfileBal _ProfileBal = new ProfileBal();
        UserBal _UserBal = new UserBal();
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
                    objusermasterresponse = _UserBal.GetMastersForUsers(response.CompanyId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.Masters = objusermasterresponse;
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

                    if(objresponse.StatusId == 1)
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

        #endregion

        #endregion
    }
}