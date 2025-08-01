using System.Application.DTOs.CitiesDTOs;
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
