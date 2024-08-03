using Hackathon.Domain.Enums;

namespace Hackathon.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CPF { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
