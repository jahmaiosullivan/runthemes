using WhiteLabel.Data.Dapper;
using WhiteLabel.Data.Models;

namespace WhiteLabel.Data.Repositories
{
    public interface IApartmentRepository : IDapperRepository<Apartment>
    {
    }

    public class ApartmentRepository : BaseDapperRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(IQueryManager queryManager) : base(queryManager)
        {
        }

        public override string TableName
        {
            get { return "apt_Apartments"; }
        }
    }
}
