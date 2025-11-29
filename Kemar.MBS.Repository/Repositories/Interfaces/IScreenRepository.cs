using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IScreenRepository : IRepository<Screen>
    {
        IEnumerable<Screen> GetScreensByTheatre(int theatreId);
    }
}
