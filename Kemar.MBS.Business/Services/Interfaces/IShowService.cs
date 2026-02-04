using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;

public interface IShowService
{
    Task AddUpdateAsync(ShowRequestDto request);
    Task<ShowResponseDto> GetShowByIdAsync(int showId);
    Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync();
    Task<IEnumerable<ShowResponseDto>> GetShowByFilterAsync(ShowFilterDto filter);
}
