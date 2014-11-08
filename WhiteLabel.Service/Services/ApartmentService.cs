using WhiteLabel.Business.Providers;
using WhiteLabel.Data.Models;
using WhiteLabel.Data.Repositories;

namespace WhiteLabel.Business.Services
{
    public interface IApartmentService : IBaseService<Apartment>
    {
    }

    public class ApartmentService : BaseDapperService<Apartment>, IApartmentService
    {
        public ApartmentService(IApartmentRepository repository, IUserProvider userProvider) 
            : base(repository, userProvider)
        {
        }
    }
}
