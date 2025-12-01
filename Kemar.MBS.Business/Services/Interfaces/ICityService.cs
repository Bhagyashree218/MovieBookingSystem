using Kemar.MBS.Model.City.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync();
        Task<CityResponseDto> GetCityByIdAsync(int cityId);
    }
}
