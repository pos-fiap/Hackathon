using Hackathon.Domain.Enums;

namespace Hackathon.Application.DTOs
{
    public class PatientUpdateDTO
    {
        public PersonDTO PersonalInformations { get; set; }
        public int Id { get; set; }
    }
}
