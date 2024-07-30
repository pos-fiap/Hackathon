using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>()
                .ForMember(prop => prop.Description, map => map.MapFrom(src => src.Description)).ReverseMap();

            CreateMap<Role, RoleUpdateDto>()
               .ForMember(prop => prop.Description, map => map.MapFrom(src => src.Description))
               .ForMember(prop => prop.Id, map => map.MapFrom(src => src.Id))
               .ReverseMap();
        }
    }
}
