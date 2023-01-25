using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ConduitCoreDbContext _context;
        public ArticleRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }
        public void CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }
        public void UpdateArticle(Article article)
        {
            _context.Update(article);
            _context.SaveChanges();
        }
        public void DeleteArticle(int ArticleId)
        {
            Article a = _context.Articles.Find(ArticleId);
            _context.Articles.Remove(a);
            _context.SaveChanges();
        }

        public Article GetArticleById(int ArticleId)
        {
            Article a = _context.Articles.Find(ArticleId);
            return a;
        }

        public IEnumerable<Article> GetAllArticles(int PageNumber, int PageSize)
        {
            return _context.Articles
                .Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
