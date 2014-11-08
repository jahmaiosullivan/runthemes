using System.Web.Mvc;
using WhiteLabel.Web.Controllers.Attributes;

namespace WhiteLabel.Web.Controllers
{
    [UnauthorizedRedirectToComingSoon]
    public class HomeController : CommonControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ComingSoon()
        {
            return View();
        }
    }
}
