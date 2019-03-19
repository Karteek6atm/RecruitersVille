﻿using RecruiterBAL;
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
                    objresponse = _ProfileBal.UpdateUserPersonalDetails(objrequest);
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
                    objresponse = _ProfileBal.UpdateCompanyDetails(objrequest);
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
                    objresponse = _ProfileBal.UpdateUserPassword(objrequest);
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