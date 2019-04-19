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
    public class JobController : Controller
    {
        // GET: user/job

        #region Members

        JobBal _JobBal = new JobBal();
        ManageSessions objManageSessions = new ManageSessions();

        #endregion

        #region Views 

        public ActionResult newjob()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    JobMastersResponse objjobmastersresponse = new JobMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objjobmastersresponse = _JobBal.GetMastersForJob(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objjobmastersresponse;
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

        public ActionResult editjob(string param1)
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    JobMastersResponse objjobmastersresponse = new JobMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objjobmastersresponse = _JobBal.GetMastersForJob(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objjobmastersresponse;
                    ViewBag.JobId = param1;
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

        public ActionResult viewjob(string param1)
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
                    ViewBag.JobId = param1;
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

        public ActionResult myjobs()
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

        public ActionResult jobtemplates()
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

        public ActionResult newtemplate()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    JobMastersResponse objjobmastersresponse = new JobMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objjobmastersresponse = _JobBal.GetMastersForJob(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objjobmastersresponse;
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

        public ActionResult editjobtemplate(string param1)
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    JobMastersResponse objjobmastersresponse = new JobMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objjobmastersresponse = _JobBal.GetMastersForJob(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    ViewBag.Masters = objjobmastersresponse;
                    ViewBag.JobTemplateId = param1;
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

        public ActionResult viewjobtemplate(string param1)
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
                    ViewBag.JobTemplateId = param1;
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

        [HttpPost]
        public JsonResult InsertAndUpdateJobDetails(JobRequest objrequest)
        {
            JobSaveResponse objresponse = new JobSaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.CompanyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));
                    objresponse = _JobBal.InsertAndUpdateJobDetails(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeJobStatus(JobChangeStatusRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.JobId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobId));
                    objresponse = _JobBal.ChangeJobStatus(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertAndUpdateJobTempateDetails(JobRequest objrequest)
        {
            JobSaveResponse objresponse = new JobSaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.CompanyId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.CompanyId));
                    objresponse = _JobBal.InsertAndUpdateJobTempateDetails(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteJobTemplate(JobChangeStatusRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.JobTemplateId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobTemplateId));
                    objresponse = _JobBal.DeleteJobTemplate(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetJobsList()
        {
            List<JobResponse> objresponse = new List<JobResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _JobBal.GetJobsList(response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetJobTemplatesList()
        {
            List<JobTemplateResponse> objresponse = new List<JobTemplateResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _JobBal.GetJobTemplatesList(response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetJobDetailsByIdForEdit(JobDetailsRequest objrequest)
        {
            JobDetailsForEditResponse objresponse = new JobDetailsForEditResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    objrequest.JobId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobId));
                    objresponse = _JobBal.GetJobDetailsByIdForEdit(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetJobDetailsByIdForView(JobDetailsRequest objrequest)
        {
            JobDetailsForViewResponse objresponse = new JobDetailsForViewResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    objrequest.JobId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobId));
                    objresponse = _JobBal.GetJobDetailsByIdForView(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetJobTemplateDetailsByIdForEdit(JobDetailsRequest objrequest)
        {
            JobDetailsForEditResponse objresponse = new JobDetailsForEditResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    objrequest.JobTemplateId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobTemplateId));
                    objresponse = _JobBal.GetJobTemplateDetailsByIdForEdit(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetJobTemplateDetailsByIdForView(JobDetailsRequest objrequest)
        {
            JobDetailsForViewResponse objresponse = new JobDetailsForViewResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    objrequest.JobTemplateId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobTemplateId));
                    objresponse = _JobBal.GetJobTemplateDetailsByIdForView(objrequest);
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