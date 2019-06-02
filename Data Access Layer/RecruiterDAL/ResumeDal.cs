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
    public class ResumeDal
    {
        #region Members

        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion

        #region Methods

        public DataSet GetMastersForProfileCreation(int userloginid, int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = userloginid },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetMastersForProfileCreation", sqlparams);
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

        public DataSet GetProfilesList(ResumeListRequest request)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = request.CompanyId },
                                            new SqlParameter("@IndustryIds", SqlDbType.VarChar, -1) { Value = request.IndustryIds },
                                            new SqlParameter("@QualificationIds", SqlDbType.VarChar, -1) { Value = request.QualificationIds },
                                            new SqlParameter("@MinExperience", SqlDbType.Int) { Value = request.MinExperience },
                                            new SqlParameter("@MaxExperience", SqlDbType.Int) { Value = request.MaxExperience },
                                            new SqlParameter("@Location", SqlDbType.VarChar, 100) { Value = request.Location },
                                            new SqlParameter("@Skills", SqlDbType.VarChar, -1) { Value = request.Skills }
                                        };
        
                    DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetProfilesList", sqlparams);
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

        public ResumeSaveResponse InsertAndUpdateProfileDetails(ProfileSaveRequest objrequest, DataTable dtProfileExperiences)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = objrequest.CompanyId },
                                            new SqlParameter("@ProfileId", SqlDbType.Int) { Value = objrequest.ProfileId },
                                            new SqlParameter("@FirstName", SqlDbType.VarChar, 100) { Value = objrequest.FirstName },
                                            new SqlParameter("@LastName", SqlDbType.VarChar, 100) { Value = objrequest.LastName },
                                            new SqlParameter("@EmailId", SqlDbType.VarChar, 100) { Value = objrequest.EmailId },
                                            new SqlParameter("@AlternateEmailId", SqlDbType.VarChar, 100) { Value = objrequest.AlternateEmailId },
                                            new SqlParameter("@MobileNumber", SqlDbType.VarChar, 100) { Value = objrequest.MobileNumber },
                                            new SqlParameter("@AlternateMobileNumber", SqlDbType.VarChar, 15) { Value = objrequest.AlternateMobileNumber },
                                            new SqlParameter("@EducationalQualification", SqlDbType.Int) { Value = objrequest.EducationalQualification },
                                            new SqlParameter("@ExpYears", SqlDbType.Int) { Value = objrequest.ExpYears },
                                            new SqlParameter("@ExpMonths", SqlDbType.Int) { Value = objrequest.ExpMonths },
                                            new SqlParameter("@Location", SqlDbType.VarChar, 100) { Value = objrequest.Location },
                                            new SqlParameter("@Country", SqlDbType.Int) { Value = objrequest.Country },
                                            new SqlParameter("@Industry", SqlDbType.Int) { Value = objrequest.Industry },
                                            new SqlParameter("@Description", SqlDbType.VarChar, -1) { Value = objrequest.Description },
                                            new SqlParameter("@Resume", SqlDbType.VarChar, -1) { Value = objrequest.Resume },
                                            new SqlParameter("@Skills", SqlDbType.VarChar, -1) { Value = objrequest.Skills },
                                            new SqlParameter("@ProfileExperiences", SqlDbType.Structured) { Value = dtProfileExperiences }
                                        };

            SqlDataReader reader = null;
            ResumeSaveResponse objSaveResponse = new ResumeSaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_InsertAndUpdateProfileDetails", sqlparams);

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

        public DataSet GetProfileDetailsById(int profileid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@ProfileId", SqlDbType.Int) { Value = profileid }
                                        };

            DataSet dsData = new DataSet();
            GetResumeResponse objresponse = new GetResumeResponse();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetProfileDetailsById", sqlparams);
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
