namespace Hackathon.Domain.Entities
{
    public class Doctor : BaseModel
    {
        public int Id { get; set; }
        public required string CRM { get; set; }
        public required string Specialty { get; set; }
        public int PersonId { get; set; }

        public virtual Person? Person { get; set; }
        public virtual DefaultAvailability? DefaultAvailability { get; set; }
        public virtual ICollection<SpecificAvailability>? SpecificAvailabilities { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

    }
}
