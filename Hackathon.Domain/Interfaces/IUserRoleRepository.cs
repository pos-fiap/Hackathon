using Hackathon.Domain.Entities;

namespace Hackathon.Domain.Interfaces
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        Task<UserRole> GetRoleByUsername(string username);

    }
}
