using AutoMapper;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Admin.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;
using BCrypt.Net;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<AdminResponseDto> LoginAdminAsync(AdminLoginRequestDto request)
        {
            var admin = await _adminRepository.GetAdminByEmailAsync(request.AdminEmail);
            if (admin == null) return null;

            bool valid = BCrypt.Net.BCrypt.Verify(request.Password, admin.Password);
            if (!valid) return null;

            return _mapper.Map<AdminResponseDto>(admin);

        }
    }
}
