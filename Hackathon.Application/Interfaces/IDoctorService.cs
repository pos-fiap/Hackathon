using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<BaseOutput<List<Doctor>>> Get();
        Task<BaseOutput<Doctor>> Get(int id);
        Task<BaseOutput<int>> Create(DoctorDto doctorDto);
        Task<BaseOutput<bool>> Update(DoctorDto doctorDto);
        Task<BaseOutput<bool>> Delete(int id);

    }
}