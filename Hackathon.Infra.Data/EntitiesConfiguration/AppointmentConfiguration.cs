using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(nameof(Appointment));

            builder.HasKey(a => a.Id);

            builder.Property(a => a.AppointmentDate).IsRequired();
            builder.Property(a => a.StartTime).IsRequired().HasColumnType("time");
            builder.Property(a => a.EndTime).IsRequired().HasColumnType("time");

            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => new { a.DoctorId, a.AppointmentDate }).HasDatabaseName("IX_Appointments_DoctorId_AppointmentDate");
            builder.HasIndex(a => new { a.PatientId, a.AppointmentDate }).HasDatabaseName("IX_Appointments_PatientId_AppointmentDate");

        }
    }
}