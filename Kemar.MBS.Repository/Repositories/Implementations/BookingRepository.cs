using AutoMapper;
using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request)
        {
            var booking = new Booking
            {
                UserId = request.UserId,
                ShowId = request.ShowId,
                BookingTime = DateTime.Now,
                PaymentStatus = "Pending",
                TotalAmount = 0
            };

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookingResponseDto>(booking);
        }

        public async Task<BookingResponseDto> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.BookingSeats)
                .FirstOrDefaultAsync(x => x.BookingId == bookingId);

            return _mapper.Map<BookingResponseDto>(booking);
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId)
        {
            var bookings = await _context.Bookings
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BookingResponseDto>>(bookings);
        }
    }
}
