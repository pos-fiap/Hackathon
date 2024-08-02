using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
