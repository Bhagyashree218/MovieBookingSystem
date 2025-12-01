using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IShowRepository : IRepository<Show>
    {
        Task CreateShowAsync(ShowCreateRequestDto request);
        Task<ShowResponseDto> GetShowByIdAsync(int showId);
        Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync();
    }
}
