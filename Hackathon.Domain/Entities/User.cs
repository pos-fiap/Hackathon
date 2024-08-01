namespace Hackathon.Domain.Entities
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryDate { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
