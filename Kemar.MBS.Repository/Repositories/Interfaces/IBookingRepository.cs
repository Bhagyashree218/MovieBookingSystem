using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetBookingsByUser(int userId);
        IEnumerable<Booking> GetBookingsByShow(int showId);
        void CancelBooking(int bookingId);
    }
}
