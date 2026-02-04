using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Model.Seat.Response;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request, int userId)
        => _bookingRepository.CreateBookingAsync(request, userId);


    public Task<BookingResponseDto> GetBookingByIdAsync(int bookingId)
        => _bookingRepository.GetBookingByIdAsync(bookingId);

    public Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId)
        => _bookingRepository.GetBookingsByUserAsync(userId);
    public async Task<IEnumerable<SeatBookedDto>> GetBookedSeatsByShowAsync(int showId)
       => await _bookingRepository.GetBookedSeatsByShowAsync(showId);

}
