using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Model.Seats.Requests;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ISeatRepository 
    {
        Task AddUpdateAsync(SeatRequestDto request);
        Task<SeatResponseDto> GetSeatByIdAsync(int seatId);
        Task<IEnumerable<SeatResponseDto>> GetSeatsByScreenIdAsync(int screenId);
        Task<IEnumerable<SeatResponseDto>> GetSeatByFilterAsync(SeatFilterDto filter);
    }
}
