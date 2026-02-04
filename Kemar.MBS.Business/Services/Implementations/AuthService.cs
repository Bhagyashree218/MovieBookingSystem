using Kemar.MBS.Business.Helpers;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtToken _jwtToken;

        public AuthService(IAuthRepository authRepository, JwtToken jwtToken)
        {
            _authRepository = authRepository;
            _jwtToken = jwtToken;
        }

        public async Task<RefreshToken> GenerateRefreshTokenAsync(int? userId, int? adminId, string jwtId)
        {
            var bytes = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(bytes);

            var refresh = new RefreshToken
            {
                UserId = userId,
                AdminId = adminId,
                Token = Convert.ToBase64String(bytes),
                JwtId = jwtId,
                IsUsed = false,
                IsRevoked = false,
                CreatedAt = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            };

            await _authRepository.SaveRefreshTokenAsync(refresh);
            return refresh;
        }

        public async Task<(bool Success, string Message, RefreshToken Token)>
            ValidateRefreshTokenAsync(string refreshToken, string jwtId)
        {
            var token = await _authRepository.GetRefreshTokenAsync(refreshToken);

            if (token == null)
                return (false, "Invalid refresh token", null);
            if (token.IsUsed)
                return (false, "Refresh token already used", null);
            if (token.IsRevoked)
                return (false, "Refresh token revoked", null);
            if (token.ExpiryDate < DateTime.UtcNow)
                return (false, "Refresh token expired", null);
            if (token.JwtId != jwtId)
                return (false, "Token mismatch", null);

            return (true, "Valid", token);
        }

        public async Task RevokeTokenAsync(string refreshToken)
        {
            var token = await _authRepository.GetRefreshTokenAsync(refreshToken);
            if (token != null)
                await _authRepository.MarkRefreshTokenRevokedAsync(token);
        }

        public async Task<string> GenerateOtpAsync(string email)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            var hash = BCrypt.Net.BCrypt.HashPassword(otp);

            var record = new OtpVerification
            {
                Email = email,
                OtpHash = hash,
                CreatedAt = DateTime.UtcNow,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5)
            };

            await _authRepository.SaveOtpAsync(record);
            return otp;
        }

        public async Task<bool> ValidateOtpAsync(string email, string otp)
        {
            var record = await _authRepository.GetLatestOtpAsync(email);
            if (record == null) return false;
            if (record.ExpiryTime < DateTime.UtcNow) return false;
            return BCrypt.Net.BCrypt.Verify(otp, record.OtpHash);
        }

        public async Task<bool> ResetPasswordAsync(string email, string otp, string newPassword)
        {
            var valid = await ValidateOtpAsync(email, otp);
            if (!valid) return false;

            var hash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _authRepository.UpdatePasswordAsync(email, hash);

            return true;
        }
    }
}
