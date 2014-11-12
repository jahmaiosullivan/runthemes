using AreaDemo.Areas.Men.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaDemo.Areas.Men.Controllers
{
    public class ClothingController : Controller
    {        
        public ActionResult Index()
        {
            MenRepository menRepository = new MenRepository();
            var getCloths = menRepository.GetCloths();
            return View(getCloths);
        }
    }
}
