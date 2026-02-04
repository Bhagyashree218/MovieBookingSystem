using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;

public class ShowService : IShowService
{
    private readonly IShowRepository _showRepository;

    public ShowService(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public Task AddUpdateAsync(ShowRequestDto request)
        => _showRepository.AddUpdateAsync(request);

    public Task<ShowResponseDto> GetShowByIdAsync(int showId)
        => _showRepository.GetShowByIdAsync(showId);

    public Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync()
        => _showRepository.GetAllShowsAsync();

    public Task<IEnumerable<ShowResponseDto>> GetShowByFilterAsync(ShowFilterDto filter)
        => _showRepository.GetShowByFilterAsync(filter);
}
