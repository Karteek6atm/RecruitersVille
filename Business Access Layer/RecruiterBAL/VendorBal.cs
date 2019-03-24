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

        public List<VendorResponse> GetVendorsList(string strcompanyid)
        {
            List<VendorResponse> objVendorResponse = new List<VendorResponse>();
            try
            {
                DataSet dsData = new DataSet();
                
                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _VendorDal.GetVendorsList(companyid);

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
                                            IsEmployer = x.Field<bool>("IsEmployer"),
                                            VendorName = x.Field<string>("VendorName"),
                                            EmailId = x.Field<string>("EmailId"),
                                            VendorId = x.Field<int>("VendorId"),
                                            Landmark = x.Field<string>("Landmark"),
                                            State = x.Field<string>("State"),
                                            Street = x.Field<string>("Street"),
                                            TechnologyNames = x.Field<string>("TechnologyNames"),
                                            Zipcode = x.Field<string>("Zipcode"),
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

        #endregion
    }
}
