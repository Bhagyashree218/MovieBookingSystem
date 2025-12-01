using Kemar.MBS.Business.Services.Interfaces;
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

        public async Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllCitiesAsync();
        }

        public async Task<CityResponseDto> GetCityByIdAsync(int cityId)
        {
            return await _cityRepository.GetCityByIdAsync(cityId);
        }
    }
}
