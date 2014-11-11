using Microsoft.Owin;
using Owin;
using RunThemes.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace RunThemes.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
