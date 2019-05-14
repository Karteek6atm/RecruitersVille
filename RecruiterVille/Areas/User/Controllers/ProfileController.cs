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
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruiterVille.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        // GET: User/Profile

        #region Members

        ResumeBal _ResumeBal = new ResumeBal();
        ManageSessions objManageSessions = new ManageSessions();

        #endregion

        #region Views

        public ActionResult myprofiles()
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
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Actions 

        [HttpGet]
        public JsonResult GetProfilesList()
        {
            List<ResumeResponse> objresponse = new List<ResumeResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _ResumeBal.GetProfilesList(response.CompanyId);
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

        #endregion
    }
}