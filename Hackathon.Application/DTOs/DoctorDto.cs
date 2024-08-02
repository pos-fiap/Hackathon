namespace Hackathon.Application.DTOs
{
    public class DoctorDto
    {
        public PersonDTO PersonalInformations { get; set; }
        public int Id { get; set; }
        public required string CRM { get; set; }
        public required string Specialty { get; set; }
    }
}
