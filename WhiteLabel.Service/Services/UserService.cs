using WhiteLabel.Business.Providers;
using WhiteLabel.Data.Models;
using WhiteLabel.Data.Repositories;

namespace WhiteLabel.Business.Services
{
    public interface IUserService : IBaseService<User>
    {
    }

    public class UserService : BaseDapperService<User>, IUserService
    {
        public UserService(IUserRepository repository, IUserProvider userProvider)
            : base(repository, userProvider)
        {
        }

    }
}
