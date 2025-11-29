using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IShowRepository : IRepository<Show>
    {
        IEnumerable<Show> GetShowsByMovie(int movieId);
        IEnumerable<Show> GetShowsByMovieAndDate(int movieId, DateTime date);
    }
}
