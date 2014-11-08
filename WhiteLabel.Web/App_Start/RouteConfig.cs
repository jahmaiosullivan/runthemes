using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RunThemes.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ComingSoon", "comingsoon", new {controller = "Home", action = "ComingSoon"});
            routes.MapRoute("FileUpload", "media/{action}", new { controller = "Media", action = "Index" });
            routes.MapRoute("ManageApartments", "manageapartments", new { controller = "Manage", action = "ManageApartments" });
            routes.MapRoute("SingleApt", "{controller}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, constraints: new { id = new IntegerConstraint() });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("ErrorNotFound", "{*path}", new { controller = "Error", action = "NotFound" });
        }
    }

    public class NonNullOrEmptyConstraing : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return values[parameterName] != null && !string.IsNullOrEmpty(values[parameterName].ToString().Trim()) && !string.IsNullOrWhiteSpace(values[parameterName].ToString().Trim());
        }
    }

    public class IntegerConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            long val;
            return  values[parameterName] != null && Int64.TryParse(values[parameterName].ToString().Trim(), out val);
        }
    }
}