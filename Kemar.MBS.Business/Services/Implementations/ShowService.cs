using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public async Task CreateShowAsync(ShowCreateRequestDto request)
        {
            await _showRepository.CreateShowAsync(request);
        }

        public async Task<ShowResponseDto> GetShowByIdAsync(int showId)
        {
            return await _showRepository.GetShowByIdAsync(showId);
        }

        public async Task<IEnumerable<ShowResponseDto>> GetAllShowsAsync()
        {
            return await _showRepository.GetAllShowsAsync();
        }
    }
}
