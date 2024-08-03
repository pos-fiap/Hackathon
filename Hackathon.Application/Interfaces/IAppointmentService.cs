using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;

namespace Hackathon.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<BaseOutput<List<AvailabilityDto>>> GetDoctorAvailability(int doctorId);
        Task<BaseOutput<int>> Create(AppointmentDto appointmentDto);
        Task<BaseOutput<bool>> Delete(int id);

    }
}