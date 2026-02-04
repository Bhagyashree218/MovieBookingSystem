using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly KemarMBSDbContext _context;

        public AuthRepository(KemarMBSDbContext context)
        {
            _context = context;
        }

        public async Task SaveRefreshTokenAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetRefreshTokenAsync(string token)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task MarkRefreshTokenUsedAsync(RefreshToken token)
        {
            token.IsUsed = true;
            _context.RefreshTokens.Update(token);
            await _context.SaveChangesAsync();
        }

        public async Task MarkRefreshTokenRevokedAsync(RefreshToken token)
        {
            token.IsRevoked = true;
            _context.RefreshTokens.Update(token);
            await _context.SaveChangesAsync();
        }

        public async Task SaveOtpAsync(OtpVerification otp)
        {
            await _context.OtpVerifications.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task<OtpVerification> GetLatestOtpAsync(string email)
        {
            return await _context.OtpVerifications
                .Where(x => x.Email == email)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task UpdatePasswordAsync(string email, string hashedPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
            if (user != null)
            {
                user.Password = hashedPassword;
                await _context.SaveChangesAsync();
                return;
            }

            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.AdminEmail == email);
            if (admin != null)
            {
                admin.Password = hashedPassword;
                await _context.SaveChangesAsync();
            }
        }
    }
}
