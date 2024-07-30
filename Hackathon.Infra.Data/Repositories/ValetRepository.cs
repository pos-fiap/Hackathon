using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class ValetRepository : BaseRepository<Valet>, IValetRepository
    {
        public ValetRepository(ApplicationContext context) : base(context)
        {
        }
    }
}