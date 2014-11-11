using RunThemes.Data.Dapper;
using RunThemes.Data.Models;

namespace RunThemes.Data.Repositories
{
    public interface IUserRepository : IDapperRepository<User>
    {
    }

    public class UserRepository : BaseDapperRepository<User>, IUserRepository
    {
        public UserRepository(IQueryManager queryManager) : base(queryManager) { }

        public override string TableName
        {
            get { return "AspNetUsers"; }
        }
    }
}
