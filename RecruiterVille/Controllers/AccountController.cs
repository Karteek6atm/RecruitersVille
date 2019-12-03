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
    public class AccountController : Controller
    {
        #region Members

        LoginBal _LoginBal = new LoginBal();
        PackagesBal _PackagesBal = new PackagesBal();
        ManageSessions objManageSessions = new ManageSessions();

        #endregion

        #region Views 

        public ActionResult login()
        {
            try
            {
                if (Session["UserLogin"] == null)
                {
                    string emailid = string.Empty;
                    string password = string.Empty;

                    if (Request.Cookies["EmailId"] != null)
                    {
                        emailid = Request.Cookies["EmailId"].Value;
                    }
                    if (Request.Cookies["Password"] != null)
                    {
                        password = Request.Cookies["Password"].Value;
                    }
                    
                    ViewBag.EmailId = emailid;
                    ViewBag.Password = password;
                    return View();
                }
                else
                {
                    return Redirect("user/dashboard");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult error()
        {
            return View();
        }

        public ActionResult register(string param1)
        {
            try
            {
                if (Session["UserLogin"] == null)
                {
                    ViewBag.Packagename = param1;
                    return View();
                }
                else
                {
                    return Redirect("user/dashboard");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return Redirect("/login");
        }

        public ActionResult packages()
        {
            return View();
        }

        public ActionResult contactus()
        {
            return View();
        }

        #endregion

        #region Actions 

        [HttpPost]
        public ActionResult UserLogin(UserLoginModal objuserlogin)
        {
            LoginResponse objresponse = new LoginResponse();
            try
            {
                LoginRequest objrequest = new LoginRequest();

                objrequest.username = objuserlogin.username;
                objrequest.password = objuserlogin.password;

                objresponse = _LoginBal.UserLogin(objrequest);

                if (objresponse.StatusId == 1)
                {
                    objManageSessions.SaveUserSessions(objresponse);

                    if (objuserlogin.isfromlogin)
                    {
                        if (objuserlogin.isremember)
                        {
                            Response.Cookies["EmailId"].Value = objuserlogin.username;
                            Response.Cookies["Password"].Value = objuserlogin.password;
                            Response.Cookies["EmailId"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Response.Cookies["EmailId"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objresponse.StatusId = 0;
                objresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objresponse.StatusId,
                StatusMessage = objresponse.StatusMessage
            });
        }

        [HttpPost]
        public ActionResult UserRegistration(UserRegistrationModal objuserregistration)
        {
            RegistrationResponse objregistrationresponse = new RegistrationResponse();
            try
            {
                RegistrationRequest objrequest = new RegistrationRequest();

                objrequest.fullname = objuserregistration.fullname;
                objrequest.companyname = objuserregistration.companyname;
                objrequest.emailid = objuserregistration.emailid;
                objrequest.contactnumber = objuserregistration.contactnumber;
                objrequest.password = objuserregistration.password;
                objrequest.aboutme = objuserregistration.aboutme;
                objrequest.packageid = objuserregistration.packageid;

                objregistrationresponse = _LoginBal.UserRegistration(objrequest);
            }
            catch (Exception ex)
            {
                objregistrationresponse.StatusId = 0;
                objregistrationresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objregistrationresponse.StatusId,
                RegistrationId = objregistrationresponse.RegistrationId,
                StatusMessage = objregistrationresponse.StatusMessage
            });
        }

        [HttpPost]
        public ActionResult ResendUserRegistrationDetails(UserRegistrationVerifyModal objuserregistration)
        {
            RegistrationResponse objregistrationresponse = new RegistrationResponse();
            try
            {
                objregistrationresponse = _LoginBal.ResendUserRegistrationDetails(objuserregistration.registrationid);
            }
            catch (Exception ex)
            {
                objregistrationresponse.StatusId = 0;
                objregistrationresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objregistrationresponse.StatusId,
                RegistrationId = objregistrationresponse.RegistrationId,
                StatusMessage = objregistrationresponse.StatusMessage
            });
        }

        [HttpPost]
        public ActionResult VerifyUserRegistration(UserRegistrationVerifyModal objuserregistration)
        {
            VerificationResponse objsaveresponse = new VerificationResponse();
            try
            {
                objsaveresponse = _LoginBal.VerifyUserRegistration(objuserregistration.registrationid, objuserregistration.verificationcode);
            }
            catch (Exception ex)
            {
                objsaveresponse.StatusId = 0;
                objsaveresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objsaveresponse.StatusId,
                StatusMessage = objsaveresponse.StatusMessage
            });
        }

        [HttpPost]
        public ActionResult UserForgotPasswordRequest(ForgotPasswordRequestModal objrequestmodal)
        {
            ForgotPasswordResponse objforgotpasswordresponse = new ForgotPasswordResponse();
            try
            {
                ForgotPasswordRequest objrequest = new ForgotPasswordRequest();

                objrequest.emailid = objrequestmodal.emailid;

                objforgotpasswordresponse = _LoginBal.UserForgotPasswordRequest(objrequest);
            }
            catch (Exception ex)
            {
                objforgotpasswordresponse.StatusId = 0;
                objforgotpasswordresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objforgotpasswordresponse.StatusId,
                RequestId = objforgotpasswordresponse.RequestId,
                StatusMessage = objforgotpasswordresponse.StatusMessage
            });
        }

        [HttpGet]
        public ActionResult ResendUserForgotPasswordRequest(int requestid)
        {
            ForgotPasswordResponse objforgotpasswordresponse = new ForgotPasswordResponse();
            try
            {
                objforgotpasswordresponse = _LoginBal.ResendUserForgotPasswordRequest(requestid);
            }
            catch (Exception ex)
            {
                objforgotpasswordresponse.StatusId = 0;
                objforgotpasswordresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objforgotpasswordresponse.StatusId,
                RequestId = objforgotpasswordresponse.RequestId,
                StatusMessage = objforgotpasswordresponse.StatusMessage
            });
        }

        [HttpPost]
        public ActionResult UpdateForgotPassword(UpdateForgotPasswordRequestModal objrequestmodal)
        {
            SaveResponse objsaveresponse = new SaveResponse();
            try
            {
                UpdateForgotPasswordRequest objrequest = new UpdateForgotPasswordRequest();

                objrequest.password = objrequestmodal.password;
                objrequest.requestid = objrequestmodal.requestid;
                objrequest.verificationcode = objrequestmodal.verificationcode;

                objsaveresponse = _LoginBal.UpdateForgotPassword(objrequest);
            }
            catch (Exception ex)
            {
                objsaveresponse.StatusId = 0;
                objsaveresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objsaveresponse.StatusId,
                StatusMessage = objsaveresponse.StatusMessage
            });
        }

        [HttpPost]
        public JsonResult GetPackages(PackagesRequestModal objrequestmodal)
        {
            List<PackagesList> objPackagesList = new List<PackagesList>();
            try
            {
                objPackagesList = _PackagesBal.GetPackages(objrequestmodal.currency);
            }
            catch (Exception ex)
            {

            }
            return Json(objPackagesList);
        }

        [HttpPost]
        public ActionResult SendContactUsRequest(ContactUsRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _LoginBal.InsertContactRequest(objrequest);
            }
            catch (Exception ex)
            {
                objresponse.StatusId = 0;
                objresponse.StatusMessage = "Oops!! unable to process your request";
            }
            return Json(new
            {
                StatusId = objresponse.StatusId,
                StatusMessage = objresponse.StatusMessage
            });
        }

        #endregion
    }
}