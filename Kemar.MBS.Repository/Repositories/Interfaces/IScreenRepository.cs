using Kemar.MBS.Model.Screen.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IScreenRepository : IRepository<Screen>
    {
        Task<IEnumerable<ScreenResponseDto>> GetScreensByTheatreAsync(int theatreId);
        Task<ScreenResponseDto> GetScreenByIdAsync(int screenId);
    }
}
