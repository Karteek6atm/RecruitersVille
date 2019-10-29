using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class JobResponse
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

    public class JobApplicationsResponse
    {
        public string ApplicationId { get; set; }
        public string ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string ResumePath { get; set; }
        public int ApplicationStatusId { get; set; }
        public string ApplicationStatus { get; set; }
        public string ApplicationDate { get; set; }
    }

    public class JobTemplateResponse
    {
        public string JobTemplateId { get; set; }
        public string JobTitle { get; set; }
        public string TemplateName { get; set; }
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
    }

    public class JobMastersResponse
    {
        public List<PayTypesResponse> PayTypes { get; set; }
        public List<CurrenciesResponse> Currencies { get; set; }
        public List<DurationTypesResponse> DurationTypes { get; set; }
        public List<TravelRequirementsResponse> TravelRequirements { get; set; }
        public List<ApplicationMethodsResponse> ApplicationMethods { get; set; }
        public List<IndustriesResponse> Industries { get; set; }
        public List<SubIndustriesResponse> SubIndustries { get; set; }
        public List<TechnologiesResponse> Technologies { get; set; }
        public List<JobTypesResponse> JobTypes { get; set; }
        public List<LocationsResponse> Locations { get; set; }
    }

    public class JobSaveResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
    }

    public class JobDetailsForEditResponse
    {
        public string CompanyJobId { get; set; }
        public string TemplateName { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public int PayTypeId { get; set; }
        public int PayCurrencyId { get; set; }
        public int MinPayRate { get; set; }
        public int MaxPayRate { get; set; }
        public int JobDurationTypeId { get; set; }
        public int JobDuration { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public int TravelAllowanceTypeId { get; set; }
        public int TravelAllowances { get; set; }
        public bool IsWFHAvailable { get; set; }
        public string JobDescription { get; set; }
        public int ApplicationMethodTypeId { get; set; }
        public string ToEmailId { get; set; }
        public string CcEmailId { get; set; }
        public string URL { get; set; }
        public string PostFromDate { get; set; }
        public string PostToDate { get; set; }
        public int IndustryId { get; set; }
        public int JobStatusId { get; set; }
        public string JobTypeIds { get; set; }
        public string SubIndustryIds { get; set; }
        public string SkillIds { get; set; }
    }

    public class JobDetailsForViewResponse
    {
        public string TemplateName { get; set; }
        public string JobTitle { get; set; }
        public string CompanyJobId { get; set; }
        public string JobLocation { get; set; }
        public string PayTypeName { get; set; }
        public string PayCurrencySign { get; set; }
        public int MinPayRate { get; set; }
        public int MaxPayRate { get; set; }
        public string JobDurationTypeName { get; set; }
        public int JobDuration { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public string TravelRequirementName { get; set; }
        public int TravelAllowances { get; set; }
        public bool IsWFHAvailable { get; set; }
        public string JobDescription { get; set; }
        public string ApplicationMethodTypeName { get; set; }
        public string ToEmailId { get; set; }
        public string CcEmailId { get; set; }
        public string URL { get; set; }
        public string PostFromDate { get; set; }
        public string PostToDate { get; set; }
        public string IndustryName { get; set; }
        public string JobStatus { get; set; }
        public string JobTypeNames { get; set; }
        public string SubIndustryNames { get; set; }
        public string TechnologyNames { get; set; }
    }
}
