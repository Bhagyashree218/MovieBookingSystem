using AutoMapper;
using Kemar.MBS.Model.Theatre.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class TheatreRepository : GenericRepository<Theatre>, ITheatreRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public TheatreRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TheatreResponseDto>> GetTheatresByCityAsync(int cityId)
        {
            var theatres = await _context.Theatres
                .Where(x => x.CityId == cityId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<TheatreResponseDto>>(theatres);
        }

        public async Task<TheatreResponseDto> GetTheatreByIdAsync(int theatreId)
        {
            var theatre = await _context.Theatres
                .FirstOrDefaultAsync(x => x.TheatreId == theatreId);

            return _mapper.Map<TheatreResponseDto>(theatre);
        }
    }
}
