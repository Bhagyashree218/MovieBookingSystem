using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IBookingService
    {
        BookingResponseDto CreateBooking(BookingRequestDto request);
        IEnumerable<BookingResponseDto> GetBookingsByUser(int userId);
        IEnumerable<BookingResponseDto> GetBookingsByShow(int showId);
        bool CancelBooking(int bookingId);
    }
}
