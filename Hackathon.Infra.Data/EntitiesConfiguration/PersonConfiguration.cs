using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(p => p.Status)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(p => p.CPF)
                   .HasColumnType("varchar(15)")
                   .IsRequired();

        }
    }
}