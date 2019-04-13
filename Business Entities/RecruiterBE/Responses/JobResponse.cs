using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class JobResponse
    {
        
    }

    public class JobMastersResponse
    {
        public List<PayTypesResponse> PayTypes { get; set; }
        public List<CurrenciesResponse> Currencies { get; set; }
        public List<DurationTypesResponse> DurationTypes { get; set; }
        public List<TravelRequirementsResponse> TravelRequirements { get; set; }
        public List<ApplicationMethodsResponse> ApplicationMethods { get; set; }
        public List<IndustriesResponse> Industries { get; set; }
        public List<SubIndustriesResponse> SubIndustries { get; set; }
        public List<TechnologiesResponse> Technologies { get; set; }
        public List<JobTypesResponse> JobTypes { get; set; }
        public List<LocationsResponse> Locations { get; set; }
    }
}
