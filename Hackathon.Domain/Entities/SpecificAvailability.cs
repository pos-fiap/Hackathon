namespace Hackathon.Domain.Entities
{
    public class SpecificAvailability
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool IsAvailable { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
