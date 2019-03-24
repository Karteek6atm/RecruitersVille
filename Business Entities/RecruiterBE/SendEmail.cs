using RecruiterBE.Requests;
using RecruiterBE.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE
{
    public static class SendEmail
    {
        public static void SendRegistrationEmail(string toemailid, string verificationcode, string name)
        {
            try
            {
                string subject = "RecruitersVille - Email Verification";
                string body = "Hello " + name + ",<br/><br/>Your EmailId verification code is : " + verificationcode + ".<br/><br/>Thank you<br/>Recruiters Ville Team";

                CommonMethods.SendEmail(toemailid, subject, body);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
        }

        public static void SendVerificationSuccessEmail(string toemailid, string name)
        {
            try
            {
                string subject = "RecruitersVille - Email Verified";
                string body = "Hello " + name + ",<br/><br/>Your EmailId verified successfully.<br/><br/>Thank you<br/>Recruiters Ville Team";

                CommonMethods.SendEmail(toemailid, subject, body);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
        }

        public static void SendForgotPasswordEmail(string toemailid, string verificationcode, string name)
        {
            try
            {
                string subject = "RecruitersVille - Reset Password";
                string body = "Hello " + name + ",<br/><br/>Your reset password verification code is :" + verificationcode + "<br/><br/>Thank you<br/>Recruiters Ville Team";

                CommonMethods.SendEmail(toemailid, subject, body);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
        }

        public static void SendContactusEmailToAdmin(string toemailid, ContactUsRequest objrequest)
        {
            try
            {
                string subject = "RecruitersVille - Contact us Request";
                string body = "Hello Admin,<br/><br/>Contact us Request from : <br/><br/><b>Name</b> : " + objrequest.Name +
                                "<br/><b>EmailId</b> : " + objrequest.EmailId + "<br/><b>Subject</b> : " + objrequest.Subject +
                                "<br/><b>Message</b> : " + objrequest.Message +
                                "<br/><br/>Thank you<br/>Recruiters Ville Team";

                CommonMethods.SendEmail(toemailid, subject, body);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
        }

        public static void SendContactusEmailToUser(string toemailid, string name)
        {
            try
            {
                string subject = "RecruitersVille - Contact us Request";
                string body = "Hello " + name + ",<br/><br/>Thank you for contact us. Our team will contact you soon on your request." +
                                "<br/><br/>Thank you<br/>Recruiters Ville Team";

                CommonMethods.SendEmail(toemailid, subject, body);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
        }

        public static void SendUserCreationEmail(string toemailid, string name, string adminname, string companyname, string password)
        {
            try
            {
                string subject = "RecruitersVille - Account Invitation";
                string body = "Hello " + name + ",<br/><br/>" +
                    "You are invited as an user by " + adminname + " from company " + companyname + ".<br/><br/>" +
                    "Below are your login details :<br/>Username : " + toemailid + "<br/>Password : " + password + "<br/><br/>" +
                    "You can change your password after login into your account using below link : <br/>"+
                    "<a href='http://recruitersville.com/login'>http://recruitersville.com/login</a>" +
                    "<br/><br/>Thank you<br/>Recruiters Ville Team";

                CommonMethods.SendEmail(toemailid, subject, body);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
        }
    }
}
