using AutoMapper;
using Conduit.Contracts.DTO;
using Conduit.Contracts.Exceptions;
using Conduit.Contracts.Requests;
using Conduit.Db.Entities;
using Conduit.Db.Repositories.Articles;
using Conduit.Db.Repositories.FavouriteArticles;

namespace Conduit.Domain.Services.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
            _mapper = mapper;
        }

        /// <summary>
        /// Create new article
        /// </summary>
        /// <param name="articleDto"></param>
        public void CreateArticle(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            _articleRepository.Create(article);
            _articleRepository.Save();
        }

        /// <summary>
        /// Update an existing article
        /// </summary>
        /// <param name="articleDto"></param>
        public void UpdateArticle(ArticleDto articleDto)
        {
            if(articleDto == null || articleDto.ArticleId == 0)
            {
                throw new ArgumentNullException(nameof(articleDto));
            }
            var article = _mapper.Map<Article>(articleDto);
            if(!_articleRepository.IsExist(article.ArticleId))
            {
                throw new RecordNotFoundException("Article not exist!!");
            }
            _articleRepository.Update(article);
            _articleRepository.Save();
        }

        /// <summary>
        /// Delete an existing article
        /// </summary>
        /// <param name="ArticleDtoId"></param>
        public void DeleteArticle(int ArticleDtoId)
        {
            if (ArticleDtoId == 0)
            {
                throw new ArgumentNullException(nameof(ArticleDtoId));
            }
            if (!_articleRepository.IsExist(ArticleDtoId))
            {
                throw new Exception("Article not exist!!");
            }
            _articleRepository.Delete(ArticleDtoId);
            _articleRepository.Save();
        }

        /// <summary>
        /// Get paginated lists of articles
        /// </summary>
        /// <param name="articleParametersDto"></param>
        /// <returns></returns>
        public IEnumerable<ArticleDto> GetAllArticles(ArticleParametersRequest articleParametersDto)
        {
            var articles = _articleRepository.GetAllArticles(articleParametersDto.PageNumber, articleParametersDto.PageSize);
            var response = articles.Select(x => _mapper.Map<ArticleDto>(x));
            return response;
        }

        /// <summary>
        /// Search article by articleId
        /// </summary>
        /// <param name="ArticleDtoId"></param>
        /// <returns></returns>
        public ArticleDto GetArticleById(int ArticleDtoId)
        {
            if (ArticleDtoId == 0)
            {
                throw new ArgumentNullException(nameof(ArticleDtoId));
            }
            if (!_articleRepository.IsExist(ArticleDtoId))
            {
                throw new RecordNotFoundException("Article not Found!!");
            }
            var article = _articleRepository.GetById(ArticleDtoId);
            var response = _mapper.Map<ArticleDto>(article);
            return response;
        }
    }
}
