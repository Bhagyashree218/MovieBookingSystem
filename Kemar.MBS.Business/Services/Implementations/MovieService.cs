using AutoMapper;
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

        public async Task CreateMovieAsync(MovieCreateRequestDto request)
        {
            await _movieRepository.CreateMovieAsync(request);
        }

        //public async Task UpdateMovieAsync(MovieUpdateRequestDto request)
        //{
        //    await _movieRepository.UpdateMovieAsync(request);
        //}

        public async Task<MovieResponseDto> GetMovieByIdAsync(int movieId)
        {
            return await _movieRepository.GetMovieByIdAsync(movieId);
        }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }
    }
}
