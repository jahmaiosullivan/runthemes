using System.Web.Mvc;

namespace RunThemes.Web.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Forum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Forum_Home",
                "Forum",
                new { action = "List", controller="Forums" },
                new[] { "NearForums.Web.Controllers" }
            );

            context.MapRoute(
                "Forum_default",
                "Forum/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, page = 1 },
                new[] { "NearForums.Web.Controllers" }
            );
        }
    }
}