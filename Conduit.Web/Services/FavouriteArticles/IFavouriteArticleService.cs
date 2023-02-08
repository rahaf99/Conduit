using Conduit.Db.Entities;
using Conduit.Web.Models;

namespace Conduit.Web.Services.FavouriteArticles
{
    public interface IFavouriteArticleService
    {
        public void CreateFavouriteArticle(FavouriteArticleDto favouriteArticleDto);

    }
}
