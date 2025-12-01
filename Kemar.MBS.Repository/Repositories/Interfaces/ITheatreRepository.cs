using Kemar.MBS.Model.Theatre.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ITheatreRepository : IRepository<Theatre>
    {
        Task<IEnumerable<TheatreResponseDto>> GetTheatresByCityAsync(int cityId);
        Task<TheatreResponseDto> GetTheatreByIdAsync(int theatreId);
    }
}
