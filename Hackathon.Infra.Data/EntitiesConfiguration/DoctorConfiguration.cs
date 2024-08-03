using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(nameof(Doctor));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CRM)
                   .HasColumnType("varchar(50)");

            builder.Property(p => p.Specialty)
                   .HasColumnType("varchar(250)");

            builder.Property(p => p.PersonId).IsRequired();

            builder.HasOne(p => p.Person)
                   .WithOne()
                   .HasForeignKey<Doctor>(p => p.PersonId);

            builder.HasOne(p => p.DefaultAvailability)
                   .WithOne(p => p.Doctor)
                   .HasForeignKey<DefaultAvailability>(p => p.DoctorId);
        }
    }
}