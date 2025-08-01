using System.Application.DTOs.BranchesDTOs;
using System.Domain.Entities;
using AutoMapper;

namespace System.Application.MappingProfiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branches, ReadBranchDTO>()
                .ForMember(dest=>dest.CityName,opt=>opt.MapFrom(src=>src.City.CityName))
                .ReverseMap();
        }
    }
}
