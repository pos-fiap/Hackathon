using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class ParkingSpotProfile : Profile
    {
        public ParkingSpotProfile()
        {
            CreateMap<ParkingSpotDto, ParkingSpot>().ReverseMap();
        }
    }
}
