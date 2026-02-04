using AutoMapper;
using Kemar.MBS.Model.Theatre.Request;
using Kemar.MBS.Model.Theatre.Responses;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;

public class TheatreRepository : ITheatreRepository
{
    private readonly KemarMBSDbContext _context;
    private readonly IMapper _mapper;

    public TheatreRepository(KemarMBSDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddUpdateAsync(TheatreRequestDto request)
    {
        var cleanedName = request.TheatreName.Trim().ToLower();

        var existingByName = await _context.Theatres
            .FirstOrDefaultAsync(x =>
                x.TheatreName.Trim().ToLower() == cleanedName &&
                x.CityId == request.CityId);

        if (request.TheatreId > 0)
        {
            var existing = await _context.Theatres
                .FirstOrDefaultAsync(x => x.TheatreId == request.TheatreId);

            if (existing == null)
                throw new Exception("Theatre not found.");

            if (existingByName != null && existingByName.TheatreId != request.TheatreId)
                throw new Exception("Theatre name already exists in this city.");

            existing.TheatreName = request.TheatreName.Trim();
            existing.Address = request.Address?.Trim();

            await _context.SaveChangesAsync();
        }
        else
        {
            if (existingByName != null)
                throw new Exception("Theatre name already exists in this city.");

            var theatre = new Theatre
            {
                CityId = request.CityId,
                TheatreName = request.TheatreName.Trim(),
                Address = request.Address?.Trim()
            };

            await _context.Theatres.AddAsync(theatre);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<TheatreResponseDto> GetTheatreByIdAsync(int theatreId)
    {
        var theatre = await _context.Theatres
            .FirstOrDefaultAsync(x => x.TheatreId == theatreId);

        return _mapper.Map<TheatreResponseDto>(theatre);
    }

    public async Task<IEnumerable<TheatreResponseDto>> GetTheatreByCityAsync(int cityId)
    {
        var theatres = await _context.Theatres
            .Where(x => x.CityId == cityId)
            .OrderBy(x => x.TheatreName) // sorted for UI
            .ToListAsync();

        return _mapper.Map<IEnumerable<TheatreResponseDto>>(theatres);
    }

    public async Task<IEnumerable<TheatreResponseDto>> GetTheatreByFilterAsync(TheatreFilterDto filter)
    {
        var query = _context.Theatres.AsQueryable();

        if (filter.CityId.HasValue)
            query = query.Where(x => x.CityId == filter.CityId.Value);

        if (!string.IsNullOrEmpty(filter.TheatreName))
        {
            var cleanedFilter = filter.TheatreName.Trim().ToLower();
            query = query.Where(x => x.TheatreName.ToLower().Contains(cleanedFilter));
        }

        var result = await query
            .OrderBy(x => x.TheatreName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<TheatreResponseDto>>(result);
    }
}
