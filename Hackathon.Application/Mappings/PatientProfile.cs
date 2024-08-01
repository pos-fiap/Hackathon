using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class PatientProfile : Patient
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDto>()
                 .ForPath(prop => prop.Person.Name, map => map.MapFrom(src => src.PersonalInformations.Name))
                 .ForPath(prop => prop.Person.Document, map => map.MapFrom(src => src.PersonalInformations.Document))
                 .ForPath(prop => prop.Person.Status, map => map.MapFrom(src => src.PersonalInformations.Status))
                 .ReverseMap();
        }
    }
}
