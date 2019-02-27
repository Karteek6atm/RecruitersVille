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
                string body = "Hello " + name + ",<br/><br/>Yuor EmailId verification code is : " + verificationcode + ".<br/><br/>Thank you<br/>Recruiters Ville Team";

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
                string body = "Hello " + name + ",<br/><br/>Yuor EmailId verified successfully.<br/><br/>Thank you<br/>Recruiters Ville Team";

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
                string body = "Hello " + name + ",<br/><br/>Yuor reset password verification code is :" + verificationcode + "<br/><br/>Thank you<br/>Recruiters Ville Team";

                CommonMethods.SendEmail(toemailid, subject, body);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
        }
    }
}
