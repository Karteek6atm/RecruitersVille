using RecruiterBAL;
using RecruiterBE.Requests;
using RecruiterBE.Responses;
using RecruiterVille.CommonClasses;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public ActionResult GetProfileDetails()
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
            return Json(objresponse);
        }

        [HttpPost]
        public ActionResult UpdateUserPersonalDetails(ProfileRequest objrequest)
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
            return Json(objresponse);
        }

        [HttpPost]
        public ActionResult UpdateCompanyDetails(CompanyProfileRequest objrequest)
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
            return Json(objresponse);
        }

        [HttpPost]
        public ActionResult UpdateUserProfessionalDetails(ProfessionalRequest objrequest)
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
            return Json(objresponse);
        }

        [HttpPost]
        public ActionResult UpdateUserPassword(UserPasswordRequest objrequest)
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
            return Json(objresponse);
        }

        #endregion
    }
}