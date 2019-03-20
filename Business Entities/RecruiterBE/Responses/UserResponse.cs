using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Designation { get; set; }
        public string CurrentCompanyWorkStartDate { get; set; }
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; }
        public string HiringForNames { get; set; }
        public string IndustryNames { get; set; }
        public string SubIndustryNames { get; set; }
        public string TechnologyNames { get; set; }
    }
    
    public class UserMasterResponse
    {
        public List<RolesResponse> Roles { get; set; }
    }
}
