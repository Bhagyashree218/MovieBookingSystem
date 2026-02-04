using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Model.Seat.Response;

public interface IBookingService
{
    Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request, int userId);
    Task<BookingResponseDto> GetBookingByIdAsync(int bookingId);
    Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId);
    Task<IEnumerable<SeatBookedDto>> GetBookedSeatsByShowAsync(int showId);

}
