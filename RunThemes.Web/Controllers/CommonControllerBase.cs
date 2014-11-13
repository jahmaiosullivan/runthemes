using System.Web.Mvc;
using System.Web.Routing;
using NearForums.Validation;
using RunThemes.Data.Models;

namespace RunThemes.Web.Controllers
{
    public class CommonControllerBase : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            InitializeCity();
        }

        public void InitializeCity()
        {
            var city = RouteData.Values["city"];
            var region = RouteData.Values["region"];

            if (city != null) ViewBag.CityName = city.ToString();
            if(region != null) ViewBag.Region = region.ToString();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            if (!ControllerContext.IsChildAction)
                RedirectToAction("NotFound", "Error");
        }

        public new User User
        {
            get
            {
                return ControllerContext.HttpContext.User as User;
            }
        }

        protected void AddErrors(ModelStateDictionary modelState, ValidationException ex)
        {
            foreach (ValidationError error in ex.ValidationErrors)
            {
                modelState.AddModelError(error.FieldName, error);
            }
        }


    }
}