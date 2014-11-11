using RunThemes.Business.Providers;
using RunThemes.Data.Models;
using RunThemes.Data.Repositories;

namespace RunThemes.Business.Services
{
    public interface IUserDownloadsService : IBaseService<UserDownload>
    {
    }

    public class UserDownloadsService : BaseDapperService<UserDownload>, IUserDownloadsService
    {
        private readonly IUserDownloadsRepository userDownloadRepository;
        public UserDownloadsService(IUserDownloadsRepository repository, IUserProvider userProvider)
            : base(repository, userProvider)
        {
            userDownloadRepository = repository;
        }
    }
}
