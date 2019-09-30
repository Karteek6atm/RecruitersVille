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
    
    public class SuperUserBal
    {

        #region Members

        SuperUserDal _SuperUserDal = new SuperUserDal();

        #endregion

        #region Methods

        public List<SuperUserResponse> GetAllCompaniesList(string strUserLoginId)
        {
            List<SuperUserResponse> objUserResponse = new List<SuperUserResponse>();
            try
            {
                DataSet dsData = new DataSet();

                long UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strUserLoginId));

                dsData = _SuperUserDal.GetAllCompaniesList(UserLoginId);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objUserResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new SuperUserResponse
                                        {
                                            CompanyId = x.Field<int>("CompanyId"),
                                            CompanyName = x.Field<string>("CompanyName"),
                                            UsersCount = x.Field<int>("UsersCount"),
                                            PackageId = x.Field<int>("PackageId"),
                                            PackageName = x.Field<string>("PackageName"),
                                            ActiveStatusId = x.Field<int>("ActiveStatusId"),
                                            ActiveStatus = x.Field<string>("ActiveStatus"),
                                            CreatedEmailId = x.Field<string>("CreatedEmailId"),
                                            CreatedById = x.Field<int>("CreatedById"),
                                            CreatedBy = x.Field<string>("CreatedBy"),
                                            CreatedDate = x.Field<string>("CreatedDate"),
                                            ModifiedById = x.Field<int>("ModifiedById"),
                                            ModifiedBy = x.Field<string>("ModifiedBy"),
                                            ModifiedDate = x.Field<string>("ModifiedDate"),
                                            CompanyLogoPath = x.Field<string>("CompanyLogoPath"),
                                            AboutCompany = x.Field<string>("AboutCompany")
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objUserResponse;
        }

        public CompanyResponse ChangeAction(CompanyActions objrequest)
        {
            CompanyResponse objresponse = new CompanyResponse();
            try
            { 
                    objresponse = _SuperUserDal.ChangeAction(objrequest);
                
            }
            catch (Exception ex)
            {

            }
            return objresponse;
        }

        public List<SuperUserProfiles> GetProfilesList(string strUserLoginId)
        {
            List<SuperUserProfiles> objUserResponse = new List<SuperUserProfiles>();
            try
            {
                DataSet dsData = new DataSet();

                long UserLoginId = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strUserLoginId));

                dsData = _SuperUserDal.GetProfilesList(UserLoginId);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objUserResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new SuperUserProfiles
                                        {
                                            ProfileId = x.Field<int>("ProfileId"),
                                            CompanyId = x.Field<int>("CompanyId"),
                                            CompanyName = x.Field<string>("CompanyName"),
                                            FirstName = x.Field<string>("FirstName"),
                                            LastName = x.Field<string>("LastName"),
                                            EmailId = x.Field<string>("EmailId"),
                                            AlternateEmailId = x.Field<string>("AlternateEmailId"),
                                            MobileNumber = x.Field<string>("MobileNumber"),
                                            AlternateMobileNumber = x.Field<string>("AlternateMobileNumber"),
                                            DOB = x.Field<string>("DOB"),
                                            GenderId = x.Field<int>("GenderId"),
                                            Gender = x.Field<string>("Gender"),
                                            EducationalQualification = x.Field<int>("EducationalQualification"),
                                            QualificationName = x.Field<string>("QualificationName"),
                                            Experience = x.Field<string>("Experience"),
                                            Location = x.Field<string>("Location"),
                                            IndustryId = x.Field<int>("IndustryId"),
                                            Industry = x.Field<string>("Industry"),
                                            Description = x.Field<string>("Description"),
                                            ResumePath = x.Field<string>("ResumePath"),
                                            ActiveStatusId = x.Field<int>("ActiveStatusId"),
                                            ActiveStatus = x.Field<string>("ActiveStatus"),
                                            CreatedById = x.Field<int>("CreatedById"),
                                            CreatedBy = x.Field<string>("CreatedBy"),
                                            CreatedDate = x.Field<string>("CreatedDate"),
                                            ModifiedById = x.Field<int>("ModifiedById"),
                                            ModifiedBy = x.Field<string>("ModifiedBy"),
                                            ModifiedDate = x.Field<string>("ModifiedDate")

                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objUserResponse;
        }

        public List<JobListResponse> GetJobsList(string strcompanyid)
        {
            List<JobListResponse> objJobResponse = new List<JobListResponse>();
            try
            {
                DataSet dsData = new DataSet();

                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _SuperUserDal.GetJobsList(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objJobResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new JobListResponse
                                        {
                                            CompanyJobId = x.Field<string>("CompanyJobId"),
                                            IndustryId = x.Field<int>("IndustryId"),
                                            IndustryName = x.Field<string>("IndustryName"),
                                            JobDuration = x.Field<int>("JobDuration"),
                                            MaxExp = x.Field<int>("MaxExp"),
                                            MinExp = x.Field<int>("MinExp"),
                                            JobDurationTypeId = x.Field<int>("JobDurationTypeId"),
                                            JobDurationTypeName = x.Field<string>("JobDurationTypeName"),
                                            JobId = CommonMethods.URLKeyEncrypt(Convert.ToString(x.Field<int>("JobId"))),
                                            JobLocation = x.Field<string>("JobLocation"),
                                            JobTitle = x.Field<string>("JobTitle"),
                                            MaxPayRate = x.Field<int>("MaxPayRate"),
                                            MinPayRate = x.Field<int>("MinPayRate"),
                                            PayCurrencyId = x.Field<int>("PayCurrencyId"),
                                            PayCurrencySign = x.Field<string>("PayCurrencySign"),
                                            PayTypeId = x.Field<int>("PayTypeId"),
                                            PayTypeName = x.Field<string>("PayTypeName"),
                                            TechnologyNames = x.Field<string>("TechnologyNames"),
                                            JobStatusId = x.Field<int>("JobStatusId"),
                                            JobStatusName = x.Field<string>("JobStatusName")
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objJobResponse;
        }

        public SaveAdminResponse ChangeJobAction(JobActions objrequest)
        {
            SaveAdminResponse objresponse = new SaveAdminResponse();
            try
            {
                objresponse = _SuperUserDal.ChangeJobAction(objrequest);

            }
            catch (Exception ex)
            {

            }
            return objresponse;
        }
        #endregion
    }
}
