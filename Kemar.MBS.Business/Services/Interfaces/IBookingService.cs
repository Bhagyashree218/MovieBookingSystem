using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request);
        Task<BookingResponseDto> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId);
    }
}
