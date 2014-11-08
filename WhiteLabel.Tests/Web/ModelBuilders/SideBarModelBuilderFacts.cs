using System;
using System.Linq;
using System.Web;
using Moq;
using WhiteLabel.Tests.Helpers;
using WhiteLabel.Web.Configuration;
using WhiteLabel.Web.ModelBuilders;
using Xunit;

namespace WhiteLabel.Tests.Web.ModelBuilders
{
    public class SideBarModelBuilderFacts
    {
  
        public class TestableSideBarModelBuilder : Facts<SideBarModelBuilder>
        {
            public Mock<HttpRequestBase> HttpRequestMock = new Mock<HttpRequestBase>();
            public string CurrentUrl = "http://WhiteLabel.com/";
            public static TestableSideBarModelBuilder Create()
            {
                var builder = new TestableSideBarModelBuilder();
                builder.HttpRequestMock.Setup(x => x.Url).Returns(new Uri(builder.CurrentUrl));
                builder.Mock<HttpContextBase>().Setup(x => x.Request).Returns(builder.HttpRequestMock.Object);
                return builder;
            }
        }
    }
}
