namespace Hackathon.Application.DTOs
{
    public class PostPatientDto
    {
        public PersonDTO PersonalInformations { get; set; }
        public required string? HealthInsuranceNumber { get; set; }
    }
}
