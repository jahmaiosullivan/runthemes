using RunThemes.Data.Dapper;
using RunThemes.Data.Models;

namespace RunThemes.Data.Repositories
{
    public interface IUserDownloadsRepository : IDapperRepository<UserDownload>
    {
    }

    public class UserDownloadsRepository : BaseDapperRepository<UserDownload>, IUserDownloadsRepository
    {
        public UserDownloadsRepository(IQueryManager queryManager)
            : base(queryManager)
        {
        }
    }
}
