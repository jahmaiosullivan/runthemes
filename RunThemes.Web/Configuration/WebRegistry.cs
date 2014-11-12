using System.Web;
using Microsoft.AspNet.Identity.Owin;
using StructureMap;

namespace RunThemes.Web.Configuration
{
    public class WebRegistry : StructureMap.Configuration.DSL.Registry
    {
        public WebRegistry()
        {
            For<HttpContextBase>().Use(ctx => GetCurrentHttpContext(ctx));
            For<ApplicationUserManager>().Use(ctx => GetUserManager(ctx));
        }

        private ApplicationUserManager GetUserManager(IContext context)
        {
            var httpContext = GetCurrentHttpContext(context);
            return httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        private HttpContextBase GetCurrentHttpContext(IContext context)
        {
            return new HttpContextWrapper(HttpContext.Current);
        }
    }
}