namespace Hackathon.Application.DTOs
{
    public class PostPatientDto
    {
        public UserDto User { get; set; }
        public required string? HealthInsuranceNumber { get; set; }
    }
}
