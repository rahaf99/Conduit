using Conduit.Db.Entities;
using Conduit.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories
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
