using System;
using WhiteLabel.Data.Azure;
using WhiteLabel.Data.Azure.Base;

namespace WhiteLabel.Business.Services
{
    public interface IBetaUserService
    {
        void SignupBetaUser(BetaUser user);
    }

    public class BetaUserService : IBetaUserService
    {
        protected readonly ITableStorageRepository<BetaUser> betaUserRepository;

        public BetaUserService(ITableStorageRepository<BetaUser> betaUserRepository)
        {
            this.betaUserRepository = betaUserRepository;
        }

        public void SignupBetaUser(BetaUser betaUser)
        {
            betaUser.RowKey = betaUser.Email + "_" + DateTime.UtcNow.ToString("ddmmyyyy");
            betaUserRepository.Insert(betaUser);
        }

        
    }
}
