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

            routes.MapRoute(
                "UsersDetail",
                "users/{id}/",
                new { controller = "Users", action = "Detail" },
                constraints: new { id = @"^\d+$" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );

            routes.MapRoute(
                         "UsersEdit",
                         "users/{id}/edit",
                         new { controller = "Users", action = "Edit" },
                         constraints: new { id = @"^\d+$" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
                     );

            routes.MapRoute(
                      "MessagesByUser",
                      "users/{id}/messages",
                      new { controller = "Users", action = "MessagesByUser" },
                      constraints: new { id = @"^\d+$" },
                      namespaces: new[] { "RunThemes.Web.Controllers" }
                  );

            routes.MapRoute(
            "ListUsers",
            "admin/users/{page}",
            new { controller = "Users", action = "List", page = 0 },
            constraints: new { page = @"\d+" },
            namespaces: new[] { "RunThemes.Web.Controllers" }
        );

            routes.MapRoute(
                "DeleteUsers",
                "admin/users/delete",
                new { controller = "Users", action = "Delete" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );

            routes.MapRoute(
                "PromoteUsers",
                "admin/users/promote",
                new { controller = "Users", action = "Promote" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );

            routes.MapRoute(
                "DemoteUsers",
                "admin/users/demote",
                new { controller = "Users", action = "Demote" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );

            routes.MapRoute(
                "WarnDismiss",
                "users/warn-dismiss",
                new { controller = "Users", action = "WarnDismiss" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );
            routes.MapRoute(
                "WarnUsers",
                "users/warn",
                new { controller = "Users", action = "Warn" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );
            routes.MapRoute(
                "SuspendUsers",
                "users/suspend",
                new { controller = "Users", action = "Suspend" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );
            routes.MapRoute(
                    "BanUsers",
                    "users/ban",
                    new { controller = "Users", action = "Ban" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
                );
            routes.MapRoute(
                "ModeratorReasonDetail",
                "users/moderator-reason",
                new { controller = "Users", action = "ModeratorReasonDetail" },
                namespaces: new[] { "RunThemes.Web.Controllers" }
            );

            routes.MapRoute("FileUpload", "media/{action}", new { controller = "Media", action = "Index" },
                new[] { "RunThemes.Web.Controllers" });
            routes.MapRoute("Downloads", "downloads", new { controller = "Home", action = "Downloads" },
                new[] { "RunThemes.Web.Controllers" });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "RunThemes.Web.Controllers" });
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