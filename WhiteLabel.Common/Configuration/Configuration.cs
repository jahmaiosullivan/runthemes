using System.Configuration;

namespace WhiteLabel.Common.Configuration
{
    public class Configuration : IConfiguration
    {
        public string StorageConnectionString { get; set; }
        public string FacebookAppId { get { return ConfigurationManager.AppSettings["FbAppId"]; }  }
        public string FacebookAppSecret { get { return ConfigurationManager.AppSettings["FbAppSecret"]; } }
    }
}
