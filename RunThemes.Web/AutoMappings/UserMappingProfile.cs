using System;
using System.Collections.Generic;
using AutoMapper;
using RunThemes.Data.Models;
using RunThemes.Web.ViewModels;

namespace RunThemes.Web.AutoMappings
{
    public class UserMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(d => d.About, opts => opts.MapFrom(s => s.About))
                .ForMember(d => d.AvatarThumbnailUrl, opts => opts.MapFrom(s =>s.Avatar))
                .ForMember(d => d.DisplayName, opts => opts.MapFrom(s => s.DisplayName))
                .ForMember(d => d.Id, opts => opts.MapFrom(s => Guid.Parse(s.Id)))
                .ForMember(d => d.Photos, opts => opts.UseValue(new List<string>()));
        }
    }
}