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

            if (existingByTitle != null)
                throw new Exception("Movie title already exists.");

            if (request.MovieId > 0)
            {
                var existing = await _context.Movies
                    .FirstOrDefaultAsync(x => x.MovieId == request.MovieId);

                if (existing == null)
                    throw new Exception("Movie not found.");

                existing.Title = request.Title;
                existing.Description = request.Description;
                existing.Category = request.Category;
                existing.Language = request.Language;
                existing.DurationInMinutes = request.DurationInMinutes;
                existing.ReleaseDate = request.ReleaseDate;

                existing.PosterUrl = request.PosterUrl;
                existing.BannerUrl = request.BannerUrl;
                existing.ThumbnailUrl = request.ThumbnailUrl;
                existing.TrailerUrl = request.TrailerUrl;
                existing.GalleryImages = request.GalleryImages;
                existing.CastImages = request.CastImages;

                // Metadata
                existing.Director = request.Director;
                existing.Cast = request.Cast;
                existing.CensorRating = request.CensorRating;
                existing.ImdbRating = request.ImdbRating;
                existing.LikesPercentage = request.LikesPercentage;

                await _context.SaveChangesAsync();
            }
            else
            {
                var movie = _mapper.Map<Movie>(request);
                await _context.Movies.AddAsync(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MovieResponseDto?> GetMovieByIdAsync(int movieId)
        {
            var movie = await _context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MovieId == movieId);

            return _mapper.Map<MovieResponseDto?>(movie);
        }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
        }

        public async Task<IEnumerable<MovieResponseDto>> GetMovieByFilterAsync(MovieFilterDto filter)
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                var title = filter.Title.ToLower();
                query = query.Where(x => x.Title.ToLower().Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(filter.Category))
            {
                var category = filter.Category.ToLower();
                query = query.Where(x => x.Category.ToLower().Contains(category));
            }

            if (!string.IsNullOrWhiteSpace(filter.Language))
            {
                var lang = filter.Language.ToLower();
                query = query.Where(x => x.Language.ToLower().Contains(lang));
            }

            if (!string.IsNullOrWhiteSpace(filter.CensorRating))
            {
                var censor = filter.CensorRating.ToLower();
                query = query.Where(x => x.CensorRating != null &&
                                         x.CensorRating.ToLower().Contains(censor));
            }

            var result = await query
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<MovieResponseDto>>(result);
        }
    }
}
