using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class ResumeResponse
    {
        public string ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Qualification { get; set; }
        public int ExpYears { get; set; }
        public int ExpMonths { get; set; }
        public string Location { get; set; }
        public string Industry { get; set; }
        public string Resume { get; set; }
        public string Skills { get; set; }
        public long Sno { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ProfileCreationMastersResponse
    {
        public List<EducationalQualificationsResponse> EducationalQualifications { get; set; }
        public List<CountriesResponse> Countries { get; set; }
        public List<IndustriesResponse> Industries { get; set; }
        public List<TechnologiesResponse> Technologies { get; set; }
    }

    public class ResumeSaveResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
    }

    public class GetResumeResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string AlternateEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public int ExpYears { get; set; }
        public int ExpMonths { get; set; }
        public string Location { get; set; }
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
        public string Skills { get; set; }
        public List<GetResumeExperiencesResponse> Experiences { get; set; }
    }

    public class GetResumeExperiencesResponse
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
