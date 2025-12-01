using Kemar.MBS.Model.Theatre.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ITheatreService
    {
        Task<IEnumerable<TheatreResponseDto>> GetTheatresByCityAsync(int cityId);
        Task<TheatreResponseDto> GetTheatreByIdAsync(int theatreId);
    }
}
