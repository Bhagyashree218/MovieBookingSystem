using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.City.Request;
using Kemar.MBS.Model.City.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync()
            => _cityRepository.GetAllCitiesAsync();

        public Task AddUpdateCityAsync(CityRequestDto request)
            => _cityRepository.AddUpdateCityAsync(request);

        public Task<CityResponseDto> GetCityByIdAsync(int cityId)
            => _cityRepository.GetCityByIdAsync(cityId);

        public Task<IEnumerable<CityResponseDto>> GetCityByFilterAsync(CityFilterDto filter)
            => _cityRepository.GetCityByFilterAsync(filter);
    }
}
