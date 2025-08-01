using System.Application.DTOs.CashierDTOs;
using System.Domain.Entities;
using AutoMapper;

namespace System.Application.MappingProfiles
{
    public class CashierProfile : Profile
    {
        public CashierProfile()
        {
            CreateMap<Cashier, ReadCashierDTO>()
                .ForMember(dest=>dest.BranchName,opt=>opt.MapFrom(src=>src.Branch.BranchName))
                .ForMember(dest=>dest.CityId,opt=>opt.MapFrom(src=>src.Branch.CityID))
                .ForMember(dest=>dest.CityName,opt=>opt.MapFrom(src=>src.Branch.City.CityName))
                .ReverseMap();
            CreateMap<Cashier, InsertCashierDTO>()
               .ReverseMap();
            CreateMap<Cashier, UpdateCashierDTO>()
               .ReverseMap();
        }
    }
}
