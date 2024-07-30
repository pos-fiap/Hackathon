using AutoMapper;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class CustomerVehicleProfile : Profile
    {
        public CustomerVehicleProfile()
        {
            CreateMap<CustomerVehicleDto, CustomerVehicle>()
                .ReverseMap();
        }
    }
}
