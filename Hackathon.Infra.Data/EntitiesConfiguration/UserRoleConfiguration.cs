using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserId)
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(p => p.RoleId)
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Role).WithMany().HasForeignKey(p => p.RoleId);

        }
    }
}
