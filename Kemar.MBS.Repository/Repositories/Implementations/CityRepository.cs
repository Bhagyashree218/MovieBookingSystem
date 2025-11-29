using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly KemarMBSDbContext _context;

        public CityRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }
    }
}
