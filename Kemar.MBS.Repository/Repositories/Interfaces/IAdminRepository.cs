using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Admin GetAdminByEmail(string email);
    }
}
