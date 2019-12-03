using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Requests
{
    public class VendorRequest
    {
        public int UserLoginId { get; set; }
        public int CompanyId { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public bool IsEmployer { get; set; }
        public string Description { get; set; }
        public string VendorLogoPath { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Technologies { get; set; }
    }

    public class VendorUploadSaveRequest
    {
        public string FilePath { get; set; }
        public List<ImportedVendorsRequest> ImportedVendors { get; set; }
    }

    public class ImportedVendorsRequest
    {
        public int Sno { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public bool IsEmployer { get; set; }
        public string Technologies { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string IsValid { get; set; }
        public string Comments { get; set; }
    }
}