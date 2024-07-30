using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Infra.Data.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<UserRole> GetRoleByUsername(string username)
        {
            return await dbSet
                .Include(x => x.Role)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.User.Username == username);
        }
    }
}