using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface ICustomerVehicleService
    {
        Task<BaseOutput<IList<CustomerVehicle>>> Get();
        Task<BaseOutput<CustomerVehicle>> Get(int id);
        Task<BaseOutput<int>> Create(CustomerVehicleDto customerVehicle);
        Task<BaseOutput<bool>> Update(CustomerVehicleDto customerVehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
