using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.Repository.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task/*<UserResponseDto>*/ RegisterUserAsync(RegisterRequestDto request);
        Task<UserResponseDto> GetUserByEmailAsync(string email);
    }
}
