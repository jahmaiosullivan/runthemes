using AutoMapper;
using WhiteLabel.Data.Azure;
using WhiteLabel.Web.ViewModels;

namespace WhiteLabel.Web.AutoMappings
{
    public class ImageInfoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ImageInfo, ImageInfoViewModel>();
        }
    }
}