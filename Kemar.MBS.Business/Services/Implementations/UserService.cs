using Kemar.MBS.Business.Helpers;
using Kemar.MBS.Business.Services.Interfaces;
using Kemar.MBS.Model.Auth.Response;
using Kemar.MBS.Model.Common;
using Kemar.MBS.Model.User.Request;
using System.IdentityModel.Tokens.Jwt;

namespace Kemar.MBS.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtToken _jwtToken;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, JwtToken jwtToken, IAuthService authService)
        {
            _userRepository = userRepository;
            _jwtToken = jwtToken;
            _authService = authService;
        }

        public async Task<ResultModel> RegisterUserAsync(RegisterRequestDto request)
        {
            var existing = await _userRepository.GetUserByEmailAsync(request.UserEmail);
            if (existing != null)
                return ResultModel.Duplicate("Email already exists");

            await _userRepository.RegisterUserAsync(request);
            return ResultModel.Created(null, "Registration successful");
        }

        public async Task<ResultModel> LoginUserAsync(LoginRequestDto request)
        {
            var userEntity = await _userRepository.GetUserForAuthAsync(request.UserEmail);

            if (userEntity == null)
                return ResultModel.Unauthorized("Invalid credentials");

            bool valid = BCrypt.Net.BCrypt.Verify(request.Password, userEntity.Password);
            if (!valid)
                return ResultModel.Unauthorized("Invalid credentials");

            // 1️⃣ Generate Access Token (JWT)
            string accessToken = _jwtToken.GenerateToken(
                userEntity.UserId,
                userEntity.UserEmail,
                "User"
            );

            // 2️⃣ Extract JTI from JWT
            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenObj = jwtHandler.ReadJwtToken(accessToken);
            var jti = tokenObj.Id;

            // 3️⃣ Generate Refresh Token & Save it
            var refreshToken = await _authService.GenerateRefreshTokenAsync(
                userEntity.UserId,  // userId
                null,               // adminId
                jti
            );

            // 4️⃣ Build response
            var response = new AuthResponseDto
            {
                Id = userEntity.UserId,
                Name = userEntity.UserName,
                Email = userEntity.UserEmail,
                Role = "User",
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };

            return ResultModel.Success(response, "Login successful");
        }


        public async Task<ResultModel> GetUserProfileAsync(int userId)
        {
            var profile = await _userRepository.GetUserByIdAsync(userId);
            if (profile == null)
                return ResultModel.NotFound("User not found");

            return ResultModel.Success(profile);
        }
    }
}
