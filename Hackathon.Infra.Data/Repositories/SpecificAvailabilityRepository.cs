using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class SpecificAvailabilityRepository : BaseRepository<SpecificAvailability>, ISpecificAvailabilityRepository
    {
        public SpecificAvailabilityRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
