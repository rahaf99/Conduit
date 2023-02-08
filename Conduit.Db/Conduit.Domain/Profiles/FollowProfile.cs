using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.Profiles
{
    public class FollowProfile : Profile
    {
        public FollowProfile()
        {
            CreateMap<Follow, FollowDto>()
                  .ForMember(
                dest => dest.FollowerId,
                opt => opt.MapFrom(src => $"{src.FollowerId}"))
                .ForMember(
                dest => dest.FollowingId,
                opt => opt.MapFrom(src => $"{src.FollowingId}"));

            CreateMap<FollowDto, Follow>()
               .ForMember(
             dest => dest.FollowerId,
             opt => opt.MapFrom(src => $"{src.FollowerId}"))
             .ForMember(
             dest => dest.FollowingId,
             opt => opt.MapFrom(src => $"{src.FollowingId}"));
        }
    }
}
