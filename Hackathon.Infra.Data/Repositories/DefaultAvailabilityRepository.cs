using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class DefaultAvailabilityRepository : BaseRepository<DefaultAvailability>, IDefaultAvailabilityRepository
    {
        public DefaultAvailabilityRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
