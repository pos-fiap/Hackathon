using Hackathon.Domain.Enums;

namespace Hackathon.Application.DTOs
{
    public class PersonDTO
    {
        public required string Name { get; set; }
        public required string Document { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
