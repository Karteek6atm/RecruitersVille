using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruiterVille.Models
{
    public class UserLoginModal
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool isremember { get; set; }
        public bool isfromlogin { get; set; }
    }

    public class UserRegistrationModal
    {
        public string fullname { get; set; }
        public string companyname { get; set; }
        public string emailid { get; set; }
        public string contactnumber { get; set; }
        public string password { get; set; }
        public string aboutme { get; set; }
        public int packageid { get; set; }
    }

    public class UserRegistrationVerifyModal
    {
        public int registrationid { get; set; }
        public string verificationcode { get; set; }
    }

    public class ForgotPasswordRequestModal
    {
        public string emailid { get; set; }
    }

    public class UpdateForgotPasswordRequestModal
    {
        public int requestid { get; set; }
        public string verificationcode { get; set; }
        public string password { get; set; }
    }

    public class PackagesRequestModal
    {
        public string currency { get; set; }
    }
}
