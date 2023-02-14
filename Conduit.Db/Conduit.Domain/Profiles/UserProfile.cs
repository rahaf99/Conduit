using AutoMapper;
using Conduit.Contracts.DTO;
using Conduit.Db.Entities;

namespace Conduit.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                 .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => $"{src.UserId}"))
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => $"{src.FirstName}"))
                .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => $"{src.LastName}"))
                .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => $"{src.UserName}"))
                .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => $"{src.Password}"));

            CreateMap<UserDto, User>()
                .ForMember(
               dest => dest.UserId,
               opt => opt.MapFrom(src => $"{src.UserId}"))
               .ForMember(
               dest => dest.FirstName,
               opt => opt.MapFrom(src => $"{src.FirstName}"))
               .ForMember(
               dest => dest.LastName,
               opt => opt.MapFrom(src => $"{src.LastName}"))
               .ForMember(
               dest => dest.UserName,
               opt => opt.MapFrom(src => $"{src.UserName}"))
               .ForMember(
               dest => dest.Password,
               opt => opt.MapFrom(src => $"{src.Password}"));

            CreateMap<User, usercred>()
                .ForMember(
               dest => dest.UserId,
               opt => opt.MapFrom(src => $"{src.UserId}"))
               .ForMember(
               dest => dest.Password,
               opt => opt.MapFrom(src => $"{src.Password}"));

            CreateMap<usercred, User>()
             .ForMember(
            dest => dest.UserId,
            opt => opt.MapFrom(src => $"{src.UserId}"))
            .ForMember(
            dest => dest.Password,
            opt => opt.MapFrom(src => $"{src.Password}"));
        }
    }
}
