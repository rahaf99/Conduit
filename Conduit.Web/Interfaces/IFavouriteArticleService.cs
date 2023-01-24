using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.Interfaces
{
    public interface IFavouriteArticleService
    {
        public void CreateFavouriteArticle(FavouriteArticleDto favouriteArticleDto);

    }
}
