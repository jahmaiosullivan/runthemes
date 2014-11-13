using System.Linq;
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

        public override User Get<TValType>(string column, TValType val)
        {
            var sql = string.Format(BaseQuery + " where u.{0} = @Val", column);
            var results = _queryManager.ExecuteSql<User>(sql, new { @Val = val });
            return results.FirstOrDefault();
        }

        public override string TableName
        {
            get { return "AspNetUsers"; }
        }
    }
}
