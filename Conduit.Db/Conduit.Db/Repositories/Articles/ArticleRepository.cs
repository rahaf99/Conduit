using Conduit.Db.Entities;
using Conduit.Db.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.Articles

{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly ConduitCoreDbContext _context;
        public ArticleRepository(ConduitCoreDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAllArticles(int PageNumber, int PageSize)
        {
            return _context.Articles
                .Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }

    
    }
}
