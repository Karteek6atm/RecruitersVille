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
    public class SiteBal
    {
        #region Members

        SiteDal _SiteDal = new SiteDal();

        #endregion

        #region Methods

        public List<LocationsResponse> GetLocations()
        {
            List<LocationsResponse> objLocationsResponse = new List<LocationsResponse>();
            try
            {
                DataSet dsData = new DataSet();
                
                dsData = _SiteDal.GetLocations();

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objLocationsResponse = dsData.Tables[0].AsEnumerable().
                                           Select(x => new LocationsResponse
                                           {
                                               LocationId = x.Field<int>("Id"),
                                               LocationName = x.Field<string>("Name")
                                           }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objLocationsResponse;
        }

        public List<SearchJobsListResponse> SearchJobs(SearchJobRequest objrequest)
        {
            List<SearchJobsListResponse> objJobResponse = new List<SearchJobsListResponse>();
            try
            {
                DataSet dsData = new DataSet();
                
                dsData = _SiteDal.SearchJobs(objrequest);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objJobResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new SearchJobsListResponse
                                        {
                                            CompanyJobId = x.Field<string>("CompanyJobId"),
                                            CompanyName = x.Field<string>("CompanyName"),
                                            CompanyLogo = x.Field<string>("CompanyLogoPath"),
                                            IndustryName = x.Field<string>("IndustryName"),
                                            JobDuration = x.Field<int>("JobDuration"),
                                            MaxExp = x.Field<int>("MaxExp"),
                                            MinExp = x.Field<int>("MinExp"),
                                            JobDurationTypeName = x.Field<string>("JobDurationTypeName"),
                                            JobId = CommonMethods.URLKeyEncrypt(Convert.ToString(x.Field<int>("JobId"))),
                                            JobLocation = x.Field<string>("JobLocation"),
                                            JobTitle = x.Field<string>("JobTitle"),
                                            MaxPayRate = x.Field<int>("MaxPayRate"),
                                            MinPayRate = x.Field<int>("MinPayRate"),
                                            //SNo = x.Field<int>("SNo"),
                                            PayCurrencySign = x.Field<string>("PayCurrencySign"),
                                            PayTypeName = x.Field<string>("PayTypeName"),
                                            TechnologyNames = x.Field<string>("TechnologyNames")
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objJobResponse;
        }

        public WebDashboardCount GetWebDashboardCount()
        {
            WebDashboardCount objWebDashboardCount = new WebDashboardCount();
            try
            {
                objWebDashboardCount = _SiteDal.GetWebDashboardCount();
            }
            catch (Exception ex)
            {

            }
            return objWebDashboardCount;
        }

        public SearchJobViewResponse SearchJobView(int jobId)
        {
            SearchJobViewResponse objSearchJobViewResponse = new SearchJobViewResponse();
            try
            {
                objSearchJobViewResponse = _SiteDal.SearchJobView(jobId);
            }
            catch (Exception ex)
            {

            }
            return objSearchJobViewResponse;
        }

        public SaveResponse ApplyJob(ApplyJobRequest request)
        {
            SaveResponse objSaveResponse = new SaveResponse();
            try
            {
                objSaveResponse = _SiteDal.ApplyJob(request);
            }
            catch (Exception ex)
            {

            }
            return objSaveResponse;
        }

        #endregion
    }
}
