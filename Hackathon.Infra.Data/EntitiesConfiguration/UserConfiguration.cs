using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(p => p.PersonId).IsRequired();

            builder.Property(p => p.Email)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(p => p.PasswordHash)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.HasOne(p => p.Person).WithOne().HasForeignKey<User>(p => p.PersonId);

        }
    }
}
