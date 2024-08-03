using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class DefaultAvailabilityProfile : Profile
    {
        public DefaultAvailabilityProfile()
        {
            CreateMap<DefaultAvailability, DefaultAvailabilityDto>().ReverseMap();
        }
    }
}
