using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Seats.Requests;
using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task CreateSeatsAsync(SeatCreateRequestDto request)
        {
            await _seatRepository.CreateSeatsAsync(request);
        }

        public async Task<SeatResponseDto> GetSeatByIdAsync(int seatId)
        {
            return await _seatRepository.GetSeatByIdAsync(seatId);
        }

        public async Task<IEnumerable<SeatResponseDto>> GetSeatsByShowIdAsync(int showId)
        {
            return await _seatRepository.GetSeatsByShowIdAsync(showId);
        }
    }
}
