using RunThemes.Business.Configuration;
using StructureMap;

namespace WhiteLabel.Web.Configuration
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
                });

            return container;
        }

       
    }
}