using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AreaDemo.Areas.Men.Models;

namespace AreaDemo.Areas.Men.Controllers
{
    public class FootwearController : Controller
    {
        public ActionResult Index()
        {
            MenRepository menRepository = new MenRepository();
            var getFootwears = menRepository.GetFootwears();
            return View(getFootwears);
        }
    }
}
