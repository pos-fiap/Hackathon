using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class DefaultAvailabilityConfiguration : IEntityTypeConfiguration<DefaultAvailability>
    {
        public void Configure(EntityTypeBuilder<DefaultAvailability> builder)
        {
            builder.ToTable(nameof(DefaultAvailability));

            builder.HasKey(da => da.Id);

            builder.Property(da => da.StartSunday).HasColumnType("time");
            builder.Property(da => da.EndSunday).HasColumnType("time");
            builder.Property(da => da.LunchStartSunday).HasColumnType("time");
            builder.Property(da => da.LunchEndSunday).HasColumnType("time");

            builder.Property(da => da.StartMonday).HasColumnType("time");
            builder.Property(da => da.EndMonday).HasColumnType("time");
            builder.Property(da => da.LunchStartMonday).HasColumnType("time");
            builder.Property(da => da.LunchEndMonday).HasColumnType("time");

            builder.Property(da => da.StartTuesday).HasColumnType("time");
            builder.Property(da => da.EndTuesday).HasColumnType("time");
            builder.Property(da => da.LunchStartTuesday).HasColumnType("time");
            builder.Property(da => da.LunchEndTuesday).HasColumnType("time");

            builder.Property(da => da.StartWednesday).HasColumnType("time");
            builder.Property(da => da.EndWednesday).HasColumnType("time");
            builder.Property(da => da.LunchStartWednesday).HasColumnType("time");
            builder.Property(da => da.LunchEndWednesday).HasColumnType("time");

            builder.Property(da => da.StartThursday).HasColumnType("time");
            builder.Property(da => da.EndThursday).HasColumnType("time");
            builder.Property(da => da.LunchStartThursday).HasColumnType("time");
            builder.Property(da => da.LunchEndThursday).HasColumnType("time");

            builder.Property(da => da.StartFriday).HasColumnType("time");
            builder.Property(da => da.EndFriday).HasColumnType("time");
            builder.Property(da => da.LunchStartFriday).HasColumnType("time");
            builder.Property(da => da.LunchEndFriday).HasColumnType("time");

            builder.Property(da => da.StartSaturday).HasColumnType("time");
            builder.Property(da => da.EndSaturday).HasColumnType("time");
            builder.Property(da => da.LunchStartSaturday).HasColumnType("time");
            builder.Property(da => da.LunchEndSaturday).HasColumnType("time");

            builder.HasOne(p => p.Doctor).WithOne().HasForeignKey<DefaultAvailability>(p => p.DoctorId);

            builder.HasIndex(da => da.DoctorId).HasDatabaseName("IX_DefaultAvailabilities_DoctorId");
        }
    }
}