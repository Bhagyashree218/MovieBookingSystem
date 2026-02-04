using AutoMapper;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly KemarMBSDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(KemarMBSDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task RegisterUserAsync(RegisterRequestDto request)
    {
        var user = _mapper.Map<User>(request);
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    // INTERNAL USE ONLY: For login password verification
    public async Task<User> GetUserForAuthAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.UserEmail == email);
    }

    public async Task<UserResponseDto> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.UserEmail == email);

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserProfileDto> GetUserByIdAsync(int userId)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.UserId == userId);

        return _mapper.Map<UserProfileDto>(user);
    }

    //public async Task<LoginResponseDto> GetLoginResponseDtoAsync(int userId)
    //{
    //    var user = await _context.Users
    //        .FirstOrDefaultAsync(x => x.UserId == userId);

    //    return _mapper.Map<LoginResponseDto>(user);
    //}
}
