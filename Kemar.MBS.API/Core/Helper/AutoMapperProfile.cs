using AutoMapper;
using Kemar.MBS.Model.Admin.Request;
using Kemar.MBS.Model.Admin.Response;
using Kemar.MBS.Model.Booking.Request;
using Kemar.MBS.Model.Booking.Response;
using Kemar.MBS.Model.City.Request;
using Kemar.MBS.Model.City.Response;
using Kemar.MBS.Model.Movie.Request;
using Kemar.MBS.Model.Movie.Response;
using Kemar.MBS.Model.Screen.Request;
using Kemar.MBS.Model.Screen.Response;
using Kemar.MBS.Model.Seat.Response;
using Kemar.MBS.Model.Seats.Requests;
using Kemar.MBS.Model.Show.Request;
using Kemar.MBS.Model.Show.Response;
using Kemar.MBS.Model.Theatre.Request;
using Kemar.MBS.Model.Theatre.Responses;
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
            CreateMap<User, LoginResponseDto>();

            CreateMap<AdminLoginRequestDto, Admin>();
            CreateMap<Admin, AdminResponseDto>();

            CreateMap<CityRequestDto, City>();
            CreateMap<City, CityResponseDto>();

            CreateMap<TheatreRequestDto, Theatre>();
            CreateMap<Theatre, TheatreResponseDto>();

            CreateMap<ScreenRequestDto, Screen>();
            CreateMap<Screen, ScreenResponseDto>();

            CreateMap<SeatRequestDto, Seat>();
            CreateMap<Seat, SeatResponseDto>();

            CreateMap<MovieRequestDto, Movie>();
            CreateMap<Movie, MovieResponseDto>();

            CreateMap<ShowRequestDto, Show>();
            CreateMap<Show, ShowResponseDto>();

            CreateMap<BookingRequestDto, Booking>();
            CreateMap<Booking, BookingResponseDto>();
        }
    }
}
