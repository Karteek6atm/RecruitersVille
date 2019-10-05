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

namespace RecruiterVille.Controllers
{
    public class SiteController : Controller
    {
        #region Members

        ManageSessions objManageSessions = new ManageSessions();
        SiteBal objSiteBal = new SiteBal();

        #endregion

        #region Views 

        public ActionResult jobs()
        {
            try
            {
                //List<LocationsResponse> objLocationsResponse = new List<LocationsResponse>();
                //objLocationsResponse = objSiteBal.GetLocations();

                //string[] locations = new string[objLocationsResponse.Count];

                //if (objLocationsResponse.Count > 0)
                //{
                //    for (int i = 0; i < objLocationsResponse.Count; i++)
                //    {
                //        locations[i] = objLocationsResponse[i].LocationName;
                //    }
                //}

                //ViewBag.Locations = locations;
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult jobview()
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
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
        public JsonResult GetJobDetailsByIdForEdit(JobDetailsRequest objrequest)
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

        #endregion
    }
}