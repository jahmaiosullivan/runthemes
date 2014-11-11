using System.Web;
using Microsoft.AspNet.Identity.Owin;
using StructureMap;

namespace RunThemes.Web.Configuration
{
    public class WebRegistry : StructureMap.Configuration.DSL.Registry
    {
        public WebRegistry()
        {
            For<HttpContextBase>().Use(GetCurrentHttpContext);
            For<ApplicationUserManager>().Use(GetUserManager);
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