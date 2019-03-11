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
}
