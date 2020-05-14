using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "RouteDiary",
				url: "Diary/{*date}",
				defaults: new { controller = "Diary", action = "Details" }
			);

			routes.MapRoute(
				name: "RouteComment",
				url: "Comment/{*date}",
				defaults: new { controller = "Diary", action = "Comment" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
    }
}
