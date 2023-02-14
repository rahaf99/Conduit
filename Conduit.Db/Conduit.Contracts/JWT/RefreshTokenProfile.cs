using AutoMapper;
using Conduit.Db.Entities;

namespace Conduit.Contracts.JWT
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
                dest => dest.RefreshedToken,
                opt => opt.MapFrom(src => $"{src.RefreshedToken}"));

            CreateMap<RefreshTokenDto, RefreshToken>()
                .ForMember(
              dest => dest.UserId,
              opt => opt.MapFrom(src => $"{src.UserId}"))
              .ForMember(
              dest => dest.RefreshedToken,
              opt => opt.MapFrom(src => $"{src.RefreshedToken}"));

        }
    }
}
