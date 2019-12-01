using Microsoft.ApplicationBlocks.Data;
using RecruiterBE;
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
    public class SiteDal
    {
        #region Members

        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion

        #region Methods

        public DataSet GetLocations()
        {
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetLocations");
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

        public WebDashboardCount GetWebDashboardCount()
        {
            SqlDataReader reader = null;
            WebDashboardCount response = new WebDashboardCount();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetWebDashboardCount");

                while (reader.Read())
                {
                    response.Companies = (long)reader["Companies"];
                    response.Jobs = (long)reader["Jobs"];
                    response.Profiles = (long)reader["Profiles"];
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
            return response;
        }
        
        public DataSet SearchJobs(SearchJobRequest request)
        {
            SqlParameter[] sqlparams = {
                                            new SqlParameter("@Skills", SqlDbType.VarChar, -1) { Value = (string.IsNullOrEmpty(request.Skills)?string.Empty:request.Skills) },
                                            new SqlParameter("@Location", SqlDbType.VarChar, -1) { Value = (string.IsNullOrEmpty(request.Location)?string.Empty:request.Location) },
                                            new SqlParameter("@PageNumber", SqlDbType.Int) { Value = request.PageNumber },
                                            new SqlParameter("@PageSize", SqlDbType.Int) { Value = request.PageSize }
                                        };

            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_SearchJobs", sqlparams);
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

        public SearchJobViewResponse SearchJobView(int jobId)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@JobId", SqlDbType.Int) { Value = jobId }
                                        };

            SqlDataReader reader = null;
            SearchJobViewResponse objresponse = new SearchJobViewResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_SearchJobView", sqlparams);

                while (reader.Read())
                {
                    objresponse.CompanyJobId = (string)reader["CompanyJobId"];
                    objresponse.CompanyName = (string)reader["CompanyName"]; 
                    objresponse.CompanyLogo = (string)reader["CompanyLogoPath"];
                    objresponse.IndustryName = (string)reader["IndustryName"];
                    objresponse.JobDescription = (string)reader["JobDescription"];
                    objresponse.JobDuration = (int)reader["JobDuration"];
                    objresponse.JobDurationTypeName = (string)reader["JobDurationTypeName"];
                    objresponse.JobId = CommonMethods.URLKeyEncrypt(Convert.ToString((int)reader["JobId"]));
                    objresponse.JobLocation = (string)reader["JobLocation"];
                    objresponse.JobTitle = (string)reader["JobTitle"];
                    objresponse.MaxExp = (int)reader["MaxExp"];
                    objresponse.MaxPayRate = (int)reader["MaxPayRate"];
                    objresponse.MinExp = (int)reader["MinExp"];
                    objresponse.MinPayRate = (int)reader["MinPayRate"];
                    objresponse.PayCurrencySign = (string)reader["PayCurrencySign"];
                    objresponse.PayTypeName = (string)reader["PayTypeName"];
                    objresponse.PostFromDate = (string)reader["PostFromDate"];
                    objresponse.PostToDate = (string)reader["PostToDate"];
                    objresponse.TechnologyNames = (string)reader["TechnologyNames"];
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

        public SaveResponse ApplyJob(ApplyJobRequest request)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@JobId", SqlDbType.Int) { Value = request.JobId },
                                            new SqlParameter("@FirstName", SqlDbType.VarChar, 100) { Value = request.FirstName },
                                            new SqlParameter("@LastName", SqlDbType.VarChar, 100) { Value = request.LastName },
                                            new SqlParameter("@EmailId", SqlDbType.VarChar, 100) { Value = request.EmailId },
                                            new SqlParameter("@ContactNumber", SqlDbType.VarChar, 20) { Value = request.ContactNumber },
                                            new SqlParameter("@ResumePath", SqlDbType.VarChar, 1000) { Value = request.ResumePath }
                                        };

            SqlDataReader reader = null;
            SaveResponse objresponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_ApplyJob", sqlparams);

                while (reader.Read())
                {
                    objresponse.StatusId = (int)reader["StatusId"];
                    objresponse.StatusMessage = (string)reader["StatusMessage"];
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

        #endregion
    }
}
