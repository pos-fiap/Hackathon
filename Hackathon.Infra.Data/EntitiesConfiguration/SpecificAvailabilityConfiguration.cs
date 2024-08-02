using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class SpecificAvailabilityConfiguration : IEntityTypeConfiguration<SpecificAvailability>
    {
        public void Configure(EntityTypeBuilder<SpecificAvailability> builder)
        {
            builder.ToTable(nameof(SpecificAvailability));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(p => p.StartTime)
                   .HasColumnType("time");

            builder.Property(p => p.EndTime)
                   .HasColumnType("time");

            builder.Property(p => p.DoctorId)
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne(a => a.Doctor)
                   .WithMany(d => d.SpecificAvailabilities)
                   .HasForeignKey(a => a.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}