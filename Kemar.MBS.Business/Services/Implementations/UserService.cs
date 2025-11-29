using AutoMapper;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterUserAsync(RegisterRequestDto request)
        {
            await _userRepository.RegisterUserAsync(request);
            return "Registration successful";  
        }

        public async Task<UserResponseDto> LoginUserAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.UserEmail);

            if (user == null || user.Password != request.Password)
                return null;

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
