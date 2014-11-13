using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NearForums;
using NearForums.Web.Output;
using NearForums.Web.State;
using RunThemes.Business.Providers;
using RunThemes.Business.Services;
using RunThemes.Web.AutoMappings;
using RunThemes.Web.Configuration;


namespace RunThemes.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependenciesHelper.Register(new HttpContextWrapper(Context));

            SetupFilterProvider();
            var factory = new StructureMapControllerFactory(WebContainer.Current);
            ControllerBuilder.Current.SetControllerFactory(factory);
       

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            
            SetupAutomappings();
        }
        
        private static void SetupFilterProvider()
        {
            var oldProvider = FilterProviders.Providers.FirstOrDefault(f => f is FilterAttributeFilterProvider);
            if(oldProvider != null) FilterProviders.Providers.Remove(oldProvider);
            var provider = new StructureMapFilterProvider();
            FilterProviders.Providers.Add(provider);
        }

        public static void SetupAutomappings()
        {
            WebMapping.Configure(WebContainer.Current);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs args)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                var userService = WebContainer.Current.GetInstance<IUserService>();
                var userProvider = WebContainer.Current.GetInstance<IUserProvider>();
                var currentUser = userService.GetById(userProvider.CurrentUserId);
                currentUser.Identity = Context.User.Identity;
                Context.User = currentUser;
            }
        }

        protected void Application_AcquireRequestState(object sender, EventArgs args)
        {
            if (Context.User.Identity.IsAuthenticated && Context.Session != null)
            {
                var contextUser = Context.User as Data.Models.User;
                if (contextUser == null) return;

                Context.Session.Add("User", new UserState(new User
                {
                    Banned = false,
                    BirthDate = contextUser.BirthDate,
                    Email = contextUser.Email,
                    EmailPolicy = EmailPolicy.None,
                    Guid = Guid.Parse(contextUser.Id),
                    Id = Guid.Parse(contextUser.Id),
                    Role = UserRole.Admin,
                    UserName = contextUser.UserName
                }, AuthenticationProvider.CustomDb));
            }
        }
    }
}