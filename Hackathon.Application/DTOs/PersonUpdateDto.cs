using Hackathon.Domain.Enums;

namespace Hackathon.Application.DTOs
{
    public class PersonUpdateDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Document { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
