namespace WhiteLabel.Web.Configuration
{
    public interface IResourceManager
    {
        string GetResource(string resourceName);
    }

    public class ResourceManager : IResourceManager
    {
        public string GetResource(string resourceName)
        {
            return Resources.Resources.ResourceManager.GetString(resourceName);
        }
    }
}