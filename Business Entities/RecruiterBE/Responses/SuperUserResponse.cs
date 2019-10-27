using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class SaveAdminResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
    }
    public class SuperUserResponse
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UsersCount { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int ActiveStatusId { get; set; }
        public string ActiveStatus { get; set; }
        public string CreatedEmailId { get; set; }
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string CompanyLogoPath { get; set; }
        public string AboutCompany { get; set; }
    }
    public class CompanyActions
    {
        public int Action { get; set; }
        public int DecryptedCompanyId { get; set; }
        public string CompanyId { get; set; } 
        public int ModifiedBy { get; set; }
    }
    public class CompanyResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
    }
    public class SuperUserProfiles
    {
        public int ProfileId { get; set; }
        public string EnProfileId { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string AlternateEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public string DOB { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public int EducationalQualification { get; set; }
        public string QualificationName { get; set; }
        public string Experience { get; set; }
        public string Location { get; set; }
        public int  IndustryId { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }
        public string ResumePath { get; set; }
        public int ActiveStatusId { get; set; }
        public string ActiveStatus { get; set; }
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ModifiedById { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
    public class JobListResponse
    {
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyJobId { get; set; }
        public string JobLocation { get; set; }
        public int PayTypeId { get; set; }
        public string PayTypeName { get; set; }
        public int PayCurrencyId { get; set; }
        public string PayCurrencySign { get; set; }
        public int MinPayRate { get; set; }
        public int MaxPayRate { get; set; }
        public int JobDurationTypeId { get; set; }
        public string JobDurationTypeName { get; set; }
        public int JobDuration { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string TechnologyNames { get; set; }
        public int JobStatusId { get; set; }
        public string JobStatusName { get; set; }
    }
    public class JobActions
    {
        public int Action { get; set; }
        public int Jobid { get; set; }
        public string EncryptedJobId { get; set; }

        public int ModifiedBy { get; set; }
    }
}
