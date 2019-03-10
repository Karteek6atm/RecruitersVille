using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Requests
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    
    public class RegistrationRequest
    {
        public string fullname { get; set; }
        public string companyname { get; set; }
        public string emailid { get; set; }
        public string contactnumber { get; set; }
        public string password { get; set; }
        public string aboutme { get; set; }
        public int packageid { get; set; }
    }

    public class ForgotPasswordRequest
    {
        public string emailid { get; set; }
    }

    public class UpdateForgotPasswordRequest
    {
        public int requestid { get; set; }
        public string verificationcode { get; set; }
        public string password { get; set; }
    }

    public class ContactUsRequest
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
