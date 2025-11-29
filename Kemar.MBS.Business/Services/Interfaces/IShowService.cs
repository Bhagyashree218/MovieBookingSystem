using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IShowService
    {
        ShowResponseDto CreateShow(ShowCreateRequestDto request);
        IEnumerable<ShowResponseDto> GetShowsByMovie(int movieId);
        IEnumerable<ShowResponseDto> GetShowsByMovieAndDate(int movieId, DateTime date);
    }
}
