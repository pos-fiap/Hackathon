using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class RoleAccessRepository : BaseRepository<RoleAccess>, IRoleAccessRepository
    {
        public RoleAccessRepository(ApplicationContext context) : base(context)
        {
        }

        public bool HasAccess(int roleId, string route)
        {
            return dbSet.Any(x => x.RoleId == roleId && x.Route.ToLower() == route.ToLower());
        }
    }
}
