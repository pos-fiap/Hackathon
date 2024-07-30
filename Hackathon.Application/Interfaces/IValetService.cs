using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IValetService
    {
        Task<BaseOutput<IList<Valet>>> Get();
        Task<BaseOutput<Valet>> Get(int id);
        Task<BaseOutput<int>> Create(ValetDto vehicle);
        Task<BaseOutput<bool>> Update(ValetDto vehicle);
        Task<BaseOutput<bool>> Delete(int id);
    }
}
