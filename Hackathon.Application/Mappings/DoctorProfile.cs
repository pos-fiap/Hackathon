using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, PostDoctorDto>().ReverseMap();
        }
    }
}
