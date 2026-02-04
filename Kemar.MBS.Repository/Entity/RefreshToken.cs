using System;

namespace Kemar.MBS.Repository.Entity
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public int? UserId { get; set; }
        public int? AdminId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }

        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
