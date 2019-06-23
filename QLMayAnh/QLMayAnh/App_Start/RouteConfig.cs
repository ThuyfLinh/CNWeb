using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLMayAnh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ABC",
                url: "MayAnh/{action}/{id}",
                defaults: new { controller = "MayAnh", action = "Login", id = UrlParameter.Optional }
            );      

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BanHang", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
