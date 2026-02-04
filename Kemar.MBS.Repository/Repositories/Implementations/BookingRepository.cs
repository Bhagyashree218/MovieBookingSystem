using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly KemarMBSDbContext _context;

        public BookingRepository(KemarMBSDbContext context)
        {
            _context = context;
        }

        public async Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto request, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var show = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                    .ThenInclude(sc => sc.Theatre)
                        .ThenInclude(t => t.City)
                .FirstOrDefaultAsync(x => x.ShowId == request.ShowId);

            if (show == null)
                throw new InvalidOperationException("Show not found.");

            var seats = await _context.Seats
                .Where(x => request.SeatIds.Contains(x.SeatId))
                .ToListAsync();

            if (seats.Count != request.SeatIds.Count)
                throw new InvalidOperationException("One or more seats not found.");

            if (seats.Any(x => x.ScreenId != show.ScreenId))
                throw new InvalidOperationException("Seat does not belong to show screen.");

            if (seats.Any(x => !x.IsAvailable))
                throw new InvalidOperationException("One or more seats already booked.");

            decimal totalAmount = 0;

            foreach (var seat in seats)
            {
                var category = seat.SeatCategory?.Trim().ToLower();
                var seatPrice = show.Price;

                switch (category)
                {
                    case "premium":
                        seatPrice += 100;
                        break;

                    case "vip":
                        seatPrice += 200;
                        break;

                    // normal / silver / null → base price
                    default:
                        break;
                }

                totalAmount += seatPrice;
            }


            var booking = new Booking
            {
                UserId = userId, // ✅ ONLY SOURCE
                ShowId = request.ShowId,
                BookingTime = DateTime.Now,
                //TotalAmount = seats.Sum(s => s.Price),
                TotalAmount = totalAmount,
                PaymentStatus = "Confirmed",
                BookingSeats = seats.Select(s => new BookingSeat
                {
                    SeatId = s.SeatId
                }).ToList()
            };

            _context.Bookings.Add(booking);

            //seats.ForEach(s => s.IsAvailable = false);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return await GetBookingByIdAsync(booking.BookingId);
        }


        public async Task<BookingResponseDto> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Show)
                    .ThenInclude(s => s.Movie)
                .Include(b => b.Show)
                    .ThenInclude(s => s.Screen)
                        .ThenInclude(sc => sc.Theatre)
                            .ThenInclude(t => t.City)
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .FirstOrDefaultAsync(x => x.BookingId == bookingId);

            if (booking == null)
                return null;

            return new BookingResponseDto
            {
                BookingId = booking.BookingId,
                UserName = booking.User.UserName,
                TheatreName = booking.Show.Screen.Theatre.TheatreName,
                ScreenName = booking.Show.Screen.ScreenName,
                MovieTitle = booking.Show.Movie.Title,
                ShowDate = booking.Show.ShowDate,
                StartTime = booking.Show.StartTime,
                Seats = booking.BookingSeats.Select(x => x.Seat.SeatNumber).ToList(),
                TotalAmount = booking.TotalAmount,
                PaymentStatus = booking.PaymentStatus,
                BookingTime = booking.BookingTime,
                CityName = booking.Show.Screen.Theatre.City.CityName
            };
        }

        public async Task<IEnumerable<BookingResponseDto>> GetBookingsByUserAsync(int userId)
        {
            var bookings = await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Show)
                    .ThenInclude(s => s.Movie)
                .Include(b => b.Show)
                    .ThenInclude(s => s.Screen)
                        .ThenInclude(sc => sc.Theatre)
                            .ThenInclude(t => t.City)
                .Include(b => b.BookingSeats)
                    .ThenInclude(bs => bs.Seat)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return bookings.Select(booking => new BookingResponseDto
            {
                BookingId = booking.BookingId,
                UserName = booking.User.UserName,
                TheatreName = booking.Show.Screen.Theatre.TheatreName,
                ScreenName = booking.Show.Screen.ScreenName,
                MovieTitle = booking.Show.Movie.Title,
                ShowDate = booking.Show.ShowDate,
                StartTime = booking.Show.StartTime,
                Seats = booking.BookingSeats.Select(x => x.Seat.SeatNumber).ToList(),
                TotalAmount = booking.TotalAmount,
                PaymentStatus = booking.PaymentStatus,
                BookingTime = booking.BookingTime,
                CityName = booking.Show.Screen.Theatre.City.CityName
            });
        }

        public async Task<IEnumerable<SeatBookedDto>> GetBookedSeatsByShowAsync(int showId)
        {
            var bookedSeats = await _context.BookingSeats
                .Include(bs => bs.Seat)
                .Include(bs => bs.Booking)
                .Where(bs => bs.Booking.ShowId == showId)
                .Select(bs => new SeatBookedDto
                {
                    SeatId = bs.SeatId,
                    SeatNumber = bs.Seat.SeatNumber
                })
                .ToListAsync();

            return bookedSeats;
        }
    }
}
