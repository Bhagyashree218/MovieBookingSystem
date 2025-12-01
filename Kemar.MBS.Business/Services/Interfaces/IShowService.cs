using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IShowService
    {
        Task CreateShowAsync(ShowCreateRequestDto request);
        Task<ShowResponseDto> GetShowByIdAsync(int showId);
        Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync();
    }
}
