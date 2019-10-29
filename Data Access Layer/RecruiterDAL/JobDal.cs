using Microsoft.ApplicationBlocks.Data;
using RecruiterBE.Requests;
using RecruiterBE.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterDAL
{
    public class JobDal
    {
        #region Members

       public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion

        #region Methods

        public DataSet GetMastersForJob(int userloginid, int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = userloginid },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetMastersForJob", sqlparams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return dsData;
        }

        public JobSaveResponse InsertAndUpdateJobDetails(JobRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = objrequest.CompanyId },
                                            new SqlParameter("@JobId", SqlDbType.Int) { Value = objrequest.JobId },
                                            new SqlParameter("@CompanyJobId", SqlDbType.VarChar, 50) { Value = objrequest.CompanyJobId },
                                            new SqlParameter("@JobTitle", SqlDbType.VarChar, 100) { Value = objrequest.JobTitle },
                                            new SqlParameter("@JobLocation", SqlDbType.VarChar, 500) { Value = objrequest.JobLocation },
                                            new SqlParameter("@IsJobTemplate", SqlDbType.Bit) { Value = objrequest.IsJobTemplate },
                                            new SqlParameter("@TemplateName", SqlDbType.VarChar, 100) { Value = objrequest.TemplateName },
                                            new SqlParameter("@PayType", SqlDbType.Int) { Value = objrequest.PayType },
                                            new SqlParameter("@PayCurrency", SqlDbType.Int) { Value = objrequest.PayCurrency },
                                            new SqlParameter("@MinPayRate", SqlDbType.Int) { Value = objrequest.MinPayRate },
                                            new SqlParameter("@MaxPayRate", SqlDbType.Int) { Value = objrequest.MaxPayRate },
                                            new SqlParameter("@JobDurationType", SqlDbType.Int) { Value = objrequest.JobDurationType },
                                            new SqlParameter("@JobDuration", SqlDbType.Int) { Value = objrequest.JobDuration },
                                            new SqlParameter("@MinExp", SqlDbType.Int) { Value = objrequest.MinExp },
                                            new SqlParameter("@MaxExp", SqlDbType.Int) { Value = objrequest.MaxExp },
                                            new SqlParameter("@TravelAllowanceType", SqlDbType.Int) { Value = objrequest.TravelAllowanceType },
                                            new SqlParameter("@TravelAllowances", SqlDbType.Int) { Value = objrequest.TravelAllowances },
                                            new SqlParameter("@IsWFHAvailable", SqlDbType.Bit) { Value = objrequest.IsWFHAvailable },
                                            new SqlParameter("@JobDescription", SqlDbType.VarChar, -1) { Value = objrequest.JobDescription },
                                            new SqlParameter("@ApplicationMethodType", SqlDbType.Int) { Value = objrequest.ApplicationMethodType },
                                            new SqlParameter("@PostFromDate", SqlDbType.VarChar, 20) { Value = objrequest.PostFromDate },
                                            new SqlParameter("@PostToDate", SqlDbType.VarChar, 20) { Value = objrequest.PostToDate },
                                            new SqlParameter("@IndustryId", SqlDbType.Int) { Value = objrequest.IndustryId },
                                            new SqlParameter("@ApplicationToEmailId", SqlDbType.VarChar, 50) { Value = objrequest.ApplicationToEmailId },
                                            new SqlParameter("@ApplicationCcEmailId", SqlDbType.VarChar, 50) { Value = objrequest.ApplicationCcEmailId },
                                            new SqlParameter("@ApplicationURL", SqlDbType.VarChar, 1000) { Value = objrequest.ApplicationURL },
                                            new SqlParameter("@SkillIds", SqlDbType.VarChar, -1) { Value = objrequest.SkillIds },
                                            new SqlParameter("@SubIndustryIds", SqlDbType.VarChar, -1) { Value = objrequest.SubIndustryIds },
                                            new SqlParameter("@JobTypeIds", SqlDbType.VarChar, -1) { Value = objrequest.JobTypeIds },
                                            new SqlParameter("@JobStatus", SqlDbType.Int) { Value = objrequest.JobStatus }
                                        };
           
            SqlDataReader reader = null;
            JobSaveResponse objSaveResponse = new JobSaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_InsertAndUpdateJobDetails", sqlparams);

                while (reader.Read())
                {
                    objSaveResponse.StatusId = (int)reader["StatusId"];
                    objSaveResponse.StatusMessage = (string)reader["StatusMessage"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objSaveResponse;
        }

        public SaveResponse ChangeJobStatus(JobChangeStatusRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@JobId", SqlDbType.Int) { Value = objrequest.JobId },
                                            new SqlParameter("@JobStatusId", SqlDbType.Int) { Value = objrequest.JobStatusId },
                                            new SqlParameter("@Comments", SqlDbType.VarChar, 500) { Value = objrequest.Comments }
                                        };

            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_ChangeJobStatus", sqlparams);

                while (reader.Read())
                {
                    objSaveResponse.StatusId = (int)reader["StatusId"];
                    objSaveResponse.StatusMessage = (string)reader["StatusMessage"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objSaveResponse;
        }

        public JobSaveResponse InsertAndUpdateJobTempateDetails(JobRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = objrequest.CompanyId },
                                            new SqlParameter("@JobTempateId", SqlDbType.Int) { Value = objrequest.JobTemplateId },
                                            new SqlParameter("@JobTitle", SqlDbType.VarChar, 100) { Value = objrequest.JobTitle },
                                            new SqlParameter("@JobLocation", SqlDbType.VarChar, 500) { Value = objrequest.JobLocation },
                                            new SqlParameter("@TemplateName", SqlDbType.VarChar, 100) { Value = objrequest.TemplateName },
                                            new SqlParameter("@PayType", SqlDbType.Int) { Value = objrequest.PayType },
                                            new SqlParameter("@PayCurrency", SqlDbType.Int) { Value = objrequest.PayCurrency },
                                            new SqlParameter("@MinPayRate", SqlDbType.Int) { Value = objrequest.MinPayRate },
                                            new SqlParameter("@MaxPayRate", SqlDbType.Int) { Value = objrequest.MaxPayRate },
                                            new SqlParameter("@JobDurationType", SqlDbType.Int) { Value = objrequest.JobDurationType },
                                            new SqlParameter("@JobDuration", SqlDbType.Int) { Value = objrequest.JobDuration },
                                            new SqlParameter("@MinExp", SqlDbType.Int) { Value = objrequest.MinExp },
                                            new SqlParameter("@MaxExp", SqlDbType.Int) { Value = objrequest.MaxExp },
                                            new SqlParameter("@TravelAllowanceType", SqlDbType.Int) { Value = objrequest.TravelAllowanceType },
                                            new SqlParameter("@TravelAllowances", SqlDbType.Int) { Value = objrequest.TravelAllowances },
                                            new SqlParameter("@IsWFHAvailable", SqlDbType.Bit) { Value = objrequest.IsWFHAvailable },
                                            new SqlParameter("@JobDescription", SqlDbType.VarChar, -1) { Value = objrequest.JobDescription },
                                            new SqlParameter("@ApplicationMethodType", SqlDbType.Int) { Value = objrequest.ApplicationMethodType },
                                            new SqlParameter("@IndustryId", SqlDbType.Int) { Value = objrequest.IndustryId },
                                            new SqlParameter("@ApplicationToEmailId", SqlDbType.VarChar, 50) { Value = objrequest.ApplicationToEmailId },
                                            new SqlParameter("@ApplicationCcEmailId", SqlDbType.VarChar, 50) { Value = objrequest.ApplicationCcEmailId },
                                            new SqlParameter("@ApplicationURL", SqlDbType.VarChar, 1000) { Value = objrequest.ApplicationURL },
                                            new SqlParameter("@SkillIds", SqlDbType.VarChar, -1) { Value = objrequest.SkillIds },
                                            new SqlParameter("@SubIndustryIds", SqlDbType.VarChar, -1) { Value = objrequest.SubIndustryIds },
                                            new SqlParameter("@JobTypeIds", SqlDbType.VarChar, -1) { Value = objrequest.JobTypeIds }
                                        };

            SqlDataReader reader = null;
            JobSaveResponse objSaveResponse = new JobSaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_InsertAndUpdateJobTempateDetails", sqlparams);

                while (reader.Read())
                {
                    objSaveResponse.StatusId = (int)reader["StatusId"];
                    objSaveResponse.StatusMessage = (string)reader["StatusMessage"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objSaveResponse;
        }

        public SaveResponse DeleteJobTemplate(JobChangeStatusRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@JobTemplateId", SqlDbType.Int) { Value = objrequest.JobTemplateId },
                                            new SqlParameter("@Comments", SqlDbType.VarChar, 500) { Value = objrequest.Comments }
                                        };

            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_DeleteJobTemplate", sqlparams);

                while (reader.Read())
                {
                    objSaveResponse.StatusId = (int)reader["StatusId"];
                    objSaveResponse.StatusMessage = (string)reader["StatusMessage"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objSaveResponse;
        }

        public DataSet GetJobsList(int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetJobsList", sqlparams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return dsData;
        }

        public DataSet GetJobTemplatesList(int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetJobTemplatesList", sqlparams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return dsData;
        }

        public JobDetailsForEditResponse GetJobTemplateDetailsByIdForEdit(JobDetailsRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@JobTemplateId", SqlDbType.Int) { Value = objrequest.JobTemplateId }
                                        };

            SqlDataReader reader = null;
            JobDetailsForEditResponse objresponse = new JobDetailsForEditResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetJobTemplateDetailsByIdForEdit", sqlparams);

                while (reader.Read())
                {
                    objresponse.ApplicationMethodTypeId = (int)reader["ApplicationMethodTypeId"];
                    objresponse.CcEmailId = (string)reader["CcEmailId"];
                    objresponse.IndustryId = (int)reader["IndustryId"];
                    objresponse.IsWFHAvailable = (bool)reader["IsWFHAvailable"];
                    objresponse.JobDescription = (string)reader["JobDescription"];
                    objresponse.JobDuration = (int)reader["JobDuration"];
                    objresponse.JobDurationTypeId = (int)reader["JobDurationTypeId"];
                    objresponse.JobLocation = (string)reader["JobLocation"];
                    objresponse.MinExp = (int)reader["MinExp"];
                    objresponse.MaxExp = (int)reader["MaxExp"];
                    objresponse.JobTitle = (string)reader["JobTitle"];
                    objresponse.JobTypeIds = (string)reader["JobTypeIds"];
                    objresponse.MaxPayRate = (int)reader["MaxPayRate"];
                    objresponse.MinPayRate = (int)reader["MinPayRate"];
                    objresponse.PayCurrencyId = (int)reader["PayCurrencyId"];
                    objresponse.PayTypeId = (int)reader["PayTypeId"];
                    objresponse.SubIndustryIds = (string)reader["SubIndustryIds"];
                    objresponse.SkillIds = (string)reader["SkillIds"];
                    objresponse.TemplateName = (string)reader["TemplateName"];
                    objresponse.ToEmailId = (string)reader["ToEmailId"];
                    objresponse.TravelAllowances = (int)reader["TravelAllowances"];
                    objresponse.TravelAllowanceTypeId = (int)reader["TravelAllowanceTypeId"];
                    objresponse.URL = (string)reader["URL"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objresponse;
        }

        public JobDetailsForEditResponse GetJobDetailsByIdForEdit(JobDetailsRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@JobId", SqlDbType.Int) { Value = objrequest.JobId }
                                        };

            SqlDataReader reader = null;
            JobDetailsForEditResponse objresponse = new JobDetailsForEditResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetJobDetailsByIdForEdit", sqlparams);

                while (reader.Read())
                {
                    objresponse.ApplicationMethodTypeId = (int)reader["ApplicationMethodTypeId"];
                    objresponse.CcEmailId = (string)reader["CcEmailId"];
                    objresponse.CompanyJobId = (string)reader["CompanyJobId"];
                    objresponse.IndustryId = (int)reader["IndustryId"];
                    objresponse.IsWFHAvailable = (bool)reader["IsWFHAvailable"];
                    objresponse.JobDescription = (string)reader["JobDescription"];
                    objresponse.JobDuration = (int)reader["JobDuration"];
                    objresponse.JobDurationTypeId = (int)reader["JobDurationTypeId"];
                    objresponse.JobLocation = (string)reader["JobLocation"];
                    objresponse.MinExp = (int)reader["MinExp"];
                    objresponse.MaxExp = (int)reader["MaxExp"];
                    objresponse.JobStatusId = (int)reader["JobStatusId"];
                    objresponse.JobTitle = (string)reader["JobTitle"];
                    objresponse.JobTypeIds = (string)reader["JobTypeIds"];
                    objresponse.MaxPayRate = (int)reader["MaxPayRate"];
                    objresponse.MinPayRate = (int)reader["MinPayRate"];
                    objresponse.PayCurrencyId = (int)reader["PayCurrencyId"];
                    objresponse.PayTypeId = (int)reader["PayTypeId"];
                    objresponse.SubIndustryIds = (string)reader["SubIndustryIds"];
                    objresponse.SkillIds = (string)reader["SkillIds"];
                    objresponse.PostFromDate = (string)reader["PostFromDate"];
                    objresponse.PostToDate = (string)reader["PostToDate"];
                    objresponse.ToEmailId = (string)reader["ToEmailId"];
                    objresponse.TravelAllowances = (int)reader["TravelAllowances"];
                    objresponse.TravelAllowanceTypeId = (int)reader["TravelAllowanceTypeId"];
                    objresponse.URL = (string)reader["URL"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objresponse;
        }

        public JobDetailsForViewResponse GetJobTemplateDetailsByIdForView(JobDetailsRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@JobTemplateId", SqlDbType.Int) { Value = objrequest.JobTemplateId }
                                        };

            SqlDataReader reader = null;
            JobDetailsForViewResponse objresponse = new JobDetailsForViewResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetJobTemplateDetailsByIdForView", sqlparams);

                while (reader.Read())
                {
                    objresponse.ApplicationMethodTypeName = (string)reader["ApplicationMethodTypeName"];
                    objresponse.CcEmailId = (string)reader["CcEmailId"];
                    objresponse.IndustryName = (string)reader["IndustryName"];
                    objresponse.IsWFHAvailable = (bool)reader["IsWFHAvailable"];
                    objresponse.JobDescription = (string)reader["JobDescription"];
                    objresponse.JobDuration = (int)reader["JobDuration"];
                    objresponse.JobDurationTypeName = (string)reader["JobDurationTypeName"];
                    objresponse.JobLocation = (string)reader["JobLocation"];
                    objresponse.MinExp = (int)reader["MinExp"];
                    objresponse.MaxExp = (int)reader["MaxExp"];
                    objresponse.JobTitle = (string)reader["JobTitle"];
                    objresponse.JobTypeNames = (string)reader["JobTypeNames"];
                    objresponse.MaxPayRate = (int)reader["MaxPayRate"];
                    objresponse.MinPayRate = (int)reader["MinPayRate"];
                    objresponse.PayCurrencySign = (string)reader["PayCurrencySign"];
                    objresponse.PayTypeName = (string)reader["PayTypeName"];
                    objresponse.SubIndustryNames = (string)reader["SubIndustryNames"];
                    objresponse.TechnologyNames = (string)reader["TechnologyNames"];
                    objresponse.TemplateName = (string)reader["TemplateName"];
                    objresponse.ToEmailId = (string)reader["ToEmailId"];
                    objresponse.TravelAllowances = (int)reader["TravelAllowances"];
                    objresponse.TravelRequirementName = (string)reader["TravelRequirementName"];
                    objresponse.URL = (string)reader["URL"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objresponse;
        }

        public JobDetailsForViewResponse GetJobDetailsByIdForView(JobDetailsRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@JobId", SqlDbType.Int) { Value = objrequest.JobId }
                                        };

            SqlDataReader reader = null;
            JobDetailsForViewResponse objresponse = new JobDetailsForViewResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetJobDetailsByIdForView", sqlparams);

                while (reader.Read())
                {
                    objresponse.ApplicationMethodTypeName = (string)reader["ApplicationMethodTypeName"];
                    objresponse.CcEmailId = (string)reader["CcEmailId"];
                    objresponse.CompanyJobId = (string)reader["CompanyJobId"];
                    objresponse.IndustryName = (string)reader["IndustryName"];
                    objresponse.IsWFHAvailable = (bool)reader["IsWFHAvailable"];
                    objresponse.JobDescription = (string)reader["JobDescription"];
                    objresponse.JobDuration = (int)reader["JobDuration"];
                    objresponse.JobDurationTypeName = (string)reader["JobDurationTypeName"];
                    objresponse.JobLocation = (string)reader["JobLocation"];
                    objresponse.MinExp = (int)reader["MinExp"];
                    objresponse.MaxExp = (int)reader["MaxExp"];
                    objresponse.JobStatus = (string)reader["JobStatus"];
                    objresponse.JobTitle = (string)reader["JobTitle"];
                    objresponse.JobTypeNames = (string)reader["JobTypeNames"];
                    objresponse.MaxPayRate = (int)reader["MaxPayRate"];
                    objresponse.MinPayRate = (int)reader["MinPayRate"];
                    objresponse.PayCurrencySign = (string)reader["PayCurrencySign"];
                    objresponse.PayTypeName = (string)reader["PayTypeName"];
                    objresponse.SubIndustryNames = (string)reader["SubIndustryNames"];
                    objresponse.TechnologyNames = (string)reader["TechnologyNames"];
                    objresponse.PostFromDate = (string)reader["PostFromDate"];
                    objresponse.PostToDate = (string)reader["PostToDate"];
                    objresponse.ToEmailId = (string)reader["ToEmailId"];
                    objresponse.TravelAllowances = (int)reader["TravelAllowances"];
                    objresponse.TravelRequirementName = (string)reader["TravelRequirementName"];
                    objresponse.URL = (string)reader["URL"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return objresponse;
        }

        public DataSet GetJobApplications(int jobid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@JobId", SqlDbType.Int) { Value = jobid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetJobApplications", sqlparams);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return dsData;
        }

        #endregion
    }
}
