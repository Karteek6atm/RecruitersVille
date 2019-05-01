using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Requests
{
    public class JobRequest
    {
        public int UserLoginId { get; set; }
        public int CompanyId { get; set; }        
        public int JobId { get; set; }
        public string strJobId { get; set; }
        public int JobTemplateId { get; set; }
        public string strJobTemplateId { get; set; }
        public string CompanyJobId { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public bool IsJobTemplate { get; set; }
        public string TemplateName { get; set; }
        public int PayType { get; set; }
        public int PayCurrency { get; set; }
        public int MinPayRate { get; set; }
        public int MaxPayRate { get; set; }
        public int JobDurationType { get; set; }
        public int JobDuration { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }        
        public int TravelAllowanceType { get; set; }
        public int TravelAllowances { get; set; }
        public bool IsWFHAvailable { get; set; }
        public string JobDescription { get; set; }
        public int ApplicationMethodType { get; set; }
        public string PostFromDate { get; set; }
        public string PostToDate { get; set; }
        public int IndustryId { get; set; }
        public string ApplicationToEmailId { get; set; }
        public string ApplicationCcEmailId { get; set; }
        public string ApplicationURL { get; set; }
        public string SkillIds { get; set; }
        public string SubIndustryIds { get; set; }
        public string JobTypeIds { get; set; }
        public int JobStatus { get; set; }
    }

    public class JobChangeStatusRequest
    {
        public int UserLoginId { get; set; }
        public int JobId { get; set; }
        public string strJobId { get; set; }
        public int JobTemplateId { get; set; }
        public string strJobTemplateId { get; set; }
        public string Comments { get; set; }
        public int JobStatusId { get; set; }
    }

    public class JobDetailsRequest
    {
        public int JobId { get; set; }
        public string strJobId { get; set; }
        public int JobTemplateId { get; set; }
        public string strJobTemplateId { get; set; }
    }
}
