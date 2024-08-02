namespace Hackathon.Application.DTOs
{
    public class PatientDto
    {
        public PersonDTO PersonalInformations { get; set; }
        public string? HealthInsuranceNumber { get; set; }
        public int Id { get; set; }
    }
}
