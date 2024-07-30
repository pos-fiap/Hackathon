using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<BaseOutput<IList<Customer>>> Get();
        Task<BaseOutput<Customer>> GetById(int id);
        Task<BaseOutput<int>> Create(CustomerDto vehicle);
        Task<BaseOutput<bool>> Update(CustomerDto vehicle);
        Task<bool> VerifyUser(int Id);
    }
}
