using RunThemes.Business.Providers;
using RunThemes.Data.Models;
using RunThemes.Data.Repositories;

namespace RunThemes.Business.Services
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
