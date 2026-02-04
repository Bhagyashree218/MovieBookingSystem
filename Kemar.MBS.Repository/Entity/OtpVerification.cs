using System;

namespace Kemar.MBS.Repository.Entity
{
    public class OtpVerification
    {
        public int OtpId { get; set; }
        public string Email { get; set; }
        public string OtpHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
