using AutoMapper;
using StructureMap;

namespace RunThemes.Web.AutoMappings
{
    public static class WebMapping
    {
        public static void Configure(IContainer container)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(container.GetInstance);
                cfg.AddProfile<ImageInfoMappingProfile>();
                cfg.AddProfile<UserMappingProfile>();
                cfg.AddProfile<PostMappingProfile>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}