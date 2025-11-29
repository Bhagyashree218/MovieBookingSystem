//using AutoMapper;
//using Kemar.MBS.Model.User.Request;
//using Kemar.MBS.Model.User.Response;
//using Kemar.MBS.Repository.Entity;

//namespace Kemar.MBS.API.Core.Helper
//{
//    public class AutoMapperProfile : Profile
//    {
//        public AutoMapperProfile()
//        {
//            CreateMap<RegisterRequestDto, User>();
//            CreateMap<User, UserResponseDto>();
//        }
//    }
//}


using AutoMapper;
using Kemar.MBS.Model.User.Request;
using Kemar.MBS.Model.User.Response;
using Kemar.MBS.Repository.Entity;

namespace Kemar.MBS.API.Core.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterRequestDto, User>();
            CreateMap<User, UserResponseDto>();
            CreateMap<User, UserProfileDto>();
            CreateMap<LoginRequestDto, User>();
        }
    }
}
