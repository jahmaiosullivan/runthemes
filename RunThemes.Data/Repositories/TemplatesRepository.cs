using RunThemes.Data.Dapper;
using RunThemes.Data.Models;

namespace RunThemes.Data.Repositories
{
    public interface ITemplatesRepository : IDapperRepository<Template>
    {
    }

    public class TemplatesRepository : BaseDapperRepository<Template>, ITemplatesRepository
    {
        public TemplatesRepository(IQueryManager queryManager) : base(queryManager)
        {
        }
    }
}
