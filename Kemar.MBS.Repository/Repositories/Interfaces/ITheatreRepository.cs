using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ITheatreRepository : IRepository<Theatre>
    {
        IEnumerable<Theatre> GetTheatresByCity(int cityId);
    }
}
