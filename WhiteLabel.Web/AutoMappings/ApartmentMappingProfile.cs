using System;
using AutoMapper;
using WhiteLabel.Common.Models;
using WhiteLabel.Data.Models;
using WhiteLabel.Web.AutoMappings.Resolvers;
using WhiteLabel.Web.ViewModels;

namespace WhiteLabel.Web.AutoMappings
{
    public class ApartmentMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Apartment, ApartmentViewModel>()
                .ForMember(d => d.Images, opts => opts.MapFrom(s => s.Images.Split(',').EmptyListIfNull()))
                .ForMember(d => d.Agent, opts => opts.ResolveUsing<IdToUserViewModelResolver>().FromMember(s => s.Agent ?? Guid.Empty));
        }
    }
}