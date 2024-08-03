namespace Hackathon.Application.DTOs
{
    public class PostDoctorDto
    {
        public DefaultAvailabilityDto DefaultAvailability { get; set; }
        public UserDto User { get; set; }
        public required string CRM { get; set; }
        public required string Specialty { get; set; }
    }
}
