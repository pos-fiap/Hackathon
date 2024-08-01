using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientDto, Patient> ()
                 .ForPath(prop => prop.Person.Name, map => map.MapFrom(src => src.PersonalInformations.Name))
                 .ForPath(prop => prop.Person.CPF, map => map.MapFrom(src => src.PersonalInformations.Document))
                 .ForPath(prop => prop.Person.Status, map => map.MapFrom(src => src.PersonalInformations.Status))
                 .ReverseMap();
        }
    }
}
