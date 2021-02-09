using AutoMapper;
using Sourceful.Data.Models;
using Sourceful.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sourceful.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDetailViewModel>()
                .ForMember(desc => desc.Name, src => src.MapFrom(user => user.FirstName))
                .ForMember(desc => desc.Town, src => src.MapFrom(user => user.Address.Town))
                .ForMember(desc => desc.StreetName, src => src.MapFrom(user => user.Address.StreetName))
                .ForMember(desc => desc.Number, src => src.MapFrom(user => user.Address.Number))
                .ForMember(desc => desc.ShortDesc, src => src.MapFrom(user => user.Info.ShortDesc))
                .ForMember(desc => desc.LongDesc, src => src.MapFrom(user => user.Info.LongDesc));
            CreateMap<UserDetailViewModel, User>()
                .ForMember(desc => desc.FirstName, src => src.MapFrom(userVM => userVM.Name))
                .ForMember(desc => desc.LastName, src => src.MapFrom(userVM => userVM.LastName));
            CreateMap<UserDetailViewModel, Address>()
                .ForMember(desc => desc.Town, src => src.MapFrom(userVM => userVM.Town))
                .ForMember(desc => desc.StreetName, src => src.MapFrom(userVM => userVM.StreetName))
                .ForMember(desc => desc.Number, src => src.MapFrom(userVM => userVM.Number));
            CreateMap<UserDetailViewModel, Info>()
                .ForMember(desc => desc.ShortDesc, src => src.MapFrom(userVM => userVM.ShortDesc))
                .ForMember(desc => desc.LongDesc, src => src.MapFrom(userVM => userVM.LongDesc));
        }
    }
}
