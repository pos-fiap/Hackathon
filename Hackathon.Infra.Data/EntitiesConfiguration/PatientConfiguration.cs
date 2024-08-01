using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(nameof(Patient));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.HealthInsuranceNumber)
                   .HasColumnType("varchar(50)");

            builder.Property(p => p.PersonId).IsRequired();

            builder.HasOne(p => p.Person).WithOne().HasForeignKey<Patient>(p => p.PersonId);

        }
    }
}