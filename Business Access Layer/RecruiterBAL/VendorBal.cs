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
    public class VendorBal
    {
        #region Members

        VendorDal _VendorDal = new VendorDal();

        #endregion

        #region Methods

        public VendorMasterResponse GetMastersForVendors(string strcompanyid)
        {
            VendorMasterResponse objVendorMasterResponse = new VendorMasterResponse();
            try
            {
                DataSet dsData = new DataSet();

                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _VendorDal.GetMastersForVendors(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        var technologies = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 1).
                                           Select(x => new TechnologiesResponse
                                           {
                                               TechnologyId = x.Field<int>("Id"),
                                               TechnologyName
                                               = x.Field<string>("Name")
                                           }).ToList();

                        objVendorMasterResponse.Technologies = technologies;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objVendorMasterResponse;
        }

        public List<VendorResponse> GetVendorsList(VendorListRequest request)
        {
            List<VendorResponse> objVendorResponse = new List<VendorResponse>();
            try
            {
                DataSet dsData = new DataSet();
                
                dsData = _VendorDal.GetVendorsList(request);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objVendorResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new VendorResponse
                                        {
                                            City = x.Field<string>("City"),
                                            ContactNumber = x.Field<string>("ContactNumber"),
                                            Country = x.Field<string>("Country"),
                                            IsEmployer = x.Field<string>("IsEmployer"),
                                            VendorName = x.Field<string>("VendorName"),
                                            EmailId = x.Field<string>("EmailId"),
                                            VendorId = x.Field<int>("VendorId"),
                                            Landmark = x.Field<string>("Landmark"),
                                            State = x.Field<string>("State"),
                                            Street = x.Field<string>("Street"),
                                            TechnologyNames = x.Field<string>("TechnologyNames"),
                                            Zipcode = x.Field<string>("Zipcode"),
                                            Sno = x.Field<long>("Sno"),
                                            TotalRecords = x.Field<int>("TotalRecords"),
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objVendorResponse;
        }

        public VendorDetailsResponse GetVendorDetailsById(int userid)
        {
            VendorDetailsResponse objresponse = new VendorDetailsResponse();
            try
            {
                objresponse = _VendorDal.GetVendorDetailsById(userid);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public VendorSaveResponse InsertAndUpdateVendorDetails(VendorRequest objrequest)
        {
            VendorSaveResponse objresponse = new VendorSaveResponse();
            try
            {
                objresponse = _VendorDal.InsertAndUpdateVendorDetails(objrequest);

                //if(objresponse.StatusId == 1 && objresponse.IsNewVendor)
                //{
                //    SendEmail.SendUserCreationEmail(objrequest.EmailId, objrequest.VendorName, objresponse.AdminName, objresponse.CompanyName);
                //}
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse DeleteVendorDetails(int userloginid, int vendorid)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _VendorDal.DeleteVendorDetails(userloginid, vendorid);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse InsertVendorUploads(int userLoginId, int companyId, string vendorFilePath, DataTable dtVendorUploads)
        {
            SaveResponse objVendorResponse = new SaveResponse();
            VendorUploadSaveResponse objVendorUploadResponse = new VendorUploadSaveResponse();

            try
            {
                DataSet dsData = new DataSet();

                dsData = _VendorDal.InsertVendorUploads(userLoginId, companyId, vendorFilePath, dtVendorUploads);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = dsData.Tables[0].Rows[0];

                            objVendorResponse.StatusId = Convert.ToInt32(dr["StatusId"]);
                            objVendorResponse.StatusMessage = Convert.ToString(dr["StatusMessage"]);

                            objVendorUploadResponse.StatusId = Convert.ToInt32(dr["StatusId"]);
                            objVendorUploadResponse.StatusMessage = Convert.ToString(dr["StatusMessage"]);
                            objVendorUploadResponse.AdminName = Convert.ToString(dr["AdminName"]);
                            objVendorUploadResponse.CompanyName = Convert.ToString(dr["CompanyName"]);
                        }
                        
                        if (objVendorResponse.StatusId == 1)
                        {
                            if (dsData.Tables.Count > 1)
                            {
                                var vendors = dsData.Tables[1].AsEnumerable().
                                       Select(x => new UploadedVendors
                                       {
                                           VendorName = x.Field<string>("VendorName"),
                                           EmailId = x.Field<string>("EmailId")
                                       }).ToList();

                                //foreach (UploadedVendors vendor in vendors)
                                //{
                                //    SendEmail.SendUserCreationEmail(vendor.EmailId, vendor.VendorName, objVendorUploadResponse.AdminName, objVendorUploadResponse.CompanyName);
                                //}
                            }
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objVendorResponse;
        }

        public List<ImportedVendorsResponse> GetVendorUploadsList(string strcompanyid)
        {
            List<ImportedVendorsResponse> objVendorResponse = new List<ImportedVendorsResponse>();
            try
            {
                DataSet dsData = new DataSet();

                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _VendorDal.GetVendorUploadsList(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objVendorResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new ImportedVendorsResponse
                                        {
                                            FilePath = x.Field<string>("FilePath"),
                                            InvalidRecords = x.Field<int>("InvalidRecords"),
                                            TotalRecords = x.Field<int>("TotalRecords"),
                                            ValidRecords = x.Field<int>("ValidRecords"),
                                            UploadedBy = x.Field<string>("UploadedBy"),
                                            UploadedDate = x.Field<string>("UploadedDate"),
                                            VendorUploadId = x.Field<int>("VendorUploadId")
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objVendorResponse;
        }

        #endregion
    }
}
