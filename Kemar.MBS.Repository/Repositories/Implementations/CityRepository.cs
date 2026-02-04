using AutoMapper;
using Kemar.MBS.Model.City.Request;
using Kemar.MBS.Model.City.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class CityRepository : ICityRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(KemarMBSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync()
        {
            var cities = await _context.Cities
                .Where(x => x.IsActive)           // Soft delete filter
                .OrderBy(x => x.CityName)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CityResponseDto>>(cities);
        }

        public async Task AddUpdateCityAsync(CityRequestDto request)
        {
            var existingByName = await _context.Cities
                .FirstOrDefaultAsync(x => x.CityName.ToLower() == request.CityName.ToLower());

            // Update
            if (request.CityId > 0)
            {
                var existing = await _context.Cities
                    .FirstOrDefaultAsync(x => x.CityId == request.CityId);

                if (existing == null)
                    throw new Exception("City not found.");

                if (existingByName != null && existingByName.CityId != request.CityId)
                    throw new Exception("City name already exists.");

                existing.CityName = request.CityName;
                existing.IsActive = request.IsActive;   // Soft delete handled here

                await _context.SaveChangesAsync();
                return;
            }

            if (existingByName != null)
                throw new Exception("City name already exists.");

            var city = new City
            {
                CityName = request.CityName,
                IsActive = request.IsActive
            };

            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task<CityResponseDto> GetCityByIdAsync(int cityId)
        {
            var city = await _context.Cities
                .FirstOrDefaultAsync(x => x.CityId == cityId && x.IsActive);

            return _mapper.Map<CityResponseDto>(city);
        }

        public async Task<IEnumerable<CityResponseDto>> GetCityByFilterAsync(CityFilterDto filter)
        {
            var query = _context.Cities
                .Where(x => x.IsActive)               // only active cities
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.CityName))
            {
                query = query.Where(x =>
                    x.CityName.ToLower().Contains(filter.CityName.ToLower())
                );
            }

            var result = await query.ToListAsync();
            return _mapper.Map<IEnumerable<CityResponseDto>>(result);
        }
    }
}
