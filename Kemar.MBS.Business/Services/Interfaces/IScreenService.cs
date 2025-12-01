using Kemar.MBS.Model.Screen.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IScreenService
    {
        Task<IEnumerable<ScreenResponseDto>> GetScreensByTheatreAsync(int theatreId);
        Task<ScreenResponseDto> GetScreenByIdAsync(int screenId);
    }
}
