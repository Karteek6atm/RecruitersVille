using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class SiteResponse
    {

    }

    public class SearchJobsListResponse
    {
        public int SNo { get; set; }
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyJobId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string JobLocation { get; set; }
        public string PayTypeName { get; set; }
        public string PayCurrencySign { get; set; }
        public int MinPayRate { get; set; }
        public int MaxPayRate { get; set; }
        public string JobDurationTypeName { get; set; }
        public int JobDuration { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public string IndustryName { get; set; }
        public string TechnologyNames { get; set; }
    }

    public class SearchJobViewResponse
    {
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyJobId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string JobLocation { get; set; }
        public string PayTypeName { get; set; }
        public string PayCurrencySign { get; set; }
        public int MinPayRate { get; set; }
        public int MaxPayRate { get; set; }
        public string JobDurationTypeName { get; set; }
        public int JobDuration { get; set; }
        public int MinExp { get; set; }
        public int MaxExp { get; set; }
        public string PostFromDate { get; set; }
        public string PostToDate { get; set; }
        public string JobDescription { get; set; }
        public string IndustryName { get; set; }
        public string TechnologyNames { get; set; }
    }
}
