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
        }
    }
}
