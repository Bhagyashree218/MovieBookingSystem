using Kemar.MBS.Repository.Entity;
using System.Threading.Tasks;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RefreshToken> GenerateRefreshTokenAsync(int? userId, int? adminId, string jwtId);
        Task<(bool Success, string Message, RefreshToken Token)> ValidateRefreshTokenAsync(string refreshToken, string jwtId);
        Task RevokeTokenAsync(string refreshToken);

        Task<string> GenerateOtpAsync(string email);
        Task<bool> ValidateOtpAsync(string email, string otp);
        Task<bool> ResetPasswordAsync(string email, string otp, string newPassword);
    }
}
