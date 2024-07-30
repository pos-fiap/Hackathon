using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IReservationService
    {
        Task<BaseOutput<bool>> Delete(int id);
        Task<BaseOutput<IList<Reservation>>> Get();
        Task<BaseOutput<Reservation>> Get(int id);
        Task<BaseOutput<int>> Post(ReservationDto reservation);
        Task<BaseOutput<int>> Update(ReservationDto reservation);
        Task<BaseOutput<bool>> CheckoutReservation(int id);
    }
}