using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<BaseOutput<List<Doctor>>> GetAll();
        Task<BaseOutput<List<DoctorDto>>> GetAllLimited();
        Task<BaseOutput<Doctor>> Get(int id);
        Task<BaseOutput<int>> Create(PostDoctorDto doctorDto);
        Task<BaseOutput<bool>> Update(PutDoctorDto doctorDto);
        Task<BaseOutput<bool>> Delete(int id);

    }
}