using RunThemes.Data.Azure;
using RunThemes.Data.Azure.Base;

namespace RunThemes.Data.Repositories
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
