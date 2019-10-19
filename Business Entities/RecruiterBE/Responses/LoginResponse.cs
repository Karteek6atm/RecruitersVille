using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class LoginResponse
    {
        public long UserLoginLogId { get; set; }
        public string UserLoginId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
        public string ProfilePicPath { get; set; }
        public string CompanyLogoPath { get; set; }
        public int PackageId { get; set; }
        public int UserId { get; set; }
        public bool IsFirstLogin { get; set; }
        public bool IsSuperUser { get; set; }
        public int SuperUserLoginId { get; set; }
    }
    
    public class RegistrationResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
        public string VerificationCode { get; set; }
        public string EmailId { get; set; }
        public string FullName { get; set; }
        public int RegistrationId { get; set; }
    }

    public class VerificationResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
    }
    
    public class ForgotPasswordResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
        public string VerificationCode { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public int RequestId { get; set; }
    }
}
