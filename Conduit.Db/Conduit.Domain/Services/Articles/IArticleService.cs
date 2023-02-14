using Conduit.Contracts.DTO;
using Conduit.Contracts.Requests;
using Conduit.Db.Entities;

namespace Conduit.Domain.Services.Articles
{
    public interface IArticleService
    {
        public void CreateArticle(ArticleDto articleDto);
        public ArticleDto GetArticleById(int ArticleDtoId);
        public IEnumerable<ArticleDto> GetAllArticles(ArticleParametersRequest articleParametersDto);
        public void UpdateArticle(ArticleDto articleDto);
        public void DeleteArticle(int ArticleDtoId);
    }
}
