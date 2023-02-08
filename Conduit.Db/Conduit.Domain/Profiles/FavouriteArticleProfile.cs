using AutoMapper;
using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.Profiles
{
    public class FavouriteArticleProfile : Profile
    {
        public FavouriteArticleProfile()
        {
            CreateMap<FavouriteArticle, FavouriteArticleDto>()
                  .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => $"{src.UserId}"))
                .ForMember(
                dest => dest.ArticleId,
                opt => opt.MapFrom(src => $"{src.ArticleId}"));

            CreateMap<FavouriteArticleDto, FavouriteArticle>()
                  .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => $"{src.UserId}"))
                .ForMember(
                dest => dest.ArticleId,
                opt => opt.MapFrom(src => $"{src.ArticleId}"));
        }
    }
}
