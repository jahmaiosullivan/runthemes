using WhiteLabel.Data.Dapper;
using WhiteLabel.Data.Models;

namespace WhiteLabel.Data.Repositories
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
