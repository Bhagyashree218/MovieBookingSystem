using Kemar.MBS.Model.Seats.Requests;
using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task CreateSeatsAsync(SeatCreateRequestDto request);
        Task<SeatResponseDto> GetSeatByIdAsync(int seatId);
        Task<IEnumerable<SeatResponseDto>> GetSeatsByShowIdAsync(int showId);
    }
}
