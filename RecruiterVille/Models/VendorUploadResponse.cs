using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruiterVille.Models
{
    public class VendorUploadResponse
    {
        public string Sno { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string IsEmployer { get; set; }
        public string Technologies { get; set; }
        public string resumepath { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public bool IsValid { get; set; }
        public string Comments { get; set; }
        public string FilePath { get; set; }
    }
}