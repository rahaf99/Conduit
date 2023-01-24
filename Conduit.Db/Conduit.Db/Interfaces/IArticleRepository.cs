using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Interfaces
{
    public interface IArticleRepository
    {
        public void CreateArticle(Article article);
        public Article GetArticleById(int ArticleId);
        public IEnumerable<Article> GetAllArticles();
        public void UpdateArticle(Article article);
        public void DeleteArticle(int ArticleId);
    }
}
