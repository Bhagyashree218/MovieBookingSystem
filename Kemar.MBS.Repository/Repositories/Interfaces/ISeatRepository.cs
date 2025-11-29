using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        IEnumerable<Seat> GetAvailableSeats(int screenId);
    }
}
