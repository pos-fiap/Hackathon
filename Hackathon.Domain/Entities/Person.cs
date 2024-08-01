using Hackathon.Domain.Enums;

namespace Hackathon.Domain.Entities
{
    public class Person : BaseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CPF { get; set; }
        public Status Status { get; set; }

    }
}
