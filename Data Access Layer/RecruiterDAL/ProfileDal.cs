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
    public class ProfileDal
    {
        #region Members

       public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion

        #region Methods

        public DataSet GetMastersForProfile(int userloginid, int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = userloginid },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetMastersForProfile", sqlparams);
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

        public DataSet GetProfileDetails(int userloginid, int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = userloginid },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetProfileDetails", sqlparams);
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

        public DataSet GetProfileViewDetails(int profileId)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@ProfileId", SqlDbType.Int) { Value = profileId } 
                                        };
            DataSet dsData = new DataSet();

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


        public SaveResponse UpdateUserPersonalDetails(ProfileRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@FullName", SqlDbType.VarChar, 50) { Value = objrequest.FullName },
                                            new SqlParameter("@ContactNumber", SqlDbType.VarChar, 20) { Value = objrequest.ContactNumber },
                                            new SqlParameter("@AboutMe", SqlDbType.VarChar, 500) { Value = objrequest.AboutMe },
                                            new SqlParameter("@ProfilePicPath", SqlDbType.VarChar, 1000) { Value = objrequest.ProfilePicPath },
                                            new SqlParameter("@Street", SqlDbType.VarChar, 200) { Value = objrequest.Street },
                                            new SqlParameter("@Landmark", SqlDbType.VarChar, 200) { Value = objrequest.Landmark },
                                            new SqlParameter("@City", SqlDbType.VarChar, 100) { Value = objrequest.City },
                                            new SqlParameter("@State", SqlDbType.VarChar, 100) { Value = objrequest.State },
                                            new SqlParameter("@Country", SqlDbType.VarChar, 100) { Value = objrequest.Country },
                                            new SqlParameter("@Zipcode", SqlDbType.VarChar, 10) { Value = objrequest.Zipcode }
                                        };
            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UpdateUserPersonalDetails", sqlparams);

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

        public SaveResponse UpdateCompanyDetails(CompanyProfileRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = objrequest.CompanyId },
                                            new SqlParameter("@CompanyName", SqlDbType.VarChar, 50) { Value = objrequest.CompanyName },
                                            new SqlParameter("@AboutCompany", SqlDbType.VarChar, 500) { Value = objrequest.AboutCompany },
                                            new SqlParameter("@CompanyLogoPath", SqlDbType.VarChar, 1000) { Value = objrequest.CompanyLogoPath },
                                            new SqlParameter("@Street", SqlDbType.VarChar, 200) { Value = objrequest.Street },
                                            new SqlParameter("@Landmark", SqlDbType.VarChar, 200) { Value = objrequest.Landmark },
                                            new SqlParameter("@City", SqlDbType.VarChar, 100) { Value = objrequest.City },
                                            new SqlParameter("@State", SqlDbType.VarChar, 100) { Value = objrequest.State },
                                            new SqlParameter("@Country", SqlDbType.VarChar, 100) { Value = objrequest.Country },
                                            new SqlParameter("@Zipcode", SqlDbType.VarChar, 10) { Value = objrequest.Zipcode }
                                        };
            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UpdateCompanyDetails", sqlparams);

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

        public SaveResponse UpdateUserProfessionalDetails(ProfessionalRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@Designation", SqlDbType.VarChar, 100) { Value = objrequest.Designation },
                                            new SqlParameter("@CurrentCompanyWorkStartDate", SqlDbType.VarChar, 20) { Value = objrequest.CurrentCompanyWorkStartDate },
                                            new SqlParameter("@Experience", SqlDbType.Int) { Value = objrequest.Experience },
                                            new SqlParameter("@Description", SqlDbType.VarChar, 1000) { Value = objrequest.Description },
                                            new SqlParameter("@Achievements", SqlDbType.VarChar, 1000) { Value = objrequest.Achievements },
                                            new SqlParameter("@HiringLevels", SqlDbType.VarChar, -1) { Value = objrequest.HiringLevels },
                                            new SqlParameter("@Industries", SqlDbType.VarChar, -1) { Value = objrequest.Industries },
                                            new SqlParameter("@FunctionalAreas", SqlDbType.VarChar, -1) { Value = objrequest.FunctionalAreas },
                                            new SqlParameter("@Skills", SqlDbType.VarChar, -1) { Value = objrequest.Skills }
                                        };
            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();
            
            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UpdateUserProfessionalDetails", sqlparams);

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

        public SaveResponse UpdateUserPassword(UserPasswordRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@NewPassword", SqlDbType.VarChar, 500) { Value = objrequest.NewPassword },
                                            new SqlParameter("@OldPassword", SqlDbType.VarChar, 500) { Value = objrequest.OldPassword }
                                        };
            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UpdateUserPassword", sqlparams);

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

        #endregion
    }
}
