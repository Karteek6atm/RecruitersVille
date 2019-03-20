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
    public class UserDal
    {
        #region Members

        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion

        #region Methods

        public DataSet GetUsersList(int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetUsersList", sqlparams);
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

        public DataSet GetMastersForUsers(int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetMastersForUsers", sqlparams);
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

        public SaveResponse InsertAndUpdateUserDetails(UserRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = objrequest.CompanyId },
                                            new SqlParameter("@UserId", SqlDbType.Int) { Value = objrequest.UserId },
                                            new SqlParameter("@FullName", SqlDbType.VarChar, 50) { Value = objrequest.FullName },
                                            new SqlParameter("@ContactNumber", SqlDbType.VarChar, 20) { Value = objrequest.ContactNumber },
                                            new SqlParameter("@AboutMe", SqlDbType.VarChar, 500) { Value = objrequest.AboutMe },
                                            new SqlParameter("@ProfilePicPath", SqlDbType.VarChar, 1000) { Value = objrequest.ProfilePicPath },
                                            new SqlParameter("@RoleId", SqlDbType.Int) { Value = objrequest.RoleId },
                                            new SqlParameter("@Password", SqlDbType.VarChar, 500) { Value = objrequest.Password },
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
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_InsertAndUpdateUserDetails", sqlparams);

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
