using Kemar.MBS.Model.Seat.Response;
using System.Collections.Generic;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface ISeatService
    {
        IEnumerable<SeatResponseDto> GetAvailableSeats(int screenId);
    }
}
