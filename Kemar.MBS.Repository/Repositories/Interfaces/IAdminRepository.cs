using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Admin.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IAdminRepository 
    {
        Task<AdminResponseDto> CreateAdminAsync(AdminLoginRequestDto request);
        Task<AdminResponseDto> GetAdminByIdAsync(int adminId);
        Task<IEnumerable<AdminResponseDto>> GetAllAdminsAsync();
        Task<Admin> GetAdminForAuthAsync(string email);  // Authentication only
    }
}
