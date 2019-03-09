using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Requests
{
    public class ProfileRequest
    {
        public int UserLoginId { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePicPath { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }

    public class CompanyProfileRequest
    {
        public int UserLoginId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string AboutCompany { get; set; }
        public string CompanyLogoPath { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }

    public class ProfessionalRequest
    {
        public int UserLoginId { get; set; }
        public string Designation { get; set; }
        public string CurrentCompanyWorkStartDate { get; set; }
        public int Experience { get; set; }
        public string Description { get; set; }
        public string Achievements { get; set; }
        public string HiringLevels { get; set; }
        public string Industries { get; set; }
        public string FunctionalAreas { get; set; }
        public string Skills { get; set; }
    }

    public class UserPasswordRequest
    {
        public int UserLoginId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}