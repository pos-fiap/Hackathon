using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
