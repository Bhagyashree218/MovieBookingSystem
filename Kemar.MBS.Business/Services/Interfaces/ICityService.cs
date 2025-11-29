using Kemar.MBS.Model.City.Response;
using System.Collections.Generic;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ICityService
    {
        IEnumerable<CityResponseDto> GetAllCities();
    }
}
