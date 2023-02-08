using Conduit.Db.Entities;
using Conduit.Web.Models;
using Conduit.Web.Requests;

namespace Conduit.Web.Services.Articles
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
