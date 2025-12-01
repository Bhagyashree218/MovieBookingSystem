using AutoMapper;
using Kemar.MBS.Model.Seats.Requests;
using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public SeatRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateSeatsAsync(SeatCreateRequestDto request)
        {
            foreach (var item in request.Seats)
            {
                var seat = new Seat
                {
                    ScreenId = request.ShowId,
                    SeatNumber = item.SeatNumber,
                    RowNumber = item.Row,
                    SeatType = item.SeatType,
                    IsAvailable = true
                };

                await _context.Seats.AddAsync(seat);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<SeatResponseDto> GetSeatByIdAsync(int seatId)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(x => x.SeatId == seatId);
            return _mapper.Map<SeatResponseDto>(seat);
        }

        public async Task<IEnumerable<SeatResponseDto>> GetSeatsByShowIdAsync(int showId)
        {
            var seats = await _context.Seats
                .Where(x => x.ScreenId == showId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SeatResponseDto>>(seats);
        }
    }
}
