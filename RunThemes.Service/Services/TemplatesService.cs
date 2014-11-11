using RunThemes.Business.Providers;
using RunThemes.Data.Models;
using RunThemes.Data.Repositories;

namespace RunThemes.Business.Services
{
    public interface ITemplatesService : IBaseService<Template>
    {
    }

    public class TemplatesService : BaseDapperService<Template>, ITemplatesService
    {
        private readonly ITemplatesRepository templatesRepository;
        public TemplatesService(ITemplatesRepository repository, IUserProvider userProvider)
            : base(repository, userProvider)
        {
            templatesRepository = repository;
        }
    }
}
