using System;

namespace WhiteLabel.Business.Providers
{
    public interface IUserProvider
    {
        Guid CurrentUserId { get; set; }
        bool IsAuthenticated { get; }
    }
}
