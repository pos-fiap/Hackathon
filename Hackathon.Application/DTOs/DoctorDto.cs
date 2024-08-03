namespace Hackathon.Application.DTOs
{
    public class DoctorDto
    {
        public PersonDTO PersonalInformations { get; set; }
        public int Id { get; set; }
        public string CRM { get; set; }
        public string Specialty { get; set; }
    }
}
