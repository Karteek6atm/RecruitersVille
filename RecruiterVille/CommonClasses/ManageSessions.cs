using RecruiterBE.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace RecruiterVille.CommonClasses
{
    public class ManageSessions
    {
        public string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = string.Empty;
            if (cell.CellValue != null)
            {
                value = cell.CellValue.InnerText;
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
                }
            }
            return value;
        }

        public bool IsSessionHasValue()
        {
            bool isSession = false;
            try
            {
                if (HttpContext.Current.Session["UserLogin"] != null)
                {
                    isSession = true;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return isSession;
        }

        public void SaveUserSessions(LoginResponse objloginresponse)//, CompanyPermissionWithFeatures objCompanyPermissionWithFeatures
        {
            try
            {
                HttpContext.Current.Session["UserLogin"] = objloginresponse;

                //var menu = (from x in objCompanyUserPermissions.Where(x => (x.ReferencePermissionId == 0) && (x.IsMenu == true) && (x.ActiveStatus == 1))
                //            select new CompanyUserPermissions
                //            {
                //                PermissionId = x.PermissionId,
                //                PermissionName = x.PermissionName,
                //                Controller = x.Controller,
                //                ActionMethod = x.ActionMethod,
                //                Icon = x.Icon,
                //                MenuName = x.MenuName,
                //                MenuOrder = x.MenuOrder
                //            }).ToList();

                //if (objCompanyLogin.CompanyId > 0)
                //{
                //    string indexes = "";

                //    for (int i = 0; i < menu.Count; i++)
                //    {
                //        CompanyUserPermissions companyuserpermission = menu[i];


                //        if (companyuserpermission.PermissionName == "Survey")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingSurvey)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //        if (companyuserpermission.PermissionName == "Quiz")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingQuiz)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //        if (companyuserpermission.PermissionName == "CRM")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingCRM)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //        if (companyuserpermission.PermissionName.ToLower() == "email marketing")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingEmailMarketing)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //        if (companyuserpermission.PermissionName == "Event")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingEvents)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //        if (companyuserpermission.PermissionName == "Marketplace")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingMarketplace)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //        if (companyuserpermission.PermissionName == "Forms")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingForms)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //        if (companyuserpermission.PermissionName == "Tasks")
                //        {
                //            if (!objCompanyPackageFeatures.IsHavingTasks)
                //            {
                //                indexes = string.IsNullOrEmpty(indexes) ? i.ToString() : indexes + "," + i.ToString();
                //            }
                //        }
                //    }

                //    if (!string.IsNullOrEmpty(indexes))
                //    {
                //        string[] strarr = indexes.Split(',');

                //        for (int i = strarr.Length - 1; i >= 0; i--)
                //        {
                //            int index = Convert.ToInt32(strarr[i]);
                //            menu.RemoveAt(index);
                //        }
                //    }
                //}

                //HttpContext.Current.Session["Menu"] = menu;

                //var submenu = (from x in objCompanyUserPermissions.Where(x => (x.ReferencePermissionId > 0) && (x.IsMenu == true) && (x.ActiveStatus == 1))
                //               select new CompanyUserPermissions
                //               {
                //                   PermissionId = x.PermissionId,
                //                   PermissionName = x.PermissionName,
                //                   ReferencePermissionId = x.ReferencePermissionId,
                //                   Controller = x.Controller,
                //                   ActionMethod = x.ActionMethod,
                //                   Icon = x.Icon,
                //                   MenuName = x.MenuName,
                //                   MenuOrder = x.MenuOrder
                //               }).ToList();
                //HttpContext.Current.Session["SubMenu"] = submenu;

                //GetPermissions(objCompanyUserPermissions, objCompanyPackageFeatures);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void GetPermissions(List<CompanyUserPermissions> objCompanyUserPermissionsList, CompanyPackageFeatures objCompanyPackageFeatures)
        //{
        //    try
        //    {
        //        RolePermissions objRolePermissions = new RolePermissions();

        //        var menu = (from x in objCompanyUserPermissionsList.Where(x => x.ReferencePermissionId == 0)
        //                    select new CompanyUserPermissions
        //                    {
        //                        PermissionId = x.PermissionId,
        //                        PermissionName = x.PermissionName
        //                    }).ToList();

        //        foreach (CompanyUserPermissions objCompanyUserPermissions in menu)
        //        {
        //            var permission = (from x in objCompanyUserPermissionsList.Where(x => x.ReferencePermissionId == objCompanyUserPermissions.PermissionId)
        //                              select new CompanyUserPermissions
        //                              {
        //                                  PermissionId = x.PermissionId,
        //                                  PermissionName = x.PermissionName
        //                              }).ToList();

        //            #region Setup

        //            if (objCompanyUserPermissions.PermissionName == "Setup")
        //            {
        //                objRolePermissions.IsHavingSetup = true;
        //                SetupPermissions objSetupPermissions = new SetupPermissions();

        //                foreach (CompanyUserPermissions objPermission in permission)
        //                {
        //                    if (objPermission.PermissionName == "Roles")
        //                    {
        //                        objSetupPermissions.IsHavingRoles = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Designations")
        //                    {
        //                        objSetupPermissions.IsHavingDesignations = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Users")
        //                    {
        //                        objSetupPermissions.IsHavingUsers = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Survey Templates")
        //                    {
        //                        objSetupPermissions.IsHavingSurveyTemplates = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Survey Groups")
        //                    {
        //                        objSetupPermissions.IsHavingSurveyGroups = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Survey Categories")
        //                    {
        //                        objSetupPermissions.IsHavingSurveyCategories = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Quiz Templates")
        //                    {
        //                        objSetupPermissions.IsHavingQuizTemplates = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Language Setup")
        //                    {
        //                        objSetupPermissions.IsHavingLanguageSetup = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Contact Groups")
        //                    {
        //                        objSetupPermissions.IsHavingContactGroups = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Contact Configuration")
        //                    {
        //                        objSetupPermissions.IsHavingContactConfiguration = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Question Groups")
        //                    {
        //                        objSetupPermissions.IsHavingQuestionGroups = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Question Setup")
        //                    {
        //                        objSetupPermissions.IsHavingQuestionSetup = true;
        //                    }
        //                    else if (objPermission.PermissionName == "Questions List")
        //                    {
        //                        objSetupPermissions.IsHavingQuestionsList = true;
        //                    }
        //                    else if (objPermission.PermissionName == "API Access")
        //                    {
        //                        objSetupPermissions.IsHavingAPIAccess = true;
        //                    }
        //                }
        //                HttpContext.Current.Session["SetupPermissions"] = objSetupPermissions;
        //            }

        //            #endregion

        //            #region Survey

        //            if (objCompanyPackageFeatures.IsHavingSurvey)
        //            {
        //                if (objCompanyUserPermissions.PermissionName == "Survey")
        //                {
        //                    objRolePermissions.IsHavingSurvey = true;
        //                    SurveyPermissions objSurveyPermissions = new SurveyPermissions();

        //                    foreach (CompanyUserPermissions objPermission in permission)
        //                    {
        //                        if (objPermission.PermissionName == "Create Survey")
        //                        {
        //                            objSurveyPermissions.IsHavingCreate = true;
        //                        }
        //                        else if (objPermission.PermissionName == "Surveys")
        //                        {
        //                            objSurveyPermissions.IsHavingView = true;
        //                        }
        //                        else if (objPermission.PermissionName == "Edit Survey")
        //                        {
        //                            objSurveyPermissions.IsHavingEdit = true;
        //                        }
        //                        else if (objPermission.PermissionName == "Survey View")
        //                        {
        //                            objSurveyPermissions.IsHavingSurveyView = true;
        //                        }
        //                        else if (objPermission.PermissionName == "Close Survey")
        //                        {
        //                            objSurveyPermissions.IsHavingCloseSurvey = true;
        //                        }
        //                        else if (objPermission.PermissionName == "Share Survey")
        //                        {
        //                            objSurveyPermissions.IsHavingShareSurvey = true;
        //                        }
        //                        else if (objPermission.PermissionName == "Publish Survey")
        //                        {
        //                            objSurveyPermissions.IsHavingPublishSurvey = true;
        //                        }
        //                        else if (objPermission.PermissionName == "View Survey Responses")
        //                        {
        //                            objSurveyPermissions.IsHavingViewSurveyResponses = true;
        //                        }
        //                        else if (objPermission.PermissionName == "View Survey Analysis")
        //                        {
        //                            objSurveyPermissions.IsHavingViewSurveyAnalysis = true;
        //                        }
        //                        else if (objPermission.PermissionName == "Export Survey Responses")
        //                        {
        //                            objSurveyPermissions.IsHavingExportSurveyResponses = true;
        //                        }
        //                        else if (objPermission.PermissionName == "View Survey Reports")
        //                        {
        //                            objSurveyPermissions.IsHavingViewSurveyResults = true;
        //                        }
        //                    }
        //                    HttpContext.Current.Session["SurveyPermissions"] = objSurveyPermissions;
        //                }
        //            }

        //            #endregion
        //        }
        //        HttpContext.Current.Session["RolePermissions"] = objRolePermissions;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public class RolePermissions
        {
            public bool IsHavingSetup { get; set; }
            public bool IsHavingSurvey { get; set; }
            public bool IsHavingQuiz { get; set; }
            public bool IsHavingContact { get; set; }
            public bool IsHavingEmailMarketing { get; set; }
            public bool IsHavingEvent { get; set; }
            public bool IsHavingPetition { get; set; }
            public bool IsHavingCrowdFunding { get; set; }
            public bool IsHavingMarketplace { get; set; }
            public bool IsHavingForms { get; set; }
            public bool IsHavingTasks { get; set; }
        }
    }
}