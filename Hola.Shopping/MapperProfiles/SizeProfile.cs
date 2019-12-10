using AutoMapper;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Domain.Model;

namespace Hola.Shopping.Api.MapperProfiles
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeDto>()
                .ReverseMap();
        }
    }
}
