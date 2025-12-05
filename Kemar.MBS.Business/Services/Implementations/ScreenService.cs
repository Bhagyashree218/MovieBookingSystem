using Kemar.MBS.Model.Screen.Request;
using Kemar.MBS.Model.Screen.Response;

public class ScreenService : IScreenService
{
    private readonly IScreenRepository _screenRepository;

    public ScreenService(IScreenRepository screenRepository)
    {
        _screenRepository = screenRepository;
    }

    public Task AddUpdateAsync(ScreenRequestDto request)
        => _screenRepository.AddUpdateAsync(request);

    public Task<ScreenResponseDto> GetScreenByIdAsync(int screenId)
        => _screenRepository.GetScreenByIdAsync(screenId);

    public Task<IEnumerable<ScreenResponseDto>> GetScreensByTheatreAsync(int theatreId)
        => _screenRepository.GetScreensByTheatreAsync(theatreId);

    public Task<IEnumerable<ScreenResponseDto>> GetScreenByFilterAsync(ScreenFilterDto filter)
        => _screenRepository.GetScreenByFilterAsync(filter);
}
