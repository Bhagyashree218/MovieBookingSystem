using AutoMapper;
using Kemar.MBS.Model.Movie.Request;
using Kemar.MBS.Model.Movie.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public MovieRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MovieResponseDto> CreateMovieAsync(MovieCreateRequestDto request)
        {
            var movie = _mapper.Map<Movie>(request);
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return _mapper.Map<MovieResponseDto>(movie);
        }

        public async Task<MovieResponseDto> GetMovieByIdAsync(int movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.MovieId == movieId);
            return _mapper.Map<MovieResponseDto>(movie);
        }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
        }
    }
}
