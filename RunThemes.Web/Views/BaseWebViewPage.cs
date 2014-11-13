using System.Web;
using System.Web.Mvc;
using RunThemes.Business.Providers;
using RunThemes.Business.Services;
using RunThemes.Data.Models;
using RunThemes.Web.Configuration;

namespace RunThemes.Web.Views
{
    public abstract class BaseWebViewPage<T> : WebViewPage<T>
    {
        public string CurrentUrl { get; set; }

        public bool IsAuthenticated { get; set; }
        
        public User CurrentUser { get; set; }

        public int PageIndex { get; set; }
        
        public override void InitHelpers()
        {
            var userService = WebContainer.Current.GetInstance<IUserService>();
            var userProvider = WebContainer.Current.GetInstance<IUserProvider>();
            //CurrentUser = userService.GetById(userProvider.CurrentUserId);
 
            CurrentUrl = HttpContext.Current.Request.Url.ToString();
            IsAuthenticated = HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated;
            base.InitHelpers();
        }
    }

    public abstract class BaseWebViewPage : BaseWebViewPage<dynamic> { }
}