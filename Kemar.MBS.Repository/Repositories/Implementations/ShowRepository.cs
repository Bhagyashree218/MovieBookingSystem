using AutoMapper;
using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;

public class ShowRepository : IShowRepository
{
    private readonly KemarMBSDbContext _context;
    private readonly IMapper _mapper;

    public ShowRepository(KemarMBSDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddUpdateAsync(ShowRequestDto request)
    {
        var duplicate = await _context.Shows
            .FirstOrDefaultAsync(x =>
                x.MovieId == request.MovieId &&
                x.ScreenId == request.ScreenId &&
                x.ShowDate == request.ShowDate &&
                x.StartTime == request.StartTime &&
                x.ShowId != request.ShowId);

        if (duplicate != null)
            throw new Exception("Show already exists for this Movie, Screen, Date and Time.");

        if (request.ShowId > 0)
        {
            var existing = await _context.Shows
                .FirstOrDefaultAsync(x => x.ShowId == request.ShowId);

            if (existing == null) return;

            existing.MovieId = request.MovieId;
            existing.ScreenId = request.ScreenId;
            existing.ShowDate = request.ShowDate;
            existing.StartTime = request.StartTime;
            existing.Price = request.Price;

            await _context.SaveChangesAsync();
        }
        else
        {
            var show = _mapper.Map<Show>(request);
            await _context.Shows.AddAsync(show);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ShowResponseDto> GetShowByIdAsync(int showId)
    {
        var show = await _context.Shows
            .Include(s => s.Movie)
            .Include(s => s.Screen)
                .ThenInclude(sc => sc.Theatre)
                    .ThenInclude(t => t.City)   // ✅ ADD
            .FirstOrDefaultAsync(x => x.ShowId == showId);

        return _mapper.Map<ShowResponseDto>(show);
    }

    public async Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync()
    {
        var shows = await _context.Shows
            .Include(s => s.Movie)
            .Include(s => s.Screen)
                .ThenInclude(sc => sc.Theatre)
                    .ThenInclude(t => t.City)   // ✅ ADD
            .OrderBy(s => s.ShowDate)
            .ThenBy(s => s.StartTime)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ShowResponseDto>>(shows);
    }

    public async Task<IEnumerable<ShowResponseDto>> GetShowByFilterAsync(ShowFilterDto filter)
    {
        var query = _context.Shows
            .Include(s => s.Movie)
            .Include(s => s.Screen)
                .ThenInclude(sc => sc.Theatre)
                    .ThenInclude(t => t.City)   // ✅ ADD
            .AsQueryable();

        if (filter.MovieId.HasValue)
            query = query.Where(x => x.MovieId == filter.MovieId.Value);

        if (filter.ScreenId.HasValue)
            query = query.Where(x => x.ScreenId == filter.ScreenId.Value);

        if (filter.ShowDate.HasValue)
            query = query.Where(x => x.ShowDate == filter.ShowDate.Value);

        var result = await query
            .OrderBy(s => s.ShowDate)
            .ThenBy(s => s.StartTime)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ShowResponseDto>>(result);
    }
}
