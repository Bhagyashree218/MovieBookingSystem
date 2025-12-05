using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Model.Seats.Requests;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ISeatService
    {
        Task AddUpdateAsync(SeatRequestDto request);
        Task<SeatResponseDto> GetSeatByIdAsync(int seatId);
        Task<IEnumerable<SeatResponseDto>> GetSeatsByScreenIdAsync(int screenId);
        Task<IEnumerable<SeatResponseDto>> GetSeatByFilterAsync(SeatFilterDto filter);
    }
}
