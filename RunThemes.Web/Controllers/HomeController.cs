using System.Web.Mvc;
using WhiteLabel.Web.Controllers;

namespace RunThemes.Web.Controllers
{
    public class HomeController : CommonControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Downloads()
        {
            return View();
        }
    }
}
