using NearForums.Services;
using RunThemes.Business.Configuration;
using StructureMap;

namespace RunThemes.Web.Configuration
{
    public class WebContainer
    {
        public static IContainer Current = GetWebContainer();

        static IContainer GetWebContainer()
        {
            var container = new Container(
            
                x => { 
                    x.AddRegistry<CoreRegistry>();
                    x.AddRegistry<WebRegistry>();
                    x.Policies.SetAllProperties( y => y.OfType<ITemplatesService>());
                });

            return container;
        }

       
    }
}