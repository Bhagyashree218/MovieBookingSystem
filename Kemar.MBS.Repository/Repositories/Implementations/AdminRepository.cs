using AutoMapper;
using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Admin.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public AdminRepository(KemarMBSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AdminResponseDto> CreateAdminAsync(AdminCreateRequestDto request)
        {
            var admin = _mapper.Map<Admin>(request);
            admin.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();

            return _mapper.Map<AdminResponseDto>(admin);
        }

        public async Task<Admin> GetAdminForAuthAsync(string email)
        {
            return await _context.Admins
                .FirstOrDefaultAsync(x => x.AdminEmail == email);
        }

        public async Task<AdminResponseDto> GetAdminByIdAsync(int adminId)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == adminId);
            return _mapper.Map<AdminResponseDto>(admin);
        }

        public async Task<IEnumerable<AdminResponseDto>> GetAllAdminsAsync()
        {
            var admins = await _context.Admins.ToListAsync();
            return _mapper.Map<IEnumerable<AdminResponseDto>>(admins);
        }


        public async Task<DailySummaryDto> GetDailySummaryAsync(DateTime date)
        {
            var bookings = await _context.Bookings
                .Where(b => b.BookingTime.Date == date.Date)
                .Include(b => b.BookingSeats)
                .ToListAsync();

            return new DailySummaryDto
            {
                Date = date.Date,
                TotalBookings = bookings.Count,
                TicketsSold = bookings.Sum(b => b.BookingSeats.Count),
                TotalRevenue = bookings.Sum(b => b.TotalAmount)
            };
        }

        public async Task<ShowBookingReportDto> GetShowReportAsync(int showId)
        {
            var show = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                    .ThenInclude(sc => sc.Theatre)
                .FirstOrDefaultAsync(x => x.ShowId == showId);

            if (show == null) return null;

            var bookings = await _context.Bookings
                .Where(b => b.ShowId == showId)
                .Include(b => b.BookingSeats)
                .ToListAsync();

            return new ShowBookingReportDto
            {
                ShowId = showId,
                MovieTitle = show.Movie.Title,
                TheatreName = show.Screen.Theatre.TheatreName,
                ScreenName = show.Screen.ScreenName,
                ShowDate = show.ShowDate,
                StartTime = show.StartTime,

                TotalBookings = bookings.Count,
                TicketsSold = bookings.Sum(b => b.BookingSeats.Count),
                TotalRevenue = bookings.Sum(b => b.TotalAmount)
            };
        }

        public async Task<MovieBookingReportDto> GetMovieReportAsync(int movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.MovieId == movieId);
            if (movie == null) return null;

            var shows = await _context.Shows
                .Where(s => s.MovieId == movieId)
                .ToListAsync();

            var showIds = shows.Select(s => s.ShowId).ToList();

            var bookings = await _context.Bookings
                .Where(b => showIds.Contains(b.ShowId))
                .Include(b => b.BookingSeats)
                .ToListAsync();

            return new MovieBookingReportDto
            {
                MovieId = movieId,
                MovieTitle = movie.Title,
                TotalBookings = bookings.Count,
                TicketsSold = bookings.Sum(b => b.BookingSeats.Count),
                TotalRevenue = bookings.Sum(b => b.TotalAmount)
            };
        }
    }
}
