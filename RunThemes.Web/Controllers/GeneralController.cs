using System.Web.Mvc;
using NearForums.Web.Controllers;
using RunThemes.Common.Helpers;
using RunThemes.Web.Models;

namespace RunThemes.Web.Controllers
{
    public class GeneralController : Controller
    {
        [ChildActionOnly]
        public ActionResult Header()
        {
            var controller = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();
            var action = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();

            var selected = HeaderMenu.Features;
            var isDownloadsPage = System.String.Compare(typeof (HomeController).Name.RemoveFromEnd("Controller"), controller, System.StringComparison.OrdinalIgnoreCase) == 0 && action == "Downloads";
            var isSupportPage = System.String.Compare(typeof(ForumsController).Name.RemoveFromEnd("Controller"), controller, System.StringComparison.OrdinalIgnoreCase) == 0;
            if (isDownloadsPage)
            {
                selected = HeaderMenu.Downloads;
            }
            else if (isSupportPage)
            {
                selected = HeaderMenu.Support;
            }
            return PartialView("Header", selected);
        }
    }
}
