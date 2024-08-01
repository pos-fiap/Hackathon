using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(prop => prop.Id, map => map.MapFrom(src => src.Id))
                .ForMember(prop => prop.PasswordHash, map => map.MapFrom(src => src.Password))
                .ForPath(prop => prop.Person.Name, map => map.MapFrom(src => src.PersonalInformations.Name))
                .ForPath(prop => prop.Person.CPF, map => map.MapFrom(src => src.PersonalInformations.Document))
                .ForPath(prop => prop.Person.Status, map => map.MapFrom(src => src.PersonalInformations.Status))
                .ReverseMap();

            CreateMap<UserUpdateDto, User>()
                .ForMember(prop => prop.Id, map => map.MapFrom(src => src.Id))
                .ForMember(prop => prop.PasswordHash, map => map.MapFrom(src => src.Password))
                .ReverseMap();
        }
    }
}
