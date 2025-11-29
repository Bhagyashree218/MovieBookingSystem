using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly KemarMBSDbContext _context;

        public AdminRepository(KemarMBSDbContext context) : base(context)
        {
            _context = context;
        }

        public Admin GetAdminByEmail(string email)
        {
            return _context.Admins.FirstOrDefault(x => x.AdminEmail == email);
        }
    }
}
