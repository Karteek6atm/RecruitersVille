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
    public class ProfileBal
    {
        #region Members

        ProfileDal _ProfileDal = new ProfileDal();

        #endregion

        #region Methods

        public ProfileMastersResponse GetMastersForProfile(string struserloginid, string strcompanyid)
        {
            ProfileMastersResponse objProfileMastersResponse = new ProfileMastersResponse();
            try
            {
                DataSet dsData = new DataSet();

                int userloginid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(struserloginid));
                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _ProfileDal.GetMastersForProfile(userloginid, companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        var experiences = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 1).
                                           Select(x => new ExperiencesResponse
                                           {
                                               ExperienceId = x.Field<int>("Id"),
                                               ExperienceName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileMastersResponse.Experiences = experiences;

                        var hiringfor = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 2).
                                           Select(x => new HiringForResponse
                                           {
                                               HiringForId = x.Field<int>("Id"),
                                               HiringForName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileMastersResponse.HiringFor = hiringfor;

                        var industries = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 3).
                                           Select(x => new IndustriesResponse
                                           {
                                               IndustryId = x.Field<int>("Id"),
                                               IndustryName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileMastersResponse.Industries = industries;

                        var subindustries = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 4).
                                           Select(x => new SubIndustriesResponse
                                           {
                                               SubIndustryId = x.Field<int>("Id"),
                                               SubIndustryName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileMastersResponse.SubIndustries = subindustries;

                        var skills = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 5).
                                           Select(x => new TechnologiesResponse
                                           {
                                               TechnologyId = x.Field<int>("Id"),
                                               TechnologyName = x.Field<string>("Name")
                                           }).ToList();

                        objProfileMastersResponse.Technologies = skills;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objProfileMastersResponse;
        }

        public ProfileResponse GetProfileDetails(string struserloginid, string strcompanyid)
        {
            ProfileResponse objProfileResponse = new ProfileResponse();
            try
            {
                DataSet dsData = new DataSet();

                int userloginid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(struserloginid));
                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _ProfileDal.GetProfileDetails(userloginid, companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = dsData.Tables[0].Rows[0];
                            PersonalProfileResponse objPersonalProfileResponse = new PersonalProfileResponse();

                            objPersonalProfileResponse.AboutMe = Convert.ToString(dr["AboutMe"]);
                            objPersonalProfileResponse.City = Convert.ToString(dr["City"]);
                            objPersonalProfileResponse.ContactNumber = Convert.ToString(dr["ContactNumber"]);
                            objPersonalProfileResponse.Country = Convert.ToString(dr["Country"]);
                            objPersonalProfileResponse.EmailId = Convert.ToString(dr["EmailId"]);
                            objPersonalProfileResponse.FullName = Convert.ToString(dr["FullName"]);
                            objPersonalProfileResponse.Landmark = Convert.ToString(dr["Landmark"]);
                            objPersonalProfileResponse.ProfilePicPath = Convert.ToString(dr["ProfilePicPath"]);
                            objPersonalProfileResponse.State = Convert.ToString(dr["State"]);
                            objPersonalProfileResponse.Street = Convert.ToString(dr["Street"]);
                            objPersonalProfileResponse.UserId = Convert.ToInt32(dr["UserId"]);
                            objPersonalProfileResponse.Zipcode = Convert.ToString(dr["Zipcode"]);

                            objProfileResponse.PersonalProfile = objPersonalProfileResponse;
                        }
                    }

                    if (dsData.Tables.Count > 1)
                    {
                        if (dsData.Tables[1].Rows.Count > 0)
                        {
                            DataRow dr = dsData.Tables[1].Rows[0];
                            CompanyProfileResponse objCompanyProfileResponse = new CompanyProfileResponse();

                            objCompanyProfileResponse.AboutCompany = Convert.ToString(dr["AboutCompany"]);
                            objCompanyProfileResponse.City = Convert.ToString(dr["City"]);
                            objCompanyProfileResponse.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                            objCompanyProfileResponse.Country = Convert.ToString(dr["Country"]);
                            objCompanyProfileResponse.CompanyLogoPath = Convert.ToString(dr["CompanyLogoPath"]);
                            objCompanyProfileResponse.CompanyName = Convert.ToString(dr["CompanyName"]);
                            objCompanyProfileResponse.Landmark = Convert.ToString(dr["Landmark"]);
                            objCompanyProfileResponse.State = Convert.ToString(dr["State"]);
                            objCompanyProfileResponse.Street = Convert.ToString(dr["Street"]);
                            objCompanyProfileResponse.Zipcode = Convert.ToString(dr["Zipcode"]);

                            objProfileResponse.CompanyProfile = objCompanyProfileResponse;
                        }
                    }

                    if (dsData.Tables.Count > 2)
                    {
                        if (dsData.Tables[2].Rows.Count > 0)
                        {
                            DataRow dr = dsData.Tables[2].Rows[0];
                            ProfessionalProfileResponse objProfessionalProfileResponse = new ProfessionalProfileResponse();

                            objProfessionalProfileResponse.Achievements = Convert.ToString(dr["Achievements"]);
                            objProfessionalProfileResponse.CurrentCompanyWorkStartDate = Convert.ToString(dr["CurrentCompanyWorkStartDate"]);
                            objProfessionalProfileResponse.Description = Convert.ToString(dr["Description"]);
                            objProfessionalProfileResponse.Designation = Convert.ToString(dr["Designation"]);
                            objProfessionalProfileResponse.Experience = Convert.ToInt32(dr["Experience"]);
                            objProfessionalProfileResponse.FunctionalAreas = Convert.ToString(dr["FunctionalAreas"]);
                            objProfessionalProfileResponse.HiringForIds = Convert.ToString(dr["HiringForIds"]);
                            objProfessionalProfileResponse.IndustryIds = Convert.ToString(dr["IndustryIds"]);
                            objProfessionalProfileResponse.TechnologyIds = Convert.ToString(dr["TechnologyIds"]);
                            objProfessionalProfileResponse.UserProfessionId = Convert.ToInt32(dr["UserProfessionId"]);

                            objProfileResponse.ProfessionalProfile = objProfessionalProfileResponse;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objProfileResponse;
        }

        public ProfileView GetProfileViewDetails(string strProfileId)
        {
            ProfileView objProfileResponse = new ProfileView();
            try
            {
                DataSet dsData = new DataSet();

                int profileId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strProfileId));

                dsData = _ProfileDal.GetProfileViewDetails(profileId);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        if (dsData.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = dsData.Tables[0].Rows[0];
                            ProfileViewResponse objPersonalProfileResponse = new ProfileViewResponse();
                            objPersonalProfileResponse.FullName = Convert.ToString(dr["FirstName"]) + " " + Convert.ToString(dr["LastName"]);
                            objPersonalProfileResponse.EmailId = Convert.ToString(dr["EmailId"]);
                            objPersonalProfileResponse.AlternateEmailId = Convert.ToString(dr["AlternateEmailId"]);
                            objPersonalProfileResponse.ContactNumber = Convert.ToString(dr["MobileNumber"]);
                            objPersonalProfileResponse.AlternateMobileNumber = Convert.ToString(dr["AlternateMobileNumber"]);
                            objPersonalProfileResponse.QualificationId = Convert.ToInt32(dr["QualificationId"]);
                            objPersonalProfileResponse.QualificationName = Convert.ToString(dr["QualificationName"]);
                            objPersonalProfileResponse.Experience = Convert.ToString(dr["ExpYears"]) + " Years " + Convert.ToString(dr["ExpMonths"]) + " Months.";
                            objPersonalProfileResponse.Location = Convert.ToString(dr["Location"]);
                            objPersonalProfileResponse.CountryId = Convert.ToInt32(dr["CountryId"]);
                            objPersonalProfileResponse.Country = Convert.ToString(dr["CountryName"]);
                            objPersonalProfileResponse.IndustryId = Convert.ToInt32(dr["IndustryId"]);
                            objPersonalProfileResponse.IndustryName = Convert.ToString(dr["IndustryName"]);
                            objPersonalProfileResponse.AboutMe = Convert.ToString(dr["Description"]);
                            objPersonalProfileResponse.Resume = Convert.ToString(dr["Resume"]);
                            objPersonalProfileResponse.Skills = Convert.ToString(dr["Skills"]);

                            objProfileResponse.PersonalProfile = objPersonalProfileResponse;
                        }
                    }                     
                }
            }
            catch (Exception ex)
            {

            }
            return objProfileResponse;
        }

        public SaveResponse UpdateUserPersonalDetails(ProfileRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _ProfileDal.UpdateUserPersonalDetails(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse UpdateCompanyDetails(CompanyProfileRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _ProfileDal.UpdateCompanyDetails(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse UpdateUserProfessionalDetails(ProfessionalRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _ProfileDal.UpdateUserProfessionalDetails(objrequest);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse UpdateUserPassword(UserPasswordRequest objrequest)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objrequest.NewPassword = CommonMethods.Encrypt(objrequest.NewPassword);
                objrequest.OldPassword = CommonMethods.Encrypt(objrequest.OldPassword);

                objresponse = _ProfileDal.UpdateUserPassword(objrequest);
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
