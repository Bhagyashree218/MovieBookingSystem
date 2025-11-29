using Kemar.MBS.Model.Screen.Response;
using System.Collections.Generic;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IScreenService
    {
        IEnumerable<ScreenResponseDto> GetScreensByTheatre(int theatreId);
    }
}
