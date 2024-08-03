using System.Text.Json.Serialization;

namespace Hackathon.Domain.Entities
{
    public class DefaultAvailabilityDto
    {
        public int Id { get; set; }

        public TimeSpan? StartSunday { get; set; }
        public TimeSpan? EndSunday { get; set; }
        public TimeSpan? LunchStartSunday { get; set; }
        public TimeSpan? LunchEndSunday { get; set; }

        public TimeSpan? StartMonday { get; set; }
        public TimeSpan? EndMonday { get; set; }
        public TimeSpan? LunchStartMonday { get; set; }
        public TimeSpan? LunchEndMonday { get; set; }

        public TimeSpan? StartTuesday { get; set; }
        public TimeSpan? EndTuesday { get; set; }
        public TimeSpan? LunchStartTuesday { get; set; }
        public TimeSpan? LunchEndTuesday { get; set; }

        public TimeSpan? StartWednesday { get; set; }
        public TimeSpan? EndWednesday { get; set; }
        public TimeSpan? LunchStartWednesday { get; set; }
        public TimeSpan? LunchEndWednesday { get; set; }

        public TimeSpan? StartThursday { get; set; }
        public TimeSpan? EndThursday { get; set; }
        public TimeSpan? LunchStartThursday { get; set; }
        public TimeSpan? LunchEndThursday { get; set; }

        public TimeSpan? StartFriday { get; set; }
        public TimeSpan? EndFriday { get; set; }
        public TimeSpan? LunchStartFriday { get; set; }
        public TimeSpan? LunchEndFriday { get; set; }

        public TimeSpan? StartSaturday { get; set; }
        public TimeSpan? EndSaturday { get; set; }
        public TimeSpan? LunchStartSaturday { get; set; }
        public TimeSpan? LunchEndSaturday { get; set; }
    }
}
