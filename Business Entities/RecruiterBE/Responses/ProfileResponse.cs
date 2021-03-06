﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class ProfileResponse
    {
        public PersonalProfileResponse PersonalProfile { get; set; }
        public CompanyProfileResponse CompanyProfile { get; set; }
        public ProfessionalProfileResponse ProfessionalProfile { get; set; }
    }
    public class ProfileView
    {
        public ProfileViewResponse PersonalProfile { get; set; } 
    }

    public class ProfileMastersResponse
    {
        public List<ExperiencesResponse> Experiences { get; set; }
        public List<HiringForResponse> HiringFor { get; set; }
        public List<IndustriesResponse> Industries { get; set; }
        public List<SubIndustriesResponse> SubIndustries { get; set; }
        public List<TechnologiesResponse> Technologies { get; set; }
    }

    public class PersonalProfileResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePicPath { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }


    public class ProfileViewResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string AlternateEmailId { get; set; }
        public string Location { get; set; }
        public int CountryId { get; set; }
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string ContactNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string AboutMe { get; set; }
        public string Resume { get; set; }
        public string Skills { get; set; }
        public string ProfilePicPath { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Experience { get; set; }

    }

    public class CompanyProfileResponse
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogoPath { get; set; }
        public string AboutCompany { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }
    
    public class ProfessionalProfileResponse
    {
        public int UserProfessionId { get; set; }
        public string Designation { get; set; }
        public string CurrentCompanyWorkStartDate { get; set; }
        public int Experience { get; set; }
        public string Description { get; set; }
        public string Achievements { get; set; }
        public string HiringForIds { get; set; }
        public string IndustryIds { get; set; }
        public string FunctionalAreas { get; set; }
        public string TechnologyIds { get; set; }
    }

    public class ImportedProfilesResponse
    {
        public int ProfileUploadId { get; set; }
        public string FilePath { get; set; }
        public int TotalRecords { get; set; }
        public int ValidRecords { get; set; }
        public int InvalidRecords { get; set; }
        public string UploadedBy { get; set; }
        public string UploadedDate { get; set; }
    }
}
