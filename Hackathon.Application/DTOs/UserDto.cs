namespace Hackathon.Application.DTOs
{
    public class UserDto
    {
        public required PersonDTO PersonalInformations { get; set; }
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
