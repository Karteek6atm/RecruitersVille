using System.Web.Mvc;

namespace RecruiterVille.Areas.SuperUser
{
    public class SuperUserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SuperUser";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "superuserdashboard",
                url: "superuser/dashboard/{param1}",
                defaults: new
                {
                    controller = "user",
                    action = "index",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "superuserprofiles",
                url: "superuser/profiles/{param1}",
                defaults: new
                {
                    controller = "user",
                    action = "profileslist",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "superusercompanies",
                url: "superuser/companies/{param1}",
                defaults: new
                {
                    controller = "user",
                    action = "companieslist",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "superuserjobs",
                url: "superuser/jobs/{param1}",
                defaults: new
                {
                    controller = "user",
                    action = "adminjobslist",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "SuperUser_default",
                "SuperUser/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}