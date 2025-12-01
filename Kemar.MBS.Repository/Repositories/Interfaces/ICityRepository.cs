using Kemar.MBS.Model.City.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<CityResponseDto>> GetAllCitiesAsync();
        Task<CityResponseDto> GetCityByIdAsync(int cityId);
    }
}
