using System.Application.DTOs.BranchesDTOs;
using System.Domain.Entities;
using AutoMapper;

namespace System.Application.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<Cities, ReadCitiesDTO>()
                .ReverseMap();
        }
    }
}
