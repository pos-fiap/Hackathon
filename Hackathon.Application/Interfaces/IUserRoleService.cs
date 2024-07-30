using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<BaseOutput<IList<UserRole>>> GetByUser(int user);
        Task<BaseOutput<int>> AssignRoleToUser(UserRoleDto userRoleDto);

        Task<UserRole> GetRoleByUsername(string username);
    }
}