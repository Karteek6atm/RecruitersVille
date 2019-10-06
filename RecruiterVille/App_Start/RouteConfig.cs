using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RecruiterVille
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("");

            routes.MapRoute(
               name: "login",
               url: "login/{param1}",
               defaults: new
               {
                   controller = "account",
                   action = "login",
                   param1 = UrlParameter.Optional
               }
           );

           routes.MapRoute(
               name: "register",
               url: "register/{param1}",
               defaults: new
               {
                   controller = "account",
                   action = "register",
                   param1 = UrlParameter.Optional
               }
           );

           routes.MapRoute(
               name: "packages",
               url: "packages/{param1}",
               defaults: new
               {
                   controller = "account",
                   action = "packages",
                   param1 = UrlParameter.Optional
               }
           );

            routes.MapRoute(
                name: "jobs",
                url: "jobs/{param1}",
                defaults: new
                {
                    controller = "site",
                    action = "jobs",
                    param1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "jobview",
                url: "jobview/{param1}",
                defaults: new
                {
                    controller = "site",
                    action = "jobview",
                    param1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
               name: "contactus",
               url: "contactus/{param1}",
               defaults: new
               {
                   controller = "account",
                   action = "contactus",
                   param1 = UrlParameter.Optional
               }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{param1}",
                defaults: new { controller = "account", action = "login", param1 = UrlParameter.Optional }
            );
        }
    }
}
