namespace Hackathon.Domain.Entities
{
    public class Patient : BaseModel
    {
        public int Id { get; set; }
        public string? HealthInsuranceNumber { get; set; }
        public int PersonId { get; set; }

        public virtual Person? Person { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
