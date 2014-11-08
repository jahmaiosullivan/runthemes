using System.Web.Mvc;
using System.Web.Routing;

namespace WhiteLabel.Web.Controllers.Attributes
{
    public class UnauthorizedRedirectToComingSoonAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult("ComingSoon", new RouteValueDictionary());
        }
    }
}