using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Screen.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<IEnumerable<ScreenResponseDto>> GetScreensByTheatreAsync(int theatreId)
        {
            return await _screenRepository.GetScreensByTheatreAsync(theatreId);
        }

        public async Task<ScreenResponseDto> GetScreenByIdAsync(int screenId)
        {
            return await _screenRepository.GetScreenByIdAsync(screenId);
        }
    }
}
