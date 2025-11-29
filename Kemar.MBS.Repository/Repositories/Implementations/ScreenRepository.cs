using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class ScreenRepository : GenericRepository<Screen>, IScreenRepository
    {
        private readonly KemarMBSDbContext _context;

        public ScreenRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Screen> GetScreensByTheatre(int theatreId)
        {
            return _context.Screens
                           .Where(s => s.TheatreId == theatreId)
                           .ToList();
        }
    }
}
