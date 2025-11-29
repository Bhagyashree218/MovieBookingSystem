using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class TheatreRepository : GenericRepository<Theatre>, ITheatreRepository
    {
        private readonly KemarMBSDbContext _context;

        public TheatreRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Theatre> GetTheatresByCity(int cityId)
        {
            return _context.Theatres
                           .Where(t => t.CityId == cityId)
                           .ToList();
        }
    }
}
