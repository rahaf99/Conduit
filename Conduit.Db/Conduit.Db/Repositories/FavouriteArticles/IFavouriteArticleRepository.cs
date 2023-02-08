using Conduit.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Db.Repositories.FavouriteArticles
{
    public interface IFavouriteArticleRepository
    {
        public void CreateFavouriteArticle(FavouriteArticle favouriteArticle);
    }
}
