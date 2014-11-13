using System.Collections.Generic;
using System.Web.Mvc;

namespace NearForums.Web.Controllers.ViewModels.Messages
{
	public class RemoveMessageViewModel
	{
		public Message Message { get; set; }
		public IList<SelectListItem> RemovalReasons { get; set; } 
	}
}
