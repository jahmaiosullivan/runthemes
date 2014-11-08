using WhiteLabel.Data.Azure;
using WhiteLabel.Data.Azure.Base;

namespace WhiteLabel.Data.Repositories
{
    public class BetaUserRepository : TableStorageRepository<BetaUser>
    {
        public BetaUserRepository(ICloudClientWrapper cloudClientWrapper) : base(cloudClientWrapper)
        {
        }

        public override string TableName
        {
            get { return "BetaUsers"; }
        }
    }
}
