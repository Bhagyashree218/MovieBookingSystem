using Kemar.MBS.Model.Common;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;

namespace Kemar.MBS.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultModel> RegisterUserAsync(RegisterRequestDto request);
        Task<ResultModel> LoginUserAsync(LoginRequestDto request);
        Task<ResultModel> GetUserProfileAsync(int userId);
    }

}
