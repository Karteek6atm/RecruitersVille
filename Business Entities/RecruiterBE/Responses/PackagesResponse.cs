using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Responses
{
    public class PackagesResponse
    {
        
    }

    public class PackagesList
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public decimal MonthlyAmount { get; set; }
        public decimal YearlyAmount { get; set; }
        public decimal MonthlyDiscountPercentage { get; set; }
        public decimal YearlyDiscountPercentage { get; set; }
        public bool IsPopular { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencySign { get; set; }
        public List<FeaturesList> FeaturesList { get; set; }
    }
    
    public class FeaturesList
    {
        public int PackageId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int Validity { get; set; }
        public int ValidityTypeId { get; set; }
        public string ValidityTypeName { get; set; }
    }
}