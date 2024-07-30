using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<Person> GetPersonByDocument(string document)
        {
            return context.Person
                    .Where(x => x.Document == document && x.Status == Status.Active)
                    .ToList();
        }
    }
}