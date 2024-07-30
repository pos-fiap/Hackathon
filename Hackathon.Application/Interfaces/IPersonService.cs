using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IPersonService
    {
        Task<BaseOutput<int>> Create(PersonDTO personDto);
        Task<BaseOutput<Person>> Update(PersonUpdateDTO personDto);
        Task<bool> Verify(string name);
        Task<bool> Verify(int Id);
        Task<BaseOutput<List<Person>>> Get();
        Task<BaseOutput<Person>> Get(int Id);
        Task<BaseOutput<Person>> Get(PersonDTO personDto);
        Task<Person> Get(string name);


    }
}