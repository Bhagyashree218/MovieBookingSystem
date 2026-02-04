using AutoMapper;
using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Model.Seats.Requests;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class SeatRepository : ISeatRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public SeatRepository(KemarMBSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddUpdateAsync(SeatRequestDto request)
        {
            foreach (var item in request.Seats)
            {
                var existing = await _context.Seats
                    .FirstOrDefaultAsync(x =>
                        x.ScreenId == request.ScreenId &&
                        x.SeatNumber.ToLower() == item.SeatNumber.ToLower());

                if (existing != null)
                {
                    existing.RowNumber = item.Row;
                    existing.SeatCategory = item.SeatCategory;
                    existing.Price = item.Price;
                }
                else
                {
                    var seat = new Seat
                    {
                        ScreenId = request.ScreenId,
                        SeatNumber = item.SeatNumber,
                        RowNumber = item.Row,
                        SeatCategory = item.SeatCategory,
                        Price = item.Price,
                        IsAvailable = true
                    };

                    await _context.Seats.AddAsync(seat);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<SeatResponseDto> GetSeatByIdAsync(int seatId)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(x => x.SeatId == seatId);
            return _mapper.Map<SeatResponseDto>(seat);
        }

        public async Task<IEnumerable<SeatResponseDto>> GetSeatsByScreenIdAsync(int screenId)
        {
            var seats = await _context.Seats
                .Where(x => x.ScreenId == screenId)
                .OrderBy(x => x.RowNumber)
                .ThenBy(x => x.SeatNumber)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SeatResponseDto>>(seats);
        }

        public async Task<IEnumerable<SeatResponseDto>> GetSeatByFilterAsync(SeatFilterDto filter)
        {
            var query = _context.Seats.AsQueryable();

            if (filter.ScreenId.HasValue)
                query = query.Where(x => x.ScreenId == filter.ScreenId.Value);

            if (!string.IsNullOrEmpty(filter.SeatCategory))
                query = query.Where(x => x.SeatCategory == filter.SeatCategory);

            if (filter.IsAvailable.HasValue)
                query = query.Where(x => x.IsAvailable == filter.IsAvailable.Value);

            var result = await query
                .OrderBy(x => x.RowNumber)
                .ThenBy(x => x.SeatNumber)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SeatResponseDto>>(result);
        }
    }
}
