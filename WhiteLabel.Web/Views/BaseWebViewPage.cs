using System.Web;
using System.Web.Mvc;
using WhiteLabel.Business.Providers;
using WhiteLabel.Business.Services;
using WhiteLabel.Data.Models;
using WhiteLabel.Web.Configuration;

namespace WhiteLabel.Web.Views
{
    public abstract class BaseWebViewPage<T> : WebViewPage<T>
    {
        public string CurrentUrl { get; set; }

        public bool IsAuthenticated { get; set; }
        
        public User CurrentUser { get; set; }
        
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