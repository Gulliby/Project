﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                name: "Login",
                url: "{Login}",
                defaults: new {controller = "Login", action = "Login"}
                );
            routes.MapRoute(
                name: "Sign",
                url: "{Sign}",
                defaults: new {controller = "Sign", action = "Sign"}
                );

            routes.MapRoute("404-catch-all", "{*catchall}", new {Controller = "Error", Action = "NotFound"});
        }
    }
}
