using AutoMapper;
using CSharpBackend.DTOs;
using CSharpBackend.Models;

namespace CSharpBackend.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>();
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id,
                    m => m.MapFrom(b => b.BeerID));
        }
    }
}
