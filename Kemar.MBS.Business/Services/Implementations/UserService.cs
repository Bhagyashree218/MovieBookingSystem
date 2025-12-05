using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Common;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
using Kemar.MBS.Repository.Repositories.Interfaces;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultModel> RegisterUserAsync(RegisterRequestDto request)
        {
            var existing = await _userRepository.GetUserByEmailAsync(request.UserEmail);
            if (existing != null)
                return ResultModel.Duplicate("Email already exists");

            await _userRepository.RegisterUserAsync(request);
            return ResultModel.Created(null, "Registration successful");
        }

        public async Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request)
        {
            var userEntity = await _userRepository.GetUserForAuthAsync(request.UserEmail);

            if (userEntity == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, userEntity.Password);

            if (!isValid)
                return null;

            return await _userRepository.GetLoginResponseDtoAsync(userEntity.UserId);
        }

        public async Task<UserProfileDto> GetUserProfileAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }
    }
}
