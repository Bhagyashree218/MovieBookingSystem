using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetAllCities();
    }
}
