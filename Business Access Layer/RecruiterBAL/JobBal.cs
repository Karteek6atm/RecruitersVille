using RecruiterBE;
using RecruiterBE.Requests;
using RecruiterBE.Responses;
using RecruiterDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBAL
{
    public class JobBal
    {
        #region Members

        JobDal _JobDal = new JobDal();

        #endregion

        #region Methods

        public JobMastersResponse GetMastersForJob(string strcompanyid, string struserloginid)
        {
            JobMastersResponse objJobMastersResponse = new JobMastersResponse();
            try
            {
                DataSet dsData = new DataSet();
                
                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));
                int userloginid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(struserloginid));
                
                dsData = _JobDal.GetMastersForJob(companyid, userloginid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        var paytypes = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 1).
                                           Select(x => new PayTypesResponse
                                           {
                                               TypeId = x.Field<int>("Id"),
                                               TypeName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.PayTypes = paytypes;

                        var currencies = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 2).
                                           Select(x => new CurrenciesResponse
                                           {
                                               CurrencyId = x.Field<int>("Id"),
                                               CurrencyName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.Currencies = currencies;

                        var durationtypes = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 3).
                                           Select(x => new DurationTypesResponse
                                           {
                                               DurationId = x.Field<int>("Id"),
                                               DurationName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.DurationTypes = durationtypes;

                        var travelrequirements = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 4).
                                           Select(x => new TravelRequirementsResponse
                                           {
                                               RequirementId = x.Field<int>("Id"),
                                               RequirementName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.TravelRequirements = travelrequirements;

                        var applicationmethods = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 5).
                                           Select(x => new ApplicationMethodsResponse
                                           {
                                               MethodId = x.Field<int>("Id"),
                                               MethodName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.ApplicationMethods = applicationmethods;

                        var industries = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 6).
                                           Select(x => new IndustriesResponse
                                           {
                                               IndustryId = x.Field<int>("Id"),
                                               IndustryName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.Industries = industries;

                        var subindustries = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 7).
                                           Select(x => new SubIndustriesResponse
                                           {
                                               SubIndustryId = x.Field<int>("Id"),
                                               SubIndustryName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.SubIndustries = subindustries;

                        var technologies = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 8).
                                           Select(x => new TechnologiesResponse
                                           {
                                               TechnologyId = x.Field<int>("Id"),
                                               TechnologyName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.Technologies = technologies;

                        var jobtypes = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 9).
                                           Select(x => new JobTypesResponse
                                           {
                                               TypeId = x.Field<int>("Id"),
                                               TypeName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.JobTypes = jobtypes;

                        var locations = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 10).
                                           Select(x => new LocationsResponse
                                           {
                                               LocationId = x.Field<int>("Id"),
                                               LocationName = x.Field<string>("Name")
                                           }).ToList();

                        objJobMastersResponse.Locations = locations;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objJobMastersResponse;
        }
        
        #endregion
    }
}
