﻿using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{
    public class RoleAccessConfiguration : IEntityTypeConfiguration<RoleAccess>
    {
        public void Configure(EntityTypeBuilder<RoleAccess> builder)
        {
            builder.ToTable(nameof(RoleAccess));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RoleId)
                .HasColumnType("int")
                .HasColumnName("RoleId")
                .IsRequired();

            builder.Property(x => x.Route)
                .HasColumnType("varchar(50)")
                .HasColumnName("Route")
                .IsRequired();
        }
    }
}
