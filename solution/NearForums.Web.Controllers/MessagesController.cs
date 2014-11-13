using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using NearForums.Web.Controllers.Filters;
using NearForums.Services;
using NearForums.Web.Controllers.ViewModels.Messages;
using NearForums.Web.Extensions;
using NearForums.Web.Controllers.Helpers;
using NearForums.Validation;

namespace NearForums.Web.Controllers
{
	public class MessagesController : BaseController
	{
		/// <summary>
		/// Messages service
		/// </summary>
		private readonly IMessagesService _service;
		/// <summary>
		/// Topic service
		/// </summary>
		private readonly ITopicsService _topicService;
		/// <summary>
		/// Service that handle the subscription to a topic
		/// </summary>
		private readonly ITopicsSubscriptionsService _topicSubscriptionService;
		/// <summary>
		/// User service
		/// </summary>
		private readonly IUsersService _userService;
		/// <summary>
		/// Message removal service
		/// </summary>
		private readonly IMessageRemovalService _messageRemovalService;

		public MessagesController(IMessagesService service, ITopicsService topicService, IUsersService userService, ITopicsSubscriptionsService topicSubscriptionService, IMessageRemovalService messageRemovalService)
		{
			_service = service;
			_topicService = topicService;
			_topicSubscriptionService = topicSubscriptionService;
			_messageRemovalService = messageRemovalService;
			_userService = userService;
		}

		#region Add
		/// <summary>
		/// Loads the "reply to a topic" form
		/// </summary>
		/// <param name="id">thread id</param>
		/// <param name="name">thread short name</param>
		/// <param name="msg">Message id of the message being quoted.</param>
		[HttpGet]
		[RequireAuthorization]
		[PreventFlood]
		public ActionResult Add(int id, string name, int? msg)
		{
			var message = new Message();
			message.Topic = _topicService.Get(id, name);
			#region Check topic
			if (message.Topic == null)
			{
				return ResultHelper.NotFoundResult(this);
			}
			if (!message.Topic.HasPostAccess(Role))
			{
				return ResultHelper.ForbiddenResult(this);
			}
			if (message.Topic.IsClosed)
			{
				return ResultHelper.ForbiddenResult(this);
			} 
			#endregion
			if (msg != null)
			{
				message.InReplyOf = new Message(msg.Value);
			}


			ViewData["notify"] = SubscriptionHelper.IsUserSubscribed(id, this.User.Id, this.Config, _topicSubscriptionService);

			return View("Edit", message);
		}

		/// <summary>
		/// Saves the message or Loads the reply form to allow the user to clear error messages
		/// </summary>
		/// <param name="id">thread id</param>
		/// <param name="msg">Message id of the message being quoted.</param>
		[HttpPost]
		[RequireAuthorization]
		[ValidateInput(false)]
		[PreventFlood(SuccessResultType = typeof(RedirectToRouteResult))]
		public ActionResult Add([Bind(Prefix = "", Exclude = "Id")] Message message, int id, string name, string forum, int? msg, bool notify, string email)
		{
			message.Topic = _topicService.Get(id, name);
			#region Check topic
			if (message.Topic == null)
			{
				return ResultHelper.NotFoundResult(this);
			}
			if (!message.Topic.HasPostAccess(Role))
			{
				return ResultHelper.ForbiddenResult(this);
			}
			if (message.Topic.IsClosed)
			{
				return ResultHelper.ForbiddenResult(this);
			}
			#endregion
			try
			{
				SubscriptionHelper.SetNotificationEmail(notify, email, Session, Config, _userService);
				SubscriptionHelper.Manage(notify, message.Topic.Id, this.User.Id, this.User.Guid, this.Config, _topicSubscriptionService);
				if (msg != null)
				{
					message.InReplyOf = new Message(msg.Value);
				}
				if (ModelState.IsValid)
				{
					_service.Add(message, Request.UserHostAddress, User.ToUser());
					SubscriptionHelper.SendNotifications(this, message, this.Config, _topicSubscriptionService);
					//Redirect to the message posted
					return new RedirectToRouteExtraResult(new { action = "Detail", controller = "Topics", id = id, name = name, forum = forum }, "#msg" + message.Id);
				}
			}
			catch (ValidationException ex)
			{
				this.AddErrors(ModelState, ex);
			}
			return View("Edit", message);
		}
		#endregion

