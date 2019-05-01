using RecruiterBE.Responses;
using RecruiterVille.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruiterVille.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        // GET: User/Profile
        
        #region Members
        
        ManageSessions objManageSessions = new ManageSessions();

        #endregion

        #region View

        public ActionResult index()
        {
            return View();
        }

        public ActionResult newprofile()
        {
            try
            {
                if (Session["UserLogin"] != null)
                {
                    //JobMastersResponse objjobmastersresponse = new JobMastersResponse();
                    LoginResponse response = (LoginResponse)Session["UserLogin"];
                    //objjobmastersresponse = _JobBal.GetMastersForJob(response.CompanyId, response.UserLoginId);
                    ViewBag.LoginId = response.UserLoginId;
                    ViewBag.CompanyId = response.CompanyId;
                    ViewBag.RoleId = response.RoleId;
                    ViewBag.CompanyName = response.CompanyName;
                    //ViewBag.Masters = objjobmastersresponse;
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
    }
}