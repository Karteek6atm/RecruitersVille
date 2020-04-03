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

    public class ProfileUploadSaveRequest
    {
        public string FilePath { get; set; }
        public List<ImportedProfilesRequest> ImportedProfiles { get; set; }
    }

    public class VendorListRequest
    {
        public int CompanyId { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string IsEmployer { get; set; }
        public string Technologies { get; set; }
        public string Address { get; set; }
        public int Pagenumber { get; set; }
        public int Pagesize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrderBy { get; set; }
    }

    public class ImportedProfilesRequest
    {
        public string Sno { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string AboutProfile { get; set; }
        public bool IsValid { get; set; }
        public string Comments { get; set; }
    }
}