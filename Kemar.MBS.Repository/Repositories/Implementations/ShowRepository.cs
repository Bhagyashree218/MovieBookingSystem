using AutoMapper;
using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public ShowRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateShowAsync(ShowCreateRequestDto request)
        {
            var show = _mapper.Map<Show>(request);
            await _context.Shows.AddAsync(show);
            await _context.SaveChangesAsync();
        }

        public async Task<ShowResponseDto> GetShowByIdAsync(int showId)
        {
            var show = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                .FirstOrDefaultAsync(x => x.ShowId == showId);

            return _mapper.Map<ShowResponseDto>(show);
        }

        public async Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync()
        {
            var shows = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ShowResponseDto>>(shows);
        }
    }
}
