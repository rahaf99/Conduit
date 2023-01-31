using AutoMapper;
using Conduit.Db;
using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using Conduit.Web.Interfaces;
using Conduit.Web.Models;
using Conduit.Web.Requests;

namespace Conduit.Web.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public void CreateArticle(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            _articleRepository.CreateArticle(article);
        }
        public void UpdateArticle(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            _articleRepository.UpdateArticle(article);
        }
        public void DeleteArticle(int ArticleDtoId)
        {
            _articleRepository.DeleteArticle(ArticleDtoId);
        }

        public IEnumerable<ArticleDto> GetAllArticles(ArticleParametersRequest articleParametersDto)
        {
            var articles = _articleRepository.GetAllArticles(articleParametersDto.PageNumber,articleParametersDto.PageSize);
            var response = articles.Select(x => _mapper.Map<ArticleDto>(x));
            return response;
        }

        public ArticleDto GetArticleById(int ArticleDtoId)
        {
            var article = _articleRepository.GetArticleById(ArticleDtoId);
            var response = _mapper.Map<ArticleDto>(article);
            return response;
        }
    }
}
