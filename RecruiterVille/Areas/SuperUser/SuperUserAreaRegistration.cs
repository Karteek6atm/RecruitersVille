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
                    controller = "superuser",
                    action = "index",
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