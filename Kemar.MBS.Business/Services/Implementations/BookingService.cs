using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request)
        {
            return await _bookingRepository.CreateBookingAsync(request);
        }

        public async Task<BookingResponseDto> GetBookingByIdAsync(int bookingId)
        {
            return await _bookingRepository.GetBookingByIdAsync(bookingId);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId)
        {
            return await _bookingRepository.GetBookingsByUserAsync(userId);
        }
    }
}
