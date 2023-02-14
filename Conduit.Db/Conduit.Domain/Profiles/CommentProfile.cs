using AutoMapper;
using Conduit.Contracts.DTO;
using Conduit.Db.Entities;

namespace Conduit.Domain.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                  .ForMember(
                dest => dest.CommentId,
                opt => opt.MapFrom(src => $"{src.CommentId}"))
                .ForMember(
                dest => dest.PostedBy,
                opt => opt.MapFrom(src => $"{src.UserId}"))
                .ForMember(
                dest => dest.ArticleId,
                opt => opt.MapFrom(src => $"{src.ArticleId}"))
                .ForMember(
                dest => dest.Content,
                opt => opt.MapFrom(src => $"{src.Content}"))
                .ForMember(
                dest => dest.PublishDate,
                opt => opt.MapFrom(src => $"{src.PublishDate}"));

            CreateMap<CommentDto, Comment>()
                .ForMember(
                dest => dest.CommentId,
                opt => opt.MapFrom(src => $"{src.CommentId}"))
                .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => $"{src.PostedBy}"))
                .ForMember(
                dest => dest.ArticleId,
                opt => opt.MapFrom(src => $"{src.ArticleId}"))
                .ForMember(
                dest => dest.Content,
                opt => opt.MapFrom(src => $"{src.Content}"))
                .ForMember(
                dest => dest.PublishDate,
                opt => opt.MapFrom(src => $"{src.PublishDate}"));
        }
    }
}