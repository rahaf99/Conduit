using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.Interfaces
{
    public interface IArticleService
    {
        public void CreateArticle(ArticleDto articleDto);
        public ArticleDto GetArticleById(int ArticleDtoId);
        public IEnumerable<ArticleDto> GetAllArticles();
        public void UpdateArticle(ArticleDto articleDto);
        public void DeleteArticle(int ArticleDtoId);
    }
}
