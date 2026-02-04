using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Common;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IAdminService
    {
        Task<ResultModel> LoginAdminAsync(AdminLoginRequestDto request);
        Task<ResultModel> CreateAdminAsync(AdminCreateRequestDto request);
        Task<ResultModel> GetAdminByIdAsync(int adminId);
        Task<ResultModel> GetAllAdminsAsync();
        Task<ResultModel> GetDailySummaryAsync(DateTime date);
        Task<ResultModel> GetShowReportAsync(int showId);
        Task<ResultModel> GetMovieReportAsync(int movieId);
    }
}
