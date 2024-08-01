namespace Hackathon.Domain.Entities
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryDate { get; set; }
        public int PersonId { get; set; }

        public virtual Person? Person { get; set; }
    }
}
