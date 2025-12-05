using Kemar.MBS.Model.Common;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultModel> RegisterUserAsync(RegisterRequestDto request);
        Task<LoginResponseDto> LoginUserAsync(LoginRequestDto request);
        Task<UserProfileDto> GetUserProfileAsync(int userId);
    }
}
