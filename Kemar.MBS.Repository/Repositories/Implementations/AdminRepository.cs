using AutoMapper;
using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Admin.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public AdminRepository(KemarMBSDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AdminResponseDto> CreateAdminAsync(AdminLoginRequestDto request)
        {
            var admin = _mapper.Map<Admin>(request);
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();

            return _mapper.Map<AdminResponseDto>(admin);
        }

        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            return await _context.Admins.FirstOrDefaultAsync(x => x.AdminEmail == email);
        }


        public async Task<AdminResponseDto> GetAdminByIdAsync(int adminId)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == adminId);
            return _mapper.Map<AdminResponseDto>(admin);
        }

        public async Task<IEnumerable<AdminResponseDto>> GetAllAdminsAsync()
        {
            var admins = await _context.Admins.ToListAsync();
            return _mapper.Map<IEnumerable<AdminResponseDto>>(admins);
        }
    }
}
