using Hackathon.Domain.Enums;

namespace Hackathon.Application.DTOs
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType VehicleType { get; set; }
        public string? Notes { get; set; }
    }
}
