using Kemar.MBS.Model.City.Request;
using Kemar.MBS.Model.City.Response;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync();
        Task AddUpdateCityAsync(CityRequestDto request);
        Task<CityResponseDto> GetCityByIdAsync(int cityId);
        Task<IEnumerable<CityResponseDto>> GetCityByFilterAsync(CityFilterDto filter);
    }
}
