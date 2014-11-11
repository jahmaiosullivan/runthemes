using System;

namespace RunThemes.Business.Providers
{
    public interface IUserProvider
    {
        Guid CurrentUserId { get; set; }
        bool IsAuthenticated { get; }
    }
}
