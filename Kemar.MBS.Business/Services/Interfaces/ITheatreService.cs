using Kemar.MBS.Model.Theatre.Request;
using Kemar.MBS.Model.Theatre.Responses;

public interface ITheatreService
{
    Task AddUpdateAsync(TheatreRequestDto request);
    Task<TheatreResponseDto> GetTheatreByIdAsync(int theatreId);
    Task<IEnumerable<TheatreResponseDto>> GetTheatreByCityAsync(int cityId);
    Task<IEnumerable<TheatreResponseDto>> GetTheatreByFilterAsync(TheatreFilterDto filter);
}
