using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IVehicleService
    {
        Task<BaseOutput<IList<Vehicle>>> Get();
        Task<BaseOutput<Vehicle>> Get(int id);
        Task<BaseOutput<int>> Create(VehicleDto vehicle);
        Task<BaseOutput<bool>> Update(VehicleDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
