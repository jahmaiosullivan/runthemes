using System;
using System.Collections.Generic;
using System.Web.Http;
using WhiteLabel.Business.Services;
using WhiteLabel.Data.Models;
using WhiteLabel.Web.Controllers.Attributes;

namespace WhiteLabel.Web.ApiControllers
{
    public class ApartmentsApiController : ApiController
    {
        private readonly IApartmentService apartmentService;

        public ApartmentsApiController(IApartmentService apartmentService)
        {
            this.apartmentService = apartmentService;
        }

        [HttpPost]
        [ValidateApiAntiForgeryToken]
        public Apartment Create(Apartment apt)
        {
            if (ModelState.IsValid)
            {
                var savedApartment = apartmentService.Save(apt);
                return savedApartment;
            }

            throw new Exception("Cannot save");
        }

        // GET: api/ApartmentsApi
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET: api/ApartmentsApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApartmentsApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApartmentsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApartmentsApi/5
        public void Delete(int id)
        {
        }
    }
}
