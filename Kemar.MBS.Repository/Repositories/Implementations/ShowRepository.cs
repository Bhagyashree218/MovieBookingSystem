using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        private readonly KemarMBSDbContext _context;

        public ShowRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Show> GetShowsByMovie(int movieId)
        {
            return _context.Shows.Where(s => s.MovieId == movieId).ToList();
        }

        public IEnumerable<Show> GetShowsByMovieAndDate(int movieId, DateTime date)
        {
            return _context.Shows
                           .Where(s => s.MovieId == movieId && s.ShowDate.Date == date.Date)
                           .ToList();
        }
    }
}
