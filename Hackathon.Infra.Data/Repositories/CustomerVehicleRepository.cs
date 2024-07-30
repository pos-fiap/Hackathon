using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Data.Context;

namespace Hackathon.Infra.Data.Repositories
{
    public class CustomerVehicleRepository : BaseRepository<CustomerVehicle>, ICustomerVehicleRepository
    {
        public CustomerVehicleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}