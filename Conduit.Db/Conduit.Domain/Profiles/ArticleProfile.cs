using AutoMapper;
using Conduit.Contracts.DTO;
using Conduit.Db.Entities;

namespace Conduit.Domain.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>()
                  .ForMember(
                dest => dest.ArticleId,
                opt => opt.MapFrom(src => $"{src.ArticleId}"))
                .ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => $"{src.Title}"))
                .ForMember(
                dest => dest.Content,
                opt => opt.MapFrom(src => $"{src.Content}"))
                .ForMember(
                dest => dest.AuthorId,
                opt => opt.MapFrom(src => $"{src.UserId}"))
                .ForMember(
                dest => dest.NumberOfLikes,
                opt => opt.MapFrom(src => $"{src.NumberOfLikes}"))
                .ForMember(
                dest => dest.PublishDate,
                opt => opt.MapFrom(src => $"{src.PublishDate}"))
                .ForMember(
                dest => dest.LastUpdate,
                opt => opt.MapFrom(src => $"{src.LastUpdate}"));

            CreateMap<ArticleDto, Article>()
                 .ForMember(
               dest => dest.ArticleId,
               opt => opt.MapFrom(src => $"{src.ArticleId}"))
               .ForMember(
               dest => dest.Title,
               opt => opt.MapFrom(src => $"{src.Title}"))
               .ForMember(
               dest => dest.Content,
               opt => opt.MapFrom(src => $"{src.Content}"))
               .ForMember(
               dest => dest.UserId,
               opt => opt.MapFrom(src => $"{src.AuthorId}"))
               .ForMember(
               dest => dest.NumberOfLikes,
               opt => opt.MapFrom(src => $"{src.NumberOfLikes}"))
               .ForMember(
               dest => dest.PublishDate,
               opt => opt.MapFrom(src => $"{src.PublishDate}"))
               .ForMember(
               dest => dest.LastUpdate,
               opt => opt.MapFrom(src => $"{src.LastUpdate}"));
        }
    }
}
