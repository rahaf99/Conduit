using AutoMapper;
using Conduit.Contracts.DTO;
using Conduit.Db.Entities;

namespace Conduit.Domain.Profiles
{
    public class FavouriteArticleProfile : Profile
    {
        public FavouriteArticleProfile()
        {
            CreateMap<FavouriteArticle, FavouriteArticleDto>()
                  .ForMember(
                dest => dest.AuthorId,
                opt => opt.MapFrom(src => $"{src.UserId}"))
                .ForMember(
                dest => dest.ArticleId,
                opt => opt.MapFrom(src => $"{src.ArticleId}"));

            CreateMap<FavouriteArticleDto, FavouriteArticle>()
                  .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => $"{src.AuthorId}"))
                .ForMember(
                dest => dest.ArticleId,
                opt => opt.MapFrom(src => $"{src.ArticleId}"));
        }
    }
}
