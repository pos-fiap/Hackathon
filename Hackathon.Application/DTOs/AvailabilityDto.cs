using System.Text.Json.Serialization;

namespace Hackathon.Application.DTOs
{
    public class AvailabilityDto
    {
        [JsonIgnore]
        public DateTime RawDate { get; set; }
        public string? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }

}
