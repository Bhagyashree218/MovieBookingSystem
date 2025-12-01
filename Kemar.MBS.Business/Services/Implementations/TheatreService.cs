using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Theatre.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class TheatreService : ITheatreService
    {
        private readonly ITheatreRepository _theatreRepository;

        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }

        public async Task<IEnumerable<TheatreResponseDto>> GetTheatresByCityAsync(int cityId)
        {
            return await _theatreRepository.GetTheatresByCityAsync(cityId);
        }

        public async Task<TheatreResponseDto> GetTheatreByIdAsync(int theatreId)
        {
            return await _theatreRepository.GetTheatreByIdAsync(theatreId);
        }
    }
}
