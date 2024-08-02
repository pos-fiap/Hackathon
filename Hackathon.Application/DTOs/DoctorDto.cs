namespace Hackathon.Application.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public required string CRM { get; set; }
        public required string Specialty { get; set; }
        public int PersonId { get; set; }
    }
}
