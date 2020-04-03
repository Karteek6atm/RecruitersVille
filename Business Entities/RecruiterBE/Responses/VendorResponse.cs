using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class VendorResponse
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string IsEmployer { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string TechnologyNames { get; set; }
        public long Sno { get; set; }
        public int TotalRecords { get; set; }
    }
    
    public class VendorDetailsResponse
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public bool IsEmployer { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Description { get; set; }
        public string VendorLogoPath { get; set; }
        public string TechnologyIds { get; set; }
    }

    public class VendorMasterResponse
    {
        public List<TechnologiesResponse> Technologies { get; set; }
    }

    public class VendorSaveResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
        public bool IsNewVendor { get; set; }
        public string AdminName { get; set; }
        public string CompanyName { get; set; }
    }

    public class VendorUploadSaveResponse
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
        public string AdminName { get; set; }
        public string CompanyName { get; set; }
    }

    public class UploadedVendors
    {
        public string VendorName { get; set; }
        public string EmailId { get; set; }
    }

    public class ImportedVendorsResponse
    {
        public int VendorUploadId { get; set; }
        public string FilePath { get; set; }
        public int TotalRecords { get; set; }
        public int ValidRecords { get; set; }
        public int InvalidRecords { get; set; }
        public string UploadedBy { get; set; }
        public string UploadedDate { get; set; }
    }
}
