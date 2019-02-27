using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruiterBE.Responses;
using IRecruiterDAL;
using RecruiterBE.Requests;

namespace IRecruiterBAL
{
    public interface ILoginBal
    {
        LoginResponse UserLogin(LoginRequest objrequest);
        RegistrationResponse UserRegistration(RegistrationRequest objrequest);
        SaveResponse VerifyUserRegistration(int registrationid, string verificationcode);
        ForgotPasswordResponse UserForgotPasswordRequest(ForgotPasswordRequest objrequest);
        SaveResponse UpdateForgotPassword(UpdateForgotPasswordRequest objrequest);
    }
}
