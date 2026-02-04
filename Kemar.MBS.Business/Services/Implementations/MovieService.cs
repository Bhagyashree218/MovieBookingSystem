using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Movie.Request;
using Kemar.MBS.Model.Movie.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Task AddUpdateAsync(MovieRequestDto request)
        {
            // here you can later add business validations if needed
            return _movieRepository.AddUpdateAsync(request);
        }

        public Task<MovieResponseDto?> GetMovieByIdAsync(int movieId)
            => _movieRepository.GetMovieByIdAsync(movieId);

        public Task<IEnumerable<MovieResponseDto>> GetAllMoviesAsync()
            => _movieRepository.GetAllMoviesAsync();

        public Task<IEnumerable<MovieResponseDto>> GetMovieByFilterAsync(MovieFilterDto filter)
            => _movieRepository.GetMovieByFilterAsync(filter);
    }
}
