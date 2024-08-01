using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Models;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IPatientService
    {
        Task<BaseOutput<List<Patient>>> Get();
        Task<BaseOutput<Patient>> Get(int id);
        Task<BaseOutput<int>> Create(PatientDto patientDto);
        Task<BaseOutput<bool>> Update(PatientDto patientDto);
        Task<BaseOutput<bool>> Delete(int id);

    }
}