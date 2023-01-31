using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.JWT
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshToken, RefreshTokenDto>()
                  .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => $"{src.UserId}"))
                .ForMember(
                dest => dest.Token,
                opt => opt.MapFrom(src => $"{src.Token}"))
                .ForMember(
                dest => dest.refreshToken,
                opt => opt.MapFrom(src => $"{src.refreshToken}"))
                .ForMember(
                dest => dest.IsActive,
                opt => opt.MapFrom(src => $"{src.IsActive}"));

            CreateMap<RefreshTokenDto, RefreshToken>()
                .ForMember(
              dest => dest.UserId,
              opt => opt.MapFrom(src => $"{src.UserId}"))
              .ForMember(
              dest => dest.Token,
              opt => opt.MapFrom(src => $"{src.Token}"))
              .ForMember(
              dest => dest.refreshToken,
              opt => opt.MapFrom(src => $"{src.refreshToken}"))
              .ForMember(
              dest => dest.IsActive,
              opt => opt.MapFrom(src => $"{src.IsActive}"));
        }
    }
}
