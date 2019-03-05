using RecruiterBE.Responses;
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
    }
}