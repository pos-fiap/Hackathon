using Hackathon.Domain.Entities;

namespace Hackathon.Domain.Interfaces
{
    public interface IRoleAccessRepository : IBaseRepository<RoleAccess>
    {
        bool HasAccess(int roleId, string route);
    }
}
