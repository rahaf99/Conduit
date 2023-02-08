using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.FavouriteArticles
{
    public class FavouriteArticleRepository : IFavouriteArticleRepository
    {
        private readonly ConduitCoreDbContext _context;
        public FavouriteArticleRepository(ConduitCoreDbContext context)
        {
            _context = context;
        }
        public void CreateFavouriteArticle(FavouriteArticle favouriteArticle)
        {
            _context.FavouriteArticles.Add(favouriteArticle);
            _context.SaveChanges();
        }
    }
}
