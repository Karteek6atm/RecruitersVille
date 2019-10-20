using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Requests
{
    public class SiteRequest
    {
    }

    public class SearchJobRequest
    {
        public string Skills { get; set; }
        public string Location { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class ApplyJobRequest
    {
        public int JobId { get; set; }
        public string strJobId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string ResumePath { get; set; }
    }
}