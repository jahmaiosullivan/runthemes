using System;
using System.Web.Mvc;

namespace WhiteLabel.Web.Controllers.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
    public class RequiresRolesAttribute : ActionFilterAttribute
    {
        public string RedirectController { get; set; }

        public string RedirectAction { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
        }
    }
    
}
