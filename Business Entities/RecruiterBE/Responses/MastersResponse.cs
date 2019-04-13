using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class MastersResponse
    {
    }

    public class ExperiencesResponse
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; }
    }

    public class HiringForResponse
    {
        public int HiringForId { get; set; }
        public string HiringForName { get; set; }
    }

    public class IndustriesResponse
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
    }

    public class SubIndustriesResponse
    {
        public int SubIndustryId { get; set; }
        public string SubIndustryName { get; set; }
    }

    public class TechnologiesResponse
    {
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }
    }

    public class RolesResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class PayTypesResponse
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class CurrenciesResponse
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
    }

    public class DurationTypesResponse
    {
        public int DurationId { get; set; }
        public string DurationName { get; set; }
    }

    public class TravelRequirementsResponse
    {
        public int RequirementId { get; set; }
        public string RequirementName { get; set; }
    }

    public class ApplicationMethodsResponse
    {
        public int MethodId { get; set; }
        public string MethodName { get; set; }
    }

    public class JobTypesResponse
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class LocationsResponse
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
