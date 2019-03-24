using System.Web.Mvc;

namespace RecruiterVille.Areas.User
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "userdashboard",
                url: "user/dashboard/{param1}",
                defaults: new
                {
                    controller = "recruiter",
                    action = "dashboard",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "userprofile",
                url: "user/profile/{param1}",
                defaults: new
                {
                    controller = "recruiter",
                    action = "profile",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "users",
                url: "user/users/{param1}",
                defaults: new
                {
                    controller = "recruiter",
                    action = "users",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "vendors",
                url: "user/vendors/{param1}",
                defaults: new
                {
                    controller = "recruiter",
                    action = "vendors",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "permissions",
                url: "user/permissions/{param1}",
                defaults: new
                {
                    controller = "recruiter",
                    action = "permissions",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "myjobs",
                url: "job/myjobs/{param1}",
                defaults: new
                {
                    controller = "job",
                    action = "myjobs",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                name: "newjob",
                url: "job/newjob/{param1}",
                defaults: new
                {
                    controller = "job",
                    action = "newjob",
                    param1 = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "User_default",
                "User/{controller}/{action}/{param1}",
                new { controller = "company", action = "dashboard", param1 = UrlParameter.Optional }
            );
        }
    }
}