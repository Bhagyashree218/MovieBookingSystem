using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly KemarMBSDbContext _context;

        public MovieRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Movie> SearchMovies(string keyword)
        {
            return _context.Movies
                           .Where(m => m.Title.Contains(keyword) || m.Genre.Contains(keyword))
                           .ToList();
        }
    }
}
