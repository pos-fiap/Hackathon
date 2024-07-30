using Hackathon.Domain.Entities;

namespace Hackathon.Application.DTOs
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public IList<Role> Roles { get; set; }
    }
}
