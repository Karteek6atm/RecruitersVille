using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruiterBE.Responses;
using RecruiterDAL;
using RecruiterBE.Requests;
using RecruiterBE;

namespace RecruiterBAL
{
    public class LoginBal
    {
        #region Members

        LoginDal _LoginDal = new LoginDal();
        
        #endregion

        #region Methods

        public LoginResponse UserLogin(LoginRequest objrequest)
        {
            objrequest.password = CommonMethods.Encrypt(objrequest.password);
            return _LoginDal.UserLogin(objrequest);
        }

        public RegistrationResponse UserRegistration(RegistrationRequest objrequest)
        {
            RegistrationResponse objresponse = new RegistrationResponse();
            try
            {
                objrequest.password = CommonMethods.Encrypt(objrequest.password);
                objresponse = _LoginDal.UserRegistration(objrequest);

                if (objresponse.StatusId == 1)
                {
                    SendEmail.SendRegistrationEmail(objrequest.emailid, objresponse.VerificationCode, objrequest.fullname);
                    objresponse.VerificationCode = string.Empty;
                }
            }
            catch(Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public VerificationResponse VerifyUserRegistration(int registrationid, string verificationcode)
        {
            VerificationResponse objresponse = new VerificationResponse();
            try
            {
                objresponse = _LoginDal.VerifyUserRegistration(registrationid, verificationcode);

                if (objresponse.StatusId == 1)
                {
                    SendEmail.SendVerificationSuccessEmail(objresponse.EmailId, objresponse.FullName);
                }
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public ForgotPasswordResponse UserForgotPasswordRequest(ForgotPasswordRequest objrequest)
        {
            ForgotPasswordResponse objresponse = new ForgotPasswordResponse();
            try
            {
                objresponse = _LoginDal.UserForgotPasswordRequest(objrequest);

                if (objresponse.StatusId == 1)
                {
                    SendEmail.SendForgotPasswordEmail(objrequest.emailid, objresponse.VerificationCode, objresponse.FullName);
                    objresponse.VerificationCode = string.Empty;
                }
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse UpdateForgotPassword(UpdateForgotPasswordRequest objrequest)
        {
            objrequest.password = CommonMethods.Encrypt(objrequest.password);
            return _LoginDal.UpdateForgotPassword(objrequest);
        }

        #endregion
    }
}
