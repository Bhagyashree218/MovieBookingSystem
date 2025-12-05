using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Model.Seats.Requests;
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

        public Task AddUpdateAsync(SeatRequestDto request)
            => _seatRepository.AddUpdateAsync(request);

        public Task<SeatResponseDto> GetSeatByIdAsync(int seatId)
            => _seatRepository.GetSeatByIdAsync(seatId);

        public Task<IEnumerable<SeatResponseDto>> GetSeatsByScreenIdAsync(int screenId)
            => _seatRepository.GetSeatsByScreenIdAsync(screenId);

        public Task<IEnumerable<SeatResponseDto>> GetSeatByFilterAsync(SeatFilterDto filter)
            => _seatRepository.GetSeatByFilterAsync(filter);
    }
}
