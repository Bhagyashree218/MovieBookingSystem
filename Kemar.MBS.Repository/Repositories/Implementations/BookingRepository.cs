using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly KemarMBSDbContext _context;

        public BookingRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetBookingsByUser(int userId)
        {
            return _context.Bookings
                           .Where(b => b.UserId == userId)
                           .ToList();
        }

        public IEnumerable<Booking> GetBookingsByShow(int showId)
        {
            return _context.Bookings
                           .Where(b => b.ShowId == showId)
                           .ToList();
        }

        public void CancelBooking(int bookingId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking != null)
            {
                booking.IsActive = false;
                _context.Bookings.Update(booking);
            }
        }
    }
}
