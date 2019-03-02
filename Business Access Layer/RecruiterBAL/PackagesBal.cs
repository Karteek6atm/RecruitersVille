using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruiterBE.Responses;
using RecruiterDAL;
using RecruiterBE.Requests;
using RecruiterBE;
using System.Data;

namespace RecruiterBAL
{
    public class PackagesBal
    {
        #region Members

        PackagesDal _PackagesDal = new PackagesDal();

        #endregion

        #region Methods

        public List<PackagesList> GetPackages(string currency)
        {
            List<PackagesList> objPackagesList = new List<PackagesList>();
            try
            {
                DataSet dsData = new DataSet();
                dsData = _PackagesDal.GetPackages(currency);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objPackagesList = dsData.Tables[0].AsEnumerable().
                                           Select(x => new PackagesList
                                           {
                                               PackageId = x.Field<int>("PackageId"),
                                               Description = x.Field<string>("Description"),
                                               IsPopular = x.Field<bool>("IsPopular"),
                                               MonthlyAmount = x.Field<decimal>("MonthlyAmount"),
                                               MonthlyDiscountPercentage = x.Field<decimal>("MonthlyDiscountPercentage"),
                                               PackageName = x.Field<string>("PackageName"),
                                               YearlyAmount = x.Field<decimal>("YearlyAmount"),
                                               YearlyDiscountPercentage = x.Field<decimal>("YearlyDiscountPercentage"),
                                               CurrencyId = x.Field<int>("CurrencyId"),
                                               CurrencySign = x.Field<string>("CurrencySign"),
                                               FeaturesList = dsData.Tables[1].AsEnumerable().
                                                              Where(a => a.Field<int>("PackageId") == x.Field<int>("PackageId")).
                                                               Select(y => new FeaturesList
                                                               {
                                                                   PackageId = y.Field<int>("PackageId"),
                                                                   Description = y.Field<string>("Description"),
                                                                   FeatureId = y.Field<int>("FeatureId"),
                                                                   FeatureName = y.Field<string>("FeatureName"),
                                                                   Validity = y.Field<int>("Validity"),
                                                                   ValidityTypeId = y.Field<int>("ValidityTypeId"),
                                                                   ValidityTypeName = y.Field<string>("ValidityTypeName"),
                                                                   Value = y.Field<int>("Value")
                                                               }).ToList()
                                           }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objPackagesList;
        }

        #endregion
    }
}
