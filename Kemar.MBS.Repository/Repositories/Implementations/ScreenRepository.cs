using AutoMapper;
using Kemar.MBS.Model.Screen.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class ScreenRepository : GenericRepository<Screen>, IScreenRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public ScreenRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScreenResponseDto>> GetScreensByTheatreAsync(int theatreId)
        {
            var screens = await _context.Screens
                .Where(x => x.TheatreId == theatreId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ScreenResponseDto>>(screens);
        }

        public async Task<ScreenResponseDto> GetScreenByIdAsync(int screenId)
        {
            var screen = await _context.Screens
                .FirstOrDefaultAsync(x => x.ScreenId == screenId);

            return _mapper.Map<ScreenResponseDto>(screen);
        }
    }
}
