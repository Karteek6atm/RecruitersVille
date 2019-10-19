using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruiterBE.Responses;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using RecruiterBE;
using RecruiterBE.Requests;

namespace RecruiterDAL
{
    public class LoginDal
    {
        #region Members

        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion

        #region Methods

        public LoginResponse UserLogin(LoginRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserName", SqlDbType.VarChar, 100) { Value = objrequest.username },
                                            new SqlParameter("@Password", SqlDbType.VarChar, 500) { Value = objrequest.password }
                                        };
            SqlDataReader reader = null;
            LoginResponse objLoginResponse = new LoginResponse();
            
            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UserLogin", sqlparams);

                while (reader.Read())
                {
                    objLoginResponse.Name = (string)reader["Name"];
                    objLoginResponse.UserLoginId = CommonMethods.URLKeyEncrypt(Convert.ToString((int)reader["LoginId"]));
                    objLoginResponse.UserLoginLogId = (long)reader["LoginLogId"]; 
                    objLoginResponse.UserId = (int)reader["UserId"];
                    objLoginResponse.RoleId = (int)reader["RoleId"];
                    objLoginResponse.RoleName = (string)reader["RoleName"];
                    objLoginResponse.StatusId = (int)reader["StatusId"];
                    objLoginResponse.StatusMessage = (string)reader["StatusMessage"];
                    objLoginResponse.CompanyName = (string)reader["CompanyName"];
                    objLoginResponse.CompanyId = CommonMethods.URLKeyEncrypt(Convert.ToString((int)reader["CompanyId"]));
                    objLoginResponse.ProfilePicPath = (string)reader["ProfilePicPath"];
                    objLoginResponse.CompanyLogoPath = (string)reader["CompanyLogoPath"];
                    objLoginResponse.PackageId = (int)reader["PackageId"];
                    objLoginResponse.EmailId = (string)reader["EmailId"];
                    objLoginResponse.ContactNumber = (string)reader["ContactNumber"];
                    objLoginResponse.IsFirstLogin = (bool)reader["IsFirstLogin"];
                    objLoginResponse.IsSuperUser = (bool)reader["IsSuperUser"];
                    objLoginResponse.SuperUserLoginId = (int)reader["SuperUserLoginId"];
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
            return objLoginResponse;
        }
        
        public RegistrationResponse UserRegistration(RegistrationRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@FullName", SqlDbType.VarChar, 50) { Value = objrequest.fullname },
                                            new SqlParameter("@CompanyName", SqlDbType.VarChar, 50) { Value = objrequest.companyname },
                                            new SqlParameter("@EmailId", SqlDbType.VarChar, 50) { Value = objrequest.emailid },
                                            new SqlParameter("@ContactNumber", SqlDbType.VarChar, 20) { Value = objrequest.contactnumber },
                                            new SqlParameter("@Password", SqlDbType.VarChar, 500) { Value = objrequest.password },
                                            new SqlParameter("@AboutMe", SqlDbType.VarChar, 500) { Value = objrequest.aboutme },
                                            new SqlParameter("@PackageId", SqlDbType.Int) { Value = objrequest.packageid }
                                        };
            SqlDataReader reader = null;
            RegistrationResponse objRegistrationResponse = new RegistrationResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UserRegistration", sqlparams);

                while (reader.Read())
                {
                    objRegistrationResponse.StatusId = (int)reader["StatusId"];
                    objRegistrationResponse.StatusMessage = (string)reader["StatusMessage"];
                    objRegistrationResponse.VerificationCode = (string)reader["VerificationCode"];
                    objRegistrationResponse.RegistrationId = (int)reader["RegistrationId"];
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
            return objRegistrationResponse;
        }

        public RegistrationResponse ResendUserRegistrationDetails(int registrationid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@RegistrationId", SqlDbType.Int) { Value = registrationid }
                                        };
            SqlDataReader reader = null;
            RegistrationResponse objRegistrationResponse = new RegistrationResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_ResendUserRegistrationDetails", sqlparams);

