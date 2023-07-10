using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Udemy_MVC5Course
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Atribute routing

            //routes.MapMvcAttributeRoutes();
            //// Custome Routing
            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "Movies/ByReleased/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },
            //    new { year = @"2015|2016", month = @"\d{2}" });



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
