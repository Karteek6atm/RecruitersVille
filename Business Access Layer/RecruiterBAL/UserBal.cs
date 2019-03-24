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
    public class UserBal
    {
        #region Members

        UserDal _UserDal = new UserDal();

        #endregion

        #region Methods

        public UserMasterResponse GetMastersForUsers(string strcompanyid)
        {
            UserMasterResponse objUserMasterResponse = new UserMasterResponse();
            try
            {
                DataSet dsData = new DataSet();
                
                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _UserDal.GetMastersForUsers(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        var roles = dsData.Tables[0].AsEnumerable().Where(a => a.Field<int>("MasterType") == 1).
                                           Select(x => new RolesResponse
                                           {
                                               RoleId = x.Field<int>("Id"),
                                               RoleName = x.Field<string>("Name")
                                           }).ToList();

                        objUserMasterResponse.Roles = roles;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objUserMasterResponse;
        }

        public List<UserResponse> GetUsersList(string strcompanyid)
        {
            List<UserResponse> objUserResponse = new List<UserResponse>();
            try
            {
                DataSet dsData = new DataSet();
                
                int companyid = Convert.ToInt32(CommonMethods.URLKeyDecrypt(strcompanyid));

                dsData = _UserDal.GetUsersList(companyid);

                if (dsData != null)
                {
                    if (dsData.Tables.Count > 0)
                    {
                        objUserResponse = dsData.Tables[0].AsEnumerable().
                                        Select(x => new UserResponse
                                        {
                                            City = x.Field<string>("City"),
                                            ContactNumber = x.Field<string>("ContactNumber"),
                                            Country = x.Field<string>("Country"),
                                            CurrentCompanyWorkStartDate = x.Field<string>("CurrentCompanyWorkStartDate"),
                                            Designation = x.Field<string>("Designation"),
                                            EmailId = x.Field<string>("EmailId"),
                                            ExperienceId = x.Field<int>("ExperienceId"),
                                            ExperienceName = x.Field<string>("ExperienceName"),
                                            FullName = x.Field<string>("FullName"),
                                            HiringForNames = x.Field<string>("HiringForNames"),
                                            IndustryNames = x.Field<string>("IndustryNames"),
                                            SubIndustryNames = x.Field<string>("IndustryNames"),
                                            Landmark = x.Field<string>("Landmark"),
                                            RoleId = x.Field<int>("RoleId"),
                                            RoleName = x.Field<string>("RoleName"),
                                            State = x.Field<string>("State"),
                                            Street = x.Field<string>("Street"),
                                            TechnologyNames = x.Field<string>("TechnologyNames"),
                                            UserId = x.Field<int>("UserId"),
                                            Zipcode = x.Field<string>("Zipcode"),
                                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return objUserResponse;
        }

        public UserDetailsResponse GetUserDetailsById(int userid)
        {
            UserDetailsResponse objresponse = new UserDetailsResponse();
            try
            {
                objresponse = _UserDal.GetUserDetailsById(userid);
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public UserSaveResponse InsertAndUpdateUserDetails(UserRequest objrequest)
        {
            UserSaveResponse objresponse = new UserSaveResponse();
            try
            {
                string password = CommonMethods.GenerateUserPassword();
                objrequest.Password = CommonMethods.Encrypt(password);
                objresponse = _UserDal.InsertAndUpdateUserDetails(objrequest);

                if(objresponse.StatusId == 1 && objresponse.IsNewUser)
                {
                    SendEmail.SendUserCreationEmail(objrequest.EmailId, objrequest.FullName, objresponse.AdminName, objresponse.CompanyName, password);
                }
            }
            catch (Exception ex)
            {
                CommonMethods.ErrorMessage(ex.Message);
            }
            return objresponse;
        }

        public SaveResponse DeleteUserDetails(int userloginid, int userid)
        {
            SaveResponse objresponse = new SaveResponse();
            try
            {
                objresponse = _UserDal.DeleteUserDetails(userloginid, userid);
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
