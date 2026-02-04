using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
using Kemar.MBS.Repository.Entity;

public interface IUserRepository
{
    Task<User> GetUserForAuthAsync(string email);
    Task RegisterUserAsync(RegisterRequestDto request);
    Task<UserResponseDto> GetUserByEmailAsync(string email);
    Task<UserProfileDto> GetUserByIdAsync(int userId);
    //Task<LoginResponseDto> GetLoginResponseDtoAsync(int userId);
}
