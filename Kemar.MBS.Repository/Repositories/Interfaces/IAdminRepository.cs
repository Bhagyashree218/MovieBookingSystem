using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Admin.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IAdminRepository 
    {
        Task<AdminResponseDto> CreateAdminAsync(AdminCreateRequestDto request);
        Task<AdminResponseDto> GetAdminByIdAsync(int adminId);
        Task<IEnumerable<AdminResponseDto>> GetAllAdminsAsync();
        Task<Admin> GetAdminForAuthAsync(string email);  // Authentication only

        Task<DailySummaryDto> GetDailySummaryAsync(DateTime date);
        Task<ShowBookingReportDto> GetShowReportAsync(int showId);
        Task<MovieBookingReportDto> GetMovieReportAsync(int movieId);
    }
}
