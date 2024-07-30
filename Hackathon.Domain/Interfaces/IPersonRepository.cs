using Hackathon.Domain.Entities;

namespace Hackathon.Domain.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        public IList<Person> GetPersonByDocument(string document);
    }
}
