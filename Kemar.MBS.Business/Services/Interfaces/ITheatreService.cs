using Kemar.MBS.Model.Theatre.Response;
using System.Collections.Generic;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ITheatreService
    {
        IEnumerable<TheatreResponseDto> GetTheatresByCity(int cityId);
    }
}
