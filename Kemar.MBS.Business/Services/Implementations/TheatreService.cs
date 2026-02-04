using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Theatre.Request;
using Kemar.MBS.Model.Theatre.Responses;
using Kemar.MBS.Repository.Repositories.Interfaces;

public class TheatreService : ITheatreService
{
    private readonly ITheatreRepository _theatreRepository;

    public TheatreService(ITheatreRepository theatreRepository)
    {
        _theatreRepository = theatreRepository;
    }

    public Task AddUpdateAsync(TheatreRequestDto request)
        => _theatreRepository.AddUpdateAsync(request);

    public Task<TheatreResponseDto> GetTheatreByIdAsync(int theatreId)
        => _theatreRepository.GetTheatreByIdAsync(theatreId);

    public Task<IEnumerable<TheatreResponseDto>> GetTheatreByCityAsync(int cityId)
        => _theatreRepository.GetTheatreByCityAsync(cityId);

    public Task<IEnumerable<TheatreResponseDto>> GetTheatreByFilterAsync(TheatreFilterDto filter)
        => _theatreRepository.GetTheatreByFilterAsync(filter);
}
