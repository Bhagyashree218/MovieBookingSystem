using Kemar.MBS.Model.Seats.Requests;
using Kemar.MBS.Model.Seat.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ISeatService
    {
        Task CreateSeatsAsync(SeatCreateRequestDto request);
        Task<SeatResponseDto> GetSeatByIdAsync(int seatId);
        Task<IEnumerable<SeatResponseDto>> GetSeatsByShowIdAsync(int showId);
    }
}
