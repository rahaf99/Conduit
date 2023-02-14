using AutoMapper;
using Conduit.Db;
using Conduit.Db.Repositories.FavouriteArticles;
using Conduit.Db.Entities;
using Conduit.Contracts.DTO;

namespace Conduit.Domain.Services.FavouriteArticles
{
    public class FavouriteArticleService : IFavouriteArticleService
    {
        private readonly IFavouriteArticleRepository _favouriteArticleRepository;
        private readonly IMapper _mapper;

        public FavouriteArticleService(IFavouriteArticleRepository favouriteArticleRepository, IMapper mapper)
        {
            _favouriteArticleRepository = favouriteArticleRepository ?? throw new ArgumentNullException(nameof(favouriteArticleRepository));
            _mapper = mapper;
        }

        /// <summary>
        /// Create favourite article
        /// </summary>
        /// <param name="favouriteArticleDto"></param>
        public void CreateFavouriteArticle(FavouriteArticleDto favouriteArticleDto)
        {
            var favouriteArticle = _mapper.Map<FavouriteArticle>(favouriteArticleDto);
            _favouriteArticleRepository.CreateFavouriteArticle(favouriteArticle);
        }
    }
}
