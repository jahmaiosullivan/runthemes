using AutoMapper;
using RunThemes.Data.Azure;
using RunThemes.Web.ViewModels;

namespace RunThemes.Web.AutoMappings
{
    public class ImageInfoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ImageInfo, ImageInfoViewModel>();
        }
    }
}