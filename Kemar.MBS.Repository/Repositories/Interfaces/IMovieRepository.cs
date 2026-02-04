using Kemar.MBS.Model.Movie.Request;
using Kemar.MBS.Model.Movie.Response;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task AddUpdateAsync(MovieRequestDto request);
        Task<MovieResponseDto?> GetMovieByIdAsync(int movieId);
        Task<IEnumerable<MovieResponseDto>> GetAllMoviesAsync();
        Task<IEnumerable<MovieResponseDto>> GetMovieByFilterAsync(MovieFilterDto filter);
    }
}
