using AutoMapper;
using Kemar.MBS.Model.City.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync()
        {
            var cities = await _context.Cities.ToListAsync();
            return _mapper.Map<IEnumerable<CityResponseDto>>(cities);
        }

        public async Task<CityResponseDto> GetCityByIdAsync(int cityId)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.CityId == cityId);
            return _mapper.Map<CityResponseDto>(city);
        }
    }
}
