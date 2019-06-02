using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Requests
{
    public class ResumeRequest
    {

    }

    public class ResumeDetailsRequest
    {
        public int ProfileId { get; set; }
        public string strProfileId { get; set; }
    }

    public class ResumeListRequest
    {
        public int CompanyId { get; set; }
        public string IndustryIds { get; set; }
        public string QualificationIds { get; set; }
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }
        public string Location { get; set; }
        public string Skills { get; set; }
    }

    public class ProfileSaveRequest
    {
        public int UserLoginId { get; set; }
        public int CompanyId { get; set; }
        public int ProfileId { get; set; }
        public string strProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string AlternateEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int EducationalQualification { get; set; }
        public int ExpYears { get; set; }
        public int ExpMonths { get; set; }
        public string Location { get; set; }
        public int Country { get; set; }
        public int Industry { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
        public string Skills { get; set; }
        public List<ProfileExpRequest> Experiences { get; set; }
    }
    
    public class ProfileExpRequest
    {
        public int ProfileExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsCurrentCompany { get; set; }
    }
}
