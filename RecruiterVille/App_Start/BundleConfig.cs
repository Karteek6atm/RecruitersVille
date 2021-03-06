﻿using System.Web;
using System.Web.Optimization;

namespace RecruiterVille
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Site Layout Section
            bundles.Add(new StyleBundle("~/content/sitelayout").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/style.css"));

            //User Layout Section
            bundles.Add(new StyleBundle("~/content/userlayout").Include(
                      "~/app/css/bootstrap.min.css",
                      "~/app/css/font-awesome.min.css",
                      "~/app/css/styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/userlayout").Include(
                      "~/app/js/bootstrap.min.js"));

            //Super User Layout Section
            bundles.Add(new StyleBundle("~/content/superuserlayout").Include(
                      "~/app/css/bootstrap.min.css",
                      "~/app/css/font-awesome.min.css",
                      "~/app/css/styles-super.css"));

            bundles.Add(new ScriptBundle("~/bundles/superuserlayout").Include(
                      "~/app/js/bootstrap.min.js"));

            //Login Section
            bundles.Add(new StyleBundle("~/content/login").Include(
                      "~/app/css/bootstrap.min.css",
                      "~/app/css/font-awesome.min.css",
                      "~/app/css/styles.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/login.js"));
            
            //Register Section
            bundles.Add(new StyleBundle("~/content/register").Include(
                      "~/app/css/bootstrap.min.css",
                      "~/app/css/font-awesome.min.css",
                      "~/app/css/styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/register").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/register.js"));

            //Packages Section
            bundles.Add(new StyleBundle("~/content/packages").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/packages").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/packages.js"));

            //Jobs Section
            bundles.Add(new ScriptBundle("~/bundles/jobs").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/jobs.js"));

            //Job View Section
            bundles.Add(new ScriptBundle("~/bundles/jobview").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/jobview.js"));

            //Contactus Section
            bundles.Add(new StyleBundle("~/content/contactus").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/contactus").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/contactus.js"));

            //Profile Section
            bundles.Add(new StyleBundle("~/content/profile").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/profile").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/profile.js"));
            bundles.Add(new ScriptBundle("~/bundles/profileView").Include(
                    "~/Scripts/application/common.js",
                    "~/Scripts/application/ProfileView.js"));

            //User Section
            bundles.Add(new StyleBundle("~/content/users").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/users").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/users.js"));
            
            //Vendor Section
            bundles.Add(new StyleBundle("~/content/vendors").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/vendors.js"));

            //Vendor Upload Section
            bundles.Add(new ScriptBundle("~/bundles/vendoruploads").Include(
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/vendoruploads.js"));

            //myjobs Section
            bundles.Add(new StyleBundle("~/content/myjobs").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/myjobs").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/myjobs.js"));

            //newjob Section
            bundles.Add(new StyleBundle("~/content/newjob").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/newjob").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/newjob.js"));

            //editjob Section
            bundles.Add(new StyleBundle("~/content/editjob").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/editjob").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/editjob.js"));

            //jobtemplates Section
            bundles.Add(new StyleBundle("~/content/jobtemplates").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/jobtemplates").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/jobtemplates.js"));

            //newtemplate Section
            bundles.Add(new StyleBundle("~/content/newtemplate").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/newtemplate").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/newtemplate.js"));

            //editjobtemplate Section
            bundles.Add(new StyleBundle("~/content/editjobtemplate").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/editjobtemplate").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/editjobtemplate.js"));

            //newprofile Section
            bundles.Add(new StyleBundle("~/content/newprofile").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/newprofile").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/newprofile.js"));

            //myprofiles Section
            bundles.Add(new StyleBundle("~/content/myprofiles").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/myprofiles").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/myprofiles.js"));

            //Profile Upload Section
            bundles.Add(new ScriptBundle("~/bundles/profileuploads").Include(
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/profileuploads.js"));
            
            //editprofile Section
            bundles.Add(new StyleBundle("~/content/editprofile").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/editprofile").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/editprofile.js"));

            //viewprofile Section
            bundles.Add(new StyleBundle("~/content/viewprofile").Include(
                      "~/app/css/fSelect.css"));

            bundles.Add(new ScriptBundle("~/bundles/viewprofile").Include(
                      "~/app/js/fSelect.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/viewprofile.js"));

            //View job Section
            bundles.Add(new ScriptBundle("~/bundles/viewjob").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/viewjob.js"));

            //View job template Section
            bundles.Add(new ScriptBundle("~/bundles/viewjobtemplate").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/viewjobtemplate.js"));

            // Super User CompaniesList Section
            bundles.Add(new ScriptBundle("~/bundles/CompaniesList").Include(
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/SuperUserCompaniesList.js"));
            // Super User ProfileList Section
            bundles.Add(new ScriptBundle("~/bundles/SuprerProfileList").Include(
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/SuperUserProfileList.js"));

            // Super User CompaniesList Section
            bundles.Add(new ScriptBundle("~/bundles/JobsList").Include(
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/SuperUserJobsList.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
