using Conduit.Contracts.DTO;
using Conduit.Db.Entities;

namespace Conduit.Domain.Services.FavouriteArticles
{
    public interface IFavouriteArticleService
    {
        public void CreateFavouriteArticle(FavouriteArticleDto favouriteArticleDto);

    }
}
