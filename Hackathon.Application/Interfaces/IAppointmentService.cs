using Hackathon.Application.BaseResponse;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<BaseOutput<int>> Create(AppointmentDto appointmentDto);
        Task<BaseOutput<bool>> Delete(int id);

    }
}