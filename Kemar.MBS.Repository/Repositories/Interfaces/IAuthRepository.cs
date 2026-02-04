using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        // Refresh Token methods
        Task SaveRefreshTokenAsync(RefreshToken token);
        Task<RefreshToken> GetRefreshTokenAsync(string token);
        Task MarkRefreshTokenUsedAsync(RefreshToken token);
        Task MarkRefreshTokenRevokedAsync(RefreshToken token);

        // OTP methods
        Task SaveOtpAsync(OtpVerification otp);
        Task<OtpVerification> GetLatestOtpAsync(string email);
        Task UpdatePasswordAsync(string email, string hashedPassword);
    }
}
