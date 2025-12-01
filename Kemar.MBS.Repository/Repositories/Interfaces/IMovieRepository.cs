using Kemar.MBS.Model.Movie.Request;
using Kemar.MBS.Model.Movie.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<MovieResponseDto> CreateMovieAsync(MovieCreateRequestDto request);
        Task<MovieResponseDto> GetMovieByIdAsync(int movieId);
        Task<IEnumerable<MovieResponseDto>> GetAllMoviesAsync();
    }
}