		#region Edit
		/// <summary>
		/// Loads the "reply to a topic" form
		/// </summary>
		/// <param name="id">thread id</param>
		/// <param name="name">thread short name</param>
		/// <param name="messageId">Message id being editted.</param>
		[HttpGet]
		[RequireAuthorization]
		public ActionResult Edit(int id, string name, int messageId)
		{
			var message = _service.Get(id, messageId);
			
			if (message == null)
			{
				return ResultHelper.NotFoundResult(this);
			}
			#region Check if user can edit
			if (User.Role < UserRole.Moderator && User.Id != message.User.Id)
			{
				return ResultHelper.ForbiddenResult(this);
			}
			#endregion

			ViewData["notify"] = SubscriptionHelper.IsUserSubscribed(id, this.User.Id, this.Config, _topicSubscriptionService);

			return View("Edit", message);
		}

		[HttpPost]
		[RequireAuthorization]
		[ValidateInput(false)]
		public ActionResult Edit(string forum, int id, string name, int messageId, [Bind(Prefix = "", Exclude = "Id")] Message message, bool notify, string email)
		{
			var originalMessage = _service.Get(id, messageId);

			if (originalMessage == null)
			{
				return ResultHelper.NotFoundResult(this);
			}

			message.Id = messageId;
			message.Topic = originalMessage.Topic;

			#region Check if user can edit
			if (User.Role < UserRole.Moderator && User.Id != originalMessage.User.Id)
			{
				return ResultHelper.ForbiddenResult(this);
			}
			#endregion

			try
			{
				SubscriptionHelper.SetNotificationEmail(notify, email, Session, Config, _userService);

				_service.Edit(message, Request.UserHostAddress, User.ToUser());
				SubscriptionHelper.Manage(notify, originalMessage.Topic.Id, User.Id, User.Guid, Config, _topicSubscriptionService);
				return new RedirectToRouteExtraResult(new { action = "Detail", controller = "Topics", id, name, forum }, "#msg" + message.Id);
			}
			catch (ValidationException ex)
			{
				AddErrors(ModelState, ex);
			}
			ViewBag.IsEdit = true;
			var roles = _userService.GetRoles().Where(x => x.Key <= Role);
			ViewBag.UserRoles = new SelectList(roles, "Key", "Value");

			return View(message);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Loads the remove message form
		/// </summary>
		/// <param name="messageId">message id</param>
		/// <param name="id">topic id</param>
		[HttpGet]
		[RequireAuthorization(UserRole.Moderator, RefuseOnFail = true)]
		public ActionResult Delete(int messageId, int id)
		{
			var message = _service.Get(id, messageId);

			if (message == null)
			{
				return ResultHelper.NotFoundResult(this);
			}

			var reasons = _messageRemovalService.GetAll().Select(x => new SelectListItem {Text = x.Title, Value = x.Id.ToString()});

			return View(new RemoveMessageViewModel { Message = message, RemovalReasons = reasons.ToList() });
		}

		/// <summary>
		/// Removes a message
		/// </summary>
		/// <param name="messageId">message id</param>
		/// <param name="id">topic id</param>
		[HttpPost]
		[RequireAuthorization(UserRole.Moderator, RefuseOnFail = true)]
		public ActionResult Delete(int messageId, int id, string name, string forum, int? removalReasonId = null)
		{
			_service.Delete(id, messageId, User.Id, removalReasonId);

			return RedirectToAction("Detail", "Topics", new {id, name, forum });
		}

		#endregion

		#region Flag messages
		/// <summary>
		/// Marks a message as inappropriate
		/// </summary>
		/// <param name="mid">Message id</param>
		/// <param name="id">Topic id</param>
		[HttpPost]
		public ActionResult Flag(int mid, int id, string forum, string name)
		{
			bool flagged = _service.Flag(id, mid, Request.UserHostAddress);

			return Json(flagged);
		}
		#endregion

		#region List flagged messages
		/// <summary>
		/// Gets a list of flagged messages
		/// </summary>
		/// <param name="page">zero-based page index</param>
		/// <returns></returns>
		[RequireAuthorization(UserRole.Moderator)]
		public ActionResult ListFlagged(int page)
		{
			var topics = _service.ListFlagged(page * Config.UI.MessagesPerPage, Config.UI.MessagesPerPage);
			ViewData["TotalMessages"] = _service.GetFlaggedMessageCount();
			ViewData["Page"] = page;

			return View(topics);
		}
		#endregion

		#region ClearFlags
		/// <summary>
		/// Removes the flags/marks on a message
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[RequireAuthorization(UserRole.Moderator, RefuseOnFail = true)]
		public ActionResult ClearFlags(int mid, int id, string forum, string name)
		{
			bool cleared = _service.ClearFlags(id, mid);
			return Json(cleared);
		}
		#endregion
	}
}
