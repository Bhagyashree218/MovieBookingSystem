using Kemar.MBS.Model.City.Request;
using Kemar.MBS.Model.City.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync();
        Task AddUpdateCityAsync(CityRequestDto request);
        Task<CityResponseDto> GetCityByIdAsync(int cityId);
        Task<IEnumerable<CityResponseDto>> GetCityByFilterAsync(CityFilterDto filter);
    }
}
