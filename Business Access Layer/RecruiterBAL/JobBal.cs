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

        public JobSaveResponse InsertAndUpdateJobDetails(JobRequest objrequest)
        {
            JobSaveResponse objresponse = new JobSaveResponse();
            try
            {
                objresponse = _JobDal.InsertAndUpdateJobDetails(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse ChangeJobStatus(JobChangeStatusRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _JobDal.ChangeJobStatus(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public JobSaveResponse InsertAndUpdateJobTempateDetails(JobRequest objrequest)
        {
            JobSaveResponse objresponse = new JobSaveResponse();
            try
            {
                objresponse = _JobDal.InsertAndUpdateJobTempateDetails(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse DeleteJobTemplate(JobChangeStatusRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _JobDal.DeleteJobTemplate(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public List<JobResponse> GetJobsList(string strcompanyid)
        {
            List<JobResponse> objJobResponse = new List<JobResponse>();
            try
            {
                DataSet dsData = new DataSet();

                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _JobDal.GetJobsList(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objJobResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new JobResponse
                                        {
                                            CompanyJobId = x.Field<string>("CompanyJobId"),
                                            IndustryId = x.Field<int>("IndustryId"),
                                            IndustryName = x.Field<string>("IndustryName"),
                                            JobDuration = x.Field<int>("JobDuration"),
                                            MaxExp = x.Field<int>("MaxExp"),
                                            MinExp = x.Field<int>("MinExp"),
                                            JobDurationTypeId = x.Field<int>("JobDurationTypeId"),
                                            JobDurationTypeName = x.Field<string>("JobDurationTypeName"),
                                            JobId = CommonMethods.URLKeyEncrypt(Convert.ToString(x.Field<int>("JobId"))),
                                            JobLocation = x.Field<string>("JobLocation"),
                                            JobTitle = x.Field<string>("JobTitle"),
                                            MaxPayRate = x.Field<int>("MaxPayRate"),
                                            MinPayRate = x.Field<int>("MinPayRate"),
                                            PayCurrencyId = x.Field<int>("PayCurrencyId"),
                                            PayCurrencySign = x.Field<string>("PayCurrencySign"),
                                            PayTypeId = x.Field<int>("PayTypeId"),
                                            PayTypeName = x.Field<string>("PayTypeName"),
                                            TechnologyNames = x.Field<string>("TechnologyNames"),
                                            JobStatusId = x.Field<int>("JobStatusId"),
                                            JobStatusName = x.Field<string>("JobStatusName")
                                        }).ToList(); 
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objJobResponse;
        }

        public List<JobTemplateResponse> GetJobTemplatesList(string strcompanyid)
        {
            List<JobTemplateResponse> objJobResponse = new List<JobTemplateResponse>();
            try
            {
                DataSet dsData = new DataSet();

                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _JobDal.GetJobTemplatesList(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objJobResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new JobTemplateResponse
                                        {
                                            IndustryId = x.Field<int>("IndustryId"),
                                            IndustryName = x.Field<string>("IndustryName"),
                                            JobDuration = x.Field<int>("JobDuration"),
                                            MaxExp = x.Field<int>("MaxExp"),
                                            MinExp = x.Field<int>("MinExp"),
                                            JobDurationTypeId = x.Field<int>("JobDurationTypeId"),
                                            JobDurationTypeName = x.Field<string>("JobDurationTypeName"),
                                            JobTemplateId = CommonMethods.URLKeyEncrypt(Convert.ToString(x.Field<int>("JobTemplateId"))),
                                            TemplateName = x.Field<string>("TemplateName"),
                                            JobTitle = x.Field<string>("JobTitle"),
                                            MaxPayRate = x.Field<int>("MaxPayRate"),
                                            MinPayRate = x.Field<int>("MinPayRate"),
                                            PayCurrencyId = x.Field<int>("PayCurrencyId"),
                                            PayCurrencySign = x.Field<string>("PayCurrencySign"),
                                            PayTypeId = x.Field<int>("PayTypeId"),
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

        public JobDetailsForEditResponse GetJobDetailsByIdForEdit(JobDetailsRequest objrequest)
        {
            JobDetailsForEditResponse objresponse = new JobDetailsForEditResponse();
            try
            {
                objresponse = _JobDal.GetJobDetailsByIdForEdit(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public JobDetailsForViewResponse GetJobDetailsByIdForView(JobDetailsRequest objrequest)
        {
            JobDetailsForViewResponse objresponse = new JobDetailsForViewResponse();
            try
            {
                objresponse = _JobDal.GetJobDetailsByIdForView(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public JobDetailsForEditResponse GetJobTemplateDetailsByIdForEdit(JobDetailsRequest objrequest)
        {
            JobDetailsForEditResponse objresponse = new JobDetailsForEditResponse();
            try
            {
                objresponse = _JobDal.GetJobTemplateDetailsByIdForEdit(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public JobDetailsForViewResponse GetJobTemplateDetailsByIdForView(JobDetailsRequest objrequest)
        {
            JobDetailsForViewResponse objresponse = new JobDetailsForViewResponse();
            try
            {
                objresponse = _JobDal.GetJobTemplateDetailsByIdForView(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public List<JobApplicationsResponse> GetJobApplications(string strjobid)
        {
            List<JobApplicationsResponse> objJobResponse = new List<JobApplicationsResponse>();
            try
            {
                DataSet dsData = new DataSet();

                int jobid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strjobid));

                dsData = _JobDal.GetJobApplications(jobid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objJobResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new JobApplicationsResponse
                                        {
                                            ApplicationDate = x.Field<string>("ApplicationDate"),
                                            ApplicationId = CommonMethods.URLKeyEncrypt(Convert.ToString(x.Field<int>("ApplicationId"))),
                                            ApplicationStatus = x.Field<string>("ApplicationStatus"),
                                            ApplicationStatusId = x.Field<int>("ApplicationStatusId"),
                                            ContactNumber = x.Field<string>("ContactNumber"),
                                            EmailId = x.Field<string>("EmailId"),
                                            FirstName = x.Field<string>("FirstName"),
                                            LastName = x.Field<string>("LastName"),
                                            ProfileId = CommonMethods.URLKeyEncrypt(Convert.ToString(x.Field<int>("ProfileId"))),
                                            ResumePath = x.Field<string>("ResumePath")
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objJobResponse;
        }

        #endregion
    }
}
