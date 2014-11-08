using WhiteLabel.Web.ViewModels;

namespace WhiteLabel.Web.ModelBuilders
{
    public interface ISideBarModelBuilder
    {
        SideBarViewModel BuildModel();
    }

    public class SideBarModelBuilder : ISideBarModelBuilder
    {
        public SideBarViewModel BuildModel()
        {
            var model = new SideBarViewModel();
            return model;
        }


    }
}