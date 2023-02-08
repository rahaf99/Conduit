using Conduit.Db.Entities;
using Conduit.Db.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.Articles
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        public IEnumerable<Entities.Article> GetAllArticles(int PageNumber, int PageSize);

    }
}
