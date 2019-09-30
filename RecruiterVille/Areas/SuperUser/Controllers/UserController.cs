using RecruiterBAL;
using RecruiterBE;
using RecruiterBE.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruiterVille.Areas.SuperUser.Controllers
{
    public class UserController : Controller
    {
        // GET: SuperUser/user
        #region Members
        SuperUserBal _SuperUserBal = new SuperUserBal();
        #endregion
        #region Views
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompaniesList()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                   // List<SuperUserResponse> objCompanymastersresponse = new List<SuperUserResponse>();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                  //  objCompanymastersresponse = _SuperUserBal.GetAllCompaniesList(response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                   // ViewBag.Masters = objCompanymastersresponse;
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

        public ActionResult ProfilesList()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    // List<SuperUserResponse> objCompanymastersresponse = new List<SuperUserResponse>();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    //  objCompanymastersresponse = _SuperUserBal.GetAllCompaniesList(response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    // ViewBag.Masters = objCompanymastersresponse;
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

        public ActionResult AdminJobsList()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    // List<SuperUserResponse> objCompanymastersresponse = new List<SuperUserResponse>();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    //  objCompanymastersresponse = _SuperUserBal.GetAllCompaniesList(response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    // ViewBag.Masters = objCompanymastersresponse;
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
        public JsonResult GetCompaniesList()
        {
            List<SuperUserResponse> objresponse = new List<SuperUserResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _SuperUserBal.GetAllCompaniesList(response.UserLoginId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChangeAction(CompanyActions objrequest)
        {
            CompanyResponse objresponse = new CompanyResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.ModifiedBy = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));                   
                        objrequest.DecryptedCompanyId = Convert.ToInt32((objrequest.CompanyId));
                        objrequest.Action = Convert.ToInt32((objrequest.Action));

                    objresponse = _SuperUserBal.ChangeAction(objrequest);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProfilesList()
        {
            List<SuperUserProfiles> objresponse = new List<SuperUserProfiles>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _SuperUserBal.GetProfilesList(response.UserLoginId);
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
            List<JobListResponse> objresponse = new List<JobListResponse>();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objresponse = _SuperUserBal.GetJobsList(response.CompanyId);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(objresponse, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ChangeJobAction(JobActions objrequest)
        {
            SaveAdminResponse objresponse = new SaveAdminResponse();
            try
            {
                if (Session["UserLogin"] != null)
                {
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    objrequest.ModifiedBy = Convert.ToInt32(CommonMethods.URLKeyDecrypt(response.UserLoginId));
                    objrequest.Jobid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(objrequest.EncryptedJobId));
                    objrequest.Action = Convert.ToInt32((objrequest.Action));

                    objresponse = _SuperUserBal.ChangeJobAction(objrequest);
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