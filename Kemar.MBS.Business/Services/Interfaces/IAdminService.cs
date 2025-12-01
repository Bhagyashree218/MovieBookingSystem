using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Admin.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminResponseDto> LoginAdminAsync(AdminLoginRequestDto request);
    }
}
