using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IParkingSpotService
    {
        Task<BaseOutput<IList<ParkingSpot>>> Get();
        Task<BaseOutput<ParkingSpot>> Get(int id);
        Task<BaseOutput<int>> Create(ParkingSpotDto vehicle);
        Task<BaseOutput<bool>> Update(ParkingSpotDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
        Task<BaseOutput<IList<ParkingSpot>>> GetAllFreeParkingSpots();
    }
}
