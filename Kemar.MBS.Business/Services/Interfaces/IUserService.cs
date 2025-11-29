using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterUserAsync(RegisterRequestDto request);
        Task<UserResponseDto> LoginUserAsync(LoginRequestDto request);
    }
}
