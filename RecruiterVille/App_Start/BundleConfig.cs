using System.Web;
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

            //Contactus Section
            bundles.Add(new StyleBundle("~/content/contactus").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/contactus").Include(
                      "~/app/js/jquery-1.11.1.min.js",
                      "~/app/js/bootstrap.min.js",
                      "~/Scripts/application/common.js",
                      "~/Scripts/application/contactus.js"));
        }
    }
}
