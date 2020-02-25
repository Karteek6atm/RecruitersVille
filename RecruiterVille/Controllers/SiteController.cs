using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RecruiterBE;
using RecruiterVille.Models;
using RecruiterBE.Responses;
using RecruiterBE.Requests;
using RecruiterVille.CommonClasses;
using RecruiterBAL;
using System.Collections.Generic;
using System.Configuration;

namespace RecruiterVille.Controllers
{
    public class SiteController : Controller
    {
        #region Members

        ManageSessions objManageSessions = new ManageSessions();
        SiteBal objSiteBal = new SiteBal();

        #endregion

        #region Views 

        public ActionResult jobs(string param1)
        {
            ViewBag.Search = param1;
            return View();
        }

        public ActionResult jobview(string param1)
        {
            try
            {
                if (!string.IsNullOrEmpty(param1))
                {
                    SearchJobViewResponse objresponse = new SearchJobViewResponse();
                    int jobId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(param1));
                    objresponse = objSiteBal.SearchJobView(jobId);
                    string companylogo = objresponse.CompanyLogo;

                    if (string.IsNullOrEmpty(companylogo))
                    {
                        companylogo = "/images/logo-icon.png";
                    }

                    //objresponse.CompanyLogo = ConfigurationManager.AppSettings["WebsiteUrl"].ToString() + companylogo;

                    ViewBag.Response = objresponse;
                    ViewBag.JobLogo = ConfigurationManager.AppSettings["WebsiteUrl"].ToString() + companylogo;
                    ViewBag.JobUrl = ConfigurationManager.AppSettings["WebsiteUrl"].ToString() + "/jobview/" + param1;
                    return View();
                }
                else
                {
                    return Redirect("/jobs");
                }
            }
            catch
            {
                return Redirect("/jobs");
            }
        }

        #endregion

        #region Actions 

        [HttpGet]
        public JsonResult GetLocations()
        {
            List<LocationsResponse> objresponse = new List<LocationsResponse>();
            try
            {
                objresponse = objSiteBal.GetLocations();
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SearchJobs(SearchJobRequest objrequest)
        {
            List<SearchJobsListResponse> objresponse = new List<SearchJobsListResponse>();
            try
            {
                objresponse = objSiteBal.SearchJobs(objrequest);
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SearchJobView(JobDetailsRequest objrequest)
        {
            SearchJobViewResponse objresponse = new SearchJobViewResponse();
            try
            {
                int jobId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobId));
                objresponse = objSiteBal.SearchJobView(jobId);
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ApplyJob(ApplyJobRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objrequest.JobId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.strJobId));
                objresponse = objSiteBal.ApplyJob(objrequest);
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubmitResume(SubmitResumeRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = objSiteBal.SubmitResume(objrequest);
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetWebDashboardCount()
        {
            WebDashboardCount objresponse = new WebDashboardCount();
            try
            {
                objresponse = objSiteBal.GetWebDashboardCount();
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}