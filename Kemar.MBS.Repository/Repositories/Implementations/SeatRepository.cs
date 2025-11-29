using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly KemarMBSDbContext _context;

        public SeatRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Seat> GetAvailableSeats(int screenId)
        {
            return _context.Seats
                           .Where(s => s.ScreenId == screenId && s.IsAvailable == true)
                           .ToList();
        }
    }
}
