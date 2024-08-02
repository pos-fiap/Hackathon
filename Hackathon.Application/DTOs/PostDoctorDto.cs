namespace Hackathon.Application.DTOs
{
    public class PostDoctorDto
    {
        public PersonDTO PersonalInformations { get; set; }
        public required string CRM { get; set; }
        public required string Specialty { get; set; }
    }
}
