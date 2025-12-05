using AutoMapper;
using Kemar.MBS.Model.Movie.Request;
using Kemar.MBS.Model.Movie.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class MovieRepository : IMovieRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public MovieRepository(KemarMBSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddUpdateAsync(MovieRequestDto request)
        {
            var existingByTitle = await _context.Movies
                .FirstOrDefaultAsync(x =>
                    x.Title.ToLower() == request.Title.ToLower()
                    && x.MovieId != request.MovieId);   

            if (request.MovieId > 0)
            {
                var existing = await _context.Movies.FirstOrDefaultAsync(x => x.MovieId == request.MovieId);
                if (existing == null) return;

                if (existingByTitle != null)
                    throw new Exception("Movie title already exists.");

                existing.Title = request.Title;
                existing.Description = request.Description;
                existing.Genre = request.Genre;
                existing.Language = request.Language;
                existing.DurationInMinutes = request.DurationInMinutes;
                existing.PosterUrl = request.PosterUrl;
                existing.ReleaseDate = request.ReleaseDate;

                await _context.SaveChangesAsync();
            }
            else
            {
                if (existingByTitle != null)
                    throw new Exception("Movie title already exists.");

                var movie = _mapper.Map<Movie>(request);

                await _context.Movies.AddAsync(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MovieResponseDto> GetMovieByIdAsync(int movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.MovieId == movieId);
            return _mapper.Map<MovieResponseDto>(movie);  // safe even if null
        }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
        }

        public async Task<IEnumerable<MovieResponseDto>> GetMovieByFilterAsync(MovieFilterDto filter)
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Genre))
                query = query.Where(x => x.Genre.ToLower().Contains(filter.Genre.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Language))
                query = query.Where(x => x.Language.ToLower().Contains(filter.Language.ToLower()));

            var result = await query.ToListAsync();
            return _mapper.Map<IEnumerable<MovieResponseDto>>(result);
        }
    }
}
