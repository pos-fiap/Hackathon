using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {

            builder.ToTable("Patient");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");

        }
    }
}