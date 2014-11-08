using System.Web.Mvc;
using AutoMapper;
using WhiteLabel.Business.Services;
using WhiteLabel.Data.Models;
using WhiteLabel.Web.ViewModels;

namespace WhiteLabel.Web.Controllers
{
    public class AptController : Controller
    {
        private readonly IApartmentService apartmentService;
        private readonly IMappingEngine mappingEngine;
        public AptController(IApartmentService apartmentService, IMappingEngine mappingEngine)
        {
            this.apartmentService = apartmentService;
            this.mappingEngine = mappingEngine;
        }

        // GET: Apt
        public ActionResult Index(long id)
        {
            var apartment = apartmentService.GetById(id);
            var model = mappingEngine.Map<Apartment, ApartmentViewModel>(apartment);
            return View(model);
        }

        // GET: Apt/Details/5
        public ActionResult Search()
        {
            return View();
        }


        // GET: Apt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apt/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apt/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Apt/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Apt/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Apt/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
