using Hackathon.Domain.Entities;

namespace Hackathon.Application.DTOs
{
    public class PutDoctorDto
    {
        public DefaultAvailabilityDto DefaultAvailability { get; set; }
        public UserDto User { get; set; }
        public int Id { get; set; }
        public required string CRM { get; set; }
        public required string Specialty { get; set; }
    }
}
