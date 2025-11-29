using AutoMapper;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
using Kemar.MBS.Repository.Context;
using Kemar.MBS.Repository.Entity;
using Kemar.MBS.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kemar.MBS.Repository.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly KemarMBSDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(KemarMBSDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task/*<UserResponseDto>*/ RegisterUserAsync(RegisterRequestDto request)
        {
            var user = _mapper.Map<User>(request);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            //return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserEmail == email);

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
