using Kemar.MBS.Model.Movie.Request;
using Kemar.MBS.Model.Movie.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IMovieService
    {
        MovieResponseDto CreateMovie(MovieCreateRequestDto request);
        MovieResponseDto UpdateMovie(MovieUpdateRequestDto request);
        bool DeleteMovie(int movieId);
        MovieResponseDto GetMovieById(int movieId);
        IEnumerable<MovieResponseDto> GetAllMovies();
    }
}
