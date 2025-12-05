using AutoMapper;
using Kemar.MBS.Model.Screen.Request;
using Kemar.MBS.Model.Screen.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;

public class ScreenRepository : IScreenRepository
{
    private readonly KemarMBSDbContext _context;
    private readonly IMapper _mapper;

    public ScreenRepository(KemarMBSDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddUpdateAsync(ScreenRequestDto request)
    {
        var cleanedName = request.ScreenName.Trim().ToLower();

        var existingByName = await _context.Screens
            .FirstOrDefaultAsync(x =>
                x.ScreenName.Trim().ToLower() == cleanedName &&
                x.TheatreId == request.TheatreId);

        if (request.ScreenId > 0)
        {
            var existing = await _context.Screens
                .FirstOrDefaultAsync(x => x.ScreenId == request.ScreenId);

            if (existing == null)
                throw new Exception("Screen not found.");

            if (existingByName != null && existingByName.ScreenId != request.ScreenId)
                throw new Exception("Screen name already exists in this theatre.");

            existing.ScreenName = request.ScreenName.Trim();

            await _context.SaveChangesAsync();
        }
        else
        {
            if (existingByName != null)
                throw new Exception("Screen name already exists in this theatre.");

            var screen = new Screen
            {
                TheatreId = request.TheatreId,
                ScreenName = request.ScreenName.Trim()
            };

            await _context.Screens.AddAsync(screen);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ScreenResponseDto> GetScreenByIdAsync(int screenId)
    {
        var screen = await _context.Screens
            .FirstOrDefaultAsync(x => x.ScreenId == screenId);

        return _mapper.Map<ScreenResponseDto>(screen);
    }

    public async Task<IEnumerable<ScreenResponseDto>> GetScreensByTheatreAsync(int theatreId)
    {
        var screens = await _context.Screens
            .Where(x => x.TheatreId == theatreId)
            .OrderBy(x => x.ScreenName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ScreenResponseDto>>(screens);
    }

    public async Task<IEnumerable<ScreenResponseDto>> GetScreenByFilterAsync(ScreenFilterDto filter)
    {
        var query = _context.Screens.AsQueryable();

        if (filter.TheatreId.HasValue)
            query = query.Where(x => x.TheatreId == filter.TheatreId);

        if (!string.IsNullOrEmpty(filter.ScreenName))
        {
            var cleanedFilter = filter.ScreenName.Trim().ToLower();
            query = query.Where(x => x.ScreenName.ToLower().Contains(cleanedFilter));
        }

        var result = await query
            .OrderBy(x => x.ScreenName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ScreenResponseDto>>(result);
    }
}
