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
    public class ResumeBal
    {
        #region Members

        ResumeDal _ResumeDal = new ResumeDal();

        #endregion

        #region Methods

        public ProfileCreationMastersResponse GetMastersForProfileCreation(string strcompanyid, string struserloginid)
        {
            ProfileCreationMastersResponse objProfileCreationMastersResponse = new ProfileCreationMastersResponse();
            try
            {
                DataSet dsData = new DataSet();

                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));
                int userloginid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(struserloginid));

                dsData = _ResumeDal.GetMastersForProfileCreation(companyid, userloginid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        var educationalqualifications = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 1).
                                           Select(x => new EducationalQualificationsResponse
                                           {
                                               QualificationId = x.Field<int>("Id"),
                                               QualificationName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileCreationMastersResponse.EducationalQualifications = educationalqualifications;

                        var countries = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 2).
                                           Select(x => new CountriesResponse
                                           {
                                               CountryId = x.Field<int>("Id"),
                                               CountryName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileCreationMastersResponse.Countries = countries;

                        var industries = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 3).
                                           Select(x => new IndustriesResponse
                                           {
                                               IndustryId = x.Field<int>("Id"),
                                               IndustryName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileCreationMastersResponse.Industries = industries;

                        var technologies = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 4).
                                           Select(x => new TechnologiesResponse
                                           {
                                               TechnologyId = x.Field<int>("Id"),
                                               TechnologyName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileCreationMastersResponse.Technologies = technologies;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objProfileCreationMastersResponse;
        }

        public List<ResumeResponse> GetProfilesList(string strcompanyid)
        {
            List<ResumeResponse> objJobResponse = new List<ResumeResponse>();
            try
            {
                DataSet dsData = new DataSet();

                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _ResumeDal.GetProfilesList(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objJobResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new ResumeResponse
                                        {
                                            EmailId = x.Field<string>("EmailId"),
                                            ExpMonths = x.Field<int>("ExpMonths"),
                                            ExpYears = x.Field<int>("ExpYears"),
                                            FirstName = x.Field<string>("FirstName"),
                                            Industry = x.Field<string>("Industry"),
                                            LastName = x.Field<string>("LastName"),
                                            Location = x.Field<string>("Location"),
                                            MobileNumber = x.Field<string>("MobileNumber"),
                                            ProfileId = CommonMethods.URLKeyEncrypt(Convert.ToString(x.Field<int>("ProfileId"))),
                                            Qualification = x.Field<string>("Qualification"),
                                            Resume = x.Field<string>("Resume"),
                                            Skills = x.Field<string>("Skills")
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objJobResponse;
        }

        public ResumeSaveResponse InsertAndUpdateProfileDetails(ProfileSaveRequest objrequest, DataTable dtProfileExperiences)
        {
            ResumeSaveResponse objresponse = new ResumeSaveResponse();
            try
            {
                objresponse = _ResumeDal.InsertAndUpdateProfileDetails(objrequest, dtProfileExperiences);
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
