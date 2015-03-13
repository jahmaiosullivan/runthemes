using System.Web;
using System.Web.Mvc;

namespace RunThemes.Web.Views
{
    public abstract class BaseWebViewPage<T> : WebViewPage<T>
    {
        public string CurrentUrl { get; set; }

        public bool IsAuthenticated { get; set; }

        public int PageIndex { get; set; }
        
        public override void InitHelpers()
        {
            //CurrentUser = userService.GetById(userProvider.CurrentUserId);
 
            CurrentUrl = HttpContext.Current.Request.Url.ToString();
            IsAuthenticated = HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated;
            base.InitHelpers();
        }
    }

    public abstract class BaseWebViewPage : BaseWebViewPage<dynamic> { }
}