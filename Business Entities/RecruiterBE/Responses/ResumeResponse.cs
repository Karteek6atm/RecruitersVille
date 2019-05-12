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
}
