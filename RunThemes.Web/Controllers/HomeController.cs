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

    }
}
