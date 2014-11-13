using System;
using System.Web.Mvc;
using NearForums;
using NearForums.Services;
using NearForums.Validation;
using NearForums.Web.Controllers.Filters;
using NearForums.Web.Controllers.Helpers;
using RunThemes.Business.Services;
using RunThemes.Common.Models;
using User = RunThemes.Data.Models.User;

namespace RunThemes.Web.Controllers
{
    public class UsersController : CommonControllerBase
	{
		/// <summary>
		/// Topic service
		/// </summary>
		private readonly ITopicsService _topicService;

        private readonly IUserService userService;
		public UsersController(ITopicsService topicService, IUserService userService)
		{
		    _topicService = topicService;
		    this.userService = userService;
		}

	    /// <summary>
		/// Bans a user permanently from the site
		/// </summary>
		/// <returns>Empty JSON</returns>
		[RequireAuthorization(UserRole.Moderator, RefuseOnFail = true)]
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Ban(Guid id, ModeratorReason reason, string reasonText)
		{
			//Include the result of banning in the viewdata for tracking (testing)
            ViewData.Model = userService.Ban(id, Guid.Parse(User.Id), UserRole.TrustedMember, reason, reasonText);
			return Json(null);
		}

		[RequireAuthorization(UserRole.Admin)]
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, string searched)
		{
            userService.Delete(id);
			return RedirectToAction("List", new
			{
				userName = searched,
				page = 0
			});
		}

		[RequireAuthorization(UserRole.Admin)]
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Demote(Guid id, string searched)
		{
            userService.Demote(id);
			return RedirectToAction("List", new
			{
				userName = searched,
				page = 0
			});
		}

        public ActionResult Detail(Guid id)
		{
			var user = userService.GetById(id);
			if (user == null)
			{
				return new HttpNotFoundResult();
			}
			//Get posted topics
			ViewData["Topics"] = _topicService.GetByUser(id, UserRole.TrustedMember);
			if (User != null)
			{
                ViewData["CanModerate"] = userService.CanModerate(user, user);
			}

			return View(user);
		}

		[RequireAuthorization]
		[HttpGet]
        public ActionResult Edit(Guid id)
		{
			if (Guid.Parse(User.Id) != id)
			{
				return new HttpUnauthorizedResult();
			}
			var user = userService.GetById(id);
			return View(user);
		}

		[RequireAuthorization]
		[HttpPost]
        public ActionResult Edit(Guid id, [Bind(Prefix = "")]User user)
		{
            if (Guid.Parse(User.Id) != id)
			{
                //if (User.HasModeratorPriviledges)
                //{
					user.Id = id.ToString();
					userService.Edit(user);
					return RedirectToAction("Detail", new { id = id });
				//}
				//return ForbiddenResult(this,true);
			}
			try
			{
				user.Id = id.ToString();
				userService.Edit(user);

				//Update membership data
				if (!String.IsNullOrEmpty(user.Email))
				{
					if (HttpContext.User.Identity.Name == "")
					{
						throw new Exception("Identity can not be null.");
					}
                    //var membershipUser = MembershipProvider.GetUser(HttpContext.User.Identity.Name, false);
                    //if (membershipUser != null)
                    //{
                    //    membershipUser.Email = user.Email;
                    //    MembershipProvider.UpdateUser(membershipUser);
                    //}
				}

				User.UserName = user.UserName;
				User.Email = Utils.EmptyToNull(user.Email);

				return RedirectToAction("Detail", new { id = id });
			}
			catch (ValidationException ex)
			{
				AddErrors(ModelState, ex);
			}
			return View(user);
		}

		[RequireAuthorization(UserRole.Admin)]
		public ActionResult List(string userName, int page)
		{
		    var users = String.IsNullOrEmpty(userName) 
                                        ? userService.FindAll().EmptyListIfNull() 
                                        : userService.GetByName(userName);
			ViewBag.UserName = userName;
			ViewBag.Page = page;

			return View(users);
		}

        public ActionResult MessagesByUser(Guid id)
		{
			var user = userService.GetById(id);
			if (user == null)
			{
				return new HttpNotFoundResult();
			}
			//Get posted messages
			var topics = _topicService.GetTopicsAndMessagesByUser(id);
			return View(topics);
		}

		/// <summary>
		/// Displays the message the moderator had to ban/warn/suspend the user
		/// </summary>
		/// <returns></returns>
		[RequireAuthorization]
		public ActionResult ModeratorReasonDetail()
		{
			var user = userService.GetById(User.Id);
			return View(user);
		}

		[RequireAuthorization(UserRole.Admin)]
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Promote(Guid id, string searched)
		{
			userService.Promote(id);
			return RedirectToAction("List", new
			{
				userName = searched,
				page = 0
			});
		}

		/// <summary>
		/// Suspends a user for a period of time
		/// </summary>
		/// <returns>Empty JSON</returns>
		[RequireAuthorization(UserRole.Moderator, RefuseOnFail = true)]
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Suspend(Guid id, ModeratorReason reason, string reasonText)
		{
            ViewData.Model = userService.Suspend(id, Guid.Parse(User.Id), UserRole.TrustedMember, reason, reasonText, DateTime.UtcNow.AddDays(15));
			return Json(ViewData.Model);
		}

		/// <summary>
		/// Warns the user of bad behaviour
		/// </summary>
		/// <returns>Empty JSON</returns>
		[RequireAuthorization(UserRole.Moderator, RefuseOnFail = true)]
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Warn(Guid id, ModeratorReason reason, string reasonText)
		{
			ViewData.Model = userService.Warn(id, Guid.Parse(User.Id), UserRole.TrustedMember, reason, reasonText);
			return Json(ViewData.Model);
		}

		/// <summary>
		/// Confirms that the user read the warning and dismisses the user message.
		/// </summary>
		/// <returns>True or false in Json</returns>
		[RequireAuthorization]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult WarnDismiss()
		{
            ViewData.Model = userService.WarnDismiss(Guid.Parse(User.Id));
			//Mark in session state that the warning was dismissed.
            User.WarningRead = true;
			return Json(ViewData.Model);
		}


        private static ActionResult ForbiddenResult(ControllerBase controller, bool emptyBody)
        {
            controller.ControllerContext.HttpContext.Response.StatusCode = 403;
            if (emptyBody)
            {
                controller.ControllerContext.HttpContext.Response.End();
                return new EmptyResult();
            }

            var viewResult = new ViewResult {ViewName = "Errors/403"};
            return viewResult;
        }
	}
}