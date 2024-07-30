using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infra.Data.EntitiesConfiguration
{

    public class CustomerVehicleConfiguration : IEntityTypeConfiguration<CustomerVehicle>
    {
        public void Configure(EntityTypeBuilder<CustomerVehicle> builder)
        {
            builder.ToTable("CustomerVehicle");
        }
    }
}