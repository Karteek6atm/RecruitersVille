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
    public class VendorDal
    {
        #region Members

        public SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["SqlCon"]);

        #endregion

        #region Methods

        public DataSet GetVendorsList(int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetVendorsList", sqlparams);
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

        public DataSet GetMastersForVendors(int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetMastersForVendors", sqlparams);
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

        public VendorDetailsResponse GetVendorDetailsById(int vendorid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@VendorId", SqlDbType.Int) { Value = vendorid }
                                        };
            SqlDataReader reader = null;
            VendorDetailsResponse objresponse = new VendorDetailsResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_GetVendorDetailsById", sqlparams);

                while (reader.Read())
                {
                    objresponse.Description = (string)reader["Description"];
                    objresponse.City = (string)reader["City"];
                    objresponse.ContactNumber = (string)reader["ContactNumber"];
                    objresponse.Country = (string)reader["Country"];
                    objresponse.IsEmployer = (bool)reader["IsEmployer"];
                    objresponse.EmailId = (string)reader["EmailId"];
                    objresponse.VendorName = (string)reader["VendorName"];
                    objresponse.Landmark = (string)reader["Landmark"];
                    objresponse.VendorLogoPath = (string)reader["VendorLogoPath"];
                    objresponse.TechnologyIds = (string)reader["TechnologyIds"];
                    objresponse.State = (string)reader["State"];
                    objresponse.Street = (string)reader["Street"];
                    objresponse.VendorId = (int)reader["VendorId"];
                    objresponse.Zipcode = (string)reader["Zipcode"];                    
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

        public VendorSaveResponse InsertAndUpdateVendorDetails(VendorRequest objrequest)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = objrequest.UserLoginId },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = objrequest.CompanyId },
                                            new SqlParameter("@VendorId", SqlDbType.Int) { Value = objrequest.VendorId },
                                            new SqlParameter("@VendorName", SqlDbType.VarChar, 50) { Value = objrequest.VendorName },
                                            new SqlParameter("@EmailId", SqlDbType.VarChar, 50) { Value = objrequest.EmailId },
                                            new SqlParameter("@ContactNumber", SqlDbType.VarChar, 20) { Value = objrequest.ContactNumber },
                                            new SqlParameter("@Description", SqlDbType.VarChar, 500) { Value = objrequest.Description },
                                            new SqlParameter("@VendorLogoPath", SqlDbType.VarChar, 1000) { Value = objrequest.VendorLogoPath },
                                            new SqlParameter("@IsEmployer", SqlDbType.Bit) { Value = objrequest.IsEmployer },
                                            new SqlParameter("@Technologies", SqlDbType.VarChar, -1) { Value = objrequest.Technologies },
                                            new SqlParameter("@Street", SqlDbType.VarChar, 200) { Value = objrequest.Street },
                                            new SqlParameter("@Landmark", SqlDbType.VarChar, 200) { Value = objrequest.Landmark },
                                            new SqlParameter("@City", SqlDbType.VarChar, 100) { Value = objrequest.City },
                                            new SqlParameter("@State", SqlDbType.VarChar, 100) { Value = objrequest.State },
                                            new SqlParameter("@Country", SqlDbType.VarChar, 100) { Value = objrequest.Country },
                                            new SqlParameter("@Zipcode", SqlDbType.VarChar, 10) { Value = objrequest.Zipcode }
                                        };
            
            SqlDataReader reader = null;
            VendorSaveResponse objSaveResponse = new VendorSaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_InsertAndUpdateVendorDetails", sqlparams);

                while (reader.Read())
                {
                    objSaveResponse.StatusId = (int)reader["StatusId"];
                    objSaveResponse.StatusMessage = (string)reader["StatusMessage"];
                    objSaveResponse.IsNewVendor = (bool)reader["IsNewVendor"];
                    objSaveResponse.AdminName = (string)reader["AdminName"];
                    objSaveResponse.CompanyName = (string)reader["CompanyName"];
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

        public SaveResponse DeleteVendorDetails(int userloginid, int vendorid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = userloginid },
                                            new SqlParameter("@VendorId", SqlDbType.Int) { Value = vendorid }
                                        };

            SqlDataReader reader = null;
            SaveResponse objSaveResponse = new SaveResponse();

            try
            {
                reader = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "USP_DeleteVendorDetails", sqlparams);

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

        public DataSet InsertVendorUploads(int userLoginId, int companyId, string vendorFilePath, DataTable dtVendorUploads)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@UserLoginId", SqlDbType.Int) { Value = userLoginId },
                                            new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyId },
                                            new SqlParameter("@VendorFilePath", SqlDbType.VarChar, -1) { Value = vendorFilePath },
                                            new SqlParameter("@VendorUploads", SqlDbType.Structured) { Value = dtVendorUploads }
                                        };

            DataSet ds = new DataSet();

            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_InsertVendorUploads", sqlparams);                
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
            return ds;
        }

        public DataSet GetVendorUploadsList(int companyid)
        {
            SqlParameter[] sqlparams = { new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyid }
                                        };
            DataSet dsData = new DataSet();

            try
            {
                dsData = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetVendorUploadsList", sqlparams);
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
