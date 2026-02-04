using Kemar.MBS.Model.Screen.Request;
using Kemar.MBS.Model.Screen.Response;
public interface IScreenRepository 
{
    Task AddUpdateAsync(ScreenRequestDto request);
    Task<ScreenResponseDto> GetScreenByIdAsync(int screenId);
    Task<IEnumerable<ScreenResponseDto>> GetScreensByTheatreAsync(int theatreId);
    Task<IEnumerable<ScreenResponseDto>> GetScreenByFilterAsync(ScreenFilterDto filter);
}
