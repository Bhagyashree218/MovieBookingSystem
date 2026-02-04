using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Model.Seat.Response;

public interface IBookingRepository
{
    Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request, int userId);
    Task<BookingResponseDto> GetBookingByIdAsync(int bookingId);//User-to view a single ticket
                                                                //Admin-to see booking details
    Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId);//user-Mybookings/History 
    Task<IEnumerable<SeatBookedDto>> GetBookedSeatsByShowAsync(int showId);
}