                while (reader.Read())
                {
                    objRegistrationResponse.StatusId = (int)reader["StatusId"];
                    objRegistrationResponse.StatusMessage = (string)reader["StatusMessage"];
                    objRegistrationResponse.VerificationCode = (string)reader["VerificationCode"];
                    objRegistrationResponse.EmailId = (string)reader["EmailId"];
                    objRegistrationResponse.FullName = (string)reader["FullName"];
                    objRegistrationResponse.RegistrationId = (int)reader["RegistrationId"];
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
            return objRegistrationResponse;
        }

        public VerificationResponse VerifyUserRegistration(int registrationid, string verificationcode)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@RegistrationId", SqlDbType.Int) { Value = registrationid },
                                            new SqlParameter("@VerificationCode", SqlDbType.VarChar, 10) { Value = verificationcode }
                                        };
            SqlDataReader reader = null;
            VerificationResponse objSaveResponse = new VerificationResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_VerifyUserRegistration", sqlparams);

                while (reader.Read())
                {
                    objSaveResponse.StatusId = (int)reader["StatusId"];
                    objSaveResponse.StatusMessage = (string)reader["StatusMessage"];
                    objSaveResponse.FullName = (string)reader["FullName"];
                    objSaveResponse.EmailId = (string)reader["EmailId"];
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

        public ForgotPasswordResponse UserForgotPasswordRequest(ForgotPasswordRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@EmailId", SqlDbType.VarChar, 50) { Value = objrequest.emailid }
                                        };
            SqlDataReader reader = null;
            ForgotPasswordResponse objForgotPasswordResponse = new ForgotPasswordResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UserForgotPasswordRequest", sqlparams);

                while (reader.Read())
                {
                    objForgotPasswordResponse.StatusId = (int)reader["StatusId"];
                    objForgotPasswordResponse.StatusMessage = (string)reader["StatusMessage"];
                    objForgotPasswordResponse.FullName = (string)reader["FullName"];
                    objForgotPasswordResponse.VerificationCode = (string)reader["VerificationCode"];
                    objForgotPasswordResponse.RequestId = (int)reader["RequestId"];
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
            return objForgotPasswordResponse;
        }

        public ForgotPasswordResponse ResendUserForgotPasswordRequest(int requestid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@RequestId", SqlDbType.Int) { Value = requestid }
                                        };
            SqlDataReader reader = null;
            ForgotPasswordResponse objForgotPasswordResponse = new ForgotPasswordResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_ResendUserForgotPasswordRequest", sqlparams);

                while (reader.Read())
                {
                    objForgotPasswordResponse.StatusId = (int)reader["StatusId"];
                    objForgotPasswordResponse.StatusMessage = (string)reader["StatusMessage"];
                    objForgotPasswordResponse.FullName = (string)reader["FullName"];
                    objForgotPasswordResponse.VerificationCode = (string)reader["VerificationCode"];
                    objForgotPasswordResponse.EmailId = (string)reader["EmailId"];
                    objForgotPasswordResponse.RequestId = (int)reader["RequestId"];
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
            return objForgotPasswordResponse;
        }

        public SaveResponse UpdateForgotPassword(UpdateForgotPasswordRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@RequestId", SqlDbType.Int) { Value = objrequest.requestid },
                                            new SqlParameter("@VerificationCode", SqlDbType.VarChar, 10) { Value = objrequest.verificationcode },
                                            new SqlParameter("@Password", SqlDbType.VarChar, 500) { Value = objrequest.password }
                                        };
            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UpdateForgotPassword", sqlparams);

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

        public SaveResponse InsertContactRequest(ContactUsRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@Name", SqlDbType.VarChar, 100) { Value = objrequest.Name },
                                            new SqlParameter("@EmailId", SqlDbType.VarChar, 100) { Value = objrequest.EmailId },
                                            new SqlParameter("@Subject", SqlDbType.VarChar, 100) { Value = objrequest.Subject },
                                            new SqlParameter("@Message", SqlDbType.VarChar, -1) { Value = objrequest.Message }
                                        };
            SqlDataReader reader = null;
            SaveResponse objresponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_InsertContactRequest", sqlparams);

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
