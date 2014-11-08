using WhiteLabel.Data.Azure;
using WhiteLabel.Data.Azure.Base;

namespace WhiteLabel.Data.Repositories
{
    public class ImageInfoRepository : TableStorageRepository<ImageInfo>
    {
        public ImageInfoRepository(ICloudClientWrapper cloudClientWrapper) : base(cloudClientWrapper)
        {
        }
        
        public override string TableName
        {
            get { return "ImageInfo"; }
        }
    }
}
