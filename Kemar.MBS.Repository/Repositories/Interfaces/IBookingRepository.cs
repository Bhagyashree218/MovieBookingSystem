using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request);
        Task<BookingResponseDto> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId);
    }
}
