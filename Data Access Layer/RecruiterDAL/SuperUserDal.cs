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
    public class SuperUserDal
    {
        #region Members

        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion
        #region Methods

        public DataSet GetAllCompaniesList(long UserLoginId)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.BigInt) { Value = UserLoginId }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCompaniesList", sqlparams);
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

        public CompanyResponse ChangeAction(CompanyActions objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@Action", SqlDbType.Int) { Value = objrequest.Action },
                 new SqlParameter("@CompanyId", SqlDbType.Int) { Value = objrequest.DecryptedCompanyId },
                  new SqlParameter("@ModifiedBy", SqlDbType.Int) { Value = objrequest.ModifiedBy }
                                        };
            CompanyResponse objresponse = new CompanyResponse();

            SqlDataReader reader = null;

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_UpdateCompanyStatus", sqlparams);

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

        public DataSet GetProfilesList(long UserLoginId)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.BigInt) { Value = UserLoginId }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllProfilesList", sqlparams);
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
